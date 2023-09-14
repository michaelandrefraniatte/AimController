using System;
using System.Windows.Forms;
using System.Reflection;
using System.Text;

namespace ciine_ga_ds4
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
                using controllers;
                using DualShock4API;
                using DualShock4API.State;
                using DualShock4API.Util;
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
                        private static bool back, start, A, B, X, Y, up, left, down, right, leftstick, rightstick, leftbumper, rightbumper, lefttrigger, righttrigger, xbox;
                        private static double leftstickx, leftsticky, rightstickx, rightsticky, lefttriggerposition, righttriggerposition;
                        private double statex = 0f, statey = 0f, mousex = 0f, mousey = 0f, mousestatex = 0f, mousestatey = 0f, dzx = 0.0f, dzy = 0.0f, viewpower1x = 0f, viewpower2x = 1f, viewpower3x = 0f, viewpower1y = 0.25f, viewpower2y = 0.75f, viewpower3y = 0f;
                        private bool[] getstate = new bool[12];
                        private int[] pollcount = new int[12];
                        private int[] keys12345 = new int[12];
                        private int[] keys54321 = new int[12];
                        private double[] mousexp = new double[12];
                        private double[] mouseyp = new double[12];
                        private int sleeptime = 1;
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
                            ds4 = DS4ChooseController();
                            if (ds4 != null)
                            {
                                Task.Run(() => DS4MainAsyncPolling());
                                ScpBus.LoadController();
                                Task.Run(() => taskX());
                            }
                        }
                        private void taskX()
                        {
                            while (running)
                            {
                                ds4wheelPos = DS4ProcessStateLogic(ds4.InputState, ds4wheelPos);
                                statex = PS4ControllerGyroX * 15f;
                                statey = PS4ControllerGyroY * 15f;
                                if (statex > 0f)
                                    mousestatex = Scale(statex, 0f, 32767f, dzx / 100f * 32767f, 32767f);
                                if (statex < 0f)
                                    mousestatex = Scale(statex, -32767f, 0f, -32767f, -(dzx / 100f) * 32767f);
                                if (statey > 0f)
                                    mousestatey = Scale(statey, 0f, 32767f, dzy / 100f * 32767f, 32767f);
                                if (statey < 0f)
                                    mousestatey = Scale(statey, -32767f, 0f, -32767f, -(dzy / 100f) * 32767f);
                                mousex = mousestatex + PS4ControllerRightStickX * 32767f;
                                mousey = mousestatey + PS4ControllerRightStickY * 32767f;
                                statex = Math.Abs(mousex) <= 32767f ? mousex : Math.Sign(mousex) * 32767f;
                                statey = Math.Abs(mousey) <= 32767f ? mousey : Math.Sign(mousey) * 32767f;
                                rightstickx = -statex;
                                rightsticky = -statey;
                                mousex = -PS4ControllerLeftStickX * 1024f;
                                mousey = -PS4ControllerLeftStickY * 1024f;
                                leftstickx = Math.Abs(-mousex * 32767f / 1024f) <= 32767f ? -mousex * 32767f / 1024f : Math.Sign(-mousex) * 32767f;
                                leftsticky = Math.Abs(-mousey * 32767f / 1024f) <= 32767f ? -mousey * 32767f / 1024f : Math.Sign(-mousey) * 32767f;
                                down = PS4ControllerButtonDPadDownPressed;
                                left = PS4ControllerButtonDPadLeftPressed;
                                right = PS4ControllerButtonDPadRightPressed;
                                up = PS4ControllerButtonDPadUpPressed;
                                leftstick = PS4ControllerButtonL3Pressed;
                                rightstick = PS4ControllerButtonR3Pressed;
                                B = PS4ControllerButtonCrossPressed;
                                A = PS4ControllerButtonCirclePressed;
                                Y = PS4ControllerButtonSquarePressed;
                                X = PS4ControllerButtonTrianglePressed;
                                lefttriggerposition = PS4ControllerLeftTriggerPosition * 255;
                                righttriggerposition = PS4ControllerRightTriggerPosition * 255;
                                leftbumper = PS4ControllerButtonL1Pressed;
                                rightbumper = PS4ControllerButtonR1Pressed;
                                back = PS4ControllerButtonLogoPressed;
                                start = PS4ControllerButtonTouchpadPressed;
                                ScpBus.SetController(back, start, A, B, X, Y, up, left, down, right, leftstick, rightstick, leftbumper, rightbumper, lefttrigger, righttrigger, leftstickx, leftsticky, rightstickx, rightsticky, lefttriggerposition, righttriggerposition, xbox);
                                Thread.Sleep(sleeptime);
                            }
                        }
                        public void Close()
                        {
                            try
                            {
                                running = false;
                                Thread.Sleep(100);
                                ScpBus.UnLoadController();
                            }
                            catch { }
                        }
                        private static double Scale(double value, double min, double max, double minScale, double maxScale)
                        {
                            double scaled = minScale + (double)(value - min) / (max - min) * (maxScale - minScale);
                            return scaled;
                        }
                        public static bool PS4ControllerButtonCrossPressed;
                        public static bool PS4ControllerButtonCirclePressed;
                        public static bool PS4ControllerButtonSquarePressed;
                        public static bool PS4ControllerButtonTrianglePressed;
                        public static bool PS4ControllerButtonDPadUpPressed;
                        public static bool PS4ControllerButtonDPadRightPressed;
                        public static bool PS4ControllerButtonDPadDownPressed;
                        public static bool PS4ControllerButtonDPadLeftPressed;
                        public static bool PS4ControllerButtonL1Pressed;
                        public static bool PS4ControllerButtonR1Pressed;
                        public static bool PS4ControllerButtonL2Pressed;
                        public static bool PS4ControllerButtonR2Pressed;
                        public static bool PS4ControllerButtonL3Pressed;
                        public static bool PS4ControllerButtonR3Pressed;
                        public static bool PS4ControllerButtonCreatePressed;
                        public static bool PS4ControllerButtonMenuPressed;
                        public static bool PS4ControllerButtonLogoPressed;
                        public static bool PS4ControllerButtonTouchpadPressed;
                        public static bool PS4ControllerButtonMicPressed;
                        public static bool PS4ControllerTouchOn;
                        public static bool PS4ControllerButtonACC, PS4ControllerRollLeft, PS4ControllerRollRight;
                        private static double PS4ControllerLeftStickX, PS4ControllerLeftStickY, PS4ControllerRightStickX, PS4ControllerRightStickY, PS4ControllerRightTriggerPosition, PS4ControllerLeftTriggerPosition, PS4ControllerTouchX, PS4ControllerTouchY;
                        public static System.Collections.Generic.List<double> PS4ValListX = new System.Collections.Generic.List<double>(), PS4ValListY = new System.Collections.Generic.List<double>();
                        public static bool PS4ControllerAccelCenter;
                        public static double PS4ControllerAccelX, PS4ControllerAccelY, PS4ControllerGyroX, PS4ControllerGyroY;
                        public static Vector3 gyr_gPS4 = new Vector3();
                        public static Vector3 acc_gPS4 = new Vector3();
                        public static Vector3 InitDirectAnglesPS4, DirectAnglesPS4;
                        public static float acc_gcalibrationPS4X, acc_gcalibrationPS4Y, acc_gcalibrationPS4Z;
                        private static DualShock4 ds4;
                        private static int ds4wheelPos = 0;
                        static int DS4ProcessStateLogic(DualShock4InputState ds4s, int ds4wheelPos)
                        {
                            PS4ControllerLeftStickX = ds4s.LeftAnalogStick.X;
                            PS4ControllerLeftStickY = ds4s.LeftAnalogStick.Y;
                            PS4ControllerRightStickX = -ds4s.RightAnalogStick.X;
                            PS4ControllerRightStickY = -ds4s.RightAnalogStick.Y;
                            PS4ControllerLeftTriggerPosition = ds4s.L2;
                            PS4ControllerRightTriggerPosition = ds4s.R2;
                            PS4ControllerTouchX = ds4s.Touchpad1.X;
                            PS4ControllerTouchY = ds4s.Touchpad1.Y;
                            PS4ControllerTouchOn = ds4s.Touchpad1.IsDown;
                            gyr_gPS4.X = ds4s.Gyro.Z;
                            gyr_gPS4.Y = -ds4s.Gyro.X;
                            gyr_gPS4.Z = -ds4s.Gyro.Y;
                            PS4ControllerGyroX = gyr_gPS4.Z;
                            PS4ControllerGyroY = gyr_gPS4.Y;
                            acc_gPS4 = new Vector3(ds4s.Accelerometer.X, ds4s.Accelerometer.Z, ds4s.Accelerometer.Y);
                            if (PS4ControllerAccelCenter)
                                InitDirectAnglesPS4 = acc_gPS4;
                            DirectAnglesPS4 = acc_gPS4 - InitDirectAnglesPS4;
                            PS4ControllerAccelX = -(DirectAnglesPS4.Y + DirectAnglesPS4.Z) / 6f;
                            PS4ControllerAccelY = DirectAnglesPS4.X / 6f;
                            IEnumerable<string> pressedButtons = ds4s.GetType().GetProperties()
                                .Where(p => p.Name.EndsWith(""Button"") && p.PropertyType == typeof(bool))
                                .Where(p => (bool)p.GetValue(ds4s))
                                .Select(p => p.Name.Replace(""Button"", """"));
                            string joined = string.Join("", "", pressedButtons);
                            if (joined.Contains(""Cross""))
                                PS4ControllerButtonCrossPressed = true;
                            else
                                PS4ControllerButtonCrossPressed = false;
                            if (joined.Contains(""Circle""))
                                PS4ControllerButtonCirclePressed = true;
                            else
                                PS4ControllerButtonCirclePressed = false;
                            if (joined.Contains(""Square""))
                                PS4ControllerButtonSquarePressed = true;
                            else
                                PS4ControllerButtonSquarePressed = false;
                            if (joined.Contains(""Triangle""))
                                PS4ControllerButtonTrianglePressed = true;
                            else
                                PS4ControllerButtonTrianglePressed = false;
                            if (joined.Contains(""DPadUp""))
                                PS4ControllerButtonDPadUpPressed = true;
                            else
                                PS4ControllerButtonDPadUpPressed = false;
                            if (joined.Contains(""DPadRight""))
                                PS4ControllerButtonDPadRightPressed = true;
                            else
                                PS4ControllerButtonDPadRightPressed = false;
                            if (joined.Contains(""DPadDown""))
                                PS4ControllerButtonDPadDownPressed = true;
                            else
                                PS4ControllerButtonDPadDownPressed = false;
                            if (joined.Contains(""DPadLeft""))
                                PS4ControllerButtonDPadLeftPressed = true;
                            else
                                PS4ControllerButtonDPadLeftPressed = false;
                            if (joined.Contains(""L1""))
                                PS4ControllerButtonL1Pressed = true;
                            else
                                PS4ControllerButtonL1Pressed = false;
                            if (joined.Contains(""R1""))
                                PS4ControllerButtonR1Pressed = true;
                            else
                                PS4ControllerButtonR1Pressed = false;
                            if (joined.Contains(""L2""))
                                PS4ControllerButtonL2Pressed = true;
                            else
                                PS4ControllerButtonL2Pressed = false;
                            if (joined.Contains(""R2""))
                                PS4ControllerButtonR2Pressed = true;
                            else
                                PS4ControllerButtonR2Pressed = false;
                            if (joined.Contains(""L3""))
                                PS4ControllerButtonL3Pressed = true;
                            else
                                PS4ControllerButtonL3Pressed = false;
                            if (joined.Contains(""R3""))
                                PS4ControllerButtonR3Pressed = true;
                            else
                                PS4ControllerButtonR3Pressed = false;
                            if (joined.Contains(""Create""))
                                PS4ControllerButtonCreatePressed = true;
                            else
                                PS4ControllerButtonCreatePressed = false;
                            if (joined.Contains(""Menu""))
                                PS4ControllerButtonMenuPressed = true;
                            else
                                PS4ControllerButtonMenuPressed = false;
                            if (joined.Contains(""Logo""))
                                PS4ControllerButtonLogoPressed = true;
                            else
                                PS4ControllerButtonLogoPressed = false;
                            if (joined.Contains(""Touchpad""))
                                PS4ControllerButtonTouchpadPressed = true;
                            else
                                PS4ControllerButtonTouchpadPressed = false;
                            if (joined.Contains(""Mic""))
                                PS4ControllerButtonMicPressed = true;
                            else
                                PS4ControllerButtonMicPressed = false;
                            return (ds4wheelPos + 5) % 384;
                        }
                        static T DS4Choose<T>(T[] ts)
                        {
                            return ts[0];
                        }
                        static DualShock4 DS4ChooseController()
                        {
                            DualShock4[] available = DualShock4.EnumerateControllers().ToArray();
                            if (available.Length == 0)
                            {
                                return null;
                            }
                            return DS4Choose(available);
                        }
                        static void DS4MainAsyncPolling()
                        {
                            ds4.Acquire();
                            while (running)
                            {
                                ds4.BeginPolling();
                                Thread.Sleep(1);
                            }
                            ds4.EndPolling();
                            ds4.Release();
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
            parameters.ReferencedAssemblies.Add("Dualshock4.dll");
            parameters.ReferencedAssemblies.Add("controllers.dll");
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