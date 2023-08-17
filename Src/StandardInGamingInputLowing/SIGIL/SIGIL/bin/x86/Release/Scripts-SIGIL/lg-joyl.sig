sleeptime = 8;
valchanged(0, JoyconLeftButtonCAPTURE);
if (wd[0] == 1 & !getstate[0]) 
{
    width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
    height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
    getstate[0] = true;
}
else 
{ 
    if (wd[0] == 1 & getstate[0]) 
    {
        MouseMoveX = 0;
        MouseMoveY = 0;
        MouseDesktopX = 0;
        MouseDesktopY = 0;
        MouseAbsX = 0;
        MouseAbsY = 0;
        SendD = false;
        SendQ = false;
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
    if (JoyconLeftButtonMINUS)
    {
        mousexp[0] = 0f;
        mouseyp[0] = 0f;
    }
    mousexp[0] += Math.Round(JoyconLeftGyroX * width / 2f / 1024f * 2f / 200f, 0) * 1f;
    mouseyp[0] += Math.Round(JoyconLeftGyroY * height / 2f / 1024f * 2f / 200f, 0) * 1f;
    if (mousexp[0] >= width / 2f) 
        mousexp[0] = width / 2f;
    if (mousexp[0] <= -width / 2f) 
        mousexp[0] = -width / 2f;
    if (mouseyp[0] >= height / 2f) 
        mouseyp[0] = height / 2f;
    if (mouseyp[0] <= -height / 2f) 
        mouseyp[0] = -height / 2f;
    MouseDesktopX = width / 2f - mousexp[0] - Math.Round(JoyconLeftGyroX * width / 2f / 1024f * 2f / 200f, 0) * 1f;
    MouseDesktopY = height / 2f + mouseyp[0] + Math.Round(JoyconLeftGyroY * height / 2f / 1024f * 2f / 200f, 0) * 1f;
    SendD         = JoyconLeftStickX > 0.25f;
    SendQ         = JoyconLeftStickX < -0.25f;
    SendZ         = JoyconLeftStickY > 0.25f;
    SendS         = JoyconLeftStickY < -0.25f;
    Send7         = JoyconLeftButtonDPAD_UP;
    Send8         = JoyconLeftButtonDPAD_LEFT;
    Send9         = JoyconLeftButtonDPAD_DOWN;
    Send0         = JoyconLeftButtonDPAD_RIGHT;
    SendT         = JoyconLeftButtonMINUS;
    SendEscape    = JoyconLeftButtonCAPTURE;
    SendLeftShift = JoyconLeftButtonSTICK;
    SendA         = JoyconLeftButtonSL;
    SendLMENU     = JoyconLeftButtonSR;
    SendSpace     = JoyconLeftButtonSHOULDER_1;
    Send1         = JoyconLeftButtonSHOULDER_2;
}