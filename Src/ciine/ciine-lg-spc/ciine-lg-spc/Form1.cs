using System;
using System.Windows.Forms;
using System.Reflection;
using System.Text;

namespace ciine_lg_spc
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
                        [DllImport(""prohidread.dll"", CallingConvention = CallingConvention.Cdecl, EntryPoint = ""Prohid_read_timeout"")]
                        public static extern int Prohid_read_timeout(SafeFileHandle dev, byte[] data, UIntPtr length);
                        [DllImport(""prohidread.dll"", CallingConvention = CallingConvention.Cdecl, EntryPoint = ""Prohid_write"")]
                        public static extern int Prohid_write(SafeFileHandle device, byte[] data, UIntPtr length);
                        [DllImport(""prohidread.dll"", CallingConvention = CallingConvention.Cdecl, EntryPoint = ""Prohid_open_path"")]
                        public static extern SafeFileHandle Prohid_open_path(IntPtr handle);
                        [DllImport(""prohidread.dll"", CallingConvention = CallingConvention.Cdecl, EntryPoint = ""Prohid_close"")]
                        public static extern void Prohid_close(SafeFileHandle device);
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
                            ScanPro();
                            Task.Run(() => taskDPro());
                            Thread.Sleep(1000);
                            InitProController();
                            Task.Run(() => taskX());
                        }
                        private void taskX()
                        {
                            while (running)
                            {
                                ProcessButtonsAndSticksPro();valchanged(0, ProControllerButtonCAPTURE);
                                if (wd[0] == 1 & !getstate[0]) 
                                {
                                    width                   = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                                    height                  = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
                                    getstate[0] = true;
                                }
                                else 
                                { 
                                    if (wd[0] == 1 & getstate[0]) 
                                    {
                                        MouseMoveX     = 0;
                                        MouseMoveY     = 0;
                                        MouseDesktopX  = 0;
                                        MouseDesktopY  = 0;
                                        MouseAbsX      = 0;
                                        MouseAbsY      = 0;
                                        SendD          = false;
                                        SendQ          = false;
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
                                    if (ProControllerButtonPLUS)
                                    {
                                        mousexp[0] = 0f;
                                        mouseyp[0] = 0f;
                                    }
                                    mousexp[0] += ProControllerGyroX * width / 2f / 1024f * 2f / 500f;
                                    mouseyp[0] += ProControllerGyroY * height / 2f / 1024f * 2f / 500f;
                                    if (mousexp[0] >= width / 2f) 
                                        mousexp[0] = width / 2f;
                                    if (mousexp[0] <= -width / 2f) 
                                        mousexp[0] = -width / 2f;
                                    if (mouseyp[0] >= height / 2f) 
                                        mouseyp[0] = height / 2f;
                                    if (mouseyp[0] <= -height / 2f) 
                                        mouseyp[0] = -height / 2f;
                                    MouseDesktopX  = width / 2f - mousexp[0] - ProControllerGyroX * width / 2f / 1024f * 2f / 500f;
                                    MouseDesktopY  = height / 2f + mouseyp[0] + ProControllerGyroY * height / 2f / 1024f * 2f / 500f;
                                    SendD          = ProControllerLeftStickX > 0.35f;
                                    SendQ          = ProControllerLeftStickX < -0.35f;
                                    SendZ          = ProControllerLeftStickY > 0.35f;
                                    SendS          = ProControllerLeftStickY < -0.35f;
                                    Send8          = ProControllerButtonDPAD_DOWN;
                                    Send7          = ProControllerButtonDPAD_LEFT;
                                    Send9          = ProControllerButtonDPAD_RIGHT;
                                    Send6          = ProControllerButtonDPAD_UP;
                                    SendSpace      = ProControllerButtonSHOULDER_Left_1;
                                    SendLeftShift  = ProControllerButtonSHOULDER_Right_1;
                                    SendE          = ProControllerButtonMINUS;
                                    SendB          = ProControllerButtonSTICK_Right;  
                                    SendR          = ProControllerButtonY;
                                    SendF          = ProControllerButtonX;
                                    SendX          = ProControllerButtonB;
                                    SendC          = ProControllerButtonA;
                                    SendRightClick = ProControllerButtonSHOULDER_Left_2;
                                    SendLeftClick  = ProControllerButtonSHOULDER_Right_2;
                                    SendH          = ProControllerButtonSTICK_Left;
                                    SendEscape     = ProControllerButtonHOME;
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
                                Subcommand3ProController(0x06, new byte[] { 0x01 }, 1);
                                Prohid_close(handlePro);
                                handlePro.Close();
                            }
                            catch { }
                        }
                        private static double Scale(double value, double min, double max, double minScale, double maxScale)
                        {
                            double scaled = minScale + (double)(value - min) / (max - min) * (maxScale - minScale);
                            return scaled;
                        }
                        private static void taskDPro()
                        {
                            while (running)
                            {
                                try
                                {
                                    Prohid_read_timeout(handlePro, report_bufPro, (UIntPtr)report_lenPro);
                                }
                                catch { }
                            }
                        }
                        public const string vendor_id = ""57e"", vendor_id_ = ""057e"", product_pro = ""2009"";
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
                        public static void InitProController()
                        {
                            try
                            {
                                stick_rawleftPro[0] = report_bufPro[6 + (ISPRO ? 0 : 3)];
                                stick_rawleftPro[1] = report_bufPro[7 + (ISPRO ? 0 : 3)];
                                stick_rawleftPro[2] = report_bufPro[8 + (ISPRO ? 0 : 3)];
                                stickCenterleftPro[0] = (UInt16)(stick_rawleftPro[0] | ((stick_rawleftPro[1] & 0xf) << 8));
                                stickCenterleftPro[1] = (UInt16)((stick_rawleftPro[1] >> 4) | (stick_rawleftPro[2] << 4));
                                stick_rawrightPro[0] = report_bufPro[6 + (!ISPRO ? 0 : 3)];
                                stick_rawrightPro[1] = report_bufPro[7 + (!ISPRO ? 0 : 3)];
                                stick_rawrightPro[2] = report_bufPro[8 + (!ISPRO ? 0 : 3)];
                                stickCenterrightPro[0] = (UInt16)(stick_rawrightPro[0] | ((stick_rawrightPro[1] & 0xf) << 8));
                                stickCenterrightPro[1] = (UInt16)((stick_rawrightPro[1] >> 4) | (stick_rawrightPro[2] << 4));
                                acc_gcalibrationProX = (Int16)(report_bufPro[13 + 0 * 12] | ((report_bufPro[14 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufPro[13 + 1 * 12] | ((report_bufPro[14 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufPro[13 + 2 * 12] | ((report_bufPro[14 + 2 * 12] << 8) & 0xff00));
                                acc_gcalibrationProY = (Int16)(report_bufPro[15 + 0 * 12] | ((report_bufPro[16 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufPro[15 + 1 * 12] | ((report_bufPro[16 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufPro[15 + 2 * 12] | ((report_bufPro[16 + 2 * 12] << 8) & 0xff00));
                                acc_gcalibrationProZ = (Int16)(report_bufPro[17 + 0 * 12] | ((report_bufPro[18 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufPro[17 + 1 * 12] | ((report_bufPro[18 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufPro[17 + 2 * 12] | ((report_bufPro[18 + 2 * 12] << 8) & 0xff00));
                            }
                            catch { }
                        }
                        public static void ProcessButtonsAndSticksPro()
                        {
                            try
                            {
                                if (ProControllerStickCenter)
                                {
                                    stick_rawleftPro[0] = report_bufPro[6 + (ISPRO ? 0 : 3)];
                                    stick_rawleftPro[1] = report_bufPro[7 + (ISPRO ? 0 : 3)];
                                    stick_rawleftPro[2] = report_bufPro[8 + (ISPRO ? 0 : 3)];
                                    stickCenterleftPro[0] = (UInt16)(stick_rawleftPro[0] | ((stick_rawleftPro[1] & 0xf) << 8));
                                    stickCenterleftPro[1] = (UInt16)((stick_rawleftPro[1] >> 4) | (stick_rawleftPro[2] << 4));
                                    stick_rawrightPro[0] = report_bufPro[6 + (!ISPRO ? 0 : 3)];
                                    stick_rawrightPro[1] = report_bufPro[7 + (!ISPRO ? 0 : 3)];
                                    stick_rawrightPro[2] = report_bufPro[8 + (!ISPRO ? 0 : 3)];
                                    stickCenterrightPro[0] = (UInt16)(stick_rawrightPro[0] | ((stick_rawrightPro[1] & 0xf) << 8));
                                    stickCenterrightPro[1] = (UInt16)((stick_rawrightPro[1] >> 4) | (stick_rawrightPro[2] << 4));
                                }
                                stick_rawleftPro[0] = report_bufPro[6 + (ISPRO ? 0 : 3)];
                                stick_rawleftPro[1] = report_bufPro[7 + (ISPRO ? 0 : 3)];
                                stick_rawleftPro[2] = report_bufPro[8 + (ISPRO ? 0 : 3)];
                                stickleftPro[0] = ((UInt16)(stick_rawleftPro[0] | ((stick_rawleftPro[1] & 0xf) << 8)) - stickCenterleftPro[0]) / 1440f;
                                stickleftPro[1] = ((UInt16)((stick_rawleftPro[1] >> 4) | (stick_rawleftPro[2] << 4)) - stickCenterleftPro[1]) / 1440f;
                                ProControllerLeftStickX = stickleftPro[0];
                                ProControllerLeftStickY = stickleftPro[1];
                                stick_rawrightPro[0] = report_bufPro[6 + (!ISPRO ? 0 : 3)];
                                stick_rawrightPro[1] = report_bufPro[7 + (!ISPRO ? 0 : 3)];
                                stick_rawrightPro[2] = report_bufPro[8 + (!ISPRO ? 0 : 3)];
                                stickrightPro[0] = ((UInt16)(stick_rawrightPro[0] | ((stick_rawrightPro[1] & 0xf) << 8)) - stickCenterrightPro[0]) / 1440f;
                                stickrightPro[1] = ((UInt16)((stick_rawrightPro[1] >> 4) | (stick_rawrightPro[2] << 4)) - stickCenterrightPro[1]) / 1440f;
                                ProControllerRightStickX = -stickrightPro[0];
                                ProControllerRightStickY = -stickrightPro[1];
                                acc_gPro.X = ((Int16)(report_bufPro[13 + 0 * 12] | ((report_bufPro[14 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufPro[13 + 1 * 12] | ((report_bufPro[14 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufPro[13 + 2 * 12] | ((report_bufPro[14 + 2 * 12] << 8) & 0xff00)) - acc_gcalibrationProX) * (1.0f / 12000f);
                                acc_gPro.Y = -((Int16)(report_bufPro[15 + 0 * 12] | ((report_bufPro[16 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufPro[15 + 1 * 12] | ((report_bufPro[16 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufPro[15 + 2 * 12] | ((report_bufPro[16 + 2 * 12] << 8) & 0xff00)) - acc_gcalibrationProY) * (1.0f / 12000f);
                                acc_gPro.Z = -((Int16)(report_bufPro[17 + 0 * 12] | ((report_bufPro[18 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufPro[17 + 1 * 12] | ((report_bufPro[18 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufPro[17 + 2 * 12] | ((report_bufPro[18 + 2 * 12] << 8) & 0xff00)) - acc_gcalibrationProZ) * (1.0f / 12000f);
                                ProControllerButtonSHOULDER_Left_1 = (report_bufPro[3 + (ISPRO ? 2 : 0)] & 0x40) != 0;
                                ProControllerButtonSHOULDER_Left_2 = (report_bufPro[3 + (ISPRO ? 2 : 0)] & 0x80) != 0;
                                ProControllerButtonDPAD_DOWN = (report_bufPro[3 + (ISPRO ? 2 : 0)] & (ISPRO ? 0x01 : 0x04)) != 0;
                                ProControllerButtonDPAD_RIGHT = (report_bufPro[3 + (ISPRO ? 2 : 0)] & (ISPRO ? 0x04 : 0x08)) != 0;
                                ProControllerButtonDPAD_UP = (report_bufPro[3 + (ISPRO ? 2 : 0)] & (ISPRO ? 0x02 : 0x02)) != 0;
                                ProControllerButtonDPAD_LEFT = (report_bufPro[3 + (ISPRO ? 2 : 0)] & (ISPRO ? 0x08 : 0x01)) != 0;
                                ProControllerButtonMINUS = (report_bufPro[4] & 0x01) != 0;
                                ProControllerButtonCAPTURE = (report_bufPro[4] & 0x20) != 0;
                                ProControllerButtonSTICK_Left = (report_bufPro[4] & (ISPRO ? 0x08 : 0x04)) != 0;
                                ProControllerButtonACC = acc_gPro.X <= -1.13;
                                ProControllerButtonSHOULDER_Right_1 = (report_bufPro[3 + (!ISPRO ? 2 : 0)] & 0x40) != 0;
                                ProControllerButtonSHOULDER_Right_2 = (report_bufPro[3 + (!ISPRO ? 2 : 0)] & 0x80) != 0;
                                ProControllerButtonA = (report_bufPro[3 + (!ISPRO ? 2 : 0)] & (!ISPRO ? 0x04 : 0x08)) != 0;
                                ProControllerButtonB = (report_bufPro[3 + (!ISPRO ? 2 : 0)] & (!ISPRO ? 0x01 : 0x04)) != 0;
                                ProControllerButtonX = (report_bufPro[3 + (!ISPRO ? 2 : 0)] & (!ISPRO ? 0x02 : 0x02)) != 0;
                                ProControllerButtonY = (report_bufPro[3 + (!ISPRO ? 2 : 0)] & (!ISPRO ? 0x08 : 0x01)) != 0;
                                ProControllerButtonPLUS = (report_bufPro[4] & 0x02) != 0;
                                ProControllerButtonHOME = (report_bufPro[4] & 0x10) != 0;
                                ProControllerButtonSTICK_Right = ((report_bufPro[4] & (!ISPRO ? 0x08 : 0x04)) != 0);
                                if (ProValListY.Count >= 50)
                                {
                                    ProValListY.RemoveAt(0);
                                    ProValListY.Add(acc_gPro.Y);
                                }
                                else
                                    ProValListY.Add(acc_gPro.Y);
                                if (ProControllerAccelCenter)
                                    InitDirectAnglesPro = acc_gPro;
                                DirectAnglesPro = acc_gPro - InitDirectAnglesPro;
                                ProControllerAccelX = DirectAnglesPro.X * 1350f;
                                ProControllerAccelY = -DirectAnglesPro.Y * 1350f;
                                gyr_gPro.X = ((Int16)(report_bufPro[19 + 0 * 12] | ((report_bufPro[20 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufPro[19 + 1 * 12] | ((report_bufPro[20 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufPro[19 + 2 * 12] | ((report_bufPro[20 + 2 * 12] << 8) & 0xff00)));
                                gyr_gPro.Y = ((Int16)(report_bufPro[21 + 0 * 12] | ((report_bufPro[22 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufPro[21 + 1 * 12] | ((report_bufPro[22 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufPro[21 + 2 * 12] | ((report_bufPro[22 + 2 * 12] << 8) & 0xff00)));
                                gyr_gPro.Z = ((Int16)(report_bufPro[23 + 0 * 12] | ((report_bufPro[24 + 0 * 12] << 8) & 0xff00)) + (Int16)(report_bufPro[23 + 1 * 12] | ((report_bufPro[24 + 1 * 12] << 8) & 0xff00)) + (Int16)(report_bufPro[23 + 2 * 12] | ((report_bufPro[24 + 2 * 12] << 8) & 0xff00)));
                                ProControllerGyroX = gyr_gPro.Z;
                                ProControllerGyroY = gyr_gPro.Y;
                            }
                            catch { }
                        }
                        public static bool ProControllerButtonACC, ProControllerRollLeft, ProControllerRollRight;
                        private static double ProControllerLeftStickX, ProControllerLeftStickY, ProControllerRightStickX, ProControllerRightStickY;
                        public static System.Collections.Generic.List<double> ProValListX = new System.Collections.Generic.List<double>(), ProValListY = new System.Collections.Generic.List<double>();
                        public static bool ProControllerAccelCenter, ProControllerStickCenter;
                        public static double ProControllerAccelX, ProControllerAccelY, ProControllerGyroX, ProControllerGyroY;
                        private static double[] stickleftPro = { 0, 0 };
                        private static double[] stickCenterleftPro = { 0, 0 };
                        private static byte[] stick_rawleftPro = { 0, 0, 0 };
                        private static double[] stickrightPro = { 0, 0 };
                        private static double[] stickCenterrightPro = { 0, 0 };
                        private static byte[] stick_rawrightPro = { 0, 0, 0 };
                        public static SafeFileHandle handlePro;
                        public static Vector3 acc_gPro = new Vector3();
                        public static Vector3 gyr_gPro = new Vector3();
                        public const uint report_lenPro = 49;
                        public static Vector3 InitDirectAnglesPro, DirectAnglesPro;
                        public static bool ProControllerButtonSHOULDER_Left_1, ProControllerButtonSHOULDER_Left_2, ProControllerButtonSHOULDER_Right_1, ProControllerButtonSHOULDER_Right_2, ProControllerButtonDPAD_DOWN, ProControllerButtonDPAD_RIGHT, ProControllerButtonDPAD_UP, ProControllerButtonDPAD_LEFT, ProControllerButtonA, ProControllerButtonB, ProControllerButtonX, ProControllerButtonY, ProControllerButtonMINUS, ProControllerButtonPLUS, ProControllerButtonSTICK_Left, ProControllerButtonSTICK_Right, ProControllerButtonCAPTURE, ProControllerButtonHOME, ISPRO;
                        public static byte[] report_bufPro = new byte[report_lenPro];
                        public static float acc_gcalibrationProX, acc_gcalibrationProY, acc_gcalibrationProZ;
                        private static bool ScanPro()
                        {
                            ISPRO = false;
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
                                    if ((diDetail.DevicePath.Contains(vendor_id) | diDetail.DevicePath.Contains(vendor_id_)) & diDetail.DevicePath.Contains(product_pro))
                                    {
                                        ISPRO = true;
                                        AttachProController(diDetail.DevicePath);
                                        return true;
                                    }
                                }
                                index++;
                            }
                            return false;
                        }
                        private static void AttachProController(string path)
                        {
                            do
                            {
                                IntPtr handle = CreateFile(path, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite, new System.IntPtr(), System.IO.FileMode.Open, EFileAttributes.Normal, new System.IntPtr());
                                handlePro = Prohid_open_path(handle);
                                Subcommand1ProController(0x06, new byte[] { 0x01 }, 1);
                                Subcommand2ProController(0x40, new byte[] { 0x1 }, 1);
                                Subcommand2ProController(0x3, new byte[] { 0x30 }, 1);
                                Subcommand2ProController(0x40, new byte[] { 0x1 }, 1);
                                Subcommand2ProController(0x3, new byte[] { 0x30 }, 1);
                            }
                            while (handlePro.IsInvalid);
                        }
                        private static void Subcommand1ProController(byte sc, byte[] buf, uint len)
                        {
                            byte[] buf_Pro = new byte[report_lenPro];
                            System.Array.Copy(buf, 0, buf_Pro, 11, len);
                            buf_Pro[10] = sc;
                            buf_Pro[1] = 0x2;
                            buf_Pro[0] = 0x80;
                            Prohid_write(handlePro, buf_Pro, new UIntPtr(2));
                            Prohid_read_timeout(handlePro, buf_Pro, (UIntPtr)report_lenPro);
                            buf_Pro[1] = 0x3;
                            buf_Pro[0] = 0x80;
                            Prohid_write(handlePro, buf_Pro, new UIntPtr(2));
                            Prohid_read_timeout(handlePro, buf_Pro, (UIntPtr)report_lenPro);
                            buf_Pro[1] = 0x2;
                            buf_Pro[0] = 0x80;
                            Prohid_write(handlePro, buf_Pro, new UIntPtr(2));
                            Prohid_read_timeout(handlePro, buf_Pro, (UIntPtr)report_lenPro);
                            buf_Pro[1] = 0x4;
                            buf_Pro[0] = 0x80;
                            Prohid_write(handlePro, buf_Pro, new UIntPtr(2));
                            Prohid_read_timeout(handlePro, buf_Pro, (UIntPtr)report_lenPro);
                        }
                        private static void Subcommand2ProController(byte sc, byte[] buf, uint len)
                        {
                            byte[] buf_Pro = new byte[report_lenPro];
                            System.Array.Copy(buf, 0, buf_Pro, 11, len);
                            buf_Pro[10] = sc;
                            buf_Pro[1] = 0;
                            buf_Pro[0] = 0x1;
                            Prohid_write(handlePro, buf_Pro, (UIntPtr)(len + 11));
                            Prohid_read_timeout(handlePro, buf_Pro, (UIntPtr)report_lenPro);
                        }
                        private static void Subcommand3ProController(byte sc, byte[] buf, uint len)
                        {
                            byte[] buf_Pro = new byte[report_lenPro];
                            System.Array.Copy(buf, 0, buf_Pro, 11, len);
                            buf_Pro[10] = sc;
                            buf_Pro[1] = 0x5;
                            buf_Pro[0] = 0x80;
                            Prohid_write(handlePro, buf_Pro, new UIntPtr(2));
                            buf_Pro[1] = 0x6;
                            buf_Pro[0] = 0x80;
                            Prohid_write(handlePro, buf_Pro, new UIntPtr(2));
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