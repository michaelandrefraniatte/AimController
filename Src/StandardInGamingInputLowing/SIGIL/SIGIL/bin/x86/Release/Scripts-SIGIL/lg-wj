valchanged(0, JoyconLeftButtonCAPTURE);
if (wd[0] == 1 & !getstate[0]) 
{
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
        getstate[0]       = false;
    }
}
if (getstate[0]) 
{
    if (irx >= 0f)
        mousex = Scale(irx * irx * irx / 1024f / 1024f * viewpower3x + irx * irx / 1024f * viewpower2x + irx * viewpower1x, 0f, 1024f, (dzx / 100f) * 1024f, 1024f);
    if (irx <= 0f)
        mousex = Scale(-(-irx * -irx * -irx) / 1024f / 1024f * viewpower3x - (-irx * -irx) / 1024f * viewpower2x - (-irx) * viewpower1x, -1024f, 0f, -1024f, -(dzx / 100f) * 1024f);
    if (iry >= 0f)
        mousey = Scale(iry * iry * iry / 1024f / 1024f * viewpower3y + iry * iry / 1024f * viewpower2y + iry * viewpower1y, 0f, 1024f, (dzy / 100f) * 1024f, 1024f);
    if (iry <= 0f)
        mousey = Scale(-(-iry * -iry * -iry) / 1024f / 1024f * viewpower3y - (-iry * -iry) / 1024f * viewpower2y - (-iry) * viewpower1y, -1024f, 0f, -1024f, -(dzy / 100f) * 1024f);  
    MouseAbsX      = 32767.5f - mousex * 32f;
    MouseAbsY      = 32767.5f + mousey * 32f;
    SendD          = JoyconLeftStickX > 0.35f;
    SendQ          = JoyconLeftStickX < -0.35f;
    SendZ          = JoyconLeftStickY > 0.35f;
    SendS          = JoyconLeftStickY < -0.35f;
    Send1          = JoyconLeftButtonDPAD_UP;
    Send2          = JoyconLeftButtonDPAD_LEFT;
    Send3          = JoyconLeftButtonDPAD_DOWN;
    Send4          = JoyconLeftButtonDPAD_RIGHT;
    SendSpace      = JoyconLeftButtonSHOULDER_1;
    SendLeftShift  = JoyconLeftButtonSHOULDER_2 | JoyconLeftButtonSTICK;
    SendE          = JoyconLeftButtonSR;
    SendA          = JoyconLeftButtonSL;
    SendV          = JoyconLeftButtonMINUS;
    SendEscape     = WiimoteButtonStateTwo;
    SendTab        = WiimoteButtonStateOne;
    SendR          = ((WiimoteRawValuesZ > 0 ? WiimoteRawValuesZ : -WiimoteRawValuesZ) >= 30f & (WiimoteRawValuesY > 0 ? WiimoteRawValuesY : -WiimoteRawValuesY) >= 30f & (WiimoteRawValuesX > 0 ? WiimoteRawValuesX : -WiimoteRawValuesX) >= 30f);
    SendF          = WiimoteButtonStateHome;
    SendT          = WiimoteButtonStateMinus;
    SendG          = WiimoteButtonStatePlus;
    SendY          = WiimoteButtonStateLeft;
    SendU          = WiimoteButtonStateRight;
    SendX          = WiimoteButtonStateUp;
    SendC          = WiimoteButtonStateDown;
    SendRightClick = WiimoteButtonStateA;
    SendLeftClick  = WiimoteButtonStateB;
}