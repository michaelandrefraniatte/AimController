using Microsoft.Win32.SafeHandles;
using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
namespace controllers
{
    public class Valuechange
    {
        public static double[] _valuechange = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public static double[] _ValueChange = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double this[int index]
        {
            get { return _ValueChange[index]; }
            set
            {
                if (_valuechange[index] != value)
                    _ValueChange[index] = value - _valuechange[index];
                else
                    _ValueChange[index] = 0;
                _valuechange[index] = value;
            }
        }
    }
    public class ScpBus : IDisposable
    {
        private static ScpBus scpBus;
        private static X360Controller controller;
        public static Valuechange ValueChange = new Valuechange();
        public static void LoadController()
        {
            scpBus = new ScpBus();
            scpBus.PlugIn(1);
            controller = new X360Controller();
        }
        public static void UnLoadController()
        {
            SetController(false, false, false, false, false, false, false, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, false);
            Thread.Sleep(100);
            scpBus.Unplug(1);
        }
        public static void SetController(bool back, bool start, bool A, bool B, bool X, bool Y, bool up, bool left, bool down, bool right, bool leftstick, bool rightstick, bool leftbumper, bool rightbumper, double leftstickx, double leftsticky, double rightstickx, double rightsticky, double lefttriggerposition, double righttriggerposition, bool xbox)
        {
            ValueChange[0] = back ? 1 : 0;
            if (Valuechange._ValueChange[0] > 0f)
                controller.Buttons ^= X360Buttons.Back;
            if (Valuechange._ValueChange[0] < 0f)
                controller.Buttons &= ~X360Buttons.Back;
            ValueChange[1] = start ? 1 : 0;
            if (Valuechange._ValueChange[1] > 0f)
                controller.Buttons ^= X360Buttons.Start;
            if (Valuechange._ValueChange[1] < 0f)
                controller.Buttons &= ~X360Buttons.Start;
            ValueChange[2] = A ? 1 : 0;
            if (Valuechange._ValueChange[2] > 0f)
                controller.Buttons ^= X360Buttons.A;
            if (Valuechange._ValueChange[2] < 0f)
                controller.Buttons &= ~X360Buttons.A;
            ValueChange[3] = B ? 1 : 0;
            if (Valuechange._ValueChange[3] > 0f)
                controller.Buttons ^= X360Buttons.B;
            if (Valuechange._ValueChange[3] < 0f)
                controller.Buttons &= ~X360Buttons.B;
            ValueChange[4] = X ? 1 : 0;
            if (Valuechange._ValueChange[4] > 0f)
                controller.Buttons ^= X360Buttons.X;
            if (Valuechange._ValueChange[4] < 0f)
                controller.Buttons &= ~X360Buttons.X;
            ValueChange[5] = Y ? 1 : 0;
            if (Valuechange._ValueChange[5] > 0f)
                controller.Buttons ^= X360Buttons.Y;
            if (Valuechange._ValueChange[5] < 0f)
                controller.Buttons &= ~X360Buttons.Y;
            ValueChange[6] = up ? 1 : 0;
            if (Valuechange._ValueChange[6] > 0f)
                controller.Buttons ^= X360Buttons.Up;
            if (Valuechange._ValueChange[6] < 0f)
                controller.Buttons &= ~X360Buttons.Up;
            ValueChange[7] = left ? 1 : 0;
            if (Valuechange._ValueChange[7] > 0f)
                controller.Buttons ^= X360Buttons.Left;
            if (Valuechange._ValueChange[7] < 0f)
                controller.Buttons &= ~X360Buttons.Left;
            ValueChange[8] = down ? 1 : 0;
            if (Valuechange._ValueChange[8] > 0f)
                controller.Buttons ^= X360Buttons.Down;
            if (Valuechange._ValueChange[8] < 0f)
                controller.Buttons &= ~X360Buttons.Down;
            ValueChange[9] = right ? 1 : 0;
            if (Valuechange._ValueChange[9] > 0f)
                controller.Buttons ^= X360Buttons.Right;
            if (Valuechange._ValueChange[9] < 0f)
                controller.Buttons &= ~X360Buttons.Right;
            ValueChange[10] = leftstick ? 1 : 0;
            if (Valuechange._ValueChange[10] > 0f)
                controller.Buttons ^= X360Buttons.LeftStick;
            if (Valuechange._ValueChange[10] < 0f)
                controller.Buttons &= ~X360Buttons.LeftStick;
            ValueChange[11] = rightstick ? 1 : 0;
            if (Valuechange._ValueChange[11] > 0f)
                controller.Buttons ^= X360Buttons.RightStick;
            if (Valuechange._ValueChange[11] < 0f)
                controller.Buttons &= ~X360Buttons.RightStick;
            ValueChange[12] = leftbumper ? 1 : 0;
            if (Valuechange._ValueChange[12] > 0f)
                controller.Buttons ^= X360Buttons.LeftBumper;
            if (Valuechange._ValueChange[12] < 0f)
                controller.Buttons &= ~X360Buttons.LeftBumper;
            ValueChange[13] = rightbumper ? 1 : 0;
            if (Valuechange._ValueChange[13] > 0f)
                controller.Buttons ^= X360Buttons.RightBumper;
            if (Valuechange._ValueChange[13] < 0f)
                controller.Buttons &= ~X360Buttons.RightBumper;
            ValueChange[14] = xbox ? 1 : 0;
            if (Valuechange._ValueChange[14] > 0f)
                controller.Buttons ^= X360Buttons.Logo;
            if (Valuechange._ValueChange[14] < 0f)
                controller.Buttons &= ~X360Buttons.Logo;
            controller.LeftStickX = (short)leftstickx;
            controller.LeftStickY = (short)leftsticky;
            controller.RightStickX = (short)rightstickx;
            controller.RightStickY = (short)rightsticky;
            controller.LeftTrigger = (byte)lefttriggerposition;
            controller.RightTrigger = (byte)righttriggerposition;
            scpBus.Report(controller.GetReport());
        }
        private const string SCP_BUS_CLASS_GUID = "{F679F562-3164-42CE-A4DB-E7DDBE723909}";
        private readonly SafeFileHandle _deviceHandle;
        public ScpBus() : this(0) { }
        public ScpBus(int instance)
        {
            string devicePath = "";
            if (Find(new Guid(SCP_BUS_CLASS_GUID), ref devicePath, instance))
            {
                _deviceHandle = GetHandle(devicePath);
            }
        }
        public ScpBus(string devicePath)
        {
            _deviceHandle = GetHandle(devicePath);
        }
        public void Close()
        {
            Dispose();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_deviceHandle != null && !_deviceHandle.IsInvalid)
            {
                _deviceHandle.Dispose();
            }
        }
        public bool PlugIn(int controllerNumber)
        {
            int transfered = 0;
            byte[] buffer = new byte[16];
            buffer[0] = 0x10;
            buffer[1] = 0x00;
            buffer[2] = 0x00;
            buffer[3] = 0x00;
            buffer[4] = (byte)((controllerNumber) & 0xFF);
            buffer[5] = (byte)((controllerNumber >> 8) & 0xFF);
            buffer[6] = (byte)((controllerNumber >> 16) & 0xFF);
            buffer[7] = (byte)((controllerNumber >> 24) & 0xFF);
            return NativeMethods.DeviceIoControl(_deviceHandle, 0x2A4000, buffer, buffer.Length, null, 0, ref transfered, IntPtr.Zero);
        }
        public bool Unplug(int controllerNumber)
        {
            int transfered = 0;
            byte[] buffer = new Byte[16];
            buffer[0] = 0x10;
            buffer[1] = 0x00;
            buffer[2] = 0x00;
            buffer[3] = 0x00;
            buffer[4] = (byte)((controllerNumber) & 0xFF);
            buffer[5] = (byte)((controllerNumber >> 8) & 0xFF);
            buffer[6] = (byte)((controllerNumber >> 16) & 0xFF);
            buffer[7] = (byte)((controllerNumber >> 24) & 0xFF);
            return NativeMethods.DeviceIoControl(_deviceHandle, 0x2A4004, buffer, buffer.Length, null, 0, ref transfered, IntPtr.Zero);
        }
        public bool UnplugAll()
        {
            int transfered = 0;
            byte[] buffer = new byte[16];
            buffer[0] = 0x10;
            buffer[1] = 0x00;
            buffer[2] = 0x00;
            buffer[3] = 0x00;
            return NativeMethods.DeviceIoControl(_deviceHandle, 0x2A4004, buffer, buffer.Length, null, 0, ref transfered, IntPtr.Zero);
        }
        int transferred;
        byte[] outputBuffer = null;
        public bool Report(byte[] controllerReport)
        {
            return NativeMethods.DeviceIoControl(_deviceHandle, 0x2A400C, controllerReport, controllerReport.Length, outputBuffer, outputBuffer?.Length ?? 0, ref transferred, IntPtr.Zero);
        }
        private static bool Find(Guid target, ref string path, int instance = 0)
        {
            IntPtr detailDataBuffer = IntPtr.Zero;
            IntPtr deviceInfoSet = IntPtr.Zero;
            try
            {
                NativeMethods.SP_DEVICE_INTERFACE_DATA DeviceInterfaceData = new NativeMethods.SP_DEVICE_INTERFACE_DATA(), da = new NativeMethods.SP_DEVICE_INTERFACE_DATA();
                int bufferSize = 0, memberIndex = 0;
                deviceInfoSet = NativeMethods.SetupDiGetClassDevs(ref target, IntPtr.Zero, IntPtr.Zero, NativeMethods.DIGCF_PRESENT | NativeMethods.DIGCF_DEVICEINTERFACE);
                DeviceInterfaceData.cbSize = da.cbSize = Marshal.SizeOf(DeviceInterfaceData);
                while (NativeMethods.SetupDiEnumDeviceInterfaces(deviceInfoSet, IntPtr.Zero, ref target, memberIndex, ref DeviceInterfaceData))
                {
                    NativeMethods.SetupDiGetDeviceInterfaceDetail(deviceInfoSet, ref DeviceInterfaceData, IntPtr.Zero, 0, ref bufferSize, ref da);
                    detailDataBuffer = Marshal.AllocHGlobal(bufferSize);
                    Marshal.WriteInt32(detailDataBuffer, (IntPtr.Size == 4) ? (4 + Marshal.SystemDefaultCharSize) : 8);
                    if (NativeMethods.SetupDiGetDeviceInterfaceDetail(deviceInfoSet, ref DeviceInterfaceData, detailDataBuffer, bufferSize, ref bufferSize, ref da))
                    {
                        IntPtr pDevicePathName = detailDataBuffer + 4;
                        path = Marshal.PtrToStringAuto(pDevicePathName).ToUpper(CultureInfo.InvariantCulture);
                        Marshal.FreeHGlobal(detailDataBuffer);
                        if (memberIndex == instance)
                            return true;
                    }
                    else
                        Marshal.FreeHGlobal(detailDataBuffer);
                    memberIndex++;
                }
            }
            finally
            {
                if (deviceInfoSet != IntPtr.Zero)
                {
                    NativeMethods.SetupDiDestroyDeviceInfoList(deviceInfoSet);
                }
            }
            return false;
        }
        private static SafeFileHandle GetHandle(string devicePath)
        {
            devicePath = devicePath.ToUpper(CultureInfo.InvariantCulture);
            SafeFileHandle handle = NativeMethods.CreateFile(devicePath, (NativeMethods.GENERIC_WRITE | NativeMethods.GENERIC_READ), NativeMethods.FILE_SHARE_READ | NativeMethods.FILE_SHARE_WRITE, IntPtr.Zero, NativeMethods.OPEN_EXISTING, NativeMethods.FILE_ATTRIBUTE_NORMAL | NativeMethods.FILE_FLAG_OVERLAPPED, UIntPtr.Zero);
            return handle;
        }
    }
    internal static class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct SP_DEVICE_INTERFACE_DATA
        {
            internal int cbSize;
            internal Guid InterfaceClassGuid;
            internal int Flags;
            internal IntPtr Reserved;
        }
        internal const uint FILE_ATTRIBUTE_NORMAL = 0x80;
        internal const uint FILE_FLAG_OVERLAPPED = 0x40000000;
        internal const uint FILE_SHARE_READ = 1;
        internal const uint FILE_SHARE_WRITE = 2;
        internal const uint GENERIC_READ = 0x80000000;
        internal const uint GENERIC_WRITE = 0x40000000;
        internal const uint OPEN_EXISTING = 3;
        internal const int DIGCF_PRESENT = 0x0002;
        internal const int DIGCF_DEVICEINTERFACE = 0x0010;
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern SafeFileHandle CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, UIntPtr hTemplateFile);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeviceIoControl(SafeFileHandle hDevice, int dwIoControlCode, byte[] lpInBuffer, int nInBufferSize, byte[] lpOutBuffer, int nOutBufferSize, ref int lpBytesReturned, IntPtr lpOverlapped);
        [DllImport("setupapi.dll", SetLastError = true)]
        internal static extern int SetupDiDestroyDeviceInfoList(IntPtr deviceInfoSet);
        [DllImport("setupapi.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetupDiEnumDeviceInterfaces(IntPtr hDevInfo, IntPtr devInfo, ref Guid interfaceClassGuid, int memberIndex, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern IntPtr SetupDiGetClassDevs(ref Guid classGuid, IntPtr enumerator, IntPtr hwndParent, int flags);
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr hDevInfo, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData, IntPtr deviceInterfaceDetailData, int deviceInterfaceDetailDataSize, ref int requiredSize, ref SP_DEVICE_INTERFACE_DATA deviceInfoData);
    }
    public class X360Controller
    {
        public X360Controller()
        {
            Buttons = X360Buttons.None;
            LeftTrigger = 0;
            RightTrigger = 0;
            LeftStickX = 0;
            LeftStickY = 0;
            RightStickX = 0;
            RightStickY = 0;
        }
        public X360Controller(X360Buttons buttons, byte leftTrigger, byte rightTrigger, short leftStickX, short leftStickY, short rightStickX, short rightStickY)
        {
            Buttons = buttons;
            LeftTrigger = leftTrigger;
            RightTrigger = rightTrigger;
            LeftStickX = leftStickX;
            LeftStickY = leftStickY;
            RightStickX = rightStickX;
            RightStickY = rightStickY;
        }
        public X360Controller(X360Controller controller)
        {
            Buttons = controller.Buttons;
            LeftTrigger = controller.LeftTrigger;
            RightTrigger = controller.RightTrigger;
            LeftStickX = controller.LeftStickX;
            LeftStickY = controller.LeftStickY;
            RightStickX = controller.RightStickX;
            RightStickY = controller.RightStickY;
        }
        public X360Buttons Buttons { get; set; }
        public byte LeftTrigger { get; set; }
        public byte RightTrigger { get; set; }
        public short LeftStickX { get; set; }
        public short LeftStickY { get; set; }
        public short RightStickX { get; set; }
        public short RightStickY { get; set; }
        byte[] bytes = new byte[20];
        byte[] fullReport = { 0x1C, 0, 0, 0, (1) & 0xFF, (1 >> 8) & 0xFF, (1 >> 16) & 0xFF, (1 >> 24) & 0xFF, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public byte[] GetReport()
        {
            bytes[0] = 0x00;
            bytes[1] = 0x14;
            bytes[2] = (byte)((ushort)Buttons & 0xFF);
            bytes[3] = (byte)((ushort)Buttons >> 8 & 0xFF);
            bytes[4] = LeftTrigger;
            bytes[5] = RightTrigger;
            bytes[6] = (byte)(LeftStickX & 0xFF);
            bytes[7] = (byte)(LeftStickX >> 8 & 0xFF);
            bytes[8] = (byte)(LeftStickY & 0xFF);
            bytes[9] = (byte)(LeftStickY >> 8 & 0xFF);
            bytes[10] = (byte)(RightStickX & 0xFF);
            bytes[11] = (byte)(RightStickX >> 8 & 0xFF);
            bytes[12] = (byte)(RightStickY & 0xFF);
            bytes[13] = (byte)(RightStickY >> 8 & 0xFF);
            Array.Copy(bytes, 0, fullReport, 8, 20);
            return fullReport;
        }
    }
    [Flags]
    public enum X360Buttons
    {
        None = 0,
        Up = 1 << 0,
        Down = 1 << 1,
        Left = 1 << 2,
        Right = 1 << 3,
        Start = 1 << 4,
        Back = 1 << 5,
        LeftStick = 1 << 6,
        RightStick = 1 << 7,
        LeftBumper = 1 << 8,
        RightBumper = 1 << 9,
        Logo = 1 << 10,
        A = 1 << 12,
        B = 1 << 13,
        X = 1 << 14,
        Y = 1 << 15,
    }
}