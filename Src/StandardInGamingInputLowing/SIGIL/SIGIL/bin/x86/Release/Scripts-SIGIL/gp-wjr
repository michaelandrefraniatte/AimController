controller1_send_down         = JoyconRightButtonDPAD_DOWN;
controller1_send_left         = JoyconRightButtonDPAD_LEFT;
controller1_send_right        = JoyconRightButtonDPAD_RIGHT;
controller1_send_up           = JoyconRightButtonDPAD_UP;
controller1_send_rightstick   = JoyconRightAccelY <= -1.13;
controller1_send_leftstick    = JoyconRightButtonSHOULDER_2;
controller1_send_A            = JoyconRightButtonSHOULDER_1;
controller1_send_back         = WiimoteButtonStateOne;
controller1_send_start        = WiimoteButtonStateTwo;
controller1_send_X            = WiimoteButtonStateHome | ((WiimoteRawValuesZ > 0 ? WiimoteRawValuesZ : -WiimoteRawValuesZ) >= 30f & (WiimoteRawValuesY > 0 ? WiimoteRawValuesY : -WiimoteRawValuesY) >= 30f & (WiimoteRawValuesX > 0 ? WiimoteRawValuesX : -WiimoteRawValuesX) >= 30f);
controller1_send_rightbumper  = WiimoteButtonStatePlus | WiimoteButtonStateUp;
controller1_send_leftbumper   = WiimoteButtonStateMinus | WiimoteButtonStateUp;
controller1_send_B            = WiimoteButtonStateDown;
controller1_send_Y            = WiimoteButtonStateLeft | WiimoteButtonStateRight;
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
if (JoyconRightStickX > 0.35f)
    controller1_send_leftstickx = 32767;
if (JoyconRightStickX < -0.35f)
    controller1_send_leftstickx = -32767;
if (JoyconRightStickX <= 0.35f & JoyconRightStickX >= -0.35f)
    controller1_send_leftstickx = 0;
if (JoyconRightStickY > 0.35f)
    controller1_send_leftsticky = 32767;
if (JoyconRightStickY < -0.35f)
    controller1_send_leftsticky = -32767;
if (JoyconRightStickY <= 0.35f & JoyconRightStickY >= -0.35f)
    controller1_send_leftsticky = 0;