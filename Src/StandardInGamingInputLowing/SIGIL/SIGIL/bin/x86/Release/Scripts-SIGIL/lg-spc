sleeptime = 8;
valchanged(0, ProControllerButtonCAPTURE);
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
    mousexp[0] += Math.Round(ProControllerGyroX * 65535f / 2f / 1024f * 2f / 20000f, 0) * 2f;
    mouseyp[0] += Math.Round(ProControllerGyroY * 65535f / 2f / 1024f * 2f / 20000f, 0) * 2f;
    if (mousexp[0] >= width / 2f) 
        mousexp[0] = width / 2f;
    if (mousexp[0] <= -width / 2f) 
        mousexp[0] = -width / 2f;
    if (mouseyp[0] >= height / 2f) 
        mouseyp[0] = height / 2f;
    if (mouseyp[0] <= -height / 2f) 
        mouseyp[0] = -height / 2f;
    MouseDesktopX  = width / 2f - mousexp[0] - Math.Round(ProControllerGyroX * 65535f / 2f / 1024f * 2f / 20000f, 0) * 2f;
    MouseDesktopY  = height / 2f + mouseyp[0] + Math.Round(ProControllerGyroY * 65535f / 2f / 1024f * 2f / 20000f, 0) * 2f;
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