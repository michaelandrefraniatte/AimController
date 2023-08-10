using Microsoft.Win32.SafeHandles;
using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
namespace controllers
{
    public class ScpBus : IDisposable
    {
        public static int[] wd = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        public static int[] wu = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        public static void valchanged(int n, bool val)
        {
            if (val)
            {
                if (wd[n] <= 1)
                {
                    wd[n] = wd[n] + 1;
                }
                wu[n] = 0;
            }
            else
            {
                if (wu[n] <= 1)
                {
                    wu[n] = wu[n] + 1;
                }
                wd[n] = 0;
            }
        }
        private static ScpBus scpBus;
        private static X360Controller controller;
        public static void LoadController()
        {
            scpBus = new ScpBus();
            scpBus.PlugIn(1);
            controller = new X360Controller();
        }
        public static void UnLoadController()
        {
            SetController(false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, 0, 0, 0, 0, 0, 0, false);
            Thread.Sleep(100);
            scpBus.Unplug(1);
        }
        public static void SetController(bool back, bool start, bool A, bool B, bool X, bool Y, bool up, bool left, bool down, bool right, bool leftstick, bool rightstick, bool leftbumper, bool rightbumper, bool lefttrigger, bool righttrigger, double leftstickx, double leftsticky, double rightstickx, double rightsticky, double lefttriggerposition, double righttriggerposition, bool xbox)
        {
            valchanged(1, back);
            if (wd[1] == 1)
                controller.Buttons ^= X360Buttons.Back;
            if (wu[1] == 1)
                controller.Buttons &= ~X360Buttons.Back;
            valchanged(2, start);
            if (wd[2] == 1)
                controller.Buttons ^= X360Buttons.Start;
            if (wu[2] == 1)
                controller.Buttons &= ~X360Buttons.Start;
            valchanged(3, A);
            if (wd[3] == 1)
                controller.Buttons ^= X360Buttons.A;
            if (wu[3] == 1)
                controller.Buttons &= ~X360Buttons.A;
            valchanged(4, B);
            if (wd[4] == 1)
                controller.Buttons ^= X360Buttons.B;
            if (wu[4] == 1)
                controller.Buttons &= ~X360Buttons.B;
            valchanged(5, X);
            if (wd[5] == 1)
                controller.Buttons ^= X360Buttons.X;
            if (wu[5] == 1)
                controller.Buttons &= ~X360Buttons.X;
            valchanged(6, Y);
            if (wd[6] == 1)
                controller.Buttons ^= X360Buttons.Y;
            if (wu[6] == 1)
                controller.Buttons &= ~X360Buttons.Y;
            valchanged(7, up);
            if (wd[7] == 1)
                controller.Buttons ^= X360Buttons.Up;
            if (wu[7] == 1)
                controller.Buttons &= ~X360Buttons.Up;
            valchanged(8, left);
            if (wd[8] == 1)
                controller.Buttons ^= X360Buttons.Left;
            if (wu[8] == 1)
                controller.Buttons &= ~X360Buttons.Left;
            valchanged(9, down);
            if (wd[9] == 1)
                controller.Buttons ^= X360Buttons.Down;
            if (wu[9] == 1)
                controller.Buttons &= ~X360Buttons.Down;
            valchanged(10, right);
            if (wd[10] == 1)
                controller.Buttons ^= X360Buttons.Right;
            if (wu[10] == 1)
                controller.Buttons &= ~X360Buttons.Right;
            valchanged(11, leftstick);
            if (wd[11] == 1)
                controller.Buttons ^= X360Buttons.LeftStick;
            if (wu[11] == 1)
                controller.Buttons &= ~X360Buttons.LeftStick;
            valchanged(12, rightstick);
            if (wd[12] == 1)
                controller.Buttons ^= X360Buttons.RightStick;
            if (wu[12] == 1)
                controller.Buttons &= ~X360Buttons.RightStick;
            valchanged(13, leftbumper);
            if (wd[13] == 1)
                controller.Buttons ^= X360Buttons.LeftBumper;
            if (wu[13] == 1)
                controller.Buttons &= ~X360Buttons.LeftBumper;
            valchanged(14, rightbumper);
            if (wd[14] == 1)
                controller.Buttons ^= X360Buttons.RightBumper;
            if (wu[14] == 1)
                controller.Buttons &= ~X360Buttons.RightBumper;
            controller.LeftStickX = (short)leftstickx;
            controller.LeftStickY = (short)leftsticky;
            controller.RightStickX = (short)rightstickx;
            controller.RightStickY = (short)rightsticky;
            controller.LeftTrigger = (byte)lefttriggerposition;
            controller.RightTrigger = (byte)righttriggerposition;
            valchanged(15, lefttrigger);
            if (lefttrigger)
                controller.LeftTrigger = 255;
            if (wu[15] == 1)
                controller.LeftTrigger = 0;
            valchanged(16, righttrigger);
            if (righttrigger)
                controller.RightTrigger = 255;
            if (wu[16] == 1)
                controller.RightTrigger = 0;
            valchanged(17, xbox);
            if (wd[17] == 1)
                controller.Buttons ^= X360Buttons.Logo;
            if (wu[17] == 1)
                controller.Buttons &= ~X360Buttons.Logo;
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