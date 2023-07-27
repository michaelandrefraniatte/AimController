using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO.Ports;
namespace WiiRoyale
{
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private unsafe static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);
        [DllImport("WiimotePairing.dll", EntryPoint = "connect")]
        public unsafe static extern bool connect();
        [DllImport("WiimotePairing.dll", EntryPoint = "disconnect")]
        public unsafe static extern bool disconnect();
        [DllImport("hid.dll")]
        public unsafe static extern void HidD_GetHidGuid(out Guid gHid);
        [DllImport("hid.dll")]
        public extern static bool HidD_SetOutputReport(IntPtr HidDeviceObject, byte[] lpReportBuffer, uint ReportBufferLength);
        [DllImport("setupapi.dll")]
        public unsafe static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, string Enumerator, IntPtr hwndParent, UInt32 Flags);
        [DllImport("setupapi.dll")]
        public unsafe static extern Boolean SetupDiEnumDeviceInterfaces(IntPtr hDevInfo, IntPtr devInvo, ref Guid interfaceClassGuid, Int32 memberIndex, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);
        [DllImport("setupapi.dll")]
        public unsafe static extern Boolean SetupDiGetDeviceInterfaceDetail(IntPtr hDevInfo, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData, IntPtr deviceInterfaceDetailData, UInt32 deviceInterfaceDetailDataSize, out UInt32 requiredSize, IntPtr deviceInfoData);
        [DllImport("setupapi.dll")]
        public unsafe static extern Boolean SetupDiGetDeviceInterfaceDetail(IntPtr hDevInfo, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData, ref SP_DEVICE_INTERFACE_DETAIL_DATA deviceInterfaceDetailData, UInt32 deviceInterfaceDetailDataSize, out UInt32 requiredSize, IntPtr deviceInfoData);
        [DllImport("Kernel32.dll")]
        public unsafe static extern SafeFileHandle CreateFile(string fileName, [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess, [MarshalAs(UnmanagedType.U4)] FileShare fileShare, IntPtr securityAttributes, [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr template);
        [DllImport("winmm.dll", EntryPoint = "timeBeginPeriod")]
        public unsafe static extern uint TimeBeginPeriod(uint ms);
        [DllImport("winmm.dll", EntryPoint = "timeEndPeriod")]
        public unsafe static extern uint TimeEndPeriod(uint ms);
        [DllImport("ntdll.dll", EntryPoint = "NtSetTimerResolution")]
        public unsafe static extern void NtSetTimerResolution(uint DesiredResolution, bool SetResolution, ref uint CurrentResolution);
        [DllImport("Kernel32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();
        [DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow([In] IntPtr hWnd, [In] Int32 nCmdShow);
        const Int32 SW_MINIMIZE = 6;
        public unsafe static double dz = 4f, REGISTER_IR = 0x04b00030, REGISTER_EXTENSION_INIT_1 = 0x04a400f0, REGISTER_EXTENSION_INIT_2 = 0x04a400fb, REGISTER_EXTENSION_TYPE = 0x04a400fa, REGISTER_EXTENSION_CALIBRATION = 0x04a40020, REGISTER_MOTIONPLUS_INIT = 0x04a600fe, irx0, iry0, irx1, iry1, irx, iry, irxc, iryc, mWSIRSensors0X, mWSIRSensors0Y, mWSIRSensors1X, mWSIRSensors1Y, mWSButtonStateIRX, mWSButtonStateIRY, mWSIR0notfound = 0, mWSRawValuesX, mWSRawValuesY, mWSRawValuesZ, calibrationinit, stickviewxinit, stickviewyinit, mWSNunchuckStateRawValuesX, mWSNunchuckStateRawValuesY, mWSNunchuckStateRawValuesZ, mWSNunchuckStateRawJoystickX, mWSNunchuckStateRawJoystickY, center = 160f, mousex, mousey, mWSIRSensors0Xcam, mWSIRSensors0Ycam, mWSIRSensors1Xcam, mWSIRSensors1Ycam, mWSIRSensorsXcam, mWSIRSensorsYcam;
        public unsafe static bool mWSIR1found, mWSIR0found, mWSButtonStateA, mWSButtonStateB, mWSButtonStateMinus, mWSButtonStateHome, mWSButtonStatePlus, mWSButtonStateOne, mWSButtonStateTwo, mWSButtonStateUp, mWSButtonStateDown, mWSButtonStateLeft, mWSButtonStateRight, mWSNunchuckStateC, mWSNunchuckStateZ, Getstate;
        public unsafe static byte[] buff = new byte[] { 0x55 }, mBuff = new byte[22], aBuffer = new byte[22];
        public unsafe static byte Type = 0x12, IR = 0x13, WriteMemory = 0x16, ReadMemory = 0x16, IRExtensionAccel = 0x37;
        public unsafe static Guid guid = new Guid();
        public unsafe static uint CurrentResolution = 0;
        private unsafe static FileStream mStream;
        private unsafe static string path;
        private unsafe static ConsoleEventDelegate handler;
        private delegate bool ConsoleEventDelegate(int eventType);
        public unsafe static ThreadStart threadstart;
        public unsafe static Thread thread;
        public unsafe static Teensy teensy = new Teensy(Message_t.MESSAGE_MAGIC);
        public unsafe static int[] wd = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        public unsafe static int[] wu = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        public unsafe static bool[] ws = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        public unsafe static void valchanged(int n, bool val)
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
            ws[n] = val;
        }
        public unsafe static void Main(string[] args)
        {
            if (teensy.Port != null)
            {
                TimeBeginPeriod(1);
                NtSetTimerResolution(1, true, ref CurrentResolution);
                MinimizeConsoleWindow();
                Task.Run(() => Start());
                handler = new ConsoleEventDelegate(ConsoleEventCallback);
                SetConsoleCtrlHandler(handler, true);
                Console.ReadLine();
            }
        }
        public unsafe static void Start()
        {
            connectingWiimote();
            Task.Run(() => taskD());
            Thread.Sleep(1000);
            calibrationinit = -aBuffer[4] + 135f;
            stickviewxinit = -aBuffer[16] + 125f;
            stickviewyinit = -aBuffer[17] + 125f;
            Task.Run(() => taskI());
            Task.Run(() => taskJ1());
            Task.Run(() => taskJ2());
            teensy.Ping();
            do
                Thread.Sleep(1);
            while (teensy.Pong() != 10);
            System.Media.SystemSounds.Beep.Play();
            Console.WriteLine("connected");
        }
        public unsafe static void connectingWiimote()
        {
            do
                Thread.Sleep(1);
            while (!connect());
            do
                Thread.Sleep(1);
            while (!ScanWiimote());
        }
        private unsafe static double Scale(double value, double min, double max, double minScale, double maxScale)
        {
            double scaled = minScale + (double)(value - min) / (max - min) * (maxScale - minScale);
            return scaled;
        }
        public static void taskI()
        {
            for (; ; )
            {
                mWSIR0found = (aBuffer[6] | ((aBuffer[8] >> 4) & 0x03) << 8) > 1 & (aBuffer[6] | ((aBuffer[8] >> 4) & 0x03) << 8) < 1023;
                mWSIR1found = (aBuffer[9] | ((aBuffer[8] >> 0) & 0x03) << 8) > 1 & (aBuffer[9] | ((aBuffer[8] >> 0) & 0x03) << 8) < 1023;
                if (mWSIR0found)
                {
                    mWSIRSensors0X = aBuffer[6] | ((aBuffer[8] >> 4) & 0x03) << 8;
                    mWSIRSensors0Y = aBuffer[7] | ((aBuffer[8] >> 6) & 0x03) << 8;
                    mWSIRSensors0Xcam = mWSIRSensors0X - 512f;
                    mWSIRSensors0Ycam = mWSIRSensors0Y - 384f;
                }
                if (mWSIR1found)
                {
                    mWSIRSensors1X = aBuffer[9] | ((aBuffer[8] >> 0) & 0x03) << 8;
                    mWSIRSensors1Y = aBuffer[10] | ((aBuffer[8] >> 2) & 0x03) << 8;
                    mWSIRSensors1Xcam = mWSIRSensors1X - 512f;
                    mWSIRSensors1Ycam = mWSIRSensors1Y - 384f;
                }
                if (mWSIR0found & mWSIR1found)
                {
                    mWSIRSensorsXcam = (mWSIRSensors0Xcam + mWSIRSensors1Xcam) / 2f;
                    mWSIRSensorsYcam = (mWSIRSensors0Ycam + mWSIRSensors1Ycam) / 2f;
                }
                irx0 = 2 * mWSIRSensors0Xcam - mWSIRSensorsXcam;
                iry0 = 2 * mWSIRSensors0Ycam - mWSIRSensorsYcam;
                irx1 = 2 * mWSIRSensors1Xcam - mWSIRSensorsXcam;
                iry1 = 2 * mWSIRSensors1Ycam - mWSIRSensorsYcam;
                irxc = irx0 + irx1;
                iryc = iry0 + iry1;
                mWSButtonStateIRX = irxc;
                mWSButtonStateIRY = iryc * 2f;
                irx = mWSButtonStateIRX * (1024f / 1360f);
                iry = mWSButtonStateIRY + center >= 0 ? Scale(mWSButtonStateIRY + center, 0f, 1360f + center, 0f, 1024f) : Scale(mWSButtonStateIRY + center, -1360f + center, 0f, -1024f, 0f);
                if (irx >= 1024f)
                    irx = 1024f;
                if (irx <= -1024f)
                    irx = -1024f;
                if (iry >= 1024f)
                    iry = 1024f;
                if (iry <= -1024f)
                    iry = -1024f;
                if (irx > 0f)
                    mousex = Scale((Math.Pow(irx, 3f) / Math.Pow(1024f, 2f) + Math.Pow(irx, 2f) / Math.Pow(1024f, 1f)) / 2f, 0f, 1024f, (dz / 100f) * 1024f, 1024f);
                if (irx < 0f)
                    mousex = Scale(-(Math.Pow(-irx, 3f) / Math.Pow(1024f, 2f) + Math.Pow(-irx, 2f) / Math.Pow(1024f, 1f)) / 2f, -1024f, 0f, -1024f, -(dz / 100f) * 1024f);
                if (iry > 0f)
                    mousey = Scale((Math.Pow(iry, 3f) / Math.Pow(1024f, 2f) + Math.Pow(iry, 2f) / Math.Pow(1024f, 1f)) / 2f, 0f, 1024f, (dz / 100f) * 1024f, 1024f);
                if (iry < 0f)
                    mousey = Scale(-(Math.Pow(-iry, 3f) / Math.Pow(1024f, 2f) + Math.Pow(-iry, 2f) / Math.Pow(1024f, 1f)) / 2f, -1024f, 0f, -1024f, -(dz / 100f) * 1024f);
                Thread.Sleep(1);
            }
        }
        public unsafe static void taskJ1()
        {
            for (; ; )
            {
                if (Getstate)
                {
                    teensy.JoystickX((int)(mousex / 2f));
                    teensy.JoystickY((int)(mousey / 2f));
                }
                Thread.Sleep(4);
            }
        }
        public unsafe static void taskJ2()
        {
            for (; ; )
            {
                mWSButtonStateA = (aBuffer[2] & 0x08) != 0;
                mWSButtonStateB = (aBuffer[2] & 0x04) != 0;
                mWSButtonStateMinus = (aBuffer[2] & 0x10) != 0;
                mWSButtonStateHome = (aBuffer[2] & 0x80) != 0;
                mWSButtonStatePlus = (aBuffer[1] & 0x10) != 0;
                mWSButtonStateOne = (aBuffer[2] & 0x02) != 0;
                mWSButtonStateTwo = (aBuffer[2] & 0x01) != 0;
                mWSButtonStateUp = (aBuffer[1] & 0x08) != 0;
                mWSButtonStateDown = (aBuffer[1] & 0x04) != 0;
                mWSButtonStateLeft = (aBuffer[1] & 0x01) != 0;
                mWSButtonStateRight = (aBuffer[1] & 0x02) != 0;
                mWSRawValuesX = aBuffer[3] - 135f + calibrationinit;
                mWSRawValuesY = aBuffer[4] - 135f + calibrationinit;
                mWSRawValuesZ = aBuffer[5] - 135f + calibrationinit;
                mWSNunchuckStateRawJoystickX = aBuffer[16] - 125f + stickviewxinit;
                mWSNunchuckStateRawJoystickY = aBuffer[17] - 125f + stickviewyinit;
                mWSNunchuckStateRawValuesX = aBuffer[18] - 125f;
                mWSNunchuckStateRawValuesY = aBuffer[19] - 125f;
                mWSNunchuckStateRawValuesZ = aBuffer[20] - 125f;
                mWSNunchuckStateC = (aBuffer[21] & 0x02) == 0;
                mWSNunchuckStateZ = (aBuffer[21] & 0x01) == 0;
                valchanged(0, mWSButtonStateHome & mWSButtonStateTwo);
                if (wd[0] == 1 & !Getstate)
                {
                    Getstate = true;
                }
                else
                {
                    if (wd[0] == 1 & Getstate)
                    {
                        Getstate = false;
                        for (int i = 1; i <= 36; i++)
                        {
                            wd[i] = 2;
                            wu[i] = 2;
                            Thread.Sleep(1);
                        }
                        teensy.JoystickRelease(1);
                        teensy.JoystickRelease(2);
                        teensy.JoystickRelease(6);
                        teensy.JoystickRelease(10);
                        teensy.JoystickRelease(9);
                    }
                }
                if (Getstate)
                {
                    teensy.JoystickZRotate((int)(mWSNunchuckStateRawJoystickX * 9f >= -512 ? mWSNunchuckStateRawJoystickX * 9f : -512));
                    teensy.JoystickZ((int)(mWSNunchuckStateRawJoystickY * 9f >= -512 ? mWSNunchuckStateRawJoystickY * 9f : -512));
                    valchanged(27, mWSButtonStateA);
                    if (wd[27] == 1)
                        teensy.JoystickSliderLeft(512);
                    if (wu[27] == 1)
                        teensy.JoystickSliderLeft(-512);
                    valchanged(11, mWSButtonStateB);
                    if (wd[11] == 1)
                        teensy.JoystickSliderRight(512);
                    if (wu[11] == 1)
                        teensy.JoystickSliderRight(-512);
                    valchanged(5, mWSNunchuckStateRawValuesX >= 41);
                    if (wd[5] == 1)
                        teensy.JoystickPress(1);
                    if (wu[5] == 1)
                        teensy.JoystickRelease(1);
                    valchanged(6, mWSNunchuckStateRawValuesX <= -41);
                    if (wd[6] == 1)
                        teensy.JoystickPress(2);
                    if (wu[6] == 1)
                        teensy.JoystickRelease(2);
                    valchanged(2, mWSNunchuckStateZ);
                    if (wd[2] == 1)
                        teensy.JoystickPress(3);
                    if (wu[2] == 1)
                        teensy.JoystickRelease(3);
                    valchanged(3, mWSNunchuckStateZ & mWSNunchuckStateC);
                    if (wd[3] == 1)
                        teensy.JoystickPress(4);
                    if (wu[3] == 1)
                        teensy.JoystickRelease(4);
                    valchanged(10, mWSNunchuckStateC & !mWSNunchuckStateZ);
                    if (wd[10] == 1)
                        teensy.JoystickPress(5);
                    if (wu[10] == 1)
                        teensy.JoystickRelease(5);
                    valchanged(4, (mWSNunchuckStateRawValuesY > 33f) & !((mWSRawValuesZ > 0 ? mWSRawValuesZ : -mWSRawValuesZ) >= 40f & (mWSRawValuesY > 0 ? mWSRawValuesY : -mWSRawValuesY) >= 40f & (mWSRawValuesX > 0 ? mWSRawValuesX : -mWSRawValuesX) >= 40f));
                    if (wd[4] == 1)
                        teensy.JoystickPress(6);
                    if (wu[4] == 1)
                        teensy.JoystickRelease(6);
                    valchanged(13, (mWSRawValuesZ > 0 ? mWSRawValuesZ : -mWSRawValuesZ) >= 40f & (mWSRawValuesY > 0 ? mWSRawValuesY : -mWSRawValuesY) >= 40f & (mWSRawValuesX > 0 ? mWSRawValuesX : -mWSRawValuesX) >= 40f);
                    if (wd[13] == 1)
                        teensy.JoystickPress(7);
                    if (wu[13] == 1)
                        teensy.JoystickRelease(7);
                    valchanged(20, mWSButtonStateOne);
                    if (wd[20] == 1)
                        teensy.JoystickPress(8);
                    if (wu[20] == 1)
                        teensy.JoystickRelease(8);
                    valchanged(26, mWSButtonStateTwo);
                    if (wd[26] == 1)
                        teensy.JoystickPress(9);
                    if (wu[26] == 1)
                        teensy.JoystickRelease(9);
                    valchanged(22, mWSButtonStateHome);
                    if (wd[22] == 1)
                        teensy.JoystickPress(10);
                    if (wu[22] == 1)
                        teensy.JoystickRelease(10);
                    valchanged(14, mWSButtonStatePlus);
                    if (wd[14] == 1)
                        teensy.JoystickPress(11);
                    if (wu[14] == 1)
                        teensy.JoystickRelease(11);
                    valchanged(15, mWSButtonStateMinus);
                    if (wd[15] == 1)
                        teensy.JoystickPress(12);
                    if (wu[15] == 1)
                        teensy.JoystickRelease(12);
                    valchanged(25, mWSButtonStateUp);
                    if (wd[25] == 1)
                        teensy.JoystcickSetHat(0);
                    if (wu[25] == 1)
                        teensy.JoystcickSetHat(-1);
                    valchanged(24, mWSButtonStateLeft);
                    if (wd[24] == 1)
                        teensy.JoystcickSetHat(90);
                    if (wu[24] == 1)
                        teensy.JoystcickSetHat(-1);
                    valchanged(21, mWSButtonStateDown);
                    if (wd[21] == 1)
                        teensy.JoystcickSetHat(180);
                    if (wu[21] == 1)
                        teensy.JoystcickSetHat(-1);
                    valchanged(23, mWSButtonStateRight);
                    if (wd[23] == 1)
                        teensy.JoystcickSetHat(270);
                    if (wu[23] == 1)
                        teensy.JoystcickSetHat(-1);
                }
                Thread.Sleep(10);
            }
        }
        public unsafe static void taskD()
        {
            for (; ; )
            {
                try
                {
                    mStream.Read(aBuffer, 0, 22);
                }
                catch
                {
                    connectingWiimote();
                }
            }
        }
        private unsafe static void MinimizeConsoleWindow()
        {
            IntPtr hWndConsole = GetConsoleWindow();
            ShowWindow(hWndConsole, SW_MINIMIZE);
        }
        public unsafe static bool ConsoleEventCallback(int eventType)
        {
            if (eventType == 2)
            {
                TimeEndPeriod(1);
                threadstart = new ThreadStart(FormClose);
                thread = new Thread(threadstart);
                thread.Start();
                Thread.Sleep(10000);
            }
            return false;
        }
        private unsafe static void FormClose()
        {
            disconnect();
        }
        private const string vendor_id = "57e", vendor_id_ = "057e", product_r1 = "0330", product_r2 = "0306";
        public enum EFileAttributes : uint
        {
            Overlapped = 0x40000000,
            Normal = 0x80
        };
        public struct SP_DEVICE_INTERFACE_DATA
        {
            public int cbSize;
            public Guid InterfaceClassGuid;
            public int Flags;
            public IntPtr RESERVED;
        }
        public struct SP_DEVICE_INTERFACE_DETAIL_DATA
        {
            public UInt32 cbSize;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 256)]
            public string DevicePath;
        }
        private unsafe static bool ScanWiimote()
        {
            int index = 0;
            Guid guid;
            HidD_GetHidGuid(out guid);
            IntPtr hDevInfo = SetupDiGetClassDevs(ref guid, null, new IntPtr(), 0x00000010);
            SP_DEVICE_INTERFACE_DATA diData = new SP_DEVICE_INTERFACE_DATA();
            diData.cbSize = Marshal.SizeOf(diData);
            while (SetupDiEnumDeviceInterfaces(hDevInfo, new IntPtr(), ref guid, index, ref diData))
            {
                UInt32 size;
                SetupDiGetDeviceInterfaceDetail(hDevInfo, ref diData, new IntPtr(), 0, out size, new IntPtr());
                SP_DEVICE_INTERFACE_DETAIL_DATA diDetail = new SP_DEVICE_INTERFACE_DETAIL_DATA();
                diDetail.cbSize = 5;
                if (SetupDiGetDeviceInterfaceDetail(hDevInfo, ref diData, ref diDetail, size, out size, new IntPtr()))
                {
                    if ((diDetail.DevicePath.Contains(vendor_id) | diDetail.DevicePath.Contains(vendor_id_)) & (diDetail.DevicePath.Contains(product_r1) | diDetail.DevicePath.Contains(product_r2)))
                    {
                        path = diDetail.DevicePath;
                        WiimoteFound(diDetail.DevicePath);
                        WiimoteFound(diDetail.DevicePath);
                        WiimoteFound(diDetail.DevicePath);
                        return true;
                    }
                }
                index++;
            }
            return false;
        }
        public unsafe static void WiimoteFound(string path)
        {
            SafeFileHandle handle = null;
            do
            {
                handle = CreateFile(path, FileAccess.ReadWrite, FileShare.ReadWrite, IntPtr.Zero, FileMode.Open, (uint)EFileAttributes.Overlapped, IntPtr.Zero);
                WriteData(handle, IR, (int)REGISTER_IR, new byte[] { 0x08 }, 1);
                WriteData(handle, Type, (int)REGISTER_EXTENSION_INIT_1, new byte[] { 0x55 }, 1);
                WriteData(handle, Type, (int)REGISTER_EXTENSION_INIT_2, new byte[] { 0x00 }, 1);
                WriteData(handle, Type, (int)REGISTER_MOTIONPLUS_INIT, new byte[] { 0x04 }, 1);
                ReadData(handle, 0x0016, 7);
                ReadData(handle, (int)REGISTER_EXTENSION_TYPE, 6);
                ReadData(handle, (int)REGISTER_EXTENSION_CALIBRATION, 16);
                ReadData(handle, (int)REGISTER_EXTENSION_CALIBRATION, 32);
            }
            while (handle.IsInvalid);
            mStream = new FileStream(handle, FileAccess.ReadWrite, 22, true);
        }
        public unsafe static void ReadData(SafeFileHandle _hFile, int address, short size)
        {
            mBuff[0] = (byte)ReadMemory;
            mBuff[1] = (byte)((address & 0xff000000) >> 24);
            mBuff[2] = (byte)((address & 0x00ff0000) >> 16);
            mBuff[3] = (byte)((address & 0x0000ff00) >> 8);
            mBuff[4] = (byte)(address & 0x000000ff);
            mBuff[5] = (byte)((size & 0xff00) >> 8);
            mBuff[6] = (byte)(size & 0xff);
            HidD_SetOutputReport(_hFile.DangerousGetHandle(), mBuff, 22);
        }
        public unsafe static void WriteData(SafeFileHandle _hFile, byte mbuff, int address, byte[] buff, short size)
        {
            mBuff[0] = (byte)mbuff;
            mBuff[1] = (byte)(0x04);
            mBuff[2] = (byte)IRExtensionAccel;
            Array.Copy(buff, 0, mBuff, 3, 1);
            HidD_SetOutputReport(_hFile.DangerousGetHandle(), mBuff, 22);
            mBuff[0] = (byte)WriteMemory;
            mBuff[1] = (byte)(((address & 0xff000000) >> 24));
            mBuff[2] = (byte)((address & 0x00ff0000) >> 16);
            mBuff[3] = (byte)((address & 0x0000ff00) >> 8);
            mBuff[4] = (byte)((address & 0x000000ff) >> 0);
            mBuff[5] = (byte)size;
            Array.Copy(buff, 0, mBuff, 6, 1);
            HidD_SetOutputReport(_hFile.DangerousGetHandle(), mBuff, 22);
        }
    }
    public class Keylayout
    {
        public const int MODIFIERKEY_CTRL = 0x01 + 0xE000;
        public const int MODIFIERKEY_SHIFT = 0x02 + 0xE000;
        public const int MODIFIERKEY_ALT = 0x04 + 0xE000;
        public const int MODIFIERKEY_GUI = 0x08 + 0xE000;
        public const int MODIFIERKEY_LEFT_CTRL = 0x01 + 0xE000;
        public const int MODIFIERKEY_LEFT_SHIFT = 0x02 + 0xE000;
        public const int MODIFIERKEY_LEFT_ALT = 0x04 + 0xE000;
        public const int MODIFIERKEY_LEFT_GUI = 0x08 + 0xE000;
        public const int MODIFIERKEY_RIGHT_CTRL = 0x10 + 0xE000;
        public const int MODIFIERKEY_RIGHT_SHIFT = 0x20 + 0xE000;
        public const int MODIFIERKEY_RIGHT_ALT = 0x40 + 0xE000;
        public const int MODIFIERKEY_RIGHT_GUI = 0x80 + 0xE000;
        public const int KEY_SYSTEM_POWER_DOWN = 0x81 + 0xE200;
        public const int KEY_SYSTEM_SLEEP = 0x82 + 0xE200;
        public const int KEY_SYSTEM_WAKE_UP = 0x83 + 0xE200;
        public const int KEY_MEDIA_PLAY = 0xB0 + 0xE400;
        public const int KEY_MEDIA_PAUSE = 0xB1 + 0xE400;
        public const int KEY_MEDIA_RECORD = 0xB2 + 0xE400;
        public const int KEY_MEDIA_FAST_FORWARD = 0xB3 + 0xE400;
        public const int KEY_MEDIA_REWIND = 0xB4 + 0xE400;
        public const int KEY_MEDIA_NEXT_TRACK = 0xB5 + 0xE400;
        public const int KEY_MEDIA_PREV_TRACK = 0xB6 + 0xE400;
        public const int KEY_MEDIA_STOP = 0xB7 + 0xE400;
        public const int KEY_MEDIA_EJECT = 0xB8 + 0xE400;
        public const int KEY_MEDIA_RANDOM_PLAY = 0xB9 + 0xE400;
        public const int KEY_MEDIA_PLAY_PAUSE = 0xCD + 0xE400;
        public const int KEY_MEDIA_PLAY_SKIP = 0xCE + 0xE400;
        public const int KEY_MEDIA_MUTE = 0xE2 + 0xE400;
        public const int KEY_MEDIA_VOLUME_INC = 0xE9 + 0xE400;
        public const int KEY_MEDIA_VOLUME_DEC = 0xEA + 0xE400;
        public const int KEY_A = 4 + 0xF000;
        public const int KEY_B = 5 + 0xF000;
        public const int KEY_C = 6 + 0xF000;
        public const int KEY_D = 7 + 0xF000;
        public const int KEY_E = 8 + 0xF000;
        public const int KEY_F = 9 + 0xF000;
        public const int KEY_G = 10 + 0xF000;
        public const int KEY_H = 11 + 0xF000;
        public const int KEY_I = 12 + 0xF000;
        public const int KEY_J = 13 + 0xF000;
        public const int KEY_K = 14 + 0xF000;
        public const int KEY_L = 15 + 0xF000;
        public const int KEY_M = 16 + 0xF000;
        public const int KEY_N = 17 + 0xF000;
        public const int KEY_O = 18 + 0xF000;
        public const int KEY_P = 19 + 0xF000;
        public const int KEY_Q = 20 + 0xF000;
        public const int KEY_R = 21 + 0xF000;
        public const int KEY_S = 22 + 0xF000;
        public const int KEY_T = 23 + 0xF000;
        public const int KEY_U = 24 + 0xF000;
        public const int KEY_V = 25 + 0xF000;
        public const int KEY_W = 26 + 0xF000;
        public const int KEY_X = 27 + 0xF000;
        public const int KEY_Y = 28 + 0xF000;
        public const int KEY_Z = 29 + 0xF000;
        public const int KEY_1 = 30 + 0xF000;
        public const int KEY_2 = 31 + 0xF000;
        public const int KEY_3 = 32 + 0xF000;
        public const int KEY_4 = 33 + 0xF000;
        public const int KEY_5 = 34 + 0xF000;
        public const int KEY_6 = 35 + 0xF000;
        public const int KEY_7 = 36 + 0xF000;
        public const int KEY_8 = 37 + 0xF000;
        public const int KEY_9 = 38 + 0xF000;
        public const int KEY_0 = 39 + 0xF000;
        public const int KEY_ENTER = 40 + 0xF000;
        public const int KEY_ESC = 41 + 0xF000;
        public const int KEY_BACKSPACE = 42 + 0xF000;
        public const int KEY_TAB = 43 + 0xF000;
        public const int KEY_SPACE = 44 + 0xF000;
        public const int KEY_MINUS = 45 + 0xF000;
        public const int KEY_EQUAL = 46 + 0xF000;
        public const int KEY_LEFT_BRACE = 47 + 0xF000;
        public const int KEY_RIGHT_BRACE = 48 + 0xF000;
        public const int KEY_BACKSLASH = 49 + 0xF000;
        public const int KEY_NON_US_NUM = 50 + 0xF000;
        public const int KEY_SEMICOLON = 51 + 0xF000;
        public const int KEY_QUOTE = 52 + 0xF000;
        public const int KEY_TILDE = 53 + 0xF000;
        public const int KEY_COMMA = 54 + 0xF000;
        public const int KEY_PERIOD = 55 + 0xF000;
        public const int KEY_SLASH = 56 + 0xF000;
        public const int KEY_CAPS_LOCK = 57 + 0xF000;
        public const int KEY_F1 = 58 + 0xF000;
        public const int KEY_F2 = 59 + 0xF000;
        public const int KEY_F3 = 60 + 0xF000;
        public const int KEY_F4 = 61 + 0xF000;
        public const int KEY_F5 = 62 + 0xF000;
        public const int KEY_F6 = 63 + 0xF000;
        public const int KEY_F7 = 64 + 0xF000;
        public const int KEY_F8 = 65 + 0xF000;
        public const int KEY_F9 = 66 + 0xF000;
        public const int KEY_F10 = 67 + 0xF000;
        public const int KEY_F11 = 68 + 0xF000;
        public const int KEY_F12 = 69 + 0xF000;
        public const int KEY_PRINTSCREEN = 70 + 0xF000;
        public const int KEY_SCROLL_LOCK = 71 + 0xF000;
        public const int KEY_PAUSE = 72 + 0xF000;
        public const int KEY_INSERT = 73 + 0xF000;
        public const int KEY_HOME = 74 + 0xF000;
        public const int KEY_PAGE_UP = 75 + 0xF000;
        public const int KEY_DELETE = 76 + 0xF000;
        public const int KEY_END = 77 + 0xF000;
        public const int KEY_PAGE_DOWN = 78 + 0xF000;
        public const int KEY_RIGHT = 79 + 0xF000;
        public const int KEY_LEFT = 80 + 0xF000;
        public const int KEY_DOWN = 81 + 0xF000;
        public const int KEY_UP = 82 + 0xF000;
        public const int KEY_NUM_LOCK = 83 + 0xF000;
        public const int KEYPAD_SLASH = 84 + 0xF000;
        public const int KEYPAD_ASTERIX = 85 + 0xF000;
        public const int KEYPAD_MINUS = 86 + 0xF000;
        public const int KEYPAD_PLUS = 87 + 0xF000;
        public const int KEYPAD_ENTER = 88 + 0xF000;
        public const int KEYPAD_1 = 89 + 0xF000;
        public const int KEYPAD_2 = 90 + 0xF000;
        public const int KEYPAD_3 = 91 + 0xF000;
        public const int KEYPAD_4 = 92 + 0xF000;
        public const int KEYPAD_5 = 93 + 0xF000;
        public const int KEYPAD_6 = 94 + 0xF000;
        public const int KEYPAD_7 = 95 + 0xF000;
        public const int KEYPAD_8 = 96 + 0xF000;
        public const int KEYPAD_9 = 97 + 0xF000;
        public const int KEYPAD_0 = 98 + 0xF000;
        public const int KEYPAD_PERIOD = 99 + 0xF000;
        public const int KEY_NON_US_BS = 100 + 0xF000;
        public const int KEY_MENU = 101 + 0xF000;
        public const int KEY_F13 = 104 + 0xF000;
        public const int KEY_F14 = 105 + 0xF000;
        public const int KEY_F15 = 106 + 0xF000;
        public const int KEY_F16 = 107 + 0xF000;
        public const int KEY_F17 = 108 + 0xF000;
        public const int KEY_F18 = 109 + 0xF000;
        public const int KEY_F19 = 110 + 0xF000;
        public const int KEY_F20 = 111 + 0xF000;
        public const int KEY_F21 = 112 + 0xF000;
        public const int KEY_F22 = 113 + 0xF000;
        public const int KEY_F23 = 114 + 0xF000;
        public const int KEY_F24 = 115 + 0xF000;
    }
    public enum Command_t : byte
    {
        InvalidMessage = 0,
        InvalidRequest,
        Ping,
        Pong,
        KeyboardPress,
        KeyboardRelease,
        MouseSetScreenSize,
        MouseMove,
        MouseMoveTo,
        MouseMoveAs,
        MouseSetButtons,
        MouseScroll,
        JoystickPress,
        JoystickRelease,
        JoystcickSetHat,
        JoystickX,
        JoystickY,
        JoystickZ,
        JoystickZRotate,
        JoystickSliderLeft,
        JoystickSliderRight
    };
    [StructLayout(LayoutKind.Sequential)]
    public struct Data_t
    {
        public int d1;
        public int d2;
        public int d3;
        public int d4;
    }
    [StructLayout(LayoutKind.Explicit)]
    unsafe struct Message_t
    {
        public unsafe static ushort MESSAGE_MAGIC = 0xBEEF;
        [FieldOffset(0)]
        public ushort Magic;
        [FieldOffset(2)]
        public Command_t Command;
        [FieldOffset(4)]
        public Data_t Data;
        public unsafe static bool MessageReady(SerialPort port)
        {
            return port.BytesToRead >= Marshal.SizeOf(typeof(Message_t));
        }
        public unsafe static void ReadMessage(SerialPort port, ref Message_t msg)
        {
            byte[] data = new byte[Marshal.SizeOf(typeof(Message_t))];
            for (int i = 0; i < data.Length; i++)
                data[i] = (byte)port.ReadByte();
            fixed (byte* b = data)
                msg = (Message_t)Marshal.PtrToStructure((IntPtr)b, typeof(Message_t));
        }
        public unsafe static void WriteMessage(SerialPort port, ref Message_t msg)
        {
            byte[] data = new byte[Marshal.SizeOf(typeof(Message_t))];
            fixed (byte* b = data)
                Marshal.StructureToPtr(msg, (IntPtr)b, true);
            port.Write(data, 0, data.Length);
        }
    }
    public class Teensy
    {
        public ushort Magic;
        public SerialPort Port;
        public Teensy(SerialPort port, ushort magic)
        {
            Port = port;
            Magic = magic;
        }
        public Teensy(ushort magic)
        {
            Port = GetArduinoPort();
            Magic = magic;
        }
        private unsafe static SerialPort GetArduinoPort()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (var port in ports)
            {
                SerialPort p = new SerialPort(port, 9600);
                Message_t msgIn = new Message_t(), msgOut = new Message_t();
                msgOut.Magic = Message_t.MESSAGE_MAGIC;
                msgOut.Command = Command_t.Ping;
                try
                {
                    p.Open();
                    Message_t.WriteMessage(p, ref msgOut);
                    Thread.Sleep(100);
                    if (!Message_t.MessageReady(p))
                        continue;
                    Message_t.ReadMessage(p, ref msgIn);
                    if (msgIn.Magic != Message_t.MESSAGE_MAGIC)
                        continue;
                    if (msgIn.Command != Command_t.Pong)
                        continue;
                    return p;
                }
                catch
                {
                    p.Close();
                }
            }
            return null;
        }
        private void sendCommand(Command_t command, int d1, int d2, int d3, int d4)
        {
            Message_t msgOut = new Message_t();
            msgOut.Magic = Magic;
            msgOut.Command = command;
            msgOut.Data.d1 = d1;
            msgOut.Data.d2 = d2;
            msgOut.Data.d3 = d3;
            msgOut.Data.d4 = d4;
            Message_t.WriteMessage(Port, ref msgOut);
        }
        public void Ping()
        {
            sendCommand(Command_t.Ping, 0, 0, 0, 0);
        }
        public int Pong()
        {
            Message_t msgIn = new Message_t();
            Message_t.ReadMessage(Port, ref msgIn);
            if (msgIn.Command == Command_t.Pong)
                return msgIn.Data.d1 + msgIn.Data.d2 + msgIn.Data.d3 + msgIn.Data.d4;
            else
                return 0;
        }
        public void KeyboardPress(int key)
        {
            sendCommand(Command_t.KeyboardPress, key, 0, 0, 0);
        }
        public void KeyboardRelease(int key)
        {
            sendCommand(Command_t.KeyboardRelease, key, 0, 0, 0);
        }
        public void MouseSetScreenSize(int x, int y)
        {
            sendCommand(Command_t.MouseSetScreenSize, x, y, 0, 0);
        }
        public void MouseMove(int x, int y)
        {
            sendCommand(Command_t.MouseMove, x, y, 0, 0);
        }
        public void MouseMoveTo(int x, int y)
        {
            sendCommand(Command_t.MouseMoveTo, x, y, 0, 0);
        }
        public void MouseMoveAs(int x, int y, int i, int j)
        {
            sendCommand(Command_t.MouseMoveAs, x, y, i, j);
        }
        public void MouseSetButtons(int left, int mid, int right)
        {
            sendCommand(Command_t.MouseSetButtons, left, mid, right, 0);
        }
        public void MouseScroll(int scroll)
        {
            sendCommand(Command_t.MouseScroll, scroll, 0, 0, 0);
        }
        public void JoystickPress(int num)
        {
            sendCommand(Command_t.JoystickPress, num, 1, 0, 0);
        }
        public void JoystickRelease(int num)
        {
            sendCommand(Command_t.JoystickRelease, num, 0, 0, 0);
        }
        public void JoystcickSetHat(int angle)
        {
            sendCommand(Command_t.JoystcickSetHat, angle, 0, 0, 0);
        }
        public void JoystickX(int value)
        {
            sendCommand(Command_t.JoystickX, value, 0, 0, 0);
        }
        public void JoystickY(int value)
        {
            sendCommand(Command_t.JoystickY, value, 0, 0, 0);
        }
        public void JoystickZ(int value)
        {
            sendCommand(Command_t.JoystickZ, value, 0, 0, 0);
        }
        public void JoystickZRotate(int value)
        {
            sendCommand(Command_t.JoystickZRotate, value, 0, 0, 0);
        }
        public void JoystickSliderLeft(int value)
        {
            sendCommand(Command_t.JoystickSliderLeft, value, 0, 0, 0);
        }
        public void JoystickSliderRight(int value)
        {
            sendCommand(Command_t.JoystickSliderRight, value, 0, 0, 0);
        }
    }
}