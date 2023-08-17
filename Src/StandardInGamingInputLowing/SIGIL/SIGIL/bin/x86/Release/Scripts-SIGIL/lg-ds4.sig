sleeptime = 8;
valchanged(0, PS4ControllerButtonCreatePressed);
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
    if (PS4ControllerButtonMenuPressed)
    {
        mousexp[0] = 0f;
        mouseyp[0] = 0f;
    }
    mousexp[0] += Math.Round(PS4ControllerGyroX * 65535f / 2f / 1024f * 2f / 5000f, 0) * 1.5f;
    mouseyp[0] += Math.Round(PS4ControllerGyroY * 65535f / 2f / 1024f * 2f / 5000f, 0) * 1.5f;
    if (mousexp[0] >= width / 2f) 
        mousexp[0] = width / 2f;
    if (mousexp[0] <= -width / 2f) 
        mousexp[0] = -width / 2f;
    if (mouseyp[0] >= height / 2f) 
        mouseyp[0] = height / 2f;
    if (mouseyp[0] <= -height / 2f) 
        mouseyp[0] = -height / 2f;
    MouseDesktopX  = width / 2f - mousexp[0] - Math.Round(PS4ControllerGyroX * 65535f / 2f / 1024f * 2f / 5000f, 0) * 1.5f;
    MouseDesktopY  = height / 2f + mouseyp[0] + Math.Round(PS4ControllerGyroY * 65535f / 2f / 1024f * 2f / 5000f, 0) * 1.5f;
    SendD          = PS4ControllerLeftStickX > 0.35f;
    SendQ          = PS4ControllerLeftStickX < -0.35f;
    SendZ          = PS4ControllerLeftStickY > 0.35f;
    SendS          = PS4ControllerLeftStickY < -0.35f;
    Send8          = PS4ControllerButtonDPadDownPressed;
    Send7          = PS4ControllerButtonDPadLeftPressed;
    Send9          = PS4ControllerButtonDPadRightPressed;
    Send6          = PS4ControllerButtonDPadUpPressed;
    SendSpace      = PS4ControllerButtonL1Pressed;
    SendLeftShift  = PS4ControllerButtonR1Pressed;
    SendE          = PS4ControllerButtonL3Pressed;
    SendB          = PS4ControllerButtonR3Pressed;
    SendR          = PS4ControllerButtonTrianglePressed;
    SendF          = PS4ControllerButtonSquarePressed;
    SendX          = PS4ControllerButtonCirclePressed;
    SendC          = PS4ControllerButtonCrossPressed;
    SendRightClick = PS4ControllerButtonL2Pressed;
    SendLeftClick  = PS4ControllerButtonR2Pressed;
    SendTab        = PS4ControllerButtonLogoPressed;
    SendEscape     = PS4ControllerButtonTouchpadPressed;
}