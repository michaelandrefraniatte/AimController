mousex     = -(Joystick1AxisX - 32767f) / 20f; 
mousey     = (Joystick1AxisY - 32767f) / 20f;
controller1_send_leftstickx = Math.Abs(-mousex * 32767f / 1024f) <= 32767f ? -mousex * 32767f / 1024f : Math.Sign(-mousex) * 32767f;
controller1_send_leftsticky = Math.Abs(-mousey * 32767f / 1024f) <= 32767f ? -mousey * 32767f / 1024f : Math.Sign(-mousey) * 32767f;
if (Joystick1Buttons12 | Joystick1Buttons15)
{
    mousexp[0] = 0f;
    mouseyp[0] = 0f;
}
mousexp[0] += Math.Round((Joystick1AxisZ - 65535f / 2f) / 10000f, 0f) * 2.0;
mouseyp[0] += Math.Round((Joystick1RotationZ - 65535f / 2f) / 10000f, 0f) * 2.0f;
if (mousexp[0] >= 1024f) 
    mousexp[0] = 1024f;
if (mousexp[0] <= -1024f) 
    mousexp[0] = -1024f;
if (mouseyp[0] >= 1024f) 
    mouseyp[0] = 1024f;
if (mouseyp[0] <= -1024f) 
    mouseyp[0] = -1024f;
mousex                        = -mousexp[0] - Math.Round((Joystick1AxisZ - 65535f / 2f) / 10000f, 0f) * 2.0f;
mousey                        = mouseyp[0] + Math.Round((Joystick1RotationZ - 65535f / 2f) / 10000f, 0f) * 2.0f;
controller1_send_rightstickx  = Math.Abs(-mousex * 32767f / 1024f) <= 32767f ? -mousex * 32767f / 1024f : Math.Sign(-mousex) * 32767f;
controller1_send_rightsticky  = Math.Abs(-mousey * 32767f / 1024f) <= 32767f ? -mousey * 32767f / 1024f : Math.Sign(-mousey) * 32767f;
controller1_send_up           = Joystick1PointOfViewControllers0 == 4500 | Joystick1PointOfViewControllers0 == 0 | Joystick1PointOfViewControllers0 == 31500;
controller1_send_left         = Joystick1PointOfViewControllers0 == 22500 | Joystick1PointOfViewControllers0 == 27000 | Joystick1PointOfViewControllers0 == 31500;
controller1_send_down         = Joystick1PointOfViewControllers0 == 22500 | Joystick1PointOfViewControllers0 == 18000 | Joystick1PointOfViewControllers0 == 13500;
controller1_send_right        = Joystick1PointOfViewControllers0 == 4500 | Joystick1PointOfViewControllers0 == 9000 | Joystick1PointOfViewControllers0 == 13500;
controller1_send_back         = Joystick1Buttons11;
controller1_send_start        = Joystick1Buttons12;
controller1_send_leftstick    = Joystick1Buttons13;
controller1_send_rightstick   = Joystick1Buttons14;
controller1_send_leftbumper   = Joystick1Buttons4;
controller1_send_rightbumper  = Joystick1Buttons5;
controller1_send_A            = Joystick1Buttons1;
controller1_send_B            = Joystick1Buttons2;
controller1_send_X            = Joystick1Buttons0;
controller1_send_Y            = Joystick1Buttons3;
controller1_send_lefttrigger  = Joystick1Buttons9;
controller1_send_righttrigger = Joystick1Buttons10;