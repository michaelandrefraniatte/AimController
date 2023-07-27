using Microsoft.Win32.SafeHandles;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Numerics;
using System.IO.Ports;
namespace JoyWar
{
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);
        [DllImport("LeftJoyconPairing.dll", EntryPoint = "lconnect")]
        public static extern bool lconnect();
        [DllImport("RightJoyconPairing.dll", EntryPoint = "rconnect")]
        public static extern bool rconnect();
        [DllImport("LeftJoyconPairing.dll", EntryPoint = "disconnectLeft")]
        public static extern bool disconnectLeft();
        [DllImport("RightJoyconPairing.dll", EntryPoint = "disconnectRight")]
        public static extern bool disconnectRight();
        [DllImport("hid.dll")]
        public static extern void HidD_GetHidGuid(out Guid gHid);
        [DllImport("hid.dll")]
        public extern static bool HidD_SetOutputReport(IntPtr HidDeviceObject, byte[] lpReportBuffer, uint ReportBufferLength);
        [DllImport("setupapi.dll")]
        public static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, string Enumerator, IntPtr hwndParent, UInt32 Flags);
        [DllImport("setupapi.dll")]
        public static extern Boolean SetupDiEnumDeviceInterfaces(IntPtr hDevInfo, IntPtr devInvo, ref Guid interfaceClassGuid, Int32 memberIndex, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);
        [DllImport("setupapi.dll")]
        public static extern Boolean SetupDiGetDeviceInterfaceDetail(IntPtr hDevInfo, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData, IntPtr deviceInterfaceDetailData, UInt32 deviceInterfaceDetailDataSize, out UInt32 requiredSize, IntPtr deviceInfoData);
        [DllImport("setupapi.dll")]
        public static extern Boolean SetupDiGetDeviceInterfaceDetail(IntPtr hDevInfo, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData, ref SP_DEVICE_INTERFACE_DETAIL_DATA deviceInterfaceDetailData, UInt32 deviceInterfaceDetailDataSize, out UInt32 requiredSize, IntPtr deviceInfoData);
        [DllImport("Kernel32.dll")]
        public static extern IntPtr CreateFile(string fileName, System.IO.FileAccess fileAccess, System.IO.FileShare fileShare, IntPtr securityAttributes, System.IO.FileMode creationDisposition, EFileAttributes flags, IntPtr template);
        [DllImport("lhidread.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Lhid_read_timeout")]
        public static extern int Lhid_read_timeout(SafeFileHandle dev, byte[] data, UIntPtr length);
        [DllImport("lhidread.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Lhid_write")]
        public static extern int Lhid_write(SafeFileHandle device, byte[] data, UIntPtr length);
        [DllImport("lhidread.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Lhid_open_path")]
        public static extern SafeFileHandle Lhid_open_path(IntPtr handle);
        [DllImport("rhidread.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Rhid_read_timeout")]
        public static extern int Rhid_read_timeout(SafeFileHandle dev, byte[] data, UIntPtr length);
        [DllImport("rhidread.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Rhid_write")]
        public static extern int Rhid_write(SafeFileHandle device, byte[] data, UIntPtr length);
        [DllImport("rhidread.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Rhid_open_path")]
        public static extern SafeFileHandle Rhid_open_path(IntPtr handle);
        [DllImport("winmm.dll", EntryPoint = "timeBeginPeriod")]
        public static extern uint TimeBeginPeriod(uint ms);
        [DllImport("winmm.dll", EntryPoint = "timeEndPeriod")]
        public static extern uint TimeEndPeriod(uint ms);
        [DllImport("ntdll.dll", EntryPoint = "NtSetTimerResolution")]
        public static extern void NtSetTimerResolution(uint DesiredResolution, bool SetResolution, ref uint CurrentResolution);
        [DllImport("Kernel32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();
        [DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow([In] IntPtr hWnd, [In] Int32 nCmdShow);
        private const Int32 SW_MINIMIZE = 6;
        public static double mousex, mousey, irx, iry, zoningx = 100f, zoningy = 100f, Width, Height, WidthS, HeightS, incx, incy, inc;
        public static bool Getstate, ISLEFT, ISRIGHT, ApressIO = false, HomeFTG = false;
        public static Guid guid = new Guid();
        public static uint CurrentResolution = 0;
        static ConsoleEventDelegate handler;
        private delegate bool ConsoleEventDelegate(int eventType);
        public static ThreadStart threadstart;
        public static Thread thread;
        public unsafe static Teensy teensy = new Teensy(Message_t.MESSAGE_MAGIC);
        public static int[] wd = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        public static int[] wu = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        public unsafe static bool[] ws = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        static void valchanged(int n, bool val)
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
        static void Main(string[] args)
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
        public static void Start()
        {
            do
                Thread.Sleep(1);
            while (!lconnect());
            do
                Thread.Sleep(1);
            while (!rconnect());
            do
                Thread.Sleep(1);
            while (!ScanLeft());
            do
                Thread.Sleep(1);
            while (!ScanRight());
            Task.Run(() => taskDLeft());
            Task.Run(() => taskDRight());
            Thread.Sleep(2000);
            stick_rawLeft[0] = report_bufLeft[6 + (ISLEFT ? 0 : 3)];
            stick_rawLeft[1] = report_bufLeft[7 + (ISLEFT ? 0 : 3)];
            stick_rawLeft[2] = report_bufLeft[8 + (ISLEFT ? 0 : 3)];
            stick_calibrationLeft[0] = (UInt16)(stick_rawLeft[0] | ((stick_rawLeft[1] & 0xf) << 8));
            stick_calibrationLeft[1] = (UInt16)((stick_rawLeft[1] >> 4) | (stick_rawLeft[2] << 4));
            acc_gcalibrationLeftX = (int)(avg((Int16)(report_bufLeft[13 + 0 * 12] | ((report_bufLeft[14 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[13 + 1 * 12] | ((report_bufLeft[14 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[13 + 2 * 12] | ((report_bufLeft[14 + 2 * 12] << 8) & 0xff00)))) * (1.0f / 4000f);
            acc_gcalibrationLeftY = (int)(avg((Int16)(report_bufLeft[15 + 0 * 12] | ((report_bufLeft[16 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[15 + 1 * 12] | ((report_bufLeft[16 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[15 + 2 * 12] | ((report_bufLeft[16 + 2 * 12] << 8) & 0xff00)))) * (1.0f / 4000f);
            acc_gcalibrationLeftZ = (int)(avg((Int16)(report_bufLeft[17 + 0 * 12] | ((report_bufLeft[18 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[17 + 1 * 12] | ((report_bufLeft[18 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[17 + 2 * 12] | ((report_bufLeft[18 + 2 * 12] << 8) & 0xff00)))) * (1.0f / 4000f);
            gyr_gcalibrationLeftX = (int)(avg((int)((Int16)((report_bufLeft[19 + 0 * 12] | ((report_bufLeft[20 + 0 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufLeft[19 + 1 * 12] | ((report_bufLeft[20 + 1 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufLeft[19 + 2 * 12] | ((report_bufLeft[20 + 2 * 12] << 8) & 0xff00)))))) * (1.0f / 600000f);
            gyr_gcalibrationLeftY = (int)(avg((int)((Int16)((report_bufLeft[21 + 0 * 12] | ((report_bufLeft[22 + 0 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufLeft[21 + 1 * 12] | ((report_bufLeft[22 + 1 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufLeft[21 + 2 * 12] | ((report_bufLeft[22 + 2 * 12] << 8) & 0xff00)))))) * (1.0f / 600000f);
            gyr_gcalibrationLeftZ = (int)(avg((int)((Int16)((report_bufLeft[23 + 0 * 12] | ((report_bufLeft[24 + 0 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufLeft[23 + 1 * 12] | ((report_bufLeft[24 + 1 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufLeft[23 + 2 * 12] | ((report_bufLeft[24 + 2 * 12] << 8) & 0xff00)))))) * (1.0f / 600000f);
            stick_rawRight[0] = report_bufRight[6 + (!ISRIGHT ? 0 : 3)];
            stick_rawRight[1] = report_bufRight[7 + (!ISRIGHT ? 0 : 3)];
            stick_rawRight[2] = report_bufRight[8 + (!ISRIGHT ? 0 : 3)];
            stick_calibrationRight[0] = (UInt16)(stick_rawRight[0] | ((stick_rawRight[1] & 0xf) << 8));
            stick_calibrationRight[1] = (UInt16)((stick_rawRight[1] >> 4) | (stick_rawRight[2] << 4));
            acc_gcalibrationRightX = (int)(avg((Int16)(report_bufRight[13 + 0 * 12] | ((report_bufRight[14 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[13 + 1 * 12] | ((report_bufRight[14 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[13 + 2 * 12] | ((report_bufRight[14 + 2 * 12] << 8) & 0xff00)))) * (1.0f / 4000f);
            acc_gcalibrationRightY = -(int)(avg((Int16)(report_bufRight[15 + 0 * 12] | ((report_bufRight[16 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[15 + 1 * 12] | ((report_bufRight[16 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[15 + 2 * 12] | ((report_bufRight[16 + 2 * 12] << 8) & 0xff00)))) * (1.0f / 4000f);
            acc_gcalibrationRightZ = -(int)(avg((Int16)(report_bufRight[17 + 0 * 12] | ((report_bufRight[18 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[17 + 1 * 12] | ((report_bufRight[18 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[17 + 2 * 12] | ((report_bufRight[18 + 2 * 12] << 8) & 0xff00)))) * (1.0f / 4000f);
            gyr_gcalibrationRightX = (int)(avg((int)((Int16)((report_bufRight[19 + 0 * 12] | ((report_bufRight[20 + 0 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufRight[19 + 1 * 12] | ((report_bufRight[20 + 1 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufRight[19 + 2 * 12] | ((report_bufRight[20 + 2 * 12] << 8) & 0xff00)))))) * (1.0f / 600000f);
            gyr_gcalibrationRightY = -(int)(avg((int)((Int16)((report_bufRight[21 + 0 * 12] | ((report_bufRight[22 + 0 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufRight[21 + 1 * 12] | ((report_bufRight[22 + 1 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufRight[21 + 2 * 12] | ((report_bufRight[22 + 2 * 12] << 8) & 0xff00)))))) * (1.0f / 600000f);
            gyr_gcalibrationRightZ = -(int)(avg((int)((Int16)((report_bufRight[23 + 0 * 12] | ((report_bufRight[24 + 0 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufRight[23 + 1 * 12] | ((report_bufRight[24 + 1 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufRight[23 + 2 * 12] | ((report_bufRight[24 + 2 * 12] << 8) & 0xff00)))))) * (1.0f / 600000f);
            Task.Run(() => taskILeft());
            Task.Run(() => taskIRight());
            Task.Run(() => taskK());
            Task.Run(() => taskM());
            teensy.Ping();
            do
                Thread.Sleep(1);
            while (teensy.Pong() != 10);
            System.Media.SystemSounds.Beep.Play();
            Console.WriteLine("connected");
        }
        public static void taskM()
        {
            for (; ; )
            {
                if (Getstate)
                {
                    irx = -EulerAnglesRight.X * 1360f / 0.06f;
                    iry = -EulerAnglesRight.Z * 768f / 0.04f;
                    if (irx >= 1360f)
                        irx = 1360f;
                    if (irx <= -1360f)
                        irx = -1360f;
                    if (iry >= 768f)
                        iry = 768f;
                    if (iry <= -768f)
                        iry = -768f;
                    mousex = (irx > 0 ? 1f : -1f) * (Math.Pow(irx > 0 ? irx : -irx, 3f) / Math.Pow(1360f, 2f));
                    mousey = (iry > 0 ? 1f : -1f) * (Math.Pow(iry > 0 ? iry : -iry, 3f) / Math.Pow(768f, 2f));
                    if (irx == 1360f | irx == -1360f | iry == 768f | iry == -768f)
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
                        teensy.MouseMoveTo((int)(WidthS - mousex * (WidthS - incx) / 1360f), (int)(HeightS + mousey * (HeightS - incy) / 768f));
                    }
                    else
                        teensy.MouseMoveTo((int)(WidthS - mousex * WidthS / 1360f), (int)(HeightS + mousey * HeightS / 768f));
                }
                Thread.Sleep(4);
            }
        }
        public static void taskK()
        {
            for (; ; )
            {
                try
                {
                    ProcessButtonsAndStickLeft();
                }
                catch { }
                try
                {
                    ProcessButtonsAndStickRight();
                }
                catch { }
                valchanged(0, LeftButtonCAPTURE & RightButtonHOME);
                if (wd[0] == 1 & !Getstate)
                {
                    Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                    Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
                    WidthS = Width / 2f;
                    HeightS = Height / 2f;
                    teensy.MouseSetScreenSize((int)Width, (int)Height);
                    Getstate = true;
                }
                else
                {
                    if (wd[0] == 1 & Getstate)
                    {
                        Getstate = false;
                        for (int i = 1; i <= 38; i++)
                        {
                            wd[i] = 2;
                            wu[i] = 2;
                            Thread.Sleep(1);
                        }
                        teensy.KeyboardRelease(Keylayout.KEY_A);
                        teensy.KeyboardRelease(Keylayout.KEY_E);
                        teensy.KeyboardRelease(Keylayout.KEY_V);
                        teensy.KeyboardRelease(Keylayout.KEY_F);
                        teensy.KeyboardRelease(Keylayout.KEY_ESC);
                    }
                }
                if (Getstate)
                {
                    valchanged(5, LeftButtonDPAD_UP);
                    if (wd[5] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_7);
                    if (wu[5] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_7);
                    valchanged(6, LeftButtonDPAD_LEFT);
                    if (wd[6] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_8);
                    if (wu[6] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_8);
                    valchanged(7, LeftButtonDPAD_DOWN);
                    if (wd[7] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_9);
                    if (wu[7] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_9);
                    valchanged(8, LeftButtonDPAD_RIGHT);
                    if (wd[8] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_0);
                    if (wu[8] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_0);
                    valchanged(3, LeftButtonMINUS);
                    if (wd[3] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_T);
                    if (wu[3] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_T);
                    valchanged(27, LeftButtonCAPTURE);
                    if (wd[27] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_ESC);
                    if (wu[27] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_ESC);
                    valchanged(9, LeftButtonSTICK);
                    if (wd[9] == 1)
                        teensy.KeyboardPress(Keylayout.MODIFIERKEY_LEFT_SHIFT);
                    if (wu[9] == 1)
                        teensy.KeyboardRelease(Keylayout.MODIFIERKEY_LEFT_SHIFT);
                    valchanged(29, LeftButtonSL);
                    if (wd[29] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_A);
                    if (wu[29] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_A);
                    valchanged(28, LeftButtonSR);
                    if (wd[28] == 1)
                        teensy.KeyboardPress(Keylayout.MODIFIERKEY_LEFT_ALT);
                    if (wu[28] == 1)
                        teensy.KeyboardRelease(Keylayout.MODIFIERKEY_LEFT_ALT);
                    valchanged(2, LeftButtonSHOULDER_1);
                    if (wd[2] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_SPACE);
                    if (wu[2] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_SPACE);
                    valchanged(24, LeftButtonSHOULDER_2);
                    if (wd[24] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_1);
                    if (wu[24] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_1);
                    valchanged(16, GetStickLeft()[0] > 0.25f);
                    valchanged(17, GetStickLeft()[0] < -0.25f);
                    valchanged(18, GetStickLeft()[1] > 0.25f);
                    valchanged(19, GetStickLeft()[1] < -0.25f);
                    if (wd[16] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_D);
                    if (wu[16] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_D);
                    if (wd[17] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_Q);
                    if (wu[17] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_Q);
                    if (wd[18] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_Z);
                    if (wu[18] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_Z);
                    if (wd[19] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_S);
                    if (wu[19] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_S);
                    valchanged(10, RightButtonDPAD_DOWN);
                    if (wd[10] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_C);
                    if (wu[10] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_C);
                    valchanged(21, RightButtonDPAD_RIGHT);
                    if (wd[21] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_2);
                    if (wu[21] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_2);
                    valchanged(33, RightButtonDPAD_LEFT);
                    if (wd[33] == 1)
                    {
                        if (ws[11])
                            teensy.MouseSetButtons(1, 0, 1);
                        else
                            teensy.MouseSetButtons(0, 0, 1);
                    }
                    if (wu[33] == 1)
                    {
                        if (ws[11])
                            teensy.MouseSetButtons(1, 0, 0);
                        else
                            teensy.MouseSetButtons(0, 0, 0);
                    }
                    valchanged(25, RightButtonDPAD_UP);
                    if (wd[25] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_X);
                    if (wu[25] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_X);
                    valchanged(20, RightButtonPLUS);
                    if (wd[20] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_G);
                    if (wu[20] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_G);
                    valchanged(22, RightButtonHOME);
                    if (wd[22] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_F);
                    if (wu[22] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_F);
                    valchanged(26, RightButtonSTICK);
                    if (wd[26] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_V);
                    if (wu[26] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_V);
                    valchanged(14, RightButtonSL);
                    if (wd[14] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_TAB);
                    if (wu[14] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_TAB);
                    valchanged(15, RightButtonSR);
                    if (wd[15] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_E);
                    if (wu[15] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_E);
                    valchanged(23, RightButtonSHOULDER_1);
                    if (wd[23] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_V);
                    if (wu[23] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_V);
                    valchanged(11, RightButtonSHOULDER_2);
                    if (wd[11] == 1)
                    {
                        if (ws[33])
                            teensy.MouseSetButtons(1, 0, 1);
                        else
                            teensy.MouseSetButtons(1, 0, 0);
                    }
                    if (wu[11] == 1)
                    {
                        if (ws[33])
                            teensy.MouseSetButtons(0, 0, 1);
                        else
                            teensy.MouseSetButtons(0, 0, 0);
                    }
                    valchanged(35, GetStickRight()[0] > 0.25f);
                    valchanged(36, GetStickRight()[0] < -0.25f);
                    valchanged(37, GetStickRight()[1] > 0.25f);
                    valchanged(38, GetStickRight()[1] < -0.25f);
                    if (wd[35] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_5);
                    if (wu[35] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_5);
                    if (wd[36] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_6);
                    if (wu[36] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_6);
                    if (wd[37] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_3);
                    if (wu[37] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_3);
                    if (wd[38] == 1)
                        teensy.KeyboardPress(Keylayout.KEY_4);
                    if (wu[38] == 1)
                        teensy.KeyboardRelease(Keylayout.KEY_4);
                }
                Thread.Sleep(10);
            }
        }
        public static void taskILeft()
        {
            for (; ; )
            {
                try
                {
                    ExtractIMUValuesLeft();
                }
                catch { }
                Thread.Sleep(12);
            }
        }
        public static void taskIRight()
        {
            for (; ; )
            {
                try
                {
                    ExtractIMUValuesRight();
                }
                catch { }
                Thread.Sleep(12);
            }
        }
        public static void taskDLeft()
        {
            for (; ; )
            {
                try
                {
                    Lhid_read_timeout(handleLeft, report_bufLeft, (UIntPtr)49);
                }
                catch { }
            }
        }
        public static void taskDRight()
        {
            for (; ; )
            {
                try
                {
                    Rhid_read_timeout(handleRight, report_bufRight, (UIntPtr)49);
                }
                catch { }
            }
        }
        private static double avg(double val1, double val2, double val3)
        {
            return (new double[] { val1, val2, val3 }).Average();
        }
        private unsafe static void MinimizeConsoleWindow()
        {
            IntPtr hWndConsole = GetConsoleWindow();
            ShowWindow(hWndConsole, SW_MINIMIZE);
        }
        static bool ConsoleEventCallback(int eventType)
        {
            if (eventType == 2)
            {
                TimeEndPeriod(1);
                threadstart = new ThreadStart(FormCloseLeft);
                thread = new Thread(threadstart);
                thread.Start();
                threadstart = new ThreadStart(FormCloseRight);
                thread = new Thread(threadstart);
                thread.Start();
                Thread.Sleep(10000);
            }
            return false;
        }
        private static void FormCloseLeft()
        {
            disconnectLeft();
        }
        private static void FormCloseRight()
        {
            disconnectRight();
        }
        public static Quaternion GetVectoraLeft()
        {
            Vector3 v1 = new Vector3(j_aLeft.X, i_aLeft.X, k_aLeft.X);
            Vector3 v2 = -(new Vector3(j_aLeft.Z, i_aLeft.Z, k_aLeft.Z));
            return QuaternionLookRotationLeft(v1, v2);
        }
        public static Quaternion GetVectorbLeft()
        {
            Vector3 v1 = new Vector3(j_bLeft.X, i_bLeft.X, k_bLeft.X);
            Vector3 v2 = -(new Vector3(j_bLeft.Z, i_bLeft.Z, k_bLeft.Z));
            return QuaternionLookRotationLeft(v1, v2);
        }
        public static Quaternion GetVectorcLeft()
        {
            Vector3 v1 = new Vector3(j_cLeft.X, i_cLeft.X, k_cLeft.X);
            Vector3 v2 = -(new Vector3(j_cLeft.Z, i_cLeft.Z, k_cLeft.Z));
            return QuaternionLookRotationLeft(v1, v2);
        }
        private static Quaternion QuaternionLookRotationLeft(Vector3 forward, Vector3 up)
        {
            Vector3 vector = Vector3.Normalize(forward);
            Vector3 vector2 = Vector3.Normalize(Vector3.Cross(up, vector));
            Vector3 vector3 = Vector3.Cross(vector, vector2);
            var m00 = vector2.X;
            var m01 = vector2.Y;
            var m02 = vector2.Z;
            var m10 = vector3.X;
            var m11 = vector3.Y;
            var m12 = vector3.Z;
            var m20 = vector.X;
            var m21 = vector.Y;
            var m22 = vector.Z;
            double num8 = (m00 + m11) + m22;
            var quaternion = new Quaternion();
            if (num8 > 0f)
            {
                var num = (double)Math.Sqrt(num8 + 1f);
                quaternion.W = (float)num * 0.5f;
                num = 0.5f / num;
                quaternion.X = (float)(m12 - m21) * (float)num;
                quaternion.Y = (float)(m20 - m02) * (float)num;
                quaternion.Z = (float)(m01 - m10) * (float)num;
                return quaternion;
            }
            if ((m00 >= m11) && (m00 >= m22))
            {
                var num7 = (double)Math.Sqrt(((1f + m00) - m11) - m22);
                var num4 = 0.5f / num7;
                quaternion.X = 0.5f * (float)num7;
                quaternion.Y = (float)(m01 + m10) * (float)num4;
                quaternion.Z = (float)(m02 + m20) * (float)num4;
                quaternion.W = (float)(m12 - m21) * (float)num4;
                return quaternion;
            }
            if (m11 > m22)
            {
                var num6 = (double)Math.Sqrt(((1f + m11) - m00) - m22);
                var num3 = 0.5f / num6;
                quaternion.X = (float)(m10 + m01) * (float)num3;
                quaternion.Y = 0.5f * (float)num6;
                quaternion.Z = (float)(m21 + m12) * (float)num3;
                quaternion.W = (float)(m20 - m02) * (float)num3;
                return quaternion;
            }
            var num5 = (double)Math.Sqrt(((1f + m22) - m00) - m11);
            var num2 = 0.5f / num5;
            quaternion.X = (float)(m20 + m02) * (float)num2;
            quaternion.Y = (float)(m21 + m12) * (float)num2;
            quaternion.Z = 0.5f * (float)num5;
            quaternion.W = (float)(m01 - m10) * (float)num2;
            return quaternion;
        }
        public static Vector3 ToEulerAnglesLeft(Quaternion q)
        {
            Vector3 pitchYawRoll = new Vector3();
            double sqw = q.W * q.W;
            double sqx = q.X * q.X;
            double sqy = q.Y * q.Y;
            double sqz = q.Z * q.Z;
            double unit = sqx + sqy + sqz + sqw;
            double test = q.X * q.Y + q.Z * q.W;
            if (test > 0.4999f * unit)                              // 0.4999f OR 0.5f - EPSILON
            {
                pitchYawRoll.Y = 2f * (float)Math.Atan2(q.X, q.W);  // Yaw
                pitchYawRoll.X = (float)Math.PI * 0.5f;                         // Pitch
                pitchYawRoll.Z = 0f;                                // Roll
                return pitchYawRoll;
            }
            else if (test < -0.4999f * unit)                        // -0.4999f OR -0.5f + EPSILON
            {
                pitchYawRoll.Y = -2f * (float)Math.Atan2(q.X, q.W); // Yaw
                pitchYawRoll.X = -(float)Math.PI * 0.5f;                        // Pitch
                pitchYawRoll.Z = 0f;                                // Roll
                return pitchYawRoll;
            }
            else
            {
                pitchYawRoll.Y = (float)Math.Atan2(2f * q.Y * q.W - 2f * q.X * q.Z, sqx - sqy - sqz + sqw);       // Yaw
                pitchYawRoll.X = (float)Math.Asin(2f * test / unit);                                             // Pitch
                pitchYawRoll.Z = (float)Math.Atan2(2f * q.X * q.W - 2f * q.Y * q.Z, -sqx + sqy - sqz + sqw);      // Roll
            }
            return pitchYawRoll;
        }
        private static void ProcessButtonsAndStickLeft()
        {
            LeftButtonSHOULDER_1 = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & 0x40) != 0;
            LeftButtonSHOULDER_2 = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & 0x80) != 0;
            LeftButtonSR = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & 0x10) != 0;
            LeftButtonSL = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & 0x20) != 0;
            LeftButtonDPAD_DOWN = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & (ISLEFT ? 0x01 : 0x04)) != 0;
            LeftButtonDPAD_RIGHT = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & (ISLEFT ? 0x04 : 0x08)) != 0;
            LeftButtonDPAD_UP = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & (ISLEFT ? 0x02 : 0x02)) != 0;
            LeftButtonDPAD_LEFT = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & (ISLEFT ? 0x08 : 0x01)) != 0;
            LeftButtonMINUS = ((report_bufLeft[4] & 0x01) != 0);
            LeftButtonCAPTURE = ((report_bufLeft[4] & 0x20) != 0);
            LeftButtonSTICK = ((report_bufLeft[4] & (ISLEFT ? 0x08 : 0x04)) != 0);
            stick_rawLeft[0] = report_bufLeft[6 + (ISLEFT ? 0 : 3)];
            stick_rawLeft[1] = report_bufLeft[7 + (ISLEFT ? 0 : 3)];
            stick_rawLeft[2] = report_bufLeft[8 + (ISLEFT ? 0 : 3)];
            stick_precalLeft[0] = (UInt16)(stick_rawLeft[0] | ((stick_rawLeft[1] & 0xf) << 8));
            stick_precalLeft[1] = (UInt16)((stick_rawLeft[1] >> 4) | (stick_rawLeft[2] << 4));
            stickLeft = CenterSticksLeft(stick_precalLeft);
        }
        private static void ExtractIMUValuesLeft()
        {
            acc_gLeft.X = (int)(averageLeft((Int16)(report_bufLeft[13 + 0 * 12] | ((report_bufLeft[14 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[13 + 1 * 12] | ((report_bufLeft[14 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[13 + 2 * 12] | ((report_bufLeft[14 + 2 * 12] << 8) & 0xff00)))) * (1.0f / 4000f) - acc_gcalibrationLeftX;
            acc_gLeft.Y = (int)(averageLeft((Int16)(report_bufLeft[15 + 0 * 12] | ((report_bufLeft[16 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[15 + 1 * 12] | ((report_bufLeft[16 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[15 + 2 * 12] | ((report_bufLeft[16 + 2 * 12] << 8) & 0xff00)))) * (1.0f / 4000f) - acc_gcalibrationLeftY;
            acc_gLeft.Z = (int)(averageLeft((Int16)(report_bufLeft[17 + 0 * 12] | ((report_bufLeft[18 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[17 + 1 * 12] | ((report_bufLeft[18 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufLeft[17 + 2 * 12] | ((report_bufLeft[18 + 2 * 12] << 8) & 0xff00)))) * (1.0f / 4000f) - acc_gcalibrationLeftZ;
            gyr_gLeft.X = (int)(averageLeft((int)((Int16)((report_bufLeft[19 + 0 * 12] | ((report_bufLeft[20 + 0 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufLeft[19 + 1 * 12] | ((report_bufLeft[20 + 1 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufLeft[19 + 2 * 12] | ((report_bufLeft[20 + 2 * 12] << 8) & 0xff00)))))) * (1.0f / 600000f) - gyr_gcalibrationLeftX;
            gyr_gLeft.Y = (int)(averageLeft((int)((Int16)((report_bufLeft[21 + 0 * 12] | ((report_bufLeft[22 + 0 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufLeft[21 + 1 * 12] | ((report_bufLeft[22 + 1 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufLeft[21 + 2 * 12] | ((report_bufLeft[22 + 2 * 12] << 8) & 0xff00)))))) * (1.0f / 600000f) - gyr_gcalibrationLeftY;
            gyr_gLeft.Z = (int)(averageLeft((int)((Int16)((report_bufLeft[23 + 0 * 12] | ((report_bufLeft[24 + 0 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufLeft[23 + 1 * 12] | ((report_bufLeft[24 + 1 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufLeft[23 + 2 * 12] | ((report_bufLeft[24 + 2 * 12] << 8) & 0xff00)))))) * (1.0f / 600000f) - gyr_gcalibrationLeftZ;
            if (!Getstate)
                InitDirectAnglesLeft = acc_gLeft;
            DirectAnglesLeft = acc_gLeft - InitDirectAnglesLeft;
            i_cLeft = new Vector3(1, 0, 0);
            k_cLeft = new Vector3(0, 0, 1);
            j_cLeft.X = 0f;
            j_cLeft.Y = 1f;
            i_bLeft = new Vector3(1, 0, 0);
            k_bLeft = new Vector3(0, 0, 1);
            j_bLeft.Y = 1f;
            j_bLeft.Z = 0f;
            i_aLeft = new Vector3(1, 0, 0);
            j_aLeft = new Vector3(0, 1, 0);
            k_aLeft.Y = 0f;
            k_aLeft.Z = 1f;
            if (EulerAnglescLeft.Y == 0f)
                j_cLeft = new Vector3(0, 1, 0);
            if (EulerAnglesbLeft.X == 0f)
                j_bLeft = new Vector3(0, 1, 0);
            if (EulerAnglesaLeft.Z == 0f)
                k_aLeft = new Vector3(0, 0, 1);
            if (!Getstate | LeftButtonCAPTURE)
            {
                j_cLeft = new Vector3(0, 1, 0);
                InitEulerAnglescLeft = ToEulerAnglesLeft(GetVectorcLeft());
                j_bLeft = new Vector3(0, 1, 0);
                InitEulerAnglesbLeft = ToEulerAnglesLeft(GetVectorbLeft());
                k_aLeft = new Vector3(0, 0, 1);
                InitEulerAnglesaLeft = ToEulerAnglesLeft(GetVectoraLeft());
            }
            j_cLeft += Vector3.Cross(Vector3.Negate(gyr_gLeft), j_cLeft);
            j_cLeft = Vector3.Normalize(j_cLeft);
            EulerAnglescLeft = ToEulerAnglesLeft(GetVectorcLeft()) - InitEulerAnglescLeft;
            j_bLeft += Vector3.Cross(Vector3.Negate(gyr_gLeft), j_bLeft);
            j_bLeft = Vector3.Normalize(j_bLeft);
            EulerAnglesbLeft = ToEulerAnglesLeft(GetVectorbLeft()) - InitEulerAnglesbLeft;
            k_aLeft += Vector3.Cross(Vector3.Negate(gyr_gLeft), k_aLeft);
            k_aLeft = Vector3.Normalize(k_aLeft);
            EulerAnglesaLeft = ToEulerAnglesLeft(GetVectoraLeft()) - InitEulerAnglesaLeft;
            EulerAnglesLeft = new Vector3(EulerAnglesbLeft.X, EulerAnglescLeft.Y, EulerAnglesaLeft.Z);
        }
        private static double averageLeft(double val1, double val2, double val3)
        {
            arrayLeft = new double[] { val1, val2, val3 };
            return arrayLeft.Average();
        }
        private static double[] CenterSticksLeft(UInt16[] vals)
        {
            double[] s = { 0, 0 };
            s[0] = ((int)((vals[0] - stick_calibrationLeft[0]) / 100f)) / 13f;
            s[1] = ((int)((vals[1] - stick_calibrationLeft[1]) / 100f)) / 13f;
            return s;
        }
        public static Quaternion GetVectoraRight()
        {
            Vector3 v1 = new Vector3(j_aRight.X, i_aRight.X, k_aRight.X);
            Vector3 v2 = -(new Vector3(j_aRight.Z, i_aRight.Z, k_aRight.Z));
            return QuaternionLookRotationRight(v1, v2);
        }
        public static Quaternion GetVectorbRight()
        {
            Vector3 v1 = new Vector3(j_bRight.X, i_bRight.X, k_bRight.X);
            Vector3 v2 = -(new Vector3(j_bRight.Z, i_bRight.Z, k_bRight.Z));
            return QuaternionLookRotationRight(v1, v2);
        }
        public static Quaternion GetVectorcRight()
        {
            Vector3 v1 = new Vector3(j_cRight.X, i_cRight.X, k_cRight.X);
            Vector3 v2 = -(new Vector3(j_cRight.Z, i_cRight.Z, k_cRight.Z));
            return QuaternionLookRotationRight(v1, v2);
        }
        private static Quaternion QuaternionLookRotationRight(Vector3 forward, Vector3 up)
        {
            Vector3 vector = Vector3.Normalize(forward);
            Vector3 vector2 = Vector3.Normalize(Vector3.Cross(up, vector));
            Vector3 vector3 = Vector3.Cross(vector, vector2);
            var m00 = vector2.X;
            var m01 = vector2.Y;
            var m02 = vector2.Z;
            var m10 = vector3.X;
            var m11 = vector3.Y;
            var m12 = vector3.Z;
            var m20 = vector.X;
            var m21 = vector.Y;
            var m22 = vector.Z;
            double num8 = (m00 + m11) + m22;
            var quaternion = new Quaternion();
            if (num8 > 0f)
            {
                var num = (double)Math.Sqrt(num8 + 1f);
                quaternion.W = (float)num * 0.5f;
                num = 0.5f / num;
                quaternion.X = (float)(m12 - m21) * (float)num;
                quaternion.Y = (float)(m20 - m02) * (float)num;
                quaternion.Z = (float)(m01 - m10) * (float)num;
                return quaternion;
            }
            if ((m00 >= m11) && (m00 >= m22))
            {
                var num7 = (double)Math.Sqrt(((1f + m00) - m11) - m22);
                var num4 = 0.5f / num7;
                quaternion.X = 0.5f * (float)num7;
                quaternion.Y = (float)(m01 + m10) * (float)num4;
                quaternion.Z = (float)(m02 + m20) * (float)num4;
                quaternion.W = (float)(m12 - m21) * (float)num4;
                return quaternion;
            }
            if (m11 > m22)
            {
                var num6 = (double)Math.Sqrt(((1f + m11) - m00) - m22);
                var num3 = 0.5f / num6;
                quaternion.X = (float)(m10 + m01) * (float)num3;
                quaternion.Y = 0.5f * (float)num6;
                quaternion.Z = (float)(m21 + m12) * (float)num3;
                quaternion.W = (float)(m20 - m02) * (float)num3;
                return quaternion;
            }
            var num5 = (double)Math.Sqrt(((1f + m22) - m00) - m11);
            var num2 = 0.5f / num5;
            quaternion.X = (float)(m20 + m02) * (float)num2;
            quaternion.Y = (float)(m21 + m12) * (float)num2;
            quaternion.Z = 0.5f * (float)num5;
            quaternion.W = (float)(m01 - m10) * (float)num2;
            return quaternion;
        }
        public static Vector3 ToEulerAnglesRight(Quaternion q)
        {
            Vector3 pitchYawRoll = new Vector3();
            double sqw = q.W * q.W;
            double sqx = q.X * q.X;
            double sqy = q.Y * q.Y;
            double sqz = q.Z * q.Z;
            double unit = sqx + sqy + sqz + sqw;
            double test = q.X * q.Y + q.Z * q.W;
            if (test > 0.4999f * unit)                              // 0.4999f OR 0.5f - EPSILON
            {
                pitchYawRoll.Y = 2f * (float)Math.Atan2(q.X, q.W);  // Yaw
                pitchYawRoll.X = (float)Math.PI * 0.5f;                         // Pitch
                pitchYawRoll.Z = 0f;                                // Roll
                return pitchYawRoll;
            }
            else if (test < -0.4999f * unit)                        // -0.4999f OR -0.5f + EPSILON
            {
                pitchYawRoll.Y = -2f * (float)Math.Atan2(q.X, q.W); // Yaw
                pitchYawRoll.X = -(float)Math.PI * 0.5f;                        // Pitch
                pitchYawRoll.Z = 0f;                                // Roll
                return pitchYawRoll;
            }
            else
            {
                pitchYawRoll.Y = (float)Math.Atan2(2f * q.Y * q.W - 2f * q.X * q.Z, sqx - sqy - sqz + sqw);       // Yaw
                pitchYawRoll.X = (float)Math.Asin(2f * test / unit);                                             // Pitch
                pitchYawRoll.Z = (float)Math.Atan2(2f * q.X * q.W - 2f * q.Y * q.Z, -sqx + sqy - sqz + sqw);      // Roll
            }
            return pitchYawRoll;
        }
        public static void ProcessButtonsAndStickRight()
        {
            RightButtonSHOULDER_1 = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & 0x40) != 0;
            RightButtonSHOULDER_2 = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & 0x80) != 0;
            RightButtonSR = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & 0x10) != 0;
            RightButtonSL = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & 0x20) != 0;
            RightButtonDPAD_DOWN = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & (!ISRIGHT ? 0x01 : 0x04)) != 0;
            RightButtonDPAD_RIGHT = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & (!ISRIGHT ? 0x04 : 0x08)) != 0;
            RightButtonDPAD_UP = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & (!ISRIGHT ? 0x02 : 0x02)) != 0;
            RightButtonDPAD_LEFT = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & (!ISRIGHT ? 0x08 : 0x01)) != 0;
            RightButtonPLUS = ((report_bufRight[4] & 0x02) != 0);
            RightButtonHOME = ((report_bufRight[4] & 0x10) != 0);
            RightButtonSTICK = ((report_bufRight[4] & (!ISRIGHT ? 0x08 : 0x04)) != 0);
            stick_rawRight[0] = report_bufRight[6 + (!ISRIGHT ? 0 : 3)];
            stick_rawRight[1] = report_bufRight[7 + (!ISRIGHT ? 0 : 3)];
            stick_rawRight[2] = report_bufRight[8 + (!ISRIGHT ? 0 : 3)];
            stick_precalRight[0] = (UInt16)(stick_rawRight[0] | ((stick_rawRight[1] & 0xf) << 8));
            stick_precalRight[1] = (UInt16)((stick_rawRight[1] >> 4) | (stick_rawRight[2] << 4));
            stickRight = CenterSticksRight(stick_precalRight);
        }
        private static void ExtractIMUValuesRight()
        {
            acc_gRight.X = (int)(averageRight((Int16)(report_bufRight[13 + 0 * 12] | ((report_bufRight[14 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[13 + 1 * 12] | ((report_bufRight[14 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[13 + 2 * 12] | ((report_bufRight[14 + 2 * 12] << 8) & 0xff00)))) * (1.0f / 4000f) - acc_gcalibrationRightX;
            acc_gRight.Y = -(int)(averageRight((Int16)(report_bufRight[15 + 0 * 12] | ((report_bufRight[16 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[15 + 1 * 12] | ((report_bufRight[16 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[15 + 2 * 12] | ((report_bufRight[16 + 2 * 12] << 8) & 0xff00)))) * (1.0f / 4000f) - acc_gcalibrationRightY;
            acc_gRight.Z = -(int)(averageRight((Int16)(report_bufRight[17 + 0 * 12] | ((report_bufRight[18 + 0 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[17 + 1 * 12] | ((report_bufRight[18 + 1 * 12] << 8) & 0xff00)), (Int16)(report_bufRight[17 + 2 * 12] | ((report_bufRight[18 + 2 * 12] << 8) & 0xff00)))) * (1.0f / 4000f) - acc_gcalibrationRightZ;
            gyr_gRight.X = (int)(averageRight((int)((Int16)((report_bufRight[19 + 0 * 12] | ((report_bufRight[20 + 0 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufRight[19 + 1 * 12] | ((report_bufRight[20 + 1 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufRight[19 + 2 * 12] | ((report_bufRight[20 + 2 * 12] << 8) & 0xff00)))))) * (1.0f / 600000f) - gyr_gcalibrationRightX;
            gyr_gRight.Y = -(int)(averageRight((int)((Int16)((report_bufRight[21 + 0 * 12] | ((report_bufRight[22 + 0 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufRight[21 + 1 * 12] | ((report_bufRight[22 + 1 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufRight[21 + 2 * 12] | ((report_bufRight[22 + 2 * 12] << 8) & 0xff00)))))) * (1.0f / 600000f) - gyr_gcalibrationRightY;
            gyr_gRight.Z = -(int)(averageRight((int)((Int16)((report_bufRight[23 + 0 * 12] | ((report_bufRight[24 + 0 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufRight[23 + 1 * 12] | ((report_bufRight[24 + 1 * 12] << 8) & 0xff00)))), (int)((Int16)((report_bufRight[23 + 2 * 12] | ((report_bufRight[24 + 2 * 12] << 8) & 0xff00)))))) * (1.0f / 600000f) - gyr_gcalibrationRightZ;
            if (!Getstate)
                InitDirectAnglesRight = acc_gRight;
            DirectAnglesRight = acc_gRight - InitDirectAnglesRight;
            i_cRight = new Vector3(1, 0, 0);
            k_cRight = new Vector3(0, 0, 1);
            j_cRight.X = 0f;
            j_cRight.Y = 1f;
            i_bRight = new Vector3(1, 0, 0);
            k_bRight = new Vector3(0, 0, 1);
            j_bRight.Y = 1f;
            j_bRight.Z = 0f;
            i_aRight = new Vector3(1, 0, 0);
            j_aRight = new Vector3(0, 1, 0);
            k_aRight.Y = 0f;
            k_aRight.Z = 1f;
            if (EulerAnglescRight.Y == 0f)
                j_cRight = new Vector3(0, 1, 0);
            if (EulerAnglesbRight.X == 0f)
                j_bRight = new Vector3(0, 1, 0);
            if (EulerAnglesaRight.Z == 0f)
                k_aRight = new Vector3(0, 0, 1);
            if (!Getstate | RightButtonHOME)
            {
                j_cRight = new Vector3(0, 1, 0);
                InitEulerAnglescRight = ToEulerAnglesRight(GetVectorcRight());
                j_bRight = new Vector3(0, 1, 0);
                InitEulerAnglesbRight = ToEulerAnglesRight(GetVectorbRight());
                k_aRight = new Vector3(0, 0, 1);
                InitEulerAnglesaRight = ToEulerAnglesRight(GetVectoraRight());
            }
            j_cRight += Vector3.Cross(Vector3.Negate(gyr_gRight), j_cRight);
            j_cRight = Vector3.Normalize(j_cRight);
            EulerAnglescRight = ToEulerAnglesRight(GetVectorcRight()) - InitEulerAnglescRight;
            j_bRight += Vector3.Cross(Vector3.Negate(gyr_gRight), j_bRight);
            j_bRight = Vector3.Normalize(j_bRight);
            EulerAnglesbRight = ToEulerAnglesRight(GetVectorbRight()) - InitEulerAnglesbRight;
            k_aRight += Vector3.Cross(Vector3.Negate(gyr_gRight), k_aRight);
            k_aRight = Vector3.Normalize(k_aRight);
            EulerAnglesaRight = ToEulerAnglesRight(GetVectoraRight()) - InitEulerAnglesaRight;
            EulerAnglesRight = new Vector3(EulerAnglesbRight.X, EulerAnglescRight.Y, EulerAnglesaRight.Z);
        }
        private static double averageRight(double val1, double val2, double val3)
        {
            arrayRight = new double[] { val1, val2, val3 };
            return arrayRight.Average();
        }
        private static double[] CenterSticksRight(UInt16[] vals)
        {
            double[] s = { 0, 0 };
            s[0] = ((int)((vals[0] - stick_calibrationRight[0]) / 100f)) / 13f;
            s[1] = ((int)((vals[1] - stick_calibrationRight[1]) / 100f)) / 13f;
            return s;
        }
        private const string vendor_id = "57e", vendor_id_ = "057e", product_l = "2006", product_r = "2007";
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
        private static double[] stickLeft = { 0, 0 };
        private static SafeFileHandle handleLeft;
        private static byte[] stick_rawLeft = { 0, 0, 0 };
        private static UInt16[] stick_calibrationLeft = { 0, 0 };
        private static UInt16[] stick_precalLeft = { 0, 0 };
        private static Vector3 gyr_gLeft = new Vector3();
        private static Vector3 acc_gLeft = new Vector3();
        private const uint report_lenLeft = 49;
        public static Vector3 i_aLeft = new Vector3(1, 0, 0);
        public static Vector3 j_aLeft = new Vector3(0, 1, 0);
        public static Vector3 k_aLeft = new Vector3(0, 0, 1);
        public static Vector3 i_bLeft = new Vector3(1, 0, 0);
        public static Vector3 j_bLeft = new Vector3(0, 1, 0);
        public static Vector3 k_bLeft = new Vector3(0, 0, 1);
        public static Vector3 i_cLeft = new Vector3(1, 0, 0);
        public static Vector3 j_cLeft = new Vector3(0, 1, 0);
        public static Vector3 k_cLeft = new Vector3(0, 0, 1);
        private static Vector3 InitDirectAnglesLeft, DirectAnglesLeft;
        private static Vector3 InitEulerAnglesaLeft, EulerAnglesaLeft, InitEulerAnglesbLeft, EulerAnglesbLeft, InitEulerAnglescLeft, EulerAnglescLeft, EulerAnglesLeft;
        private static bool LeftButtonSHOULDER_1, LeftButtonSHOULDER_2, LeftButtonSR, LeftButtonSL, LeftButtonDPAD_DOWN, LeftButtonDPAD_RIGHT, LeftButtonDPAD_UP, LeftButtonDPAD_LEFT, LeftButtonMINUS, LeftButtonSTICK, LeftButtonCAPTURE;
        private static byte[] report_bufLeft = new byte[report_lenLeft];
        private static double[] arrayLeft;
        private static byte[] buf_Left = new byte[report_lenLeft];
        public static double indexLeft = 0;
        public static float acc_gcalibrationLeftX, acc_gcalibrationLeftY, acc_gcalibrationLeftZ, gyr_gcalibrationLeftX, gyr_gcalibrationLeftY, gyr_gcalibrationLeftZ;
        public static double[] GetStickLeft()
        {
            return stickLeft;
        }
        public static Vector3 GetAccelLeft()
        {
            return acc_gLeft;
        }
        private static bool ScanLeft()
        {
            int index = 0;
            System.Guid guid;
            HidD_GetHidGuid(out guid);
            System.IntPtr hDevInfo = SetupDiGetClassDevs(ref guid, null, new System.IntPtr(), 0x00000010);
            SP_DEVICE_INTERFACE_DATA diData = new SP_DEVICE_INTERFACE_DATA();
            diData.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(diData);
            while (SetupDiEnumDeviceInterfaces(hDevInfo, new System.IntPtr(), ref guid, index, ref diData))
            {
                System.UInt32 size;
                SetupDiGetDeviceInterfaceDetail(hDevInfo, ref diData, new System.IntPtr(), 0, out size, new System.IntPtr());
                SP_DEVICE_INTERFACE_DETAIL_DATA diDetail = new SP_DEVICE_INTERFACE_DETAIL_DATA();
                diDetail.cbSize = 5;
                if (SetupDiGetDeviceInterfaceDetail(hDevInfo, ref diData, ref diDetail, size, out size, new System.IntPtr()))
                {
                    if ((diDetail.DevicePath.Contains(vendor_id) | diDetail.DevicePath.Contains(vendor_id_)) & diDetail.DevicePath.Contains(product_l))
                    {
                        ISLEFT = true;
                        AttachJoyLeft(diDetail.DevicePath);
                        AttachJoyLeft(diDetail.DevicePath);
                        AttachJoyLeft(diDetail.DevicePath);
                        return true;
                    }
                }
                index++;
            }
            return false;
        }
        public static void AttachJoyLeft(string path)
        {
            do
            {
                IntPtr handle = CreateFile(path, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite, new System.IntPtr(), System.IO.FileMode.Open, EFileAttributes.Normal, new System.IntPtr());
                handleLeft = Lhid_open_path(handle);
                SubcommandLeft(0x3, new byte[] { 0x30 }, 1);
                SubcommandLeft(0x40, new byte[] { 0x1 }, 1);
            }
            while (handleLeft.IsInvalid);
        }
        private static void SubcommandLeft(byte sc, byte[] buf, uint len)
        {
            Array.Copy(buf, 0, buf_Left, 11, len);
            buf_Left[0] = 0x1;
            buf_Left[1] = 0;
            buf_Left[10] = sc;
            Lhid_write(handleLeft, buf_Left, (UIntPtr)(len + 11));
            Lhid_read_timeout(handleLeft, buf_Left, (UIntPtr)49);
        }
        private static double[] stickRight = { 0, 0 };
        private static SafeFileHandle handleRight;
        private static byte[] stick_rawRight = { 0, 0, 0 };
        private static UInt16[] stick_calibrationRight = { 0, 0 };
        private static UInt16[] stick_precalRight = { 0, 0 };
        private static Vector3 acc_gRight = new Vector3();
        private static Vector3 gyr_gRight = new Vector3();
        private const uint report_lenRight = 49;
        public static Vector3 i_cRight = new Vector3(1, 0, 0);
        public static Vector3 j_cRight = new Vector3(0, 1, 0);
        public static Vector3 k_cRight = new Vector3(0, 0, 1);
        public static Vector3 i_bRight = new Vector3(1, 0, 0);
        public static Vector3 j_bRight = new Vector3(0, 1, 0);
        public static Vector3 k_bRight = new Vector3(0, 0, 1);
        public static Vector3 i_aRight = new Vector3(1, 0, 0);
        public static Vector3 j_aRight = new Vector3(0, 1, 0);
        public static Vector3 k_aRight = new Vector3(0, 0, 1);
        private static Vector3 InitDirectAnglesRight, DirectAnglesRight;
        private static Vector3 InitEulerAnglesaRight, EulerAnglesaRight, InitEulerAnglesbRight, EulerAnglesbRight, InitEulerAnglescRight, EulerAnglescRight, EulerAnglesRight;
        private static bool RightButtonSHOULDER_1, RightButtonSHOULDER_2, RightButtonSR, RightButtonSL, RightButtonDPAD_DOWN, RightButtonDPAD_RIGHT, RightButtonDPAD_UP, RightButtonDPAD_LEFT, RightButtonPLUS, RightButtonSTICK, RightButtonHOME;
        private static byte[] report_bufRight = new byte[report_lenRight];
        private static double[] arrayRight;
        private static byte[] buf_Right = new byte[report_lenRight];
        public static double indexRight = 0;
        public static float acc_gcalibrationRightX, acc_gcalibrationRightY, acc_gcalibrationRightZ, gyr_gcalibrationRightX, gyr_gcalibrationRightY, gyr_gcalibrationRightZ;
        public static double[] GetStickRight()
        {
            return stickRight;
        }
        public static Vector3 GetAccelRight()
        {
            return acc_gRight;
        }
        private static bool ScanRight()
        {
            int index = 0;
            System.Guid guid;
            HidD_GetHidGuid(out guid);
            System.IntPtr hDevInfo = SetupDiGetClassDevs(ref guid, null, new System.IntPtr(), 0x00000010);
            SP_DEVICE_INTERFACE_DATA diData = new SP_DEVICE_INTERFACE_DATA();
            diData.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(diData);
            while (SetupDiEnumDeviceInterfaces(hDevInfo, new System.IntPtr(), ref guid, index, ref diData))
            {
                System.UInt32 size;
                SetupDiGetDeviceInterfaceDetail(hDevInfo, ref diData, new System.IntPtr(), 0, out size, new System.IntPtr());
                SP_DEVICE_INTERFACE_DETAIL_DATA diDetail = new SP_DEVICE_INTERFACE_DETAIL_DATA();
                diDetail.cbSize = 5;
                if (SetupDiGetDeviceInterfaceDetail(hDevInfo, ref diData, ref diDetail, size, out size, new System.IntPtr()))
                {
                    if ((diDetail.DevicePath.Contains(vendor_id) | diDetail.DevicePath.Contains(vendor_id_)) & diDetail.DevicePath.Contains(product_r))
                    {
                        ISRIGHT = true;
                        AttachJoyRight(diDetail.DevicePath);
                        AttachJoyRight(diDetail.DevicePath);
                        AttachJoyRight(diDetail.DevicePath);
                        return true;
                    }
                }
                index++;
            }
            return false;
        }
        public static void AttachJoyRight(string path)
        {
            do
            {
                IntPtr handle = CreateFile(path, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite, new System.IntPtr(), System.IO.FileMode.Open, EFileAttributes.Normal, new System.IntPtr());
                handleRight = Rhid_open_path(handle);
                SubcommandRight(0x3, new byte[] { 0x30 }, 1);
                SubcommandRight(0x40, new byte[] { 0x1 }, 1);
            }
            while (handleRight.IsInvalid);
        }
        private static void SubcommandRight(byte sc, byte[] buf, uint len)
        {
            Array.Copy(buf, 0, buf_Right, 11, len);
            buf_Right[0] = 0x1;
            buf_Right[1] = 0;
            buf_Right[10] = sc;
            Rhid_write(handleRight, buf_Right, (UIntPtr)(len + 11));
            Rhid_read_timeout(handleRight, buf_Right, (UIntPtr)49);
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
        public const int KEY_A = 20 + 0xF000;
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
        public const int KEY_Q = 4 + 0xF000;
        public const int KEY_R = 21 + 0xF000;
        public const int KEY_S = 22 + 0xF000;
        public const int KEY_T = 23 + 0xF000;
        public const int KEY_U = 24 + 0xF000;
        public const int KEY_V = 25 + 0xF000;
        public const int KEY_W = 29 + 0xF000;
        public const int KEY_X = 27 + 0xF000;
        public const int KEY_Y = 28 + 0xF000;
        public const int KEY_Z = 26 + 0xF000;
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