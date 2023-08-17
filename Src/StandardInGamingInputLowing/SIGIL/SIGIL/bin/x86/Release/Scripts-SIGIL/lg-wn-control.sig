KeyboardMouseDriverType = "sendinput";
viewpower1x             = 0.08f;
viewpower2x             = 0f;
viewpower3x             = 0.92f;
viewpower1y             = 0.08f;
viewpower2y             = 0f;
viewpower3y             = 0.92f;
dzx                     = 0.2f;
dzy                     = 0.2f;
sleeptime               = 6;
valchanged(0, WiimoteButtonStateOne);
if (wd[0] == 1 & !getstate[0]) 
{
    width  = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
    height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
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
    MouseMoveX    = -mousex * 600 / 1024f;
    MouseMoveY    = mousey * 400 / 1024f;
    MouseDesktopX = width / 2f - mousex * width / 2f / 1024f;
    MouseDesktopY = height / 2f + mousey * height / 2f / 1024f;
    SendD         = WiimoteNunchuckStateRawJoystickX >= 60f;
    SendA         = WiimoteNunchuckStateRawJoystickX <= -60f;
    SendW         = WiimoteNunchuckStateRawJoystickY >= 60f;
    SendS         = WiimoteNunchuckStateRawJoystickY <= -60f;
    SendSpace     = WiimoteNunchuckStateC;
    SendLeftShift = WiimoteNunchuckStateZ;
    SendV         = WiimoteNunchuckStateRawValuesY > 33f;
    SendEscape    = WiimoteButtonStateTwo;
    SendTab       = WiimoteButtonStateOne;
    SendR         = ((WiimoteRawValuesZ > 0 ? WiimoteRawValuesZ : -WiimoteRawValuesZ) >= 30f & (WiimoteRawValuesY > 0 ? WiimoteRawValuesY : -WiimoteRawValuesY) >= 30f & (WiimoteRawValuesX > 0 ? WiimoteRawValuesX : -WiimoteRawValuesX) >= 30f);
    SendF         = WiimoteButtonStateHome;
    SendT         = WiimoteButtonStateMinus;
    SendG         = WiimoteButtonStatePlus;
    SendY         = WiimoteButtonStateLeft;
    SendU         = WiimoteButtonStateRight;
    SendX         = WiimoteButtonStateUp;
    SendC         = WiimoteButtonStateDown;
    SendLeftClick = WiimoteButtonStateB;
    valchanged(1, WiimoteButtonStateA);
    if (wd[1] == 1 & !getstate[1])
    {
        getstate[1] = true;
    }
    else
    {
        if (wd[1] == 1 & getstate[1])
        {
            getstate[1] = false;
        }
    }
    if (SendSpace | SendLeftShift | SendV | SendEscape | SendTab | SendR | SendF | SendT | SendG | SendY | SendU | SendX | SendC)
    {
        getstate[1] = false;
    }
    SendRightClick = getstate[1];
}