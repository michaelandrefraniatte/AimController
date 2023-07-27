valchanged(0, Joystick1Buttons11);
if (wd[0] == 1 & !getstate[0])  
{
    KeyboardMouseDriverType = "kmevent";
    width                   = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
    height                  = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
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
    if (Joystick1Buttons12 | Joystick1Buttons15)
    {
        mousexp[0] = 0f;
        mouseyp[0] = 0f;
    }
    mousexp[0] += Math.Round((Joystick1AxisZ - 65535f / 2f) * width / 2f / 1024f * 2f / 6000f, 0) * 0.5f;
    mouseyp[0] += Math.Round((Joystick1RotationZ - 65535f / 2f) * height / 2f / 1024f * 2f / 6000f, 0) * 0.5f;
    if (mousexp[0] >= width / 2f) 
        mousexp[0] = width / 2f;
    if (mousexp[0] <= -width / 2f) 
        mousexp[0] = -width / 2f;
    if (mouseyp[0] >= height / 2f) 
        mouseyp[0] = height / 2f;
    if (mouseyp[0] <= -height / 2f) 
        mouseyp[0] = -height / 2f;
    MouseDesktopX  = width / 2f + mousexp[0] + Math.Round((Joystick1AxisZ - 65535f / 2f) * width / 2f / 1024f * 2f / 6000f, 0) * 0.5f;
    MouseDesktopY  = height / 2f + mouseyp[0] + Math.Round((Joystick1RotationZ - 65535f / 2f) * height / 2f / 1024f * 2f / 6000f, 0) * 0.5f;
    SendD          = Joystick1AxisX - 65535f / 2f > 32767f / 2f;
    SendQ          = Joystick1AxisX - 65535f / 2f < -32767f / 2f;
    SendS          = Joystick1AxisY - 65535f / 2f > 32767f / 2f;
    SendZ          = Joystick1AxisY - 65535f / 2f < -32767f / 2f;
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
    SendY          = Joystick1Buttons7;
    SendU          = Joystick1Buttons8;
    SendTab        = Joystick1Buttons13;
    SendEscape     = Joystick1Buttons14;
}