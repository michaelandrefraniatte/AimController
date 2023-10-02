using vJoy.Wrapper;

namespace controllersvjoy
{
    public class VJoyController
    {
        public static VirtualJoystick joystick1;
        public static void Connect()
        {
            joystick1 = new VirtualJoystick(1);
            joystick1.Aquire();
        }
        public static void Disconnect()
        {
            joystick1.Dispose();
        }
        public static void SubmitReport1(bool Controller1VJoy_Send_1, bool Controller1VJoy_Send_2, bool Controller1VJoy_Send_3, bool Controller1VJoy_Send_4, bool Controller1VJoy_Send_5, bool Controller1VJoy_Send_6, bool Controller1VJoy_Send_7, bool Controller1VJoy_Send_8, double Controller1VJoy_Send_X, double Controller1VJoy_Send_Y, double Controller1VJoy_Send_Z, double Controller1VJoy_Send_WHL, double Controller1VJoy_Send_SL0, double Controller1VJoy_Send_SL1, double Controller1VJoy_Send_RX, double Controller1VJoy_Send_RY, double Controller1VJoy_Send_RZ, double Controller1VJoy_Send_POV, double Controller1VJoy_Send_Hat, double Controller1VJoy_Send_HatExt1, double Controller1VJoy_Send_HatExt2, double Controller1VJoy_Send_HatExt3)
        {
            joystick1.SetJoystickButton(Controller1VJoy_Send_1, 1);
            joystick1.SetJoystickButton(Controller1VJoy_Send_2, 2);
            joystick1.SetJoystickButton(Controller1VJoy_Send_3, 3);
            joystick1.SetJoystickButton(Controller1VJoy_Send_4, 4);
            joystick1.SetJoystickButton(Controller1VJoy_Send_5, 5);
            joystick1.SetJoystickButton(Controller1VJoy_Send_6, 6);
            joystick1.SetJoystickButton(Controller1VJoy_Send_7, 7);
            joystick1.SetJoystickButton(Controller1VJoy_Send_8, 8);
            joystick1.SetJoystickAxis((int)Controller1VJoy_Send_X, Axis.HID_USAGE_X);
            joystick1.SetJoystickAxis((int)Controller1VJoy_Send_Y, Axis.HID_USAGE_Y);
            joystick1.SetJoystickAxis((int)Controller1VJoy_Send_Z, Axis.HID_USAGE_Z);
            joystick1.SetJoystickAxis((int)Controller1VJoy_Send_WHL, Axis.HID_USAGE_WHL);
            joystick1.SetJoystickAxis((int)Controller1VJoy_Send_SL0, Axis.HID_USAGE_SL0);
            joystick1.SetJoystickAxis((int)Controller1VJoy_Send_SL1, Axis.HID_USAGE_SL1);
            joystick1.SetJoystickAxis((int)Controller1VJoy_Send_RX, Axis.HID_USAGE_RX);
            joystick1.SetJoystickAxis((int)Controller1VJoy_Send_RY, Axis.HID_USAGE_RY);
            joystick1.SetJoystickAxis((int)Controller1VJoy_Send_RZ, Axis.HID_USAGE_RZ);
            joystick1.SetJoystickAxis((int)Controller1VJoy_Send_POV, Axis.HID_USAGE_POV);
            joystick1.SetJoystickHat((int)Controller1VJoy_Send_Hat, Hats.Hat);
            joystick1.SetJoystickHat((int)Controller1VJoy_Send_HatExt1, Hats.HatExt1);
            joystick1.SetJoystickHat((int)Controller1VJoy_Send_HatExt2, Hats.HatExt2);
            joystick1.SetJoystickHat((int)Controller1VJoy_Send_HatExt3, Hats.HatExt3);
            joystick1.Update();
        }
    }
}