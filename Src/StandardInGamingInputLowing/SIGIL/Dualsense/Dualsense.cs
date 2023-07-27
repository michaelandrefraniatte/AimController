using Device.Net;
using Hid.Net.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DualSenseAPI
{
    /// <summary>
    /// Interaction logic for DualSense controllers.
    /// </summary>
    public class DualSense
    {
        // IO parameters
        private readonly IDevice underlyingDevice;
        private readonly int? writeBufferSize;

        // async polling
        private IDisposable pollerSubscription;

        private Task<TransferResult> transfer;

        private byte[] data;

        private byte miscByte;

        private byte btnBlock1, btnBlock2, btnBlock3;

        /// <summary>
        /// Private constructor for <see cref="EnumerateControllers"/>.
        /// </summary>
        /// <param name="underlyingDevice">The underlying low-level device.</param>
        /// <param name="writeBufferSize">The device's declared write buffer size.</param>
        private DualSense(IDevice underlyingDevice, int? writeBufferSize)
        {
            this.underlyingDevice = underlyingDevice;
            this.writeBufferSize = writeBufferSize;
        }

        /// <summary>
        /// Acquires the controller.
        /// </summary>
        public void Acquire()
        {
            if (!underlyingDevice.IsInitialized)
            {
                underlyingDevice.InitializeAsync().Wait();
            }
        }

        /// <summary>
        /// Releases the controller.
        /// </summary>
        public void Release()
        {
            if (underlyingDevice.IsInitialized)
            {
                underlyingDevice.Close();
            }
        }

        /// <summary>
        /// Begins asynchously updating the output state and polling the input state at the specified interval.
        /// </summary>
        /// <param name="pollingIntervalMs">How long to wait between each I/O loop, in milliseconds</param>
        /// <remarks>
        /// Instance state is not thread safe. In other words, when using polling, updating instance state 
        /// (such as <see cref="OutputState"/>) both inside and outside of <see cref="OnStatePolled"/>
        /// may create unexpected results. When using polling, it is generally expected you will only make
        /// modifications to state inside the <see cref="OnStatePolled"/> handler in response to input, or
        /// outside of the handler in response to external events (for example, game logic). It's also
        /// expected that you will only use the <see cref="DualSense"/> instance passed as an argument to 
        /// the sender, rather than external references to instance.
        /// </remarks>
        public async void BeginPolling()
        {
            transfer = underlyingDevice.WriteAndReadAsync(GetOutputDataBytes());
            transfer.Wait();
            data = ((TransferResult)await transfer).Data.Skip(1).ToArray();

            // Analog inputs
            LeftAnalogStick = ReadAnalogStick(data[0], data[1]);
            RightAnalogStick = ReadAnalogStick(data[2], data[3]);
            L2 = GetModeSwitch(data, 4).ToUnsignedFloat();
            R2 = GetModeSwitch(data, 5).ToUnsignedFloat();

            // Buttons
            btnBlock1 = GetModeSwitch(data, 7);
            btnBlock2 = GetModeSwitch(data, 8);
            btnBlock3 = GetModeSwitch(data, 9);
            SquareButton = btnBlock1.HasFlag(0x10);
            CrossButton = btnBlock1.HasFlag(0x20);
            CircleButton = btnBlock1.HasFlag(0x40);
            TriangleButton = btnBlock1.HasFlag(0x80);
            DPadUpButton = ReadDPadButton(btnBlock1, 0, 1, 7);
            DPadRightButton = ReadDPadButton(btnBlock1, 1, 2, 3);
            DPadDownButton = ReadDPadButton(btnBlock1, 3, 4, 5);
            DPadLeftButton = ReadDPadButton(btnBlock1, 5, 6, 7);
            L1Button = btnBlock2.HasFlag(0x01);
            R1Button = btnBlock2.HasFlag(0x02);
            L2Button = btnBlock2.HasFlag(0x04);
            R2Button = btnBlock2.HasFlag(0x08);
            CreateButton = btnBlock2.HasFlag(0x10);
            MenuButton = btnBlock2.HasFlag(0x20);
            L3Button = btnBlock2.HasFlag(0x40);
            R3Button = btnBlock2.HasFlag(0x80);
            LogoButton = btnBlock3.HasFlag(0x01);
            TouchpadButton = btnBlock3.HasFlag(0x02);
            MicButton = GetModeSwitch(data, 9).HasFlag(0x04); // not supported on the broken BT protocol, otherwise would likely be in btnBlock3

            // Multitouch
            Touchpad1 = ReadTouchpad(GetModeSwitch(data, 32, 4));
            Touchpad2 = ReadTouchpad(GetModeSwitch(data, 36, 4));

            // 6-axis
            // gyro directions seem to follow left-hand rule rather than right, so reverse the directions
            Gyro = -ReadAccelAxes(
                GetModeSwitch(data, 15, 2),
                GetModeSwitch(data, 17, 2),
                GetModeSwitch(data, 19, 2)
            );
            Accelerometer = ReadAccelAxes(
                GetModeSwitch(data, 21, 2),
                GetModeSwitch(data, 23, 2),
                GetModeSwitch(data, 25, 2)
            );

            miscByte = GetModeSwitch(data, 53); // this contains various stuff, seems to have both audio and battery info
            IsHeadphoneConnected = miscByte.HasFlag(0x01);
        }

        // TODO: find a way to differentiate between the "valid" and "broken" BT states - now that stuff is working right,
        // we can always take the USB index. Hold the other one for when we can fix this (or prove it can't break)
        // this seems to be a discovery issue of some kind, other things (like steam and ds4windows) have no problem finding it.
        // seems to be fixed permanently after using DS4Windows but ideally we shouldn't have to have that precondition,
        // and steam was able to handle it fine before that
        /// <summary>
        /// Gets a data byte at the given index based on the input mode.
        /// </summary>
        /// <param name="inputMode">The current input mode.</param>
        /// <param name="data">The data bytes to read from.</param>
        /// <param name="indexIfUsb">The index to access in USB or valid Bluetooth input mode.</param>
        /// <param name="indexIfBt">The index to access in the broken Bluetooth input mode.</param>
        /// <returns>
        /// The data at the given index for the input mode, or 0 if the index is negative (allows defaults for
        /// values that aren't supported in a given mode).
        /// </returns>
        /// <remarks>
        /// This was due to a previous issue where controllers connected over Bluetooth were providing data bytes 
        /// in a different order with some data missing. It resolved itself before I could solve the problem but
        /// keeping this around for when I can find it again. Currently always uses <paramref name="indexIfUsb"/>.
        /// </remarks>
        private byte GetModeSwitch(byte[] data, int indexIfUsb)
        {
            return indexIfUsb >= 0 ? data[indexIfUsb] : (byte)0;
        }

        /// <summary>
        /// Gets several data bytes at the given index based on the input mode.
        /// </summary>
        /// <param name="inputMode">The current input mode.</param>
        /// <param name="data">The data bytes to read from.</param>
        /// <param name="startIndexIfUsb">The start index in USB or valid Bluetooth input mode.</param>
        /// <param name="startIndexIfBt">The start index in the broken Bluetooth input mode.</param>
        /// <param name="size">The number of bytes to get.</param>
        /// <returns>
        /// <paramref name="size"/> bytes at the given start index for the input mode, or an array of <paramref name="size"/>
        /// 0's if the index is negative.
        /// </returns>
        /// <remarks>
        /// This was due to a previous issue where controllers connected over Bluetooth were providing data bytes 
        /// in a different order with some data missing. It resolved itself before I could solve the problem but
        /// keeping this around for when I can find it again. Currently always uses <paramref name="startIndexIfUsb"/>.
        /// </remarks>
        private byte[] GetModeSwitch(byte[] data, int startIndexIfUsb, int size)
        {
            return startIndexIfUsb >= 0 ? data.Skip(startIndexIfUsb).Take(size).ToArray() : new byte[size];
        }

        /// <summary>
        /// Reads the 2 bytes of an analog stick and silences the dead zone.
        /// </summary>
        /// <param name="x">The x byte.</param>
        /// <param name="y">The y byte.</param>
        /// <returns>A vector for the joystick input.</returns>
        private Vec2 ReadAnalogStick(byte x, byte y)
        {
            float x1 = x.ToSignedFloat();
            float y1 = -y.ToSignedFloat();
            return new Vec2
            {
                X = Math.Abs(x1) >= 0f ? x1 : 0,
                Y = Math.Abs(y1) >= 0f ? y1 : 0
            };
        }

        /// <summary>
        /// Checks if the DPad lower nibble is one of the 3 values possible for a button.
        /// </summary>
        /// <param name="b">The dpad byte.</param>
        /// <param name="v1">The first value.</param>
        /// <param name="v2">The second value.</param>
        /// <param name="v3">The third value.</param>
        /// <returns>Whether the lower nibble of <paramref name="b"/> is one of the 3 values.</returns>
        private static bool ReadDPadButton(byte b, int v1, int v2, int v3)
        {
            int val = b & 0x0F;
            return val == v1 || val == v2 || val == v3;
        }

        /// <summary>
        /// Reads a touchpad.
        /// </summary>
        /// <param name="bytes">The touchpad's byte array.</param>
        /// <returns>A parsed <see cref="DualSenseTouch"/>.</returns>
        private static DualSenseTouch ReadTouchpad(byte[] bytes)
        {
            // force everything into the right byte order; input bytes are LSB-first
            if (!BitConverter.IsLittleEndian)
            {
                bytes = bytes.Reverse().ToArray();
            }
            uint raw = BitConverter.ToUInt32(bytes, 0);
            return new DualSenseTouch
            {
                X = (raw & 0x000FFF00) >> 8,
                Y = (raw & 0xFFF00000) >> 20,
                IsDown = (raw & 128) == 0,
                Id = bytes[0]
            };
        }

        /// <summary>
        /// Reads 3 axes of the accellerometer.
        /// </summary>
        /// <param name="x">The X axis bytes.</param>
        /// <param name="y">The Y axis bytes.</param>
        /// <param name="z">The Z axis bytes.</param>
        /// <returns>A vector for the gyro axes.</returns>
        private static Vec3 ReadAccelAxes(byte[] x, byte[] y, byte[] z)
        {
            // force everything into the right byte order; assuming that input bytes is little-endian
            if (!BitConverter.IsLittleEndian)
            {
                x = x.Reverse().ToArray();
                y = y.Reverse().ToArray();
                z = z.Reverse().ToArray();
            }
            return new Vec3
            {
                X = -BitConverter.ToInt16(x, 0),
                Y = BitConverter.ToInt16(y, 0),
                Z = BitConverter.ToInt16(z, 0)
            };
        }

        /// <summary>
        /// The left analog stick. Values are from -1 to 1. Positive X is right, positive Y is up.
        /// </summary>
        public static Vec2 LeftAnalogStick { get; private set; }

        /// <summary>
        /// The right analog stick. Values are from -1 to 1. Positive X is right, positive Y is up.
        /// </summary>
        public static Vec2 RightAnalogStick { get; private set; }

        /// <summary>
        /// L2's analog value, from 0 to 1.
        /// </summary>
        public static float L2 { get; private set; }

        /// <summary>
        /// R2's analog value, from 0 to 1.
        /// </summary>
        public static float R2 { get; private set; }

        /// <summary>
        /// The status of the square button.
        /// </summary>
        public static bool SquareButton { get; private set; }

        /// <summary>
        /// The status of the cross button.
        /// </summary>
        public static bool CrossButton { get; private set; }

        /// <summary>
        /// The status of the circle button.
        /// </summary>
        public static bool CircleButton { get; private set; }

        /// <summary>
        /// The status of the triangle button.
        /// </summary>
        public static bool TriangleButton { get; private set; }

        /// <summary>
        /// The status of the D-pad up button.
        /// </summary>
        public static bool DPadUpButton { get; private set; }

        /// <summary>
        /// The status of the D-pad right button.
        /// </summary>
        public static bool DPadRightButton { get; private set; }

        /// <summary>
        /// The status of the D-pad down button.
        /// </summary>
        public static bool DPadDownButton { get; private set; }

        /// <summary>
        /// The status of the D-pad left button.
        /// </summary>
        public static bool DPadLeftButton { get; private set; }

        /// <summary>
        /// The status of the L1 button.
        /// </summary>
        public static bool L1Button { get; private set; }

        /// <summary>
        /// The status of the R1 button.
        /// </summary>
        public static bool R1Button { get; private set; }

        /// <summary>
        /// The status of the L2 button.
        /// </summary>
        public static bool L2Button { get; private set; }

        /// <summary>
        /// The status of the R2 button.
        /// </summary>
        public static bool R2Button { get; private set; }

        /// <summary>
        /// The status of the create button.
        /// </summary>
        public static bool CreateButton { get; private set; }

        /// <summary>
        /// The status of the menu button.
        /// </summary>
        public static bool MenuButton { get; private set; }

        /// <summary>
        /// The status of the L3 button.
        /// </summary>
        public static bool L3Button { get; private set; }

        /// <summary>
        /// The status of the R3 button.
        /// </summary>
        public static bool R3Button { get; private set; }

        /// <summary>
        /// The status of the PlayStation logo button.
        /// </summary>
        public static bool LogoButton { get; private set; }

        /// <summary>
        /// The status of the touchpad button.
        /// </summary>
        public static bool TouchpadButton { get; private set; }

        /// <summary>
        /// The status of the mic button.
        /// </summary>
        public static bool MicButton { get; private set; }

        /// <summary>
        /// The first touch point.
        /// </summary>
        public static DualSenseTouch Touchpad1 { get; private set; }

        /// <summary>
        /// The second touch point.
        /// </summary>
        public static DualSenseTouch Touchpad2 { get; private set; }

        /// <summary>
        /// The accelerometer's rotational axes. The directions of the axes have been slightly adjusted from the controller's original values
        /// to make them behave nicer with standard Newtonian physics. The signs follow normal right-hand rule with respect to
        /// <see cref="Accelerometer"/>'s axes, e.g. +X rotation means counterclockwise around the +X axis and so on. Unit is unclear, but
        /// magnitude while stationary is about 0.
        /// </summary>
        public static Vec3 Gyro { get; private set; }

        /// <summary>
        /// The accelerometer's linear axes. The directions of the axes have been slightly adjusted from the controller's original values
        /// to make them behave nicer with standard Newtonian physics. +X is to the right. +Y is behind the controller (roughly straight down
        /// if the controller is flat on the table). +Z is at the top of the controller (where the USB port is). Unit is unclear, but magnitude
        /// while stationary (e.g. just gravity) is about 8000 +- 100.
        /// </summary>
        public static Vec3 Accelerometer { get; private set; }

        /// <summary>
        /// Whether or not headphones are connected to the controller.
        /// </summary>
        public static bool IsHeadphoneConnected { get; private set; }

        /// <summary>
        /// Stop asynchronously updating the output state and polling for new inputs.
        /// </summary>
        public void EndPolling()
        {
            if (pollerSubscription == null)
            {
                throw new InvalidOperationException("Can't end polling without starting polling first");
            }
            pollerSubscription.Dispose();
            pollerSubscription = null;
        }

        /// <summary>
        /// Builds the output byte array that will be sent to the controller.
        /// </summary>
        /// <returns>An array of bytes to send to the controller</returns>
        private byte[] GetOutputDataBytes()
        {
            byte[] bytes = new byte[writeBufferSize ?? 0];
            bytes[0] = 0x02;
            return bytes;
        }

        /// <summary>
        /// Enumerates available controllers.
        /// </summary>
        /// <returns>Enumerable of available controllers.</returns>
        public static DualSense EnumerateControllers(string vendor_id, string product_id, string label_id)
        {
            foreach (ConnectedDeviceDefinition deviceDefinition in ListDevices(vendor_id, product_id, label_id))
            {
                IDevice device = GetConnectedDevice(deviceDefinition);
                return new DualSense(device, deviceDefinition.WriteBufferSize);
            }
            return null;
        }

        /// <summary>
        /// A handler for a state polling IO event. The sender has the <see cref="DualSenseInputState"/>
        /// from the most recent poll, and can be used to update the next
        /// <see cref="DualSenseOutputState"/>.
        /// </summary>
        /// <param name="sender">The <see cref="DualSense"/> instance that was just polled.</param>
        public delegate void StatePolledHandler(DualSense sender);

        private static IDeviceFactory hidFactory;

        public static void Initialize(string vendor_id, string product_id, string label_id)
        {
            hidFactory = new FilterDeviceDefinition((uint)int.Parse(vendor_id, System.Globalization.NumberStyles.HexNumber), (uint)int.Parse(product_id, System.Globalization.NumberStyles.HexNumber), label: label_id).CreateWindowsHidDeviceFactory();
        }
        /// <summary>
        /// Lists connected devices.
        /// </summary>
        /// <returns>An enumerable of connected devices.</returns>
        public static IEnumerable<ConnectedDeviceDefinition> ListDevices(string vendor_id, string product_id, string label_id)
        {
            Initialize(vendor_id, product_id, label_id);
            Task<IEnumerable<ConnectedDeviceDefinition>> scannerTask = hidFactory.GetConnectedDeviceDefinitionsAsync();
            scannerTask.Wait();
            return scannerTask.Result;
        }

        /// <summary>
        /// Gets a device from its information.
        /// </summary>
        /// <param name="deviceDefinition">The information for the connected device.</param>
        /// <returns>The actual device.</returns>
        public static IDevice GetConnectedDevice(ConnectedDeviceDefinition deviceDefinition)
        {
            Task<IDevice> connectTask = hidFactory.GetDeviceAsync(deviceDefinition);
            connectTask.Wait();
            return connectTask.Result;
        }
    }
    /// <summary>
    /// Extension logic to help conversion between bytes and more useful formats.
    /// </summary>
    internal static class DualSenseByteConverterExtensions
    {
        /// <summary>
        /// Converts a byte to the corresponding signed float.
        /// </summary>
        /// <param name="b">The byte value</param>
        /// <returns>The byte, scaled and translated to floating point value between -1 and 1.</returns>
        public static float ToSignedFloat(this byte b)
        {
            return (b / 255.0f - 0.5f) * 2.0f;
        }

        /// <summary>
        /// Converts a byte to the corresponding unsigned float.
        /// </summary>
        /// <param name="b">The byte value</param>
        /// <returns>The byte, scaled to a floating point value between 0 and 1.</returns>
        public static float ToUnsignedFloat(this byte b)
        {
            return b / 255.0f;
        }

        /// <summary>
        /// Checks whether the provided flag's bits are set on this byte. Similar to <see cref="Enum.HasFlag(Enum)"/>.
        /// </summary>
        /// <param name="b">The byte value</param>
        /// <param name="flag">The flag to check</param>
        /// <returns>Whether all the bits of the flag are set on the byte.</returns>
        public static bool HasFlag(this byte b, byte flag)
        {
            return (b & flag) == flag;
        }
    }
    /// <summary>
    /// One of the DualSense's 2 touch points. The touchpad is 1920x1080, 0-indexed.
    /// </summary>
    public struct DualSenseTouch
    {
        /// <summary>
        /// The X position of the touchpoint. 0 is the leftmost edge. If the touch point is currently pressed,
        /// this is the current position. If the touch point is released, it was the last position before it
        /// was released.
        /// </summary>
        public uint X;

        /// <summary>
        /// The Y position of the touchpoint. 0 is the topmost edge. If the touch point is currently pressed,
        /// this is the current position. If the touch point is released, it was the last position before it
        /// was released.
        /// </summary>
        public uint Y;

        /// <summary>
        /// Whether the touch point is currently pressed.
        /// </summary>
        public bool IsDown;

        /// <summary>
        /// The touch id. This is a counter that changes whenever a touch is pressed or released.
        /// </summary>
        public byte Id;
    }
    /// <summary>
    /// A 2D vector
    /// </summary>
    public struct Vec2
    {
        public float X, Y;

        public float Magnitude()
        {
            return (float)Math.Sqrt(X * X + Y * Y);
        }

        public Vec2 Normalize()
        {
            float m = Magnitude();
            return new Vec2 { X = X / m, Y = Y / m };
        }

        public static Vec2 operator -(Vec2 v)
        {
            return new Vec2 { X = -v.X, Y = -v.Y };
        }
    }
    /// <summary>
    /// A 3D vector
    /// </summary>
    public struct Vec3
    {
        public float X, Y, Z;

        public float Magnitude()
        {
            return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public Vec3 Normalize()
        {
            float m = Magnitude();
            return new Vec3 { X = X / m, Y = Y / m, Z = Z / m };
        }

        public static Vec3 operator -(Vec3 v)
        {
            return new Vec3 { X = -v.X, Y = -v.Y, Z = -v.Z };
        }
    }
}