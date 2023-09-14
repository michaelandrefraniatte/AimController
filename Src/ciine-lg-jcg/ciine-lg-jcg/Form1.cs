using System;
using System.Windows.Forms;
using System.Reflection;
using System.Text;

namespace ciine_lg_jcg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Type program;
        private object obj;
        private Assembly assembly;
        private System.CodeDom.Compiler.CompilerResults results;
        private Microsoft.CSharp.CSharpCodeProvider provider;
        private System.CodeDom.Compiler.CompilerParameters parameters;
        private string code = @"
                using Microsoft.Win32.SafeHandles;
                using System;
                using System.Globalization;
                using System.IO;
                using System.Numerics;
                using System.Runtime.InteropServices;
                using System.Threading;
                using System.Threading.Tasks;
                using System.Windows;
                using System.Windows.Forms;
                using System.Reflection;
                using keyboards;
                using mouses;
                using Vector3 = System.Numerics.Vector3;
                namespace StringToCode
                {
                    public class FooClass 
                    { 
                        [DllImport(""hid.dll"")]
                        public static extern void HidD_GetHidGuid(out Guid gHid);
                        [DllImport(""hid.dll"")]
                        public extern static bool HidD_SetOutputReport(IntPtr HidDeviceObject, byte[] lpReportBuffer, uint ReportBufferLength);
                        [DllImport(""setupapi.dll"")]
                        public static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, string Enumerator, IntPtr hwndParent, UInt32 Flags);
                        [DllImport(""setupapi.dll"")]
                        public static extern Boolean SetupDiEnumDeviceInterfaces(IntPtr hDevInfo, IntPtr devInvo, ref Guid interfaceClassGuid, Int32 memberIndex, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);
                        [DllImport(""setupapi.dll"")]
                        public static extern Boolean SetupDiGetDeviceInterfaceDetail(IntPtr hDevInfo, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData, IntPtr deviceInterfaceDetailData, UInt32 deviceInterfaceDetailDataSize, out UInt32 requiredSize, IntPtr deviceInfoData);
                        [DllImport(""setupapi.dll"")]
                        public static extern Boolean SetupDiGetDeviceInterfaceDetail(IntPtr hDevInfo, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData, ref SP_DEVICE_INTERFACE_DETAIL_DATA deviceInterfaceDetailData, UInt32 deviceInterfaceDetailDataSize, out UInt32 requiredSize, IntPtr deviceInfoData);
                        [DllImport(""Kernel32.dll"")]
                        public static extern SafeFileHandle CreateFile(string fileName, [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess, [MarshalAs(UnmanagedType.U4)] FileShare fileShare, IntPtr securityAttributes, [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr template);
                        [DllImport(""Kernel32.dll"")]
                        public static extern IntPtr CreateFile(string fileName, System.IO.FileAccess fileAccess, System.IO.FileShare fileShare, IntPtr securityAttributes, System.IO.FileMode creationDisposition, EFileAttributes flags, IntPtr template);
                        [DllImport(""lhidread.dll"", CallingConvention = CallingConvention.Cdecl, EntryPoint = ""Lhid_read_timeout"")]
                        public static extern int Lhid_read_timeout(SafeFileHandle dev, byte[] data, UIntPtr length);
                        [DllImport(""lhidread.dll"", CallingConvention = CallingConvention.Cdecl, EntryPoint = ""Lhid_write"")]
                        public static extern int Lhid_write(SafeFileHandle device, byte[] data, UIntPtr length);
                        [DllImport(""lhidread.dll"", CallingConvention = CallingConvention.Cdecl, EntryPoint = ""Lhid_open_path"")]
                        public static extern SafeFileHandle Lhid_open_path(IntPtr handle);
                        [DllImport(""lhidread.dll"", CallingConvention = CallingConvention.Cdecl, EntryPoint = ""Lhid_close"")]
                        public static extern void Lhid_close(SafeFileHandle device);
                        [DllImport(""rhidread.dll"", CallingConvention = CallingConvention.Cdecl, EntryPoint = ""Rhid_read_timeout"")]
                        public static extern int Rhid_read_timeout(SafeFileHandle dev, byte[] data, UIntPtr length);
                        [DllImport(""rhidread.dll"", CallingConvention = CallingConvention.Cdecl, EntryPoint = ""Rhid_write"")]
                        public static extern int Rhid_write(SafeFileHandle device, byte[] data, UIntPtr length);
                        [DllImport(""rhidread.dll"", CallingConvention = CallingConvention.Cdecl, EntryPoint = ""Rhid_open_path"")]
                        public static extern SafeFileHandle Rhid_open_path(IntPtr handle);
                        [DllImport(""rhidread.dll"", CallingConvention = CallingConvention.Cdecl, EntryPoint = ""Rhid_close"")]
                        public static extern void Rhid_close(SafeFileHandle device);
                        [DllImport(""winmm.dll"", EntryPoint = ""timeBeginPeriod"")]
                        private static extern uint TimeBeginPeriod(uint ms);
                        [DllImport(""winmm.dll"", EntryPoint = ""timeEndPeriod"")]
                        private static extern uint TimeEndPeriod(uint ms);
                        [DllImport(""ntdll.dll"", EntryPoint = ""NtSetTimerResolution"")]
                        private static extern void NtSetTimerResolution(uint DesiredResolution, bool SetResolution, ref uint CurrentResolution);
                        private static uint CurrentResolution = 0;
                        private static bool running;
                        private static int width, height;
                        private double statex = 0f, statey = 0f, mousex = 0f, mousey = 0f, mousestatex = 0f, mousestatey = 0f, viewpower1x = 1f, viewpower2x = 0f, viewpower3x = 0f, viewpower1y = 1f, viewpower2y = 0f, viewpower3y = 0f, dzx = 20.0f, dzy = 0f;
                        private bool[] getstate = new bool[12];
                        private int[] pollcount = new int[12];
                        private int[] keys12345 = new int[12];
                        private int[] keys54321 = new int[12];
                        private double[] mousexp = new double[12];
                        private double[] mouseyp = new double[12];
                        private int sleeptime = 1;
                        string KeyboardMouseDriverType = """"; double MouseMoveX; double MouseMoveY; double MouseAbsX; double MouseAbsY; double MouseDesktopX; double MouseDesktopY; bool SendLeftClick; bool SendRightClick; bool SendMiddleClick; bool SendWheelUp; bool SendWheelDown; bool SendLeft; bool SendRight; bool SendUp; bool SendDown; bool SendLButton; bool SendRButton; bool SendCancel; bool SendMBUTTON; bool SendXBUTTON1; bool SendXBUTTON2; bool SendBack; bool SendTab; bool SendClear; bool SendReturn; bool SendSHIFT; bool SendCONTROL; bool SendMENU; bool SendPAUSE; bool SendCAPITAL; bool SendKANA; bool SendHANGEUL; bool SendHANGUL; bool SendJUNJA; bool SendFINAL; bool SendHANJA; bool SendKANJI; bool SendEscape; bool SendCONVERT; bool SendNONCONVERT; bool SendACCEPT; bool SendMODECHANGE; bool SendSpace; bool SendPRIOR; bool SendNEXT; bool SendEND; bool SendHOME; bool SendLEFT; bool SendUP; bool SendRIGHT; bool SendDOWN; bool SendSELECT; bool SendPRINT; bool SendEXECUTE; bool SendSNAPSHOT; bool SendINSERT; bool SendDELETE; bool SendHELP; bool SendAPOSTROPHE; bool Send0; bool Send1; bool Send2; bool Send3; bool Send4; bool Send5; bool Send6; bool Send7; bool Send8; bool Send9; bool SendA; bool SendB; bool SendC; bool SendD; bool SendE; bool SendF; bool SendG; bool SendH; bool SendI; bool SendJ; bool SendK; bool SendL; bool SendM; bool SendN; bool SendO; bool SendP; bool SendQ; bool SendR; bool SendS; bool SendT; bool SendU; bool SendV; bool SendW; bool SendX; bool SendY; bool SendZ; bool SendLWIN; bool SendRWIN; bool SendAPPS; bool SendSLEEP; bool SendNUMPAD0; bool SendNUMPAD1; bool SendNUMPAD2; bool SendNUMPAD3; bool SendNUMPAD4; bool SendNUMPAD5; bool SendNUMPAD6; bool SendNUMPAD7; bool SendNUMPAD8; bool SendNUMPAD9; bool SendMULTIPLY; bool SendADD; bool SendSEPARATOR; bool SendSUBTRACT; bool SendDECIMAL; bool SendDIVIDE; bool SendF1; bool SendF2; bool SendF3; bool SendF4; bool SendF5; bool SendF6; bool SendF7; bool SendF8; bool SendF9; bool SendF10; bool SendF11; bool SendF12; bool SendF13; bool SendF14; bool SendF15; bool SendF16; bool SendF17; bool SendF18; bool SendF19; bool SendF20; bool SendF21; bool SendF22; bool SendF23; bool SendF24; bool SendNUMLOCK; bool SendSCROLL; bool SendLeftShift; bool SendRightShift; bool SendLeftControl; bool SendRightControl; bool SendLMENU; bool SendRMENU;
                        private static int[] wd = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
                        private static int[] wu = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
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
                        public void Load()
                        {
                            TimeBeginPeriod(1);
                            NtSetTimerResolution(1, true, ref CurrentResolution);
                            Task.Run(() => Start());
                        }
                        private void Start()
                        {
                            running = true;
                            ScanGrip();
                            Task.Run(() => taskDLeft());
                            Task.Run(() => taskDRight());
                            Thread.Sleep(1000);
                            InitLeftJoycon();
                            InitRightJoycon();
                            Task.Run(() => taskX());
                        }
                        private void taskX()
                        {
                            while (running)
                            {
                                ProcessButtonsLeftJoycon();
                                ProcessButtonsRightJoycon();valchanged(0, JoyconLeftButtonCAPTURE);
                                if (wd[0] == 1 & !getstate[0]) 
                                {
                                    width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                                    height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
                                    getstate[0] = true;
                                }
                                else 
                                { 
                                    if (wd[0] == 1 & getstate[0]) 
                                    {
                                        MouseMoveX = 0;
                                        MouseMoveY = 0;
                                        MouseDesktopX = 0;
                                        MouseDesktopY = 0;
                                        MouseAbsX = 0;
                                        MouseAbsY = 0;
                                        SendD = false;
                                        SendQ = false;
                                        SendZ          = false;
                                        SendS          = false;
                                        Send8          = false;
                                        Send7          = false;
                                        Send9          = false;
                                        Send6          = false;
                                        SendB          = false;  
                                        Send1          = false;
                                        Send2          = false;
                                        Send3          = false;
                                        Send4          = false;
                                        SendSpace      = false;
                                        SendLeftShift  = false;
                                        SendE          = false;
                                        SendA          = false;
                                        SendV          = false;
                                        SendEscape     = false;
                                        SendTab        = false;
                                        SendR          = false;
                                        SendF          = false;
                                        SendT          = false;
                                        SendG          = false;
                                        SendY          = false; 
                                        SendU          = false;
                                        SendX          = false;
                                        SendC          = false;
                                        SendRightClick = false;
                                        SendLeftClick  = false;
                                        getstate[0]    = false;
                                    }
                                }
                                if (getstate[0]) 
                                {
                                    if (JoyconRightButtonPLUS)
                                    {
                                        mousexp[0] = 0f;
                                        mouseyp[0] = 0f;
                                    }
                                    mousexp[0] += JoyconRightGyroX * width / 2f / 1024f * 2f / 500f;
                                    mouseyp[0] += JoyconRightGyroY * height / 2f / 1024f * 2f / 500f;
                                    if (mousexp[0] >= width / 2f) 
                                        mousexp[0] = width / 2f;
                                    if (mousexp[0] <= -width / 2f) 
                                        mousexp[0] = -width / 2f;
                                    if (mouseyp[0] >= height / 2f) 
                                        mouseyp[0] = height / 2f;
                                    if (mouseyp[0] <= -height / 2f) 
                                        mouseyp[0] = -height / 2f;
                                    MouseDesktopX  = width / 2f + mousexp[0] + JoyconRightGyroX * width / 2f / 1024f * 2f / 500f;
                                    MouseDesktopY  = height / 2f - mouseyp[0] - JoyconRightGyroY * height / 2f / 1024f * 2f / 500f;
                                    SendD          = JoyconLeftStickX > 0.25f;
                                    SendQ          = JoyconLeftStickX < -0.25f;
                                    SendZ          = JoyconLeftStickY > 0.25f;
                                    SendS          = JoyconLeftStickY < -0.25f;
                                    Send5          = JoyconRightStickX > 0.25f;
                                    Send6          = JoyconRightStickX < -0.25f;
                                    Send3          = JoyconRightStickY > 0.25f;
                                    Send4          = JoyconRightStickY < -0.25f;
                                    Send7          = JoyconLeftButtonDPAD_UP;
                                    Send8          = JoyconLeftButtonDPAD_LEFT;
                                    Send9          = JoyconLeftButtonDPAD_DOWN;
                                    Send0          = JoyconLeftButtonDPAD_RIGHT;
                                    SendT          = JoyconLeftButtonMINUS;
                                    SendEscape     = JoyconLeftButtonCAPTURE;
                                    SendLeftShift  = JoyconLeftButtonSTICK;
                                    SendA          = JoyconLeftButtonSL;
                                    SendLMENU      = JoyconLeftButtonSR;
                                    SendSpace      = JoyconLeftButtonSHOULDER_1;
                                    Send1          = JoyconLeftButtonSHOULDER_2;
                                    SendC          = JoyconRightButtonDPAD_DOWN;
                                    Send2          = JoyconRightButtonDPAD_RIGHT;
                                    SendRightClick = JoyconRightButtonDPAD_LEFT;
                                    SendX          = JoyconRightButtonDPAD_UP;
                                    SendG          = JoyconRightButtonPLUS;
                                    SendF          = JoyconRightButtonHOME;
                                    SendV          = JoyconRightButtonSTICK;
                                    SendTab        = JoyconRightButtonSL;
                                    SendE          = JoyconRightButtonSR;
                                    SendR          = JoyconRightButtonSHOULDER_1;
                                    SendLeftClick  = JoyconRightButtonSHOULDER_2;
                                }
                                SendKeyboard.SetKM(KeyboardMouseDriverType, SendLeftClick, SendRightClick, SendMiddleClick, SendWheelUp, SendWheelDown, SendLeft, SendRight, SendUp, SendDown, SendLButton, SendRButton, SendCancel, SendMBUTTON, SendXBUTTON1, SendXBUTTON2, SendBack, SendTab, SendClear, SendReturn, SendSHIFT, SendCONTROL, SendMENU, SendPAUSE, SendCAPITAL, SendKANA, SendHANGEUL, SendHANGUL, SendJUNJA, SendFINAL, SendHANJA, SendKANJI, SendEscape, SendCONVERT, SendNONCONVERT, SendACCEPT, SendMODECHANGE, SendSpace, SendPRIOR, SendNEXT, SendEND, SendHOME, SendLEFT, SendUP, SendRIGHT, SendDOWN, SendSELECT, SendPRINT, SendEXECUTE, SendSNAPSHOT, SendINSERT, SendDELETE, SendHELP, SendAPOSTROPHE, Send0, Send1, Send2, Send3, Send4, Send5, Send6, Send7, Send8, Send9, SendA, SendB, SendC, SendD, SendE, SendF, SendG, SendH, SendI, SendJ, SendK, SendL, SendM, SendN, SendO, SendP, SendQ, SendR, SendS, SendT, SendU, SendV, SendW, SendX, SendY, SendZ, SendLWIN, SendRWIN, SendAPPS, SendSLEEP, SendNUMPAD0, SendNUMPAD1, SendNUMPAD2, SendNUMPAD3, SendNUMPAD4, SendNUMPAD5, SendNUMPAD6, SendNUMPAD7, SendNUMPAD8, SendNUMPAD9, SendMULTIPLY, SendADD, SendSEPARATOR, SendSUBTRACT, SendDECIMAL, SendDIVIDE, SendF1, SendF2, SendF3, SendF4, SendF5, SendF6, SendF7, SendF8, SendF9, SendF10, SendF11, SendF12, SendF13, SendF14, SendF15, SendF16, SendF17, SendF18, SendF19, SendF20, SendF21, SendF22, SendF23, SendF24, SendNUMLOCK, SendSCROLL, SendLeftShift, SendRightShift, SendLeftControl, SendRightControl, SendLMENU, SendRMENU);
                                SendMouse.SetKM(KeyboardMouseDriverType, MouseMoveX, MouseMoveY, MouseAbsX, MouseAbsY, MouseDesktopX, MouseDesktopY);
                                Thread.Sleep(sleeptime);
                            }
                        }
                        public void Close()
                        {
                            try
                            {
                                running = false;
                                Thread.Sleep(100);
                                SendKeyboard.UnLoadKM();
                                Subcommand3GripLeftController(0x06, new byte[] { 0x01 }, 1);
                                Subcommand3GripRightController(0x06, new byte[] { 0x01 }, 1);
                                Lhid_close(handleLeft);
                                handleLeft.Close();
                                Rhid_close(handleRight);
                                handleRight.Close();
                            }
                            catch { }
                        }
                        private static double Scale(double value, double min, double max, double minScale, double maxScale)
                        {
                            double scaled = minScale + (double)(value - min) / (max - min) * (maxScale - minScale);
                            return scaled;
                        }
                        private static void taskDLeft()
                        {
                            while (running)
                            {
                                try
                                {
                                    Lhid_read_timeout(handleLeft, report_bufLeft, (UIntPtr)report_lenLeft);
                                }
                                catch { }
                            }
                        }
                        private static void taskDRight()
                        {
                            while (running)
                            {
                                try
                                {
                                    Rhid_read_timeout(handleRight, report_bufRight, (UIntPtr)report_lenRight);
                                }
                                catch { }
                            }
                        }
                        public const string vendor_id = ""57e"", vendor_id_ = ""057e"", product_grip = ""200e"";
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
                        public static void InitLeftJoycon()
                        {
                            try
                            {
                                stick_rawLeft[0] = report_bufLeft[6 + (ISLEFT ? 0 : 3)];
                                stick_rawLeft[1] = report_bufLeft[7 + (ISLEFT ? 0 : 3)];
                                stick_rawLeft[2] = report_bufLeft[8 + (ISLEFT ? 0 : 3)];
                                stickCenterLeft[0] = (UInt16)(stick_rawLeft[0] | ((stick_rawLeft[1] & 0xf) << 8));
                                stickCenterLeft[1] = (UInt16)((stick_rawLeft[1] >> 4) | (stick_rawLeft[2] << 4));
                                acc_gcalibrationLeftX = (Int16)(report_bufLeft[13 + 0 * 12] | ((report_bufLeft[14 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufLeft[13 + 1 * 12] | ((report_bufLeft[14 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufLeft[13 + 2 * 12] | ((report_bufLeft[14 + 2 * 12] << 8) & 0xff00));
                                acc_gcalibrationLeftY = (Int16)(report_bufLeft[15 + 0 * 12] | ((report_bufLeft[16 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufLeft[15 + 1 * 12] | ((report_bufLeft[16 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufLeft[15 + 2 * 12] | ((report_bufLeft[16 + 2 * 12] << 8) & 0xff00));
                                acc_gcalibrationLeftZ = (Int16)(report_bufLeft[17 + 0 * 12] | ((report_bufLeft[18 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufLeft[17 + 1 * 12] | ((report_bufLeft[18 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufLeft[17 + 2 * 12] | ((report_bufLeft[18 + 2 * 12] << 8) & 0xff00));
                            }
                            catch { }
                        }
                        public static void ProcessButtonsLeftJoycon()
                        {
                            try
                            {
                                if (JoyconLeftStickCenter)
                                {
                                    stick_rawLeft[0] = report_bufLeft[6 + (ISLEFT ? 0 : 3)];
                                    stick_rawLeft[1] = report_bufLeft[7 + (ISLEFT ? 0 : 3)];
                                    stick_rawLeft[2] = report_bufLeft[8 + (ISLEFT ? 0 : 3)];
                                    stickCenterLeft[0] = (UInt16)(stick_rawLeft[0] | ((stick_rawLeft[1] & 0xf) << 8));
                                    stickCenterLeft[1] = (UInt16)((stick_rawLeft[1] >> 4) | (stick_rawLeft[2] << 4));
                                }
                                stick_rawLeft[0] = report_bufLeft[6 + (ISLEFT ? 0 : 3)];
                                stick_rawLeft[1] = report_bufLeft[7 + (ISLEFT ? 0 : 3)];
                                stick_rawLeft[2] = report_bufLeft[8 + (ISLEFT ? 0 : 3)];
                                stickLeft[0] = ((UInt16)(stick_rawLeft[0] | ((stick_rawLeft[1] & 0xf) << 8)) - stickCenterLeft[0]) / 1440f;
                                stickLeft[1] = ((UInt16)((stick_rawLeft[1] >> 4) | (stick_rawLeft[2] << 4)) - stickCenterLeft[1]) / 1440f;
                                JoyconLeftStickX = stickLeft[0];
                                JoyconLeftStickY = stickLeft[1];
                                acc_gLeft.X = ((Int16)(report_bufLeft[13 + 0 * 12] | ((report_bufLeft[14 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufLeft[13 + 1 * 12] | ((report_bufLeft[14 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufLeft[13 + 2 * 12] | ((report_bufLeft[14 + 2 * 12] << 8) & 0xff00)) - acc_gcalibrationLeftX) * (1.0f / 12000f);
                                acc_gLeft.Y = -((Int16)(report_bufLeft[15 + 0 * 12] | ((report_bufLeft[16 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufLeft[15 + 1 * 12] | ((report_bufLeft[16 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufLeft[15 + 2 * 12] | ((report_bufLeft[16 + 2 * 12] << 8) & 0xff00)) - acc_gcalibrationLeftY) * (1.0f / 12000f);
                                acc_gLeft.Z = -((Int16)(report_bufLeft[17 + 0 * 12] | ((report_bufLeft[18 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufLeft[17 + 1 * 12] | ((report_bufLeft[18 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufLeft[17 + 2 * 12] | ((report_bufLeft[18 + 2 * 12] << 8) & 0xff00)) - acc_gcalibrationLeftZ) * (1.0f / 12000f);
                                JoyconLeftButtonSHOULDER_1 = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & 0x40) != 0;
                                JoyconLeftButtonSHOULDER_2 = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & 0x80) != 0;
                                JoyconLeftButtonSR = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & 0x10) != 0;
                                JoyconLeftButtonSL = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & 0x20) != 0;
                                JoyconLeftButtonDPAD_DOWN = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & (ISLEFT ? 0x01 : 0x04)) != 0;
                                JoyconLeftButtonDPAD_RIGHT = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & (ISLEFT ? 0x04 : 0x08)) != 0;
                                JoyconLeftButtonDPAD_UP = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & (ISLEFT ? 0x02 : 0x02)) != 0;
                                JoyconLeftButtonDPAD_LEFT = (report_bufLeft[3 + (ISLEFT ? 2 : 0)] & (ISLEFT ? 0x08 : 0x01)) != 0;
                                JoyconLeftButtonMINUS = (report_bufLeft[4] & 0x01) != 0;
                                JoyconLeftButtonCAPTURE = (report_bufLeft[4] & 0x20) != 0;
                                JoyconLeftButtonSTICK = (report_bufLeft[4] & (ISLEFT ? 0x08 : 0x04)) != 0;
                                JoyconLeftButtonACC = acc_gLeft.X <= -1.13;
                                JoyconLeftButtonSMA = JoyconLeftButtonSL | JoyconLeftButtonSR | JoyconLeftButtonMINUS | JoyconLeftButtonACC;
                                if (JoyconLeftAccelCenter)
                                    InitDirectAnglesLeft = acc_gLeft;
                                DirectAnglesLeft = acc_gLeft - InitDirectAnglesLeft;
                                JoyconLeftAccelX = DirectAnglesLeft.X * 1350f;
                                JoyconLeftAccelY = -DirectAnglesLeft.Y * 1350f;
                                gyr_gLeft.X = ((Int16)(report_bufLeft[19 + 0 * 12] | ((report_bufLeft[20 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufLeft[19 + 1 * 12] | ((report_bufLeft[20 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufLeft[19 + 2 * 12] | ((report_bufLeft[20 + 2 * 12] << 8) & 0xff00)));
                                gyr_gLeft.Y = ((Int16)(report_bufLeft[21 + 0 * 12] | ((report_bufLeft[22 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufLeft[21 + 1 * 12] | ((report_bufLeft[22 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufLeft[21 + 2 * 12] | ((report_bufLeft[22 + 2 * 12] << 8) & 0xff00)));
                                gyr_gLeft.Z = ((Int16)(report_bufLeft[23 + 0 * 12] | ((report_bufLeft[24 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufLeft[23 + 1 * 12] | ((report_bufLeft[24 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufLeft[23 + 2 * 12] | ((report_bufLeft[24 + 2 * 12] << 8) & 0xff00)));
                                JoyconLeftGyroX = gyr_gLeft.Z;
                                JoyconLeftGyroY = gyr_gLeft.Y;
                            }
                            catch { }
                        }
                        public static bool JoyconLeftButtonSMA, JoyconLeftButtonACC, JoyconLeftRollLeft, JoyconLeftRollRight;
                        private static double JoyconLeftStickX, JoyconLeftStickY;
                        public static System.Collections.Generic.List<double> LeftValListX = new System.Collections.Generic.List<double>(), LeftValListY = new System.Collections.Generic.List<double>();
                        public static bool JoyconLeftAccelCenter, JoyconLeftStickCenter;
                        public static double JoyconLeftAccelX, JoyconLeftAccelY, JoyconLeftGyroX, JoyconLeftGyroY;
                        private static double[] stickLeft = { 0, 0 };
                        private static double[] stickCenterLeft = { 0, 0 };
                        private static byte[] stick_rawLeft = { 0, 0, 0 };
                        public static SafeFileHandle handleLeft;
                        public static Vector3 acc_gLeft = new Vector3();
                        public static Vector3 gyr_gLeft = new Vector3();
                        public const uint report_lenLeft = 49;
                        public static Vector3 InitDirectAnglesLeft, DirectAnglesLeft;
                        public static bool JoyconLeftButtonSHOULDER_1, JoyconLeftButtonSHOULDER_2, JoyconLeftButtonSR, JoyconLeftButtonSL, JoyconLeftButtonDPAD_DOWN, JoyconLeftButtonDPAD_RIGHT, JoyconLeftButtonDPAD_UP, JoyconLeftButtonDPAD_LEFT, JoyconLeftButtonMINUS, JoyconLeftButtonSTICK, JoyconLeftButtonCAPTURE, ISLEFT;
                        public static byte[] report_bufLeft = new byte[report_lenLeft];
                        public static float acc_gcalibrationLeftX, acc_gcalibrationLeftY, acc_gcalibrationLeftZ;
                        public static void InitRightJoycon()
                        {
                            try
                            {
                                stick_rawRight[0] = report_bufRight[6 + (!ISRIGHT ? 0 : 3)];
                                stick_rawRight[1] = report_bufRight[7 + (!ISRIGHT ? 0 : 3)];
                                stick_rawRight[2] = report_bufRight[8 + (!ISRIGHT ? 0 : 3)];
                                stickCenterRight[0] = (UInt16)(stick_rawRight[0] | ((stick_rawRight[1] & 0xf) << 8));
                                stickCenterRight[1] = (UInt16)((stick_rawRight[1] >> 4) | (stick_rawRight[2] << 4));
                                acc_gcalibrationRightX = (Int16)(report_bufRight[13 + 0 * 12] | ((report_bufRight[14 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufRight[13 + 1 * 12] | ((report_bufRight[14 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufRight[13 + 2 * 12] | ((report_bufRight[14 + 2 * 12] << 8) & 0xff00));
                                acc_gcalibrationRightY = (Int16)(report_bufRight[15 + 0 * 12] | ((report_bufRight[16 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufRight[15 + 1 * 12] | ((report_bufRight[16 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufRight[15 + 2 * 12] | ((report_bufRight[16 + 2 * 12] << 8) & 0xff00));
                                acc_gcalibrationRightZ = (Int16)(report_bufRight[17 + 0 * 12] | ((report_bufRight[18 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufRight[17 + 1 * 12] | ((report_bufRight[18 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufRight[17 + 2 * 12] | ((report_bufRight[18 + 2 * 12] << 8) & 0xff00));
                            }
                            catch { }
                        }
                        public static void ProcessButtonsRightJoycon()
                        {
                            try
                            {
                                if (JoyconRightStickCenter)
                                {
                                    stick_rawRight[0] = report_bufRight[6 + (!ISRIGHT ? 0 : 3)];
                                    stick_rawRight[1] = report_bufRight[7 + (!ISRIGHT ? 0 : 3)];
                                    stick_rawRight[2] = report_bufRight[8 + (!ISRIGHT ? 0 : 3)];
                                    stickCenterRight[0] = (UInt16)(stick_rawRight[0] | ((stick_rawRight[1] & 0xf) << 8));
                                    stickCenterRight[1] = (UInt16)((stick_rawRight[1] >> 4) | (stick_rawRight[2] << 4));
                                }
                                stick_rawRight[0] = report_bufRight[6 + (!ISRIGHT ? 0 : 3)];
                                stick_rawRight[1] = report_bufRight[7 + (!ISRIGHT ? 0 : 3)];
                                stick_rawRight[2] = report_bufRight[8 + (!ISRIGHT ? 0 : 3)];
                                stickRight[0] = ((UInt16)(stick_rawRight[0] | ((stick_rawRight[1] & 0xf) << 8)) - stickCenterRight[0]) / 1440f;
                                stickRight[1] = ((UInt16)((stick_rawRight[1] >> 4) | (stick_rawRight[2] << 4)) - stickCenterRight[1]) / 1440f;
                                JoyconRightStickX = -stickRight[0];
                                JoyconRightStickY = -stickRight[1];
                                acc_gRight.X = ((Int16)(report_bufRight[13 + 0 * 12] | ((report_bufRight[14 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufRight[13 + 1 * 12] | ((report_bufRight[14 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufRight[13 + 2 * 12] | ((report_bufRight[14 + 2 * 12] << 8) & 0xff00)) - acc_gcalibrationRightX) * (1.0f / 12000f);
                                acc_gRight.Y = -((Int16)(report_bufRight[15 + 0 * 12] | ((report_bufRight[16 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufRight[15 + 1 * 12] | ((report_bufRight[16 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufRight[15 + 2 * 12] | ((report_bufRight[16 + 2 * 12] << 8) & 0xff00)) - acc_gcalibrationRightY) * (1.0f / 12000f);
                                acc_gRight.Z = -((Int16)(report_bufRight[17 + 0 * 12] | ((report_bufRight[18 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufRight[17 + 1 * 12] | ((report_bufRight[18 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufRight[17 + 2 * 12] | ((report_bufRight[18 + 2 * 12] << 8) & 0xff00)) - acc_gcalibrationRightZ) * (1.0f / 12000f);
                                JoyconRightButtonSHOULDER_1 = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & 0x40) != 0;
                                JoyconRightButtonSHOULDER_2 = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & 0x80) != 0;
                                JoyconRightButtonSR = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & 0x10) != 0;
                                JoyconRightButtonSL = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & 0x20) != 0;
                                JoyconRightButtonDPAD_DOWN = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & (!ISRIGHT ? 0x01 : 0x04)) != 0;
                                JoyconRightButtonDPAD_RIGHT = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & (!ISRIGHT ? 0x04 : 0x08)) != 0;
                                JoyconRightButtonDPAD_UP = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & (!ISRIGHT ? 0x02 : 0x02)) != 0;
                                JoyconRightButtonDPAD_LEFT = (report_bufRight[3 + (!ISRIGHT ? 2 : 0)] & (!ISRIGHT ? 0x08 : 0x01)) != 0;
                                JoyconRightButtonPLUS = ((report_bufRight[4] & 0x02) != 0);
                                JoyconRightButtonHOME = ((report_bufRight[4] & 0x10) != 0);
                                JoyconRightButtonSTICK = ((report_bufRight[4] & (!ISRIGHT ? 0x08 : 0x04)) != 0);
                                JoyconRightButtonACC = acc_gRight.X <= -1.13;
                                JoyconRightButtonSPA = JoyconRightButtonSL | JoyconRightButtonSR | JoyconRightButtonPLUS | JoyconRightButtonACC;
                                if (JoyconRightAccelCenter)
                                    InitDirectAnglesRight = acc_gRight;
                                DirectAnglesRight = acc_gRight - InitDirectAnglesRight;
                                JoyconRightAccelX = DirectAnglesRight.X * 1350f;
                                JoyconRightAccelY = -DirectAnglesRight.Y * 1350f;
                                gyr_gRight.X = ((Int16)(report_bufRight[19 + 0 * 12] | ((report_bufRight[20 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufRight[19 + 1 * 12] | ((report_bufRight[20 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufRight[19 + 2 * 12] | ((report_bufRight[20 + 2 * 12] << 8) & 0xff00)));
                                gyr_gRight.Y = ((Int16)(report_bufRight[21 + 0 * 12] | ((report_bufRight[22 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufRight[21 + 1 * 12] | ((report_bufRight[22 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufRight[21 + 2 * 12] | ((report_bufRight[22 + 2 * 12] << 8) & 0xff00)));
                                gyr_gRight.Z = ((Int16)(report_bufRight[23 + 0 * 12] | ((report_bufRight[24 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufRight[23 + 1 * 12] | ((report_bufRight[24 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufRight[23 + 2 * 12] | ((report_bufRight[24 + 2 * 12] << 8) & 0xff00)));
                                JoyconRightGyroX = gyr_gRight.Z;
                                JoyconRightGyroY = gyr_gRight.Y;
                            }
                            catch { }
                        }
                        public static bool JoyconRightButtonSPA, JoyconRightButtonACC, JoyconRightRollLeft, JoyconRightRollRight;
                        private static double JoyconRightStickX, JoyconRightStickY;
                        public static System.Collections.Generic.List<double> RightValListX = new System.Collections.Generic.List<double>(), RightValListY = new System.Collections.Generic.List<double>();
                        public static bool JoyconRightAccelCenter, JoyconRightStickCenter;
                        public static double JoyconRightAccelX, JoyconRightAccelY, JoyconRightGyroX, JoyconRightGyroY;
                        private static double[] stickRight = { 0, 0 };
                        private static double[] stickCenterRight = { 0, 0 };
                        private static byte[] stick_rawRight = { 0, 0, 0 };
                        public static SafeFileHandle handleRight;
                        public static Vector3 acc_gRight = new Vector3();
                        public static Vector3 gyr_gRight = new Vector3();
                        public const uint report_lenRight = 49;
                        public static Vector3 InitDirectAnglesRight, DirectAnglesRight;
                        public static bool JoyconRightButtonSHOULDER_1, JoyconRightButtonSHOULDER_2, JoyconRightButtonSR, JoyconRightButtonSL, JoyconRightButtonDPAD_DOWN, JoyconRightButtonDPAD_RIGHT, JoyconRightButtonDPAD_UP, JoyconRightButtonDPAD_LEFT, JoyconRightButtonPLUS, JoyconRightButtonSTICK, JoyconRightButtonHOME, ISRIGHT;
                        public static byte[] report_bufRight = new byte[report_lenRight];
                        public static float acc_gcalibrationRightX, acc_gcalibrationRightY, acc_gcalibrationRightZ;
                        private static bool ScanGrip()
                        {
                            ISLEFT = false;
                            ISRIGHT = false;
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
                                    if ((diDetail.DevicePath.Contains(vendor_id) | diDetail.DevicePath.Contains(vendor_id_)) & diDetail.DevicePath.Contains(product_grip))
                                    {
                                        if (ISLEFT)
                                        {
                                            AttachGripRightController(diDetail.DevicePath);
                                            ISRIGHT = true;
                                        }
                                        if (!ISLEFT)
                                        {
                                            AttachGripLeftController(diDetail.DevicePath);
                                            ISLEFT = true;
                                        }
                                        if (ISLEFT & ISRIGHT)
                                            return true;
                                    }
                                }
                                index++;
                            }
                            return false;
                        }
                        private static void AttachGripLeftController(string path)
                        {
                            do
                            {
                                IntPtr handle = CreateFile(path, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite, new System.IntPtr(), System.IO.FileMode.Open, EFileAttributes.Normal, new System.IntPtr());
                                handleLeft = Lhid_open_path(handle);
                                Subcommand1GripLeftController(0x06, new byte[] { 0x01 }, 1);
                                Subcommand2GripLeftController(0x40, new byte[] { 0x1 }, 1);
                                Subcommand2GripLeftController(0x3, new byte[] { 0x30 }, 1);
                            }
                            while (handleLeft.IsInvalid);
                        }
                        private static void Subcommand1GripLeftController(byte sc, byte[] buf, uint len)
                        {
                            byte[] buf_Left = new byte[report_lenLeft];
                            System.Array.Copy(buf, 0, buf_Left, 11, len);
                            buf_Left[10] = sc;
                            buf_Left[1] = 0x2;
                            buf_Left[0] = 0x80;
                            Lhid_write(handleLeft, buf_Left, new UIntPtr(2));
                            Lhid_read_timeout(handleLeft, buf_Left, (UIntPtr)report_lenLeft);
                            buf_Left[1] = 0x3;
                            buf_Left[0] = 0x80;
                            Lhid_write(handleLeft, buf_Left, new UIntPtr(2));
                            Lhid_read_timeout(handleLeft, buf_Left, (UIntPtr)report_lenLeft);
                            buf_Left[1] = 0x2;
                            buf_Left[0] = 0x80;
                            Lhid_write(handleLeft, buf_Left, new UIntPtr(2));
                            Lhid_read_timeout(handleLeft, buf_Left, (UIntPtr)report_lenLeft);
                            buf_Left[1] = 0x4;
                            buf_Left[0] = 0x80;
                            Lhid_write(handleLeft, buf_Left, new UIntPtr(2));
                            Lhid_read_timeout(handleLeft, buf_Left, (UIntPtr)report_lenLeft);
                        }
                        private static void Subcommand2GripLeftController(byte sc, byte[] buf, uint len)
                        {
                            byte[] buf_Left = new byte[report_lenLeft];
                            System.Array.Copy(buf, 0, buf_Left, 11, len);
                            buf_Left[10] = sc;
                            buf_Left[1] = 0;
                            buf_Left[0] = 0x1;
                            Lhid_write(handleLeft, buf_Left, (UIntPtr)(len + 11));
                            Lhid_read_timeout(handleLeft, buf_Left, (UIntPtr)report_lenLeft);
                        }
                        private static void Subcommand3GripLeftController(byte sc, byte[] buf, uint len)
                        {
                            byte[] buf_Left = new byte[report_lenLeft];
                            System.Array.Copy(buf, 0, buf_Left, 11, len);
                            buf_Left[10] = sc;
                            buf_Left[1] = 0x5;
                            buf_Left[0] = 0x80;
                            Lhid_write(handleLeft, buf_Left, new UIntPtr(2));
                            buf_Left[1] = 0x6;
                            buf_Left[0] = 0x80;
                            Lhid_write(handleLeft, buf_Left, new UIntPtr(2));
                        }
                        private static void AttachGripRightController(string path)
                        {
                            do
                            {
                                IntPtr handle = CreateFile(path, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite, new System.IntPtr(), System.IO.FileMode.Open, EFileAttributes.Normal, new System.IntPtr());
                                handleRight = Rhid_open_path(handle);
                                Subcommand1GripRightController(0x06, new byte[] { 0x01 }, 1);
                                Subcommand2GripRightController(0x40, new byte[] { 0x1 }, 1);
                                Subcommand2GripRightController(0x3, new byte[] { 0x30 }, 1);
                            }
                            while (handleRight.IsInvalid);
                        }
                        private static void Subcommand1GripRightController(byte sc, byte[] buf, uint len)
                        {
                            byte[] buf_Right = new byte[report_lenRight];
                            System.Array.Copy(buf, 0, buf_Right, 11, len);
                            buf_Right[10] = sc;
                            buf_Right[1] = 0x2;
                            buf_Right[0] = 0x80;
                            Rhid_write(handleRight, buf_Right, new UIntPtr(2));
                            Rhid_read_timeout(handleRight, buf_Right, (UIntPtr)report_lenRight);
                            buf_Right[1] = 0x3;
                            buf_Right[0] = 0x80;
                            Rhid_write(handleRight, buf_Right, new UIntPtr(2));
                            Rhid_read_timeout(handleRight, buf_Right, (UIntPtr)report_lenRight);
                            buf_Right[1] = 0x2;
                            buf_Right[0] = 0x80;
                            Rhid_write(handleRight, buf_Right, new UIntPtr(2));
                            Rhid_read_timeout(handleRight, buf_Right, (UIntPtr)report_lenRight);
                            buf_Right[1] = 0x4;
                            buf_Right[0] = 0x80;
                            Rhid_write(handleRight, buf_Right, new UIntPtr(2));
                            Rhid_read_timeout(handleRight, buf_Right, (UIntPtr)report_lenRight);
                        }
                        private static void Subcommand2GripRightController(byte sc, byte[] buf, uint len)
                        {
                            byte[] buf_Right = new byte[report_lenRight];
                            System.Array.Copy(buf, 0, buf_Right, 11, len);
                            buf_Right[10] = sc;
                            buf_Right[1] = 0;
                            buf_Right[0] = 0x1;
                            Rhid_write(handleRight, buf_Right, (UIntPtr)(len + 11));
                            Rhid_read_timeout(handleRight, buf_Right, (UIntPtr)report_lenRight);
                        }
                        private static void Subcommand3GripRightController(byte sc, byte[] buf, uint len)
                        {
                            byte[] buf_Right = new byte[report_lenRight];
                            System.Array.Copy(buf, 0, buf_Right, 11, len);
                            buf_Right[10] = sc;
                            buf_Right[1] = 0x5;
                            buf_Right[0] = 0x80;
                            Rhid_write(handleRight, buf_Right, new UIntPtr(2));
                            buf_Right[1] = 0x6;
                            buf_Right[0] = 0x80;
                            Rhid_write(handleRight, buf_Right, new UIntPtr(2));
                        }
                    }
                }";
        private void Form1_Load(object sender, EventArgs e)
        {
            parameters = new System.CodeDom.Compiler.CompilerParameters();
            parameters.GenerateExecutable = false;
            parameters.GenerateInMemory = true;
            parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            parameters.ReferencedAssemblies.Add("System.Drawing.dll");
            parameters.ReferencedAssemblies.Add("System.Numerics.Vectors.dll");
            parameters.ReferencedAssemblies.Add("System.Numerics.dll");
            parameters.ReferencedAssemblies.Add("keyboards.dll");
            parameters.ReferencedAssemblies.Add("mouses.dll");
            provider = new Microsoft.CSharp.CSharpCodeProvider();
            results = provider.CompileAssemblyFromSource(parameters, code);
            if (results.Errors.HasErrors)
            {
                StringBuilder sb = new StringBuilder();
                foreach (System.CodeDom.Compiler.CompilerError error in results.Errors)
                {
                    sb.AppendLine(String.Format("Error ({0}) : {1}", error.ErrorNumber, error.ErrorText));
                }
                MessageBox.Show("Script Error :\n\r" + sb.ToString());
                return;
            }
            assembly = results.CompiledAssembly;
            program = assembly.GetType("StringToCode.FooClass");
            obj = Activator.CreateInstance(program);
            program.InvokeMember("Load", BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, new object[] { });
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            program.InvokeMember("Close", BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, new object[] { });
        }
    }
}