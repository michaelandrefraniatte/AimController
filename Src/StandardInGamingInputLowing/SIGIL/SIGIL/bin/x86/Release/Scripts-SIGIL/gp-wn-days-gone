viewpower1x                   = 0.33f;
viewpower2x                   = 0f;
viewpower3x                   = 0.67f;
viewpower1y                   = 0.25f;
viewpower2y                   = 0.75f;
viewpower3y                   = 0f;
dzx                           = 3f;
dzy                           = 3f;
controller1_send_rightstick   = WiimoteNunchuckStateRawValuesY > 33f;
controller1_send_leftstick    = WiimoteNunchuckStateZ;
controller1_send_A            = WiimoteNunchuckStateC;
controller1_send_back         = WiimoteButtonStateOne;
controller1_send_start        = WiimoteButtonStateTwo;
controller1_send_X            = WiimoteButtonStateHome | ((WiimoteRawValuesZ > 0 ? WiimoteRawValuesZ : -WiimoteRawValuesZ) >= 30f & (WiimoteRawValuesY > 0 ? WiimoteRawValuesY : -WiimoteRawValuesY) >= 30f & (WiimoteRawValuesX > 0 ? WiimoteRawValuesX : -WiimoteRawValuesX) >= 30f);
controller1_send_leftbumper   = WiimoteButtonStateMinus | WiimoteButtonStateUp;
controller1_send_rightbumper  = WiimoteButtonStatePlus | WiimoteButtonStateUp;
controller1_send_B            = WiimoteButtonStateDown;
controller1_send_Y            = WiimoteButtonStateRight;
controller1_send_righttrigger = WiimoteButtonStateB;
valchanged(0, WiimoteButtonStateA);
if (wd[0] == 1 & !getstate[0])
{
    getstate[0] = true;
}
else
{
    if (wd[0] == 1 & getstate[0])
    {
        getstate[0] = false;
    }
}
if (controller1_send_X | controller1_send_Y | controller1_send_rightbumper | controller1_send_leftbumper | controller1_send_rightstick | controller1_send_leftstick | controller1_send_back | controller1_send_start)
{
    getstate[0] = false;
}
controller1_send_lefttrigger = getstate[0];
if (irx >= 0f & irx <= 1024f)
    mousex = Scale(irx * irx * irx / 1024f / 1024f * viewpower3x + irx * irx / 1024f * viewpower2x + irx * viewpower1x, 0f, 1024f, dzx / 100f * 1024f, 1024f);
if (irx <= 0f & irx >= -1024f)
    mousex = Scale(-(-irx * -irx * -irx) / 1024f / 1024f * viewpower3x - (-irx * -irx) / 1024f * viewpower2x - (-irx) * viewpower1x, -1024f, 0f, -1024f, -(dzx / 100f) * 1024f);
if (iry >= 0f & iry <= 1024f)
    mousey = Scale(iry * iry * iry / 1024f / 1024f * viewpower3y + iry * iry / 1024f * viewpower2y + iry * viewpower1y, 0f, 1024f, dzy / 100f * 1024f, 1024f);
if (iry <= 0f & iry >= -1024f)
    mousey = Scale(-(-iry * -iry * -iry) / 1024f / 1024f * viewpower3y - (-iry * -iry) / 1024f * viewpower2y - (-iry) * viewpower1y, -1024f, 0f, -1024f, -(dzy / 100f) * 1024f);
controller1_send_rightstickx = (short)(-mousex / 1024f * 32767f);
controller1_send_rightsticky = (short)(-mousey / 1024f * 32767f);
if (!WiimoteButtonStateOne)
{
    if (!WiimoteButtonStateLeft)
    {
        if (WiimoteNunchuckStateRawJoystickX > 42f)
            controller1_send_leftstickx = 32767;
        if (WiimoteNunchuckStateRawJoystickX < -42f)
            controller1_send_leftstickx = -32767;
        if (WiimoteNunchuckStateRawJoystickX <= 42f & WiimoteNunchuckStateRawJoystickX >= -42f)
            controller1_send_leftstickx = 0;
        if (WiimoteNunchuckStateRawJoystickY > 42f)
            controller1_send_leftsticky = 32767;
        if (WiimoteNunchuckStateRawJoystickY < -42f)
            controller1_send_leftsticky = -32767;
        if (WiimoteNunchuckStateRawJoystickY <= 42f & WiimoteNunchuckStateRawJoystickY >= -42f)
            controller1_send_leftsticky = 0;
        controller1_send_right = false;
        controller1_send_left  = false;
        controller1_send_up    = false;
        controller1_send_down  = false;
    }
    else
    {
        controller1_send_leftstickx = 0;
        controller1_send_leftsticky = 0;
        controller1_send_right      = WiimoteNunchuckStateRawJoystickX >= 42f;
        controller1_send_left       = WiimoteNunchuckStateRawJoystickX <= -42f;
        controller1_send_up         = WiimoteNunchuckStateRawJoystickY >= 42f;
        controller1_send_down       = WiimoteNunchuckStateRawJoystickY <= -42f;
    }
}