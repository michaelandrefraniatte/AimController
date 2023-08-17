sleeptime        = 8;
valchanged(0, JoyconRightButtonHOME);
if (wd[0] == 1 & !getstate[0]) 
{
    width                 = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
    height                = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
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
        getstate[0]       = false;
    }
}
if (getstate[0]) 
{
    if (JoyconRightButtonPLUS)
    {
        mousexp[0] = 0f;
        mouseyp[0] = 0f;
    }
    mousexp[0] += Math.Round(JoyconRightGyroX * width / 2f / 1024f * 2f / 200f, 0) * 1f;
    mouseyp[0] += Math.Round(JoyconRightGyroY * height / 2f / 1024f * 2f / 200f, 0) * 1f;
    if (mousexp[0] >= width / 2f) 
        mousexp[0] = width / 2f;
    if (mousexp[0] <= -width / 2f) 
        mousexp[0] = -width / 2f;
    if (mouseyp[0] >= height / 2f) 
        mouseyp[0] = height / 2f;
    if (mouseyp[0] <= -height / 2f) 
        mouseyp[0] = -height / 2f;
    MouseDesktopX  = width / 2f + mousexp[0] + Math.Round(JoyconRightGyroX * width / 2f / 1024f * 2f / 200f, 0) * 1f;
    MouseDesktopY  = height / 2f - mouseyp[0] - Math.Round(JoyconRightGyroY * height / 2f / 1024f * 2f / 200f, 0) * 1f;
    SendD          = JoyconRightStickX < 0.35f;
    SendQ          = JoyconRightStickX > -0.35f;
    SendZ          = JoyconRightStickY < 0.35f;
    SendS          = JoyconRightStickY > -0.35f;
    Send1          = JoyconRightButtonDPAD_UP;
    Send2          = JoyconRightButtonDPAD_LEFT;
    Send3          = JoyconRightButtonDPAD_DOWN;
    Send4          = JoyconRightButtonDPAD_RIGHT;
    SendE          = JoyconRightButtonSR;
    SendA          = JoyconRightButtonSL;
    SendV          = JoyconRightButtonSTICK;
    SendLeftClick  = JoyconRightButtonSHOULDER_2;
    SendRightClick = JoyconRightButtonSHOULDER_1;
}