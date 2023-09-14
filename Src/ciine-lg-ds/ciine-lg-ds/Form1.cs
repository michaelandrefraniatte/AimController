using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ciine_lg_ds
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
                using System.Runtime.InteropServices;
                using System.Threading;
                using System.Threading.Tasks;
                using System.Windows;
                using System.Windows.Forms;
                using System.Reflection;
                using keyboards;
                using mouses;
                using DualSenseAPI;
                using DualSenseAPI.State;
                using DualSenseAPI.Util;
                using Device.Net;
                using System.Numerics;
                using System.Collections.Generic;
                using System.Runtime;
                using System.Linq;
                namespace StringToCode
                {
                    public class FooClass 
                    { 
                        [DllImport(""winmm.dll"", EntryPoint = ""timeBeginPeriod"")]
                        private static extern uint TimeBeginPeriod(uint ms);
                        [DllImport(""winmm.dll"", EntryPoint = ""timeEndPeriod"")]
                        private static extern uint TimeEndPeriod(uint ms);
                        [DllImport(""ntdll.dll"", EntryPoint = ""NtSetTimerResolution"")]
                        private static extern void NtSetTimerResolution(uint DesiredResolution, bool SetResolution, ref uint CurrentResolution);
                        private static uint CurrentResolution = 0;
                        private static bool running;
                        private static int width, height;
                        private double statex = 0f, statey = 0f, mousex = 0f, mousey = 0f, mousestatex = 0f, mousestatey = 0f, dzx = 0.0f, dzy = 0.0f, viewpower1x = 0f, viewpower2x = 1f, viewpower3x = 0f, viewpower1y = 0.25f, viewpower2y = 0.75f, viewpower3y = 0f;
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
                            ds = ChooseController();
                            if (ds != null)
                            {
                                Task.Run(() => MainAsyncPolling());
                                Task.Run(() => taskX());
                            }
                        }
                        private void taskX()
                        {
                            while (running)
                            {
                                wheelPos = ProcessStateLogic(ds.InputState, wheelPos);
                                valchanged(0, PS5ControllerButtonCreatePressed);
                                if (wd[0] == 1 & !getstate[0]) 
                                {
                                    KeyboardMouseDriverType = ""kmevent"";
                                    width                   = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                                    height                  = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
                                    getstate[0] = true;
                                }
                                else 
                                { 
                                    if (wd[0] == 1 & getstate[0]) 
                                    {
                                        MouseMoveX              = 0;
                                        MouseMoveY              = 0;
                                        MouseDesktopX           = 0;
                                        MouseDesktopY           = 0;
                                        MouseAbsX               = 0;
                                        MouseAbsY               = 0;
                                        SendD                   = false;
                                        SendQ                   = false;
                                        SendZ                   = false;
                                        SendS                   = false;
                                        Send8                   = false;
                                        Send7                   = false;
                                        Send9                   = false;
                                        Send6                   = false;
                                        SendB                   = false;  
                                        Send1                   = false;
                                        Send2                   = false;
                                        Send3                   = false;
                                        Send4                   = false;
                                        SendSpace               = false;
                                        SendLeftShift           = false;
                                        SendE                   = false;
                                        SendA                   = false;
                                        SendV                   = false;
                                        SendEscape              = false;
                                        SendTab                 = false;
                                        SendR                   = false;
                                        SendF                   = false;
                                        SendT                   = false;
                                        SendG                   = false;
                                        SendY                   = false; 
                                        SendU                   = false;
                                        SendX                   = false;
                                        SendC                   = false;
                                        SendRightClick          = false;
                                        SendLeftClick           = false;
                                        getstate[0]    = false;
                                    }
                                }
                                if (getstate[0]) 
                                {
                                    if (PS5ControllerButtonMenuPressed)
                                    {
                                        mousexp[0] = 0f;
                                        mouseyp[0] = 0f;
                                    }
                                    mousexp[0] += PS5ControllerGyroX * width / 2f / 1024f * 2f / 500f;
                                    mouseyp[0] += PS5ControllerGyroY * height / 2f / 1024f * 2f / 500f;
                                    if (mousexp[0] >= width / 2f) 
                                        mousexp[0] = width / 2f;
                                    if (mousexp[0] <= -width / 2f) 
                                        mousexp[0] = -width / 2f;
                                    if (mouseyp[0] >= height / 2f) 
                                        mouseyp[0] = height / 2f;
                                    if (mouseyp[0] <= -height / 2f) 
                                        mouseyp[0] = -height / 2f;
                                    MouseDesktopX  = width / 2f - mousexp[0] - PS5ControllerGyroX * width / 2f / 1024f * 2f / 500f;
                                    MouseDesktopY  = height / 2f + mouseyp[0] + PS5ControllerGyroY * height / 2f / 1024f * 2f / 500f;
                                    SendD          = PS5ControllerLeftStickX > 0.35f;
                                    SendQ          = PS5ControllerLeftStickX < -0.35f;
                                    SendZ          = PS5ControllerLeftStickY > 0.35f;
                                    SendS          = PS5ControllerLeftStickY < -0.35f;
                                    Send8          = PS5ControllerButtonDPadDownPressed;
                                    Send7          = PS5ControllerButtonDPadLeftPressed;
                                    Send9          = PS5ControllerButtonDPadRightPressed;
                                    Send6          = PS5ControllerButtonDPadUpPressed;
                                    SendSpace      = PS5ControllerButtonL1Pressed;
                                    SendLeftShift  = PS5ControllerButtonR1Pressed;
                                    SendE          = PS5ControllerButtonL3Pressed;
                                    SendB          = PS5ControllerButtonR3Pressed;
                                    SendR          = PS5ControllerButtonTrianglePressed;
                                    SendF          = PS5ControllerButtonSquarePressed;
                                    SendX          = PS5ControllerButtonCirclePressed;
                                    SendC          = PS5ControllerButtonCrossPressed;
                                    SendRightClick = PS5ControllerButtonL2Pressed;
                                    SendLeftClick  = PS5ControllerButtonR2Pressed;
                                    SendTab        = PS5ControllerButtonLogoPressed;
                                    SendEscape     = PS5ControllerButtonTouchpadPressed;
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
                            }
                            catch { }
                        }
                        private static double Scale(double value, double min, double max, double minScale, double maxScale)
                        {
                            double scaled = minScale + (double)(value - min) / (max - min) * (maxScale - minScale);
                            return scaled;
                        }
                        public static bool PS5ControllerButtonCrossPressed;
                        public static bool PS5ControllerButtonCirclePressed;
                        public static bool PS5ControllerButtonSquarePressed;
                        public static bool PS5ControllerButtonTrianglePressed;
                        public static bool PS5ControllerButtonDPadUpPressed;
                        public static bool PS5ControllerButtonDPadRightPressed;
                        public static bool PS5ControllerButtonDPadDownPressed;
                        public static bool PS5ControllerButtonDPadLeftPressed;
                        public static bool PS5ControllerButtonL1Pressed;
                        public static bool PS5ControllerButtonR1Pressed;
                        public static bool PS5ControllerButtonL2Pressed;
                        public static bool PS5ControllerButtonR2Pressed;
                        public static bool PS5ControllerButtonL3Pressed;
                        public static bool PS5ControllerButtonR3Pressed;
                        public static bool PS5ControllerButtonCreatePressed;
                        public static bool PS5ControllerButtonMenuPressed;
                        public static bool PS5ControllerButtonLogoPressed;
                        public static bool PS5ControllerButtonTouchpadPressed;
                        public static bool PS5ControllerButtonMicPressed;
                        public static bool PS5ControllerTouchOn;
                        public static bool PS5ControllerButtonACC, PS5ControllerRollLeft, PS5ControllerRollRight;
                        private static double PS5ControllerLeftStickX, PS5ControllerLeftStickY, PS5ControllerRightStickX, PS5ControllerRightStickY, PS5ControllerRightTriggerPosition, PS5ControllerLeftTriggerPosition, PS5ControllerTouchX, PS5ControllerTouchY;
                        public static System.Collections.Generic.List<double> PS5ValListX = new System.Collections.Generic.List<double>(), PS5ValListY = new System.Collections.Generic.List<double>();
                        public static bool PS5ControllerAccelCenter;
                        public static double PS5ControllerAccelX, PS5ControllerAccelY, PS5ControllerGyroX, PS5ControllerGyroY;
                        public static Vector3 gyr_gPS5 = new Vector3();
                        public static Vector3 acc_gPS5 = new Vector3();
                        public static Vector3 InitDirectAnglesPS5, DirectAnglesPS5;
                        public static float acc_gcalibrationPS5X, acc_gcalibrationPS5Y, acc_gcalibrationPS5Z;
                        private static DualSense ds;
                        private static int wheelPos = 0;
                        static int ProcessStateLogic(DualSenseInputState dss, int wheelPos)
                        {
                            PS5ControllerLeftStickX = dss.LeftAnalogStick.X;
                            PS5ControllerLeftStickY = dss.LeftAnalogStick.Y;
                            PS5ControllerRightStickX = -dss.RightAnalogStick.X;
                            PS5ControllerRightStickY = -dss.RightAnalogStick.Y;
                            PS5ControllerLeftTriggerPosition = dss.L2;
                            PS5ControllerRightTriggerPosition = dss.R2;
                            PS5ControllerTouchX = dss.Touchpad1.X;
                            PS5ControllerTouchY = dss.Touchpad1.Y;
                            PS5ControllerTouchOn = dss.Touchpad1.IsDown;
                            gyr_gPS5.X = dss.Gyro.Z;
                            gyr_gPS5.Y = -dss.Gyro.X;
                            gyr_gPS5.Z = -dss.Gyro.Y;
                            PS5ControllerGyroX = gyr_gPS5.Z;
                            PS5ControllerGyroY = gyr_gPS5.Y;
                            acc_gPS5 = new Vector3(dss.Accelerometer.X, dss.Accelerometer.Z, dss.Accelerometer.Y);
                            if (PS5ControllerAccelCenter)
                                InitDirectAnglesPS5 = acc_gPS5;
                            DirectAnglesPS5 = acc_gPS5 - InitDirectAnglesPS5;
                            PS5ControllerAccelX = -(DirectAnglesPS5.Y + DirectAnglesPS5.Z) / 6f;
                            PS5ControllerAccelY = DirectAnglesPS5.X / 6f;
                            IEnumerable<string> pressedButtons = dss.GetType().GetProperties()
                                .Where(p => p.Name.EndsWith(""Button"") && p.PropertyType == typeof(bool))
                                .Where(p => (bool)p.GetValue(dss))
                                .Select(p => p.Name.Replace(""Button"", """"));
                            string joined = string.Join("", "", pressedButtons);
                            if (joined.Contains(""Cross""))
                                PS5ControllerButtonCrossPressed = true;
                            else
                                PS5ControllerButtonCrossPressed = false;
                            if (joined.Contains(""Circle""))
                                PS5ControllerButtonCirclePressed = true;
                            else
                                PS5ControllerButtonCirclePressed = false;
                            if (joined.Contains(""Square""))
                                PS5ControllerButtonSquarePressed = true;
                            else
                                PS5ControllerButtonSquarePressed = false;
                            if (joined.Contains(""Triangle""))
                                PS5ControllerButtonTrianglePressed = true;
                            else
                                PS5ControllerButtonTrianglePressed = false;
                            if (joined.Contains(""DPadUp""))
                                PS5ControllerButtonDPadUpPressed = true;
                            else
                                PS5ControllerButtonDPadUpPressed = false;
                            if (joined.Contains(""DPadRight""))
                                PS5ControllerButtonDPadRightPressed = true;
                            else
                                PS5ControllerButtonDPadRightPressed = false;
                            if (joined.Contains(""DPadDown""))
                                PS5ControllerButtonDPadDownPressed = true;
                            else
                                PS5ControllerButtonDPadDownPressed = false;
                            if (joined.Contains(""DPadLeft""))
                                PS5ControllerButtonDPadLeftPressed = true;
                            else
                                PS5ControllerButtonDPadLeftPressed = false;
                            if (joined.Contains(""L1""))
                                PS5ControllerButtonL1Pressed = true;
                            else
                                PS5ControllerButtonL1Pressed = false;
                            if (joined.Contains(""R1""))
                                PS5ControllerButtonR1Pressed = true;
                            else
                                PS5ControllerButtonR1Pressed = false;
                            if (joined.Contains(""L2""))
                                PS5ControllerButtonL2Pressed = true;
                            else
                                PS5ControllerButtonL2Pressed = false;
                            if (joined.Contains(""R2""))
                                PS5ControllerButtonR2Pressed = true;
                            else
                                PS5ControllerButtonR2Pressed = false;
                            if (joined.Contains(""L3""))
                                PS5ControllerButtonL3Pressed = true;
                            else
                                PS5ControllerButtonL3Pressed = false;
                            if (joined.Contains(""R3""))
                                PS5ControllerButtonR3Pressed = true;
                            else
                                PS5ControllerButtonR3Pressed = false;
                            if (joined.Contains(""Create""))
                                PS5ControllerButtonCreatePressed = true;
                            else
                                PS5ControllerButtonCreatePressed = false;
                            if (joined.Contains(""Menu""))
                                PS5ControllerButtonMenuPressed = true;
                            else
                                PS5ControllerButtonMenuPressed = false;
                            if (joined.Contains(""Logo""))
                                PS5ControllerButtonLogoPressed = true;
                            else
                                PS5ControllerButtonLogoPressed = false;
                            if (joined.Contains(""Touchpad""))
                                PS5ControllerButtonTouchpadPressed = true;
                            else
                                PS5ControllerButtonTouchpadPressed = false;
                            if (joined.Contains(""Mic""))
                                PS5ControllerButtonMicPressed = true;
                            else
                                PS5ControllerButtonMicPressed = false;
                            return (wheelPos + 5) % 384;
                        }
                        static T Choose<T>(T[] ts)
                        {
                            return ts[0];
                        }
                        static DualSense ChooseController()
                        {
                            DualSense[] available = DualSense.EnumerateControllers().ToArray();
                            if (available.Length == 0)
                            {
                                return null;
                            }
                            return Choose(available);
                        }
                        static void MainAsyncPolling()
                        {
                            ds.Acquire();
                            while (running)
                            {
                                ds.BeginPolling();
                                Thread.Sleep(1);
                            }
                            ds.EndPolling();
                            ds.Release();
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
            parameters.ReferencedAssemblies.Add("System.Runtime.dll");
            parameters.ReferencedAssemblies.Add("System.Numerics.dll");
            parameters.ReferencedAssemblies.Add("System.Core.dll");
            parameters.ReferencedAssemblies.Add("netstandard.dll");
            parameters.ReferencedAssemblies.Add("Hid.Net.dll");
            parameters.ReferencedAssemblies.Add("Device.Net.dll");
            parameters.ReferencedAssemblies.Add("Dualsense.dll");
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