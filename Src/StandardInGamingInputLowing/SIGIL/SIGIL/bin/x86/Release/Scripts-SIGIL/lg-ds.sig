sleeptime = 8;
valchanged(0, PS5ControllerButtonCreatePressed); 
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
    mousexp[0] += Math.Round(PS5ControllerGyroX * 65535f / 2f / 1024f * 2f / 5000f, 0);
    mouseyp[0] += Math.Round(PS5ControllerGyroY * 65535f / 2f / 1024f * 2f / 5000f, 0);
    if (mousexp[0] >= width / 2f) 
        mousexp[0] = width / 2f;
    if (mousexp[0] <= -width / 2f) 
        mousexp[0] = -width / 2f;
    if (mouseyp[0] >= height / 2f) 
        mouseyp[0] = height / 2f;
    if (mouseyp[0] <= -height / 2f) 
        mouseyp[0] = -height / 2f;
    MouseDesktopX  = width / 2f - mousexp[0] - Math.Round(PS5ControllerGyroX * 65535f / 2f / 1024f * 2f / 5000f, 0);
    MouseDesktopY  = height / 2f + mouseyp[0] + Math.Round(PS5ControllerGyroY * 65535f / 2f / 1024f * 2f / 5000f, 0);
    SendD          = PS5ControllerLeftStickX > 0.35f;
    SendA          = PS5ControllerLeftStickX < -0.35f;
    SendW          = PS5ControllerLeftStickY > 0.35f;
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