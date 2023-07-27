using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO.Ports;
using System.Linq;
namespace WiiWar
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
        private const Int32 SW_MINIMIZE = 6;
        public unsafe static double REGISTER_IR = 0x04b00030, REGISTER_EXTENSION_INIT_1 = 0x04a400f0, REGISTER_EXTENSION_INIT_2 = 0x04a400fb, REGISTER_EXTENSION_TYPE = 0x04a400fa, REGISTER_EXTENSION_CALIBRATION = 0x04a40020, REGISTER_MOTIONPLUS_INIT = 0x04a600fe, irx0, iry0, irx1, iry1, irx, iry, irxc, iryc, mWSIRSensors0X, mWSIRSensors0Y, mWSIRSensors1X, mWSIRSensors1Y, mWSButtonStateIRX, mWSButtonStateIRY, mWSIR0notfound = 0, mWSRawValuesX, mWSRawValuesY, mWSRawValuesZ, calibrationinit, stickviewxinit, stickviewyinit, mWSNunchuckStateRawValuesX, mWSNunchuckStateRawValuesY, mWSNunchuckStateRawValuesZ, mWSNunchuckStateRawJoystickX, mWSNunchuckStateRawJoystickY, center = 160f, mousex, mousey, keys123456,  mWSIRSensors0Xcam, mWSIRSensors0Ycam, mWSIRSensors1Xcam, mWSIRSensors1Ycam, mWSIRSensorsXcam, mWSIRSensorsYcam, Width, Height, WidthS, HeightS, rolling, incx, incy, inc, crouchcount, streakcount, slowingright;
        public unsafe static bool mWSIR1found, mWSIR0found, mWSButtonStateA, mWSButtonStateB, mWSButtonStateMinus, mWSButtonStateHome, mWSButtonStatePlus, mWSButtonStateOne, mWSButtonStateTwo, mWSButtonStateUp, mWSButtonStateDown, mWSButtonStateLeft, mWSButtonStateRight, Getstate, mWSNunchuckStateC, mWSNunchuckStateZ, firstright, secondright;
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
        public unsafe static SerialPort Port;
        public unsafe static System.Collections.Generic.List<double> valListX = new System.Collections.Generic.List<double>();
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
            TimeBeginPeriod(1);
            NtSetTimerResolution(1, true, ref CurrentResolution);
            MinimizeConsoleWindow();
            handler = new ConsoleEventDelegate(ConsoleEventCallback);
            SetConsoleCtrlHandler(handler, true);
            string[] ports = SerialPort.GetPortNames();
            foreach (var port in ports)
            {
                Port = new SerialPort(port, 9600);
                Port.DtrEnable = true;
                Port.Open();
                Ping();
                string a = Port.ReadExisting();
                if (a.Contains("1"))
                {
                    Task.Run(() => Start());
                    Console.ReadLine();
                    break;
                }
                else
                    Port.Close();
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
            Task.Run(() => taskK());
            Task.Run(() => taskM());
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
                irx = mWSButtonStateIRX;
                iry = mWSButtonStateIRY + center >= 0 ? Scale(mWSButtonStateIRY + center, 0f, 1360f + center, 0f, 768f) : Scale(mWSButtonStateIRY + center, -1360f + center, 0f, -768f, 0f);
                if (irx >= 1360f)
                    irx = 1360f;
                if (irx <= -1360f)
                    irx = -1360f;
                if (iry >= 768f)
                    iry = 768f;
                if (iry <= -768f)
                    iry = -768f;
                mousex = (irx >= 0f ? 1f : -1f) * (Math.Pow(irx >= 0 ? irx : -irx, 4.5f) / Math.Pow(1360f, 3.5f) * (1f - 1360f / (127f * 660f)) + Math.Pow(irx >= 0 ? irx : -irx, 0.5f) * Math.Pow(1360f, 0.5f) * 1360f / (127f * 660f));
                mousey = (iry >= 0f ? 1f : -1f) * (Math.Pow(iry >= 0 ? iry : -iry, 4.5f) / Math.Pow(768f, 3.5f) * (1f - 768f / (127f * 360f)) + Math.Pow(iry >= 0 ? iry : -iry, 0.5f) * Math.Pow(768f, 0.5f) * 768f / (127f * 360f));
                Thread.Sleep(1);
            }
        }
        public unsafe static void taskM()
        {
            for (; ; )
            {
                if (Getstate)
                {
                    if (!mWSIR0found & !mWSIR1found)
                    {
                        inc += 1f;
                        if (inc >= 20f)
                            inc = 0f;
                        if (inc >= 0f & inc < 10f)
                        {
                            incx += 1f;
                            incy += 1f;
                        }
                        if (inc >= 10f & inc < 20f)
                        {
                            incx -= 1f;
                            incy -= 1f;
                        }
                        AbsMouseMove((int)(WidthS - mousex * (WidthS - incx) / 1360f), (int)(HeightS + mousey * (HeightS - incy) / 768f));
                    }
                    else
                        AbsMouseMove((int)(WidthS - mousex * WidthS / 1360f), (int)(HeightS + mousey * HeightS / 768f));
                }
                Thread.Sleep(4);
            }
        }
        public unsafe static void taskK()
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
                    Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                    Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
                    WidthS = Width / 2f;
                    HeightS = Height / 2f;
                    AbsMouseInit((int)Width, (int)Height);
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
                        KeyboardRelease(Key.KEY_A);
                        KeyboardRelease(Key.KEY_E);
                        KeyboardRelease(Key.KEY_V);
                        KeyboardRelease(Key.KEY_F);
                        KeyboardRelease(Key.KEY_ESC);
                    }
                }
                if (Getstate)
                {
                    if (valListX.Count >= 10)
                    {
                        valListX.RemoveAt(0);
                        valListX.Add(mWSNunchuckStateRawValuesX);
                        rolling = valListX.Average();
                    }
                    else
                        valListX.Add(mWSNunchuckStateRawValuesX);
                    valchanged(6, rolling <= -48f);
                    if (wd[6] == 1)
                        KeyboardPress(Key.KEY_A);
                    if (wu[6] == 1)
                        KeyboardRelease(Key.KEY_A);
                    valchanged(5, rolling >= 48f);
                    if (wd[5] == 1)
                        KeyboardPress(Key.KEY_E);
                    if (wu[5] == 1)
                        KeyboardRelease(Key.KEY_E);
                    valchanged(2, mWSNunchuckStateZ);
                    if (wd[2] == 1)
                        KeyboardPress(Key.KEY_LEFT_SHIFT);
                    if (wu[2] == 1)
                        KeyboardRelease(Key.KEY_LEFT_SHIFT);
                    valchanged(3, mWSNunchuckStateZ & mWSNunchuckStateC);
                    if (wd[3] == 1)
                        KeyboardPress(Key.KEY_LEFT_CTRL);
                    if (wu[3] == 1)
                        KeyboardRelease(Key.KEY_LEFT_CTRL);
                    valchanged(10, mWSNunchuckStateC);
                    if (wd[10] == 1)
                        KeyboardPress(Key.KEY_SPACE);
                    if (wu[10] == 1)
                        KeyboardRelease(Key.KEY_SPACE);
                    valchanged(4, (mWSNunchuckStateRawValuesY > 33f) & !(rolling <= -48f) & !(rolling >= 48f) & !((mWSRawValuesZ > 0 ? mWSRawValuesZ : -mWSRawValuesZ) >= 40f & (mWSRawValuesY > 0 ? mWSRawValuesY : -mWSRawValuesY) >= 40f & (mWSRawValuesX > 0 ? mWSRawValuesX : -mWSRawValuesX) >= 40f));
                    if (wd[4] == 1)
                        KeyboardPress(Key.KEY_V);
                    if (wu[4] == 1)
                        KeyboardRelease(Key.KEY_V);
                    valchanged(16, mWSNunchuckStateRawJoystickX > 33f);
                    valchanged(17, mWSNunchuckStateRawJoystickX < -33f);
                    valchanged(18, mWSNunchuckStateRawJoystickY > 33f);
                    valchanged(19, mWSNunchuckStateRawJoystickY < -33f);
                    if (wd[16] == 1)
                        KeyboardPress(Key.KEY_D);
                    if (wu[16] == 1)
                        KeyboardRelease(Key.KEY_D);
                    if (wd[17] == 1)
                        KeyboardPress(Key.KEY_Q);
                    if (wu[17] == 1)
                        KeyboardRelease(Key.KEY_Q);
                    if (wd[18] == 1)
                        KeyboardPress(Key.KEY_Z);
                    if (wu[18] == 1)
                        KeyboardRelease(Key.KEY_Z);
                    if (wd[19] == 1)
                        KeyboardPress(Key.KEY_S);
                    if (wu[19] == 1)
                        KeyboardRelease(Key.KEY_S);
                    valchanged(13, (mWSRawValuesZ > 0 ? mWSRawValuesZ : -mWSRawValuesZ) >= 30f & (mWSRawValuesY > 0 ? mWSRawValuesY : -mWSRawValuesY) >= 30f & (mWSRawValuesX > 0 ? mWSRawValuesX : -mWSRawValuesX) >= 30f);
                    if (wd[13] == 1)
                        KeyboardPress(Key.KEY_R);
                    if (wu[13] == 1)
                        KeyboardRelease(Key.KEY_R);
                    valchanged(20, mWSButtonStateOne);
                    if (wd[20] == 1)
                        KeyboardPress(Key.KEY_TAB);
                    if (wu[20] == 1)
                        KeyboardRelease(Key.KEY_TAB);
                    crouchcount = mWSButtonStateDown ? crouchcount + 1 : 0;
                    valchanged(21, crouchcount > 0 & crouchcount <= 30);
                    if (wd[21] == 1)
                        KeyboardPress(Key.KEY_C);
                    if (wu[21] == 1)
                        KeyboardRelease(Key.KEY_C);
                    valchanged(1, crouchcount > 30);
                    if (wd[1] == 1)
                        KeyboardPress(Key.KEY_LEFT_ALT);
                    if (wu[1] == 1)
                        KeyboardRelease(Key.KEY_LEFT_ALT);
                    valchanged(22, mWSButtonStateHome);
                    if (wd[22] == 1)
                        KeyboardPress(Key.KEY_F);
                    if (wu[22] == 1)
                        KeyboardRelease(Key.KEY_F);
                    valchanged(8, mWSButtonStateRight);
                    if (slowingright < 20f)
                    {
                        if (firstright & wd[8] == 1)
                        {
                            secondright = true;
                            firstright = false;
                        }
                    }
                    if (slowingright >= 20f)
                    {
                        if (wd[8] == 1)
                        {
                            slowingright = 0f;
                            firstright = true;
                        }
                        else
                            firstright = false;
                        secondright = false;
                    }
                    slowingright += 1f;
                    streakcount = secondright | streakcount > 0 ? streakcount + 1 : 0;
                    if (streakcount > 55)
                        streakcount = 0;
                    valchanged(23, (streakcount > 0 & streakcount <= 5) | (streakcount > 10 & streakcount <= 15) | (streakcount > 20 & streakcount <= 25) | (streakcount > 30 & streakcount <= 35) | (streakcount > 40 & streakcount <= 45) | (streakcount > 50 & streakcount <= 55));
                    if (wd[23] == 1)
                    {
                        if (keys123456 == 0)
                            KeyboardPress(Key.KEY_1);
                        if (keys123456 == 1)
                            KeyboardPress(Key.KEY_2);
                        if (keys123456 == 2)
                            KeyboardPress(Key.KEY_3);
                        if (keys123456 == 3)
                            KeyboardPress(Key.KEY_4);
                        if (keys123456 == 4)
                            KeyboardPress(Key.KEY_5);
                        if (keys123456 == 5)
                            KeyboardPress(Key.KEY_6);
                    }
                    if (wu[23] == 1)
                    {
                        if (keys123456 == 0)
                        {
                            KeyboardRelease(Key.KEY_1);
                            keys123456 = 1;
                        }
                        else
                            if (keys123456 == 1)
                        {
                            KeyboardRelease(Key.KEY_2);
                            keys123456 = 2;
                        }
                        else
                                if (keys123456 == 2)
                        {
                            KeyboardRelease(Key.KEY_3);
                            keys123456 = 3;
                        }
                        else
                        if (keys123456 == 3)
                        {
                            KeyboardRelease(Key.KEY_4);
                            keys123456 = 4;
                        }
                        else
                            if (keys123456 == 4)
                        {
                            KeyboardRelease(Key.KEY_5);
                            keys123456 = 5;
                        }
                        else
                                if (keys123456 == 5)
                        {
                            KeyboardRelease(Key.KEY_6);
                            keys123456 = 0;
                        }
                    }
                    valchanged(28, mWSButtonStateRight);
                    if (wd[28] == 1)
                        KeyboardPress(Key.KEY_U);
                    if (wu[28] == 1)
                        KeyboardRelease(Key.KEY_U);
                    valchanged(24, mWSButtonStateLeft);
                    if (wd[24] == 1)
                        KeyboardPress(Key.KEY_Y);
                    if (wu[24] == 1)
                        KeyboardRelease(Key.KEY_Y);
                    valchanged(25, mWSButtonStateUp);
                    if (wd[25] == 1)
                        KeyboardPress(Key.KEY_X);
                    if (wu[25] == 1)
                        KeyboardRelease(Key.KEY_X);
                    valchanged(26, mWSButtonStateTwo);
                    if (wd[26] == 1)
                        KeyboardPress(Key.KEY_ESC);
                    if (wu[26] == 1)
                        KeyboardRelease(Key.KEY_ESC);
                    valchanged(14, mWSButtonStatePlus);
                    if (wd[14] == 1)
                        KeyboardPress(Key.KEY_G);
                    if (wu[14] == 1)
                        KeyboardRelease(Key.KEY_G);
                    valchanged(15, mWSButtonStateMinus);
                    if (wd[15] == 1)
                        KeyboardPress(Key.KEY_T);
                    if (wu[15] == 1)
                        KeyboardRelease(Key.KEY_T);
                    valchanged(27, mWSButtonStateA);
                    if (wd[27] == 1)
                        MousePress(Key.MOUSE_RIGHT);
                    if (wu[27] == 1)
                        MouseRelease(Key.MOUSE_RIGHT);
                    valchanged(11, mWSButtonStateB);
                    if (wd[11] == 1)
                        MousePress(Key.MOUSE_LEFT);
                    if (wu[11] == 1)
                        MouseRelease(Key.MOUSE_LEFT);
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
                Port.Close();
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
        public unsafe static void Ping()
        {
            sendCommand(-1, 0, 0, 0, 0, 0);
        }
        public unsafe static void KeyboardPress(int Key)
        {
            sendCommand(1, Key, 0, 0, 0, 0);
        }
        public unsafe static void KeyboardRelease(int Key)
        {
            sendCommand(2, Key, 0, 0, 0, 0);
        }
        public unsafe static void MouseMove(int x, int y)
        {
            sendCommand(3, y, x, 0, 0, 0);
        }
        public unsafe static void MouseWheel(int x)
        {
            sendCommand(4, x, 0, 0, 0, 0);
        }
        public unsafe static void MousePress(int Key)
        {
            sendCommand(5, Key, 0, 0, 0, 0);
        }
        public unsafe static void MouseRelease(int Key)
        {
            sendCommand(6, Key, 0, 0, 0, 0);
        }
        public unsafe static void AbsMouseInit(int x, int y)
        {
            sendCommand(7, y, x, 0, 0, 0);
        }
        public unsafe static void AbsMouseMove(int x, int y)
        {
            sendCommand(8, y, x, 0, 0, 0);
        }
        private unsafe static void sendCommand(int d1, int d2, int d3, int d4, int d5, int d6)
        {
            Message_t msgOut = new Message_t();
            msgOut.Data.d1 = d1;
            msgOut.Data.d2 = d2;
            msgOut.Data.d3 = d3;
            msgOut.Data.d4 = d4;
            msgOut.Data.d5 = d5;
            msgOut.Data.d6 = d6;
            byte[] data = new byte[Marshal.SizeOf(typeof(Message_t))];
            fixed (byte* b = data)
                Marshal.StructureToPtr(msgOut, (IntPtr)b, true);
            Port.Write(data, 0, data.Length);
        }
        public class Key
        {
            public const int MOUSE_LEFT = 0;
            public const int MOUSE_RIGHT = 1;
            public const int MOUSE_MIDDLE = 2;
            public const int KEY_LEFT_CTRL = 3;
            public const int KEY_LEFT_SHIFT = 4;
            public const int KEY_LEFT_ALT = 5;
            public const int KEY_RIGHT_CTRL = 6;
            public const int KEY_RIGHT_SHIFT = 7;
            public const int KEY_RIGHT_ALT = 8;
            public const int KEY_UP_ARROW = 9;
            public const int KEY_DOWN_ARROW = 10;
            public const int KEY_LEFT_ARROW = 11;
            public const int KEY_RIGHT_ARROW = 12;
            public const int KEY_BACKSPACE = 13;
            public const int KEY_SPACE = 14;
            public const int KEY_TAB = 15;
            public const int KEY_RETURN = 16;
            public const int KEY_ESC = 17;
            public const int KEY_INSERT = 18;
            public const int KEY_DELETE = 19;
            public const int KEY_PAGE_UP = 20;
            public const int KEY_PAGE_DOWN = 21;
            public const int KEY_HOME = 22;
            public const int KEY_END = 23;
            public const int KEY_CAPS_LOCK = 24;
            public const int KEY_F1 = 25;
            public const int KEY_F2 = 26;
            public const int KEY_F3 = 27;
            public const int KEY_F4 = 28;
            public const int KEY_F5 = 29;
            public const int KEY_F6 = 30;
            public const int KEY_F7 = 31;
            public const int KEY_F8 = 32;
            public const int KEY_F9 = 33;
            public const int KEY_F10 = 34;
            public const int KEY_F11 = 35;
            public const int KEY_F12 = 36;
            public const int KEY_F13 = 37;
            public const int KEY_F14 = 38;
            public const int KEY_F15 = 39;
            public const int KEY_F16 = 40;
            public const int KEY_F17 = 41;
            public const int KEY_F18 = 42;
            public const int KEY_F19 = 43;
            public const int KEY_F20 = 44;
            public const int KEY_F21 = 45;
            public const int KEY_F22 = 46;
            public const int KEY_F23 = 47;
            public const int KEY_F24 = 48;
            public const int KEY_A = 49;
            public const int KEY_B = 50;
            public const int KEY_C = 51;
            public const int KEY_D = 52;
            public const int KEY_E = 53;
            public const int KEY_F = 54;
            public const int KEY_G = 55;
            public const int KEY_H = 56;
            public const int KEY_I = 57;
            public const int KEY_J = 58;
            public const int KEY_K = 59;
            public const int KEY_L = 60;
            public const int KEY_M = 61;
            public const int KEY_N = 62;
            public const int KEY_O = 63;
            public const int KEY_P = 64;
            public const int KEY_Q = 65;
            public const int KEY_R = 66;
            public const int KEY_S = 67;
            public const int KEY_T = 68;
            public const int KEY_U = 69;
            public const int KEY_V = 70;
            public const int KEY_W = 71;
            public const int KEY_X = 72;
            public const int KEY_Y = 73;
            public const int KEY_Z = 74;
            public const int KEY_1 = 75;
            public const int KEY_2 = 76;
            public const int KEY_3 = 77;
            public const int KEY_4 = 78;
            public const int KEY_5 = 79;
            public const int KEY_6 = 80;
            public const int KEY_7 = 81;
            public const int KEY_8 = 82;
            public const int KEY_9 = 83;
            public const int KEY_0 = 84;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct Data_t
        {
            public int d1;
            public int d2;
            public int d3;
            public int d4;
            public int d5;
            public int d6;
        }
        [StructLayout(LayoutKind.Explicit)]
        public unsafe struct Message_t
        {
            [FieldOffset(0)]
            public Data_t Data;
        }
    }
}