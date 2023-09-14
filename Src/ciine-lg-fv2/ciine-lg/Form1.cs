using System;
using System.Windows.Forms;
using System.Reflection;
using System.Text;

namespace ciine_lg
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
                using SharpDX.DirectInput;
                using SharpDX;
                using keyboards;
                using mouses;
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
                        DirectInput directInput = new DirectInput();
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
                            DirectInputHookConnect();
                            Task.Run(() => taskKM());
                        }
                        private void taskKM()
                        {
                            while (running)
                            {
                                GamepadProcess();
                                valchanged(0, Joystick1Buttons11);
                                if (wd[0] == 1 & !getstate[0]) 
                                {
                                    KeyboardMouseDriverType = ""kmevent"";
                                    width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                                    height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
                                    getstate[0] = true;
                                }
                                else 
                                { 
                                    if (wd[0] == 1 & getstate[0]) 
                                    {
                                        MouseMoveX            = 0;
                                        MouseMoveY            = 0;
                                        MouseDesktopX         = 0;
                                        MouseDesktopY         = 0;
                                        MouseAbsX             = 0;
                                        MouseAbsY             = 0;
                                        SendD                 = false;
                                        SendQ                 = false;
                                        SendZ                 = false;
                                        SendS                 = false;
                                        Send8                 = false;
                                        Send7                 = false;
                                        Send9                 = false;
                                        Send6                 = false;
                                        SendB                 = false;  
                                        Send1                 = false;
                                        Send2                 = false;
                                        Send3                 = false;
                                        Send4                 = false;
                                        SendSpace             = false;
                                        SendLeftShift         = false;
                                        SendE                 = false;
                                        SendA                 = false;
                                        SendV                 = false;
                                        SendEscape            = false;
                                        SendTab               = false;
                                        SendR                 = false;
                                        SendF                 = false;
                                        SendT                 = false;
                                        SendG                 = false;
                                        SendY                 = false; 
                                        SendU                 = false;
                                        SendX                 = false;
                                        SendC                 = false;
                                        SendRightClick        = false;
                                        SendLeftClick         = false;
                                        getstate[0]    = false;
                                    }
                                }
                                if (getstate[0]) 
                                {
                                    if (Joystick1Buttons12)
                                    {
                                        mousexp[0] = 0f;
                                        mouseyp[0] = 0f;
                                    }
                                    mousexp[0] += (Joystick1AxisZ - 65535f / 2f) * width / 2f / 1024f * 2f / 5000f;
                                    mouseyp[0] += (Joystick1RotationZ - 65535f / 2f) * height / 2f / 1024f * 2f / 5000f;
                                    if (mousexp[0] >= width / 2f) 
                                        mousexp[0] = width / 2f;
                                    if (mousexp[0] <= -width / 2f) 
                                        mousexp[0] = -width / 2f;
                                    if (mouseyp[0] >= height / 2f) 
                                        mouseyp[0] = height / 2f;
                                    if (mouseyp[0] <= -height / 2f) 
                                        mouseyp[0] = -height / 2f;
                                    MouseDesktopX  = width / 2f + mousexp[0] + (Joystick1AxisZ - 65535f / 2f) * width / 2f / 1024f * 2f / 5000f;
                                    MouseDesktopY  = height / 2f + mouseyp[0] + (Joystick1RotationZ - 65535f / 2f) * height / 2f / 1024f * 2f / 5000f;
                                    SendD          = Joystick1AxisX - 65535f / 2f > 32767f / 5f;
                                    SendQ          = Joystick1AxisX - 65535f / 2f < -32767f / 5f;
                                    SendZ          = Joystick1AxisY - 65535f / 2f > 32767f / 5f;
                                    SendS          = Joystick1AxisY - 65535f / 2f < -32767f / 5f;
                                    Send1          = Joystick1PointOfViewControllers0 == 4500 | Joystick1PointOfViewControllers0 == 0 | Joystick1PointOfViewControllers0 == 31500;
                                    Send2          = Joystick1PointOfViewControllers0 == 22500 | Joystick1PointOfViewControllers0 == 27000 | Joystick1PointOfViewControllers0 == 31500;
                                    Send3          = Joystick1PointOfViewControllers0 == 22500 | Joystick1PointOfViewControllers0 == 18000 | Joystick1PointOfViewControllers0 == 13500;
                                    Send4          = Joystick1PointOfViewControllers0 == 4500 | Joystick1PointOfViewControllers0 == 9000 | Joystick1PointOfViewControllers0 == 13500; 
                                    SendRightClick = Joystick1Buttons9;
                                    SendLeftClick  = Joystick1Buttons10;
                                    SendR          = Joystick1Buttons1;
                                    SendF          = Joystick1Buttons2;
                                    SendX          = Joystick1Buttons3;
                                    SendC          = Joystick1Buttons4;
                                    SendA          = Joystick1Buttons5;
                                    SendE          = Joystick1Buttons6;
                                    SendSpace      = Joystick1Buttons7;
                                    SendLeftShift  = Joystick1Buttons8;
                                    SendTab        = Joystick1Buttons13;
                                    SendEscape     = Joystick1Buttons14;
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
                        private static Joystick[] joystick = new Joystick[] { null };
                        private static Guid[] joystickGuid = new Guid[] { Guid.Empty };
                        private static int dinum = 0;
                        public static int Joystick1AxisX;
                        public static int Joystick1AxisY;
                        public static int Joystick1AxisZ;
                        public static int Joystick1RotationX;
                        public static int Joystick1RotationY;
                        public static int Joystick1RotationZ;
                        public static int Joystick1Sliders0;
                        public static int Joystick1Sliders1;
                        public static int Joystick1PointOfViewControllers0;
                        public static int Joystick1PointOfViewControllers1;
                        public static int Joystick1PointOfViewControllers2;
                        public static int Joystick1PointOfViewControllers3;
                        public static int Joystick1VelocityX;
                        public static int Joystick1VelocityY;
                        public static int Joystick1VelocityZ;
                        public static int Joystick1AngularVelocityX;
                        public static int Joystick1AngularVelocityY;
                        public static int Joystick1AngularVelocityZ;
                        public static int Joystick1VelocitySliders0;
                        public static int Joystick1VelocitySliders1;
                        public static int Joystick1AccelerationX;
                        public static int Joystick1AccelerationY;
                        public static int Joystick1AccelerationZ;
                        public static int Joystick1AngularAccelerationX;
                        public static int Joystick1AngularAccelerationY;
                        public static int Joystick1AngularAccelerationZ;
                        public static int Joystick1AccelerationSliders0;
                        public static int Joystick1AccelerationSliders1;
                        public static int Joystick1ForceX;
                        public static int Joystick1ForceY;
                        public static int Joystick1ForceZ;
                        public static int Joystick1TorqueX;
                        public static int Joystick1TorqueY;
                        public static int Joystick1TorqueZ;
                        public static int Joystick1ForceSliders0;
                        public static int Joystick1ForceSliders1;
                        public static bool Joystick1Buttons0, Joystick1Buttons1, Joystick1Buttons2, Joystick1Buttons3, Joystick1Buttons4, Joystick1Buttons5, Joystick1Buttons6, Joystick1Buttons7, Joystick1Buttons8, Joystick1Buttons9, Joystick1Buttons10, Joystick1Buttons11, Joystick1Buttons12, Joystick1Buttons13, Joystick1Buttons14, Joystick1Buttons15, Joystick1Buttons16, Joystick1Buttons17, Joystick1Buttons18, Joystick1Buttons19, Joystick1Buttons20, Joystick1Buttons21, Joystick1Buttons22, Joystick1Buttons23, Joystick1Buttons24, Joystick1Buttons25, Joystick1Buttons26, Joystick1Buttons27, Joystick1Buttons28, Joystick1Buttons29, Joystick1Buttons30, Joystick1Buttons31, Joystick1Buttons32, Joystick1Buttons33, Joystick1Buttons34, Joystick1Buttons35, Joystick1Buttons36, Joystick1Buttons37, Joystick1Buttons38, Joystick1Buttons39, Joystick1Buttons40, Joystick1Buttons41, Joystick1Buttons42, Joystick1Buttons43, Joystick1Buttons44, Joystick1Buttons45, Joystick1Buttons46, Joystick1Buttons47, Joystick1Buttons48, Joystick1Buttons49, Joystick1Buttons50, Joystick1Buttons51, Joystick1Buttons52, Joystick1Buttons53, Joystick1Buttons54, Joystick1Buttons55, Joystick1Buttons56, Joystick1Buttons57, Joystick1Buttons58, Joystick1Buttons59, Joystick1Buttons60, Joystick1Buttons61, Joystick1Buttons62, Joystick1Buttons63, Joystick1Buttons64, Joystick1Buttons65, Joystick1Buttons66, Joystick1Buttons67, Joystick1Buttons68, Joystick1Buttons69, Joystick1Buttons70, Joystick1Buttons71, Joystick1Buttons72, Joystick1Buttons73, Joystick1Buttons74, Joystick1Buttons75, Joystick1Buttons76, Joystick1Buttons77, Joystick1Buttons78, Joystick1Buttons79, Joystick1Buttons80, Joystick1Buttons81, Joystick1Buttons82, Joystick1Buttons83, Joystick1Buttons84, Joystick1Buttons85, Joystick1Buttons86, Joystick1Buttons87, Joystick1Buttons88, Joystick1Buttons89, Joystick1Buttons90, Joystick1Buttons91, Joystick1Buttons92, Joystick1Buttons93, Joystick1Buttons94, Joystick1Buttons95, Joystick1Buttons96, Joystick1Buttons97, Joystick1Buttons98, Joystick1Buttons99, Joystick1Buttons100, Joystick1Buttons101, Joystick1Buttons102, Joystick1Buttons103, Joystick1Buttons104, Joystick1Buttons105, Joystick1Buttons106, Joystick1Buttons107, Joystick1Buttons108, Joystick1Buttons109, Joystick1Buttons110, Joystick1Buttons111, Joystick1Buttons112, Joystick1Buttons113, Joystick1Buttons114, Joystick1Buttons115, Joystick1Buttons116, Joystick1Buttons117, Joystick1Buttons118, Joystick1Buttons119, Joystick1Buttons120, Joystick1Buttons121, Joystick1Buttons122, Joystick1Buttons123, Joystick1Buttons124, Joystick1Buttons125, Joystick1Buttons126, Joystick1Buttons127;
                        public bool DirectInputHookConnect()
                        {
                            try
                            {
                                directInput = new DirectInput();
                                joystick = new Joystick[] { null };
                                joystickGuid = new Guid[] { Guid.Empty };
                                dinum = 0;
                                foreach (var deviceInstance in directInput.GetDevices(SharpDX.DirectInput.DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
                                {
                                    joystickGuid[dinum] = deviceInstance.InstanceGuid;
                                    dinum++;
                                    if (dinum >= 1)
                                    {
                                        break;
                                    }
                                }
                                if (dinum < 1)
                                {
                                    foreach (var deviceInstance in directInput.GetDevices(SharpDX.DirectInput.DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
                                    {
                                        joystickGuid[dinum] = deviceInstance.InstanceGuid;
                                        dinum++;
                                        if (dinum >= 1)
                                        {
                                            break;
                                        }
                                    }
                                }
                                if (dinum < 1)
                                {
                                    foreach (var deviceInstance in directInput.GetDevices(SharpDX.DirectInput.DeviceType.Flight, DeviceEnumerationFlags.AllDevices))
                                    {
                                        joystickGuid[dinum] = deviceInstance.InstanceGuid;
                                        dinum++;
                                        if (dinum >= 1)
                                        {
                                            break;
                                        }
                                    }
                                }
                                if (dinum < 1)
                                {
                                    foreach (var deviceInstance in directInput.GetDevices(SharpDX.DirectInput.DeviceType.FirstPerson, DeviceEnumerationFlags.AllDevices))
                                    {
                                        joystickGuid[dinum] = deviceInstance.InstanceGuid;
                                        dinum++;
                                        if (dinum >= 1)
                                        {
                                            break;
                                        }
                                    }
                                }
                                if (dinum < 1)
                                {
                                    foreach (var deviceInstance in directInput.GetDevices(SharpDX.DirectInput.DeviceType.Driving, DeviceEnumerationFlags.AllDevices))
                                    {
                                        joystickGuid[dinum] = deviceInstance.InstanceGuid;
                                        dinum++;
                                        if (dinum >= 1)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                            catch { }
                            if (joystickGuid[0] == Guid.Empty)
                            {
                                return false;
                            }
                            else
                            {
                                for (int inc = 0; inc < dinum; inc++)
                                {
                                    joystick[inc] = new Joystick(directInput, joystickGuid[inc]);
                                    joystick[inc].Properties.BufferSize = 128;
                                    joystick[inc].Acquire();
                                }
                                return true;
                            }
                        }
                        private void GamepadProcess()
                        {
                            for (int inc = 0; inc < dinum; inc++)
                            {
                                joystick[inc].Poll();
                                var datas = joystick[inc].GetBufferedData();
                                foreach (var state in datas)
                                {
                                    if (inc == 0 & state.Offset == JoystickOffset.X)
                                        Joystick1AxisX = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.Y)
                                        Joystick1AxisY = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.Z)
                                        Joystick1AxisZ = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.RotationX)
                                        Joystick1RotationX = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.RotationY)
                                        Joystick1RotationY = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.RotationZ)
                                        Joystick1RotationZ = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.Sliders0)
                                        Joystick1Sliders0 = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.Sliders1)
                                        Joystick1Sliders1 = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.PointOfViewControllers0)
                                        Joystick1PointOfViewControllers0 = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.PointOfViewControllers1)
                                        Joystick1PointOfViewControllers1 = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.PointOfViewControllers2)
                                        Joystick1PointOfViewControllers2 = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.PointOfViewControllers3)
                                        Joystick1PointOfViewControllers3 = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.VelocityX)
                                        Joystick1VelocityX = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.VelocityY)
                                        Joystick1VelocityY = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.VelocityZ)
                                        Joystick1VelocityZ = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.AngularVelocityX)
                                        Joystick1AngularVelocityX = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.AngularVelocityY)
                                        Joystick1AngularVelocityY = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.AngularVelocityZ)
                                        Joystick1AngularVelocityZ = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.VelocitySliders0)
                                        Joystick1VelocitySliders0 = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.VelocitySliders1)
                                        Joystick1VelocitySliders1 = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.AccelerationX)
                                        Joystick1AccelerationX = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.AccelerationY)
                                        Joystick1AccelerationY = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.AccelerationZ)
                                        Joystick1AccelerationZ = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.AngularAccelerationX)
                                        Joystick1AngularAccelerationX = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.AngularAccelerationY)
                                        Joystick1AngularAccelerationY = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.AngularAccelerationZ)
                                        Joystick1AngularAccelerationZ = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.AccelerationSliders0)
                                        Joystick1AccelerationSliders0 = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.AccelerationSliders1)
                                        Joystick1AccelerationSliders1 = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.ForceX)
                                        Joystick1ForceX = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.ForceY)
                                        Joystick1ForceY = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.ForceZ)
                                        Joystick1ForceZ = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.TorqueX)
                                        Joystick1TorqueX = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.TorqueY)
                                        Joystick1TorqueY = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.TorqueZ)
                                        Joystick1TorqueZ = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.ForceSliders0)
                                        Joystick1ForceSliders0 = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.ForceSliders1)
                                        Joystick1ForceSliders1 = state.Value;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons0 & state.Value == 128)
                                        Joystick1Buttons0 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons0 & state.Value == 0)
                                        Joystick1Buttons0 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons1 & state.Value == 128)
                                        Joystick1Buttons1 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons1 & state.Value == 0)
                                        Joystick1Buttons1 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons2 & state.Value == 128)
                                        Joystick1Buttons2 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons2 & state.Value == 0)
                                        Joystick1Buttons2 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons3 & state.Value == 128)
                                        Joystick1Buttons3 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons3 & state.Value == 0)
                                        Joystick1Buttons3 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons4 & state.Value == 128)
                                        Joystick1Buttons4 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons4 & state.Value == 0)
                                        Joystick1Buttons4 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons5 & state.Value == 128)
                                        Joystick1Buttons5 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons5 & state.Value == 0)
                                        Joystick1Buttons5 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons6 & state.Value == 128)
                                        Joystick1Buttons6 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons6 & state.Value == 0)
                                        Joystick1Buttons6 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons7 & state.Value == 128)
                                        Joystick1Buttons7 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons7 & state.Value == 0)
                                        Joystick1Buttons7 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons8 & state.Value == 128)
                                        Joystick1Buttons8 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons8 & state.Value == 0)
                                        Joystick1Buttons8 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons9 & state.Value == 128)
                                        Joystick1Buttons9 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons9 & state.Value == 0)
                                        Joystick1Buttons9 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons10 & state.Value == 128)
                                        Joystick1Buttons10 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons10 & state.Value == 0)
                                        Joystick1Buttons10 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons11 & state.Value == 128)
                                        Joystick1Buttons11 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons11 & state.Value == 0)
                                        Joystick1Buttons11 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons12 & state.Value == 128)
                                        Joystick1Buttons12 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons12 & state.Value == 0)
                                        Joystick1Buttons12 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons13 & state.Value == 128)
                                        Joystick1Buttons13 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons13 & state.Value == 0)
                                        Joystick1Buttons13 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons14 & state.Value == 128)
                                        Joystick1Buttons14 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons14 & state.Value == 0)
                                        Joystick1Buttons14 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons15 & state.Value == 128)
                                        Joystick1Buttons15 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons15 & state.Value == 0)
                                        Joystick1Buttons15 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons16 & state.Value == 128)
                                        Joystick1Buttons16 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons16 & state.Value == 0)
                                        Joystick1Buttons16 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons17 & state.Value == 128)
                                        Joystick1Buttons17 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons17 & state.Value == 0)
                                        Joystick1Buttons17 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons18 & state.Value == 128)
                                        Joystick1Buttons18 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons18 & state.Value == 0)
                                        Joystick1Buttons18 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons19 & state.Value == 128)
                                        Joystick1Buttons19 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons19 & state.Value == 0)
                                        Joystick1Buttons19 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons20 & state.Value == 128)
                                        Joystick1Buttons20 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons20 & state.Value == 0)
                                        Joystick1Buttons20 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons21 & state.Value == 128)
                                        Joystick1Buttons21 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons21 & state.Value == 0)
                                        Joystick1Buttons21 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons22 & state.Value == 128)
                                        Joystick1Buttons22 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons22 & state.Value == 0)
                                        Joystick1Buttons22 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons23 & state.Value == 128)
                                        Joystick1Buttons23 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons23 & state.Value == 0)
                                        Joystick1Buttons23 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons24 & state.Value == 128)
                                        Joystick1Buttons24 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons24 & state.Value == 0)
                                        Joystick1Buttons24 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons25 & state.Value == 128)
                                        Joystick1Buttons25 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons25 & state.Value == 0)
                                        Joystick1Buttons25 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons26 & state.Value == 128)
                                        Joystick1Buttons26 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons26 & state.Value == 0)
                                        Joystick1Buttons26 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons27 & state.Value == 128)
                                        Joystick1Buttons27 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons27 & state.Value == 0)
                                        Joystick1Buttons27 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons28 & state.Value == 128)
                                        Joystick1Buttons28 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons28 & state.Value == 0)
                                        Joystick1Buttons28 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons29 & state.Value == 128)
                                        Joystick1Buttons29 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons29 & state.Value == 0)
                                        Joystick1Buttons29 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons30 & state.Value == 128)
                                        Joystick1Buttons30 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons30 & state.Value == 0)
                                        Joystick1Buttons30 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons31 & state.Value == 128)
                                        Joystick1Buttons31 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons31 & state.Value == 0)
                                        Joystick1Buttons31 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons32 & state.Value == 128)
                                        Joystick1Buttons32 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons32 & state.Value == 0)
                                        Joystick1Buttons32 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons33 & state.Value == 128)
                                        Joystick1Buttons33 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons33 & state.Value == 0)
                                        Joystick1Buttons33 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons34 & state.Value == 128)
                                        Joystick1Buttons34 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons34 & state.Value == 0)
                                        Joystick1Buttons34 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons35 & state.Value == 128)
                                        Joystick1Buttons35 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons35 & state.Value == 0)
                                        Joystick1Buttons35 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons36 & state.Value == 128)
                                        Joystick1Buttons36 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons36 & state.Value == 0)
                                        Joystick1Buttons36 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons37 & state.Value == 128)
                                        Joystick1Buttons37 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons37 & state.Value == 0)
                                        Joystick1Buttons37 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons38 & state.Value == 128)
                                        Joystick1Buttons38 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons38 & state.Value == 0)
                                        Joystick1Buttons38 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons39 & state.Value == 128)
                                        Joystick1Buttons39 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons39 & state.Value == 0)
                                        Joystick1Buttons39 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons40 & state.Value == 128)
                                        Joystick1Buttons40 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons40 & state.Value == 0)
                                        Joystick1Buttons40 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons41 & state.Value == 128)
                                        Joystick1Buttons41 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons41 & state.Value == 0)
                                        Joystick1Buttons41 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons42 & state.Value == 128)
                                        Joystick1Buttons42 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons42 & state.Value == 0)
                                        Joystick1Buttons42 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons43 & state.Value == 128)
                                        Joystick1Buttons43 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons43 & state.Value == 0)
                                        Joystick1Buttons43 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons44 & state.Value == 128)
                                        Joystick1Buttons44 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons44 & state.Value == 0)
                                        Joystick1Buttons44 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons45 & state.Value == 128)
                                        Joystick1Buttons45 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons45 & state.Value == 0)
                                        Joystick1Buttons45 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons46 & state.Value == 128)
                                        Joystick1Buttons46 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons46 & state.Value == 0)
                                        Joystick1Buttons46 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons47 & state.Value == 128)
                                        Joystick1Buttons47 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons47 & state.Value == 0)
                                        Joystick1Buttons47 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons48 & state.Value == 128)
                                        Joystick1Buttons48 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons48 & state.Value == 0)
                                        Joystick1Buttons48 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons49 & state.Value == 128)
                                        Joystick1Buttons49 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons49 & state.Value == 0)
                                        Joystick1Buttons49 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons50 & state.Value == 128)
                                        Joystick1Buttons50 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons50 & state.Value == 0)
                                        Joystick1Buttons50 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons51 & state.Value == 128)
                                        Joystick1Buttons51 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons51 & state.Value == 0)
                                        Joystick1Buttons51 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons52 & state.Value == 128)
                                        Joystick1Buttons52 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons52 & state.Value == 0)
                                        Joystick1Buttons52 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons53 & state.Value == 128)
                                        Joystick1Buttons53 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons53 & state.Value == 0)
                                        Joystick1Buttons53 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons54 & state.Value == 128)
                                        Joystick1Buttons54 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons54 & state.Value == 0)
                                        Joystick1Buttons54 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons55 & state.Value == 128)
                                        Joystick1Buttons55 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons55 & state.Value == 0)
                                        Joystick1Buttons55 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons56 & state.Value == 128)
                                        Joystick1Buttons56 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons56 & state.Value == 0)
                                        Joystick1Buttons56 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons57 & state.Value == 128)
                                        Joystick1Buttons57 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons57 & state.Value == 0)
                                        Joystick1Buttons57 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons58 & state.Value == 128)
                                        Joystick1Buttons58 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons58 & state.Value == 0)
                                        Joystick1Buttons58 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons59 & state.Value == 128)
                                        Joystick1Buttons59 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons59 & state.Value == 0)
                                        Joystick1Buttons59 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons60 & state.Value == 128)
                                        Joystick1Buttons60 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons60 & state.Value == 0)
                                        Joystick1Buttons60 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons61 & state.Value == 128)
                                        Joystick1Buttons61 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons61 & state.Value == 0)
                                        Joystick1Buttons61 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons62 & state.Value == 128)
                                        Joystick1Buttons62 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons62 & state.Value == 0)
                                        Joystick1Buttons62 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons63 & state.Value == 128)
                                        Joystick1Buttons63 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons63 & state.Value == 0)
                                        Joystick1Buttons63 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons64 & state.Value == 128)
                                        Joystick1Buttons64 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons64 & state.Value == 0)
                                        Joystick1Buttons64 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons65 & state.Value == 128)
                                        Joystick1Buttons65 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons65 & state.Value == 0)
                                        Joystick1Buttons65 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons66 & state.Value == 128)
                                        Joystick1Buttons66 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons66 & state.Value == 0)
                                        Joystick1Buttons66 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons67 & state.Value == 128)
                                        Joystick1Buttons67 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons67 & state.Value == 0)
                                        Joystick1Buttons67 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons68 & state.Value == 128)
                                        Joystick1Buttons68 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons68 & state.Value == 0)
                                        Joystick1Buttons68 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons69 & state.Value == 128)
                                        Joystick1Buttons69 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons69 & state.Value == 0)
                                        Joystick1Buttons69 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons70 & state.Value == 128)
                                        Joystick1Buttons70 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons70 & state.Value == 0)
                                        Joystick1Buttons70 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons71 & state.Value == 128)
                                        Joystick1Buttons71 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons71 & state.Value == 0)
                                        Joystick1Buttons71 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons72 & state.Value == 128)
                                        Joystick1Buttons72 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons72 & state.Value == 0)
                                        Joystick1Buttons72 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons73 & state.Value == 128)
                                        Joystick1Buttons73 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons73 & state.Value == 0)
                                        Joystick1Buttons73 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons74 & state.Value == 128)
                                        Joystick1Buttons74 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons74 & state.Value == 0)
                                        Joystick1Buttons74 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons75 & state.Value == 128)
                                        Joystick1Buttons75 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons75 & state.Value == 0)
                                        Joystick1Buttons75 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons76 & state.Value == 128)
                                        Joystick1Buttons76 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons76 & state.Value == 0)
                                        Joystick1Buttons76 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons77 & state.Value == 128)
                                        Joystick1Buttons77 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons77 & state.Value == 0)
                                        Joystick1Buttons77 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons78 & state.Value == 128)
                                        Joystick1Buttons78 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons78 & state.Value == 0)
                                        Joystick1Buttons78 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons79 & state.Value == 128)
                                        Joystick1Buttons79 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons79 & state.Value == 0)
                                        Joystick1Buttons79 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons80 & state.Value == 128)
                                        Joystick1Buttons80 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons80 & state.Value == 0)
                                        Joystick1Buttons80 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons81 & state.Value == 128)
                                        Joystick1Buttons81 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons81 & state.Value == 0)
                                        Joystick1Buttons81 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons82 & state.Value == 128)
                                        Joystick1Buttons82 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons82 & state.Value == 0)
                                        Joystick1Buttons82 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons83 & state.Value == 128)
                                        Joystick1Buttons83 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons83 & state.Value == 0)
                                        Joystick1Buttons83 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons84 & state.Value == 128)
                                        Joystick1Buttons84 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons84 & state.Value == 0)
                                        Joystick1Buttons84 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons85 & state.Value == 128)
                                        Joystick1Buttons85 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons85 & state.Value == 0)
                                        Joystick1Buttons85 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons86 & state.Value == 128)
                                        Joystick1Buttons86 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons86 & state.Value == 0)
                                        Joystick1Buttons86 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons87 & state.Value == 128)
                                        Joystick1Buttons87 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons87 & state.Value == 0)
                                        Joystick1Buttons87 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons88 & state.Value == 128)
                                        Joystick1Buttons88 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons88 & state.Value == 0)
                                        Joystick1Buttons88 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons89 & state.Value == 128)
                                        Joystick1Buttons89 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons89 & state.Value == 0)
                                        Joystick1Buttons89 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons90 & state.Value == 128)
                                        Joystick1Buttons90 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons90 & state.Value == 0)
                                        Joystick1Buttons90 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons91 & state.Value == 128)
                                        Joystick1Buttons91 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons91 & state.Value == 0)
                                        Joystick1Buttons91 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons92 & state.Value == 128)
                                        Joystick1Buttons92 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons92 & state.Value == 0)
                                        Joystick1Buttons92 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons93 & state.Value == 128)
                                        Joystick1Buttons93 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons93 & state.Value == 0)
                                        Joystick1Buttons93 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons94 & state.Value == 128)
                                        Joystick1Buttons94 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons94 & state.Value == 0)
                                        Joystick1Buttons94 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons95 & state.Value == 128)
                                        Joystick1Buttons95 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons95 & state.Value == 0)
                                        Joystick1Buttons95 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons96 & state.Value == 128)
                                        Joystick1Buttons96 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons96 & state.Value == 0)
                                        Joystick1Buttons96 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons97 & state.Value == 128)
                                        Joystick1Buttons97 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons97 & state.Value == 0)
                                        Joystick1Buttons97 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons98 & state.Value == 128)
                                        Joystick1Buttons98 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons98 & state.Value == 0)
                                        Joystick1Buttons98 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons99 & state.Value == 128)
                                        Joystick1Buttons99 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons99 & state.Value == 0)
                                        Joystick1Buttons99 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons100 & state.Value == 128)
                                        Joystick1Buttons100 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons100 & state.Value == 0)
                                        Joystick1Buttons100 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons101 & state.Value == 128)
                                        Joystick1Buttons101 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons101 & state.Value == 0)
                                        Joystick1Buttons101 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons102 & state.Value == 128)
                                        Joystick1Buttons102 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons102 & state.Value == 0)
                                        Joystick1Buttons102 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons103 & state.Value == 128)
                                        Joystick1Buttons103 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons103 & state.Value == 0)
                                        Joystick1Buttons103 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons104 & state.Value == 128)
                                        Joystick1Buttons104 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons104 & state.Value == 0)
                                        Joystick1Buttons104 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons105 & state.Value == 128)
                                        Joystick1Buttons105 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons105 & state.Value == 0)
                                        Joystick1Buttons105 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons106 & state.Value == 128)
                                        Joystick1Buttons106 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons106 & state.Value == 0)
                                        Joystick1Buttons106 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons107 & state.Value == 128)
                                        Joystick1Buttons107 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons107 & state.Value == 0)
                                        Joystick1Buttons107 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons108 & state.Value == 128)
                                        Joystick1Buttons108 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons108 & state.Value == 0)
                                        Joystick1Buttons108 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons109 & state.Value == 128)
                                        Joystick1Buttons109 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons109 & state.Value == 0)
                                        Joystick1Buttons109 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons110 & state.Value == 128)
                                        Joystick1Buttons110 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons110 & state.Value == 0)
                                        Joystick1Buttons110 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons111 & state.Value == 128)
                                        Joystick1Buttons111 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons111 & state.Value == 0)
                                        Joystick1Buttons111 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons112 & state.Value == 128)
                                        Joystick1Buttons112 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons112 & state.Value == 0)
                                        Joystick1Buttons112 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons113 & state.Value == 128)
                                        Joystick1Buttons113 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons113 & state.Value == 0)
                                        Joystick1Buttons113 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons114 & state.Value == 128)
                                        Joystick1Buttons114 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons114 & state.Value == 0)
                                        Joystick1Buttons114 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons115 & state.Value == 128)
                                        Joystick1Buttons115 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons115 & state.Value == 0)
                                        Joystick1Buttons115 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons116 & state.Value == 128)
                                        Joystick1Buttons116 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons116 & state.Value == 0)
                                        Joystick1Buttons116 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons117 & state.Value == 128)
                                        Joystick1Buttons117 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons117 & state.Value == 0)
                                        Joystick1Buttons117 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons118 & state.Value == 128)
                                        Joystick1Buttons118 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons118 & state.Value == 0)
                                        Joystick1Buttons118 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons119 & state.Value == 128)
                                        Joystick1Buttons119 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons119 & state.Value == 0)
                                        Joystick1Buttons119 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons120 & state.Value == 128)
                                        Joystick1Buttons120 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons120 & state.Value == 0)
                                        Joystick1Buttons120 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons121 & state.Value == 128)
                                        Joystick1Buttons121 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons121 & state.Value == 0)
                                        Joystick1Buttons121 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons122 & state.Value == 128)
                                        Joystick1Buttons122 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons122 & state.Value == 0)
                                        Joystick1Buttons122 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons123 & state.Value == 128)
                                        Joystick1Buttons123 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons123 & state.Value == 0)
                                        Joystick1Buttons123 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons124 & state.Value == 128)
                                        Joystick1Buttons124 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons124 & state.Value == 0)
                                        Joystick1Buttons124 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons125 & state.Value == 128)
                                        Joystick1Buttons125 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons125 & state.Value == 0)
                                        Joystick1Buttons125 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons126 & state.Value == 128)
                                        Joystick1Buttons126 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons126 & state.Value == 0)
                                        Joystick1Buttons126 = false;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons127 & state.Value == 128)
                                        Joystick1Buttons127 = true;
                                    if (inc == 0 & state.Offset == JoystickOffset.Buttons127 & state.Value == 0)
                                        Joystick1Buttons127 = false;
                                }
                            }
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
            parameters.ReferencedAssemblies.Add("SharpDX.dll");
            parameters.ReferencedAssemblies.Add("SharpDX.DirectInput.dll");
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