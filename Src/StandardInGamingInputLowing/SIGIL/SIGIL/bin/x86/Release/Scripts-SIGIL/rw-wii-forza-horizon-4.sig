dzx = 15.0f;
dzy = 0.0f;
if (WiimoteRawValuesY > 0f)
    mousex = Scale(WiimoteRawValuesY * 45f, 0f, 1024f, (dzx / 100f) * 1024f, 1024f);
if (WiimoteRawValuesY < 0f)
    mousex = Scale(WiimoteRawValuesY * 45f, -1024f, 0f, -1024f, -(dzx / 100f) * 1024f);
if (WiimoteRawValuesX > 0f)
    mousey = Scale(WiimoteRawValuesX * 90f, 0f, 1024f, (dzy / 100f) * 1024f, 1024f);
if (WiimoteRawValuesX < 0f)
    mousey = Scale(WiimoteRawValuesX * 90f, -1024f, 0f, -1024f, -(dzy / 100f) * 1024f);
controller1_send_leftstickx   = Math.Abs(-mousex * 32767f / 1024f) <= 32767f ? -mousex * 32767f / 1024f : Math.Sign(-mousex) * 32767f;
controller1_send_leftsticky   = Math.Abs(-mousey * 32767f / 1024f) <= 32767f ? -mousey * 32767f / 1024f : Math.Sign(-mousey) * 32767f;
controller1_send_down         = WiimoteButtonStateLeft;
controller1_send_left         = WiimoteButtonStateUp;
controller1_send_right        = WiimoteButtonStateDown;
controller1_send_up           = WiimoteButtonStateRight;
controller1_send_A            = WiimoteButtonStateB;
controller1_send_B            = WiimoteButtonStateOne & WiimoteButtonStateTwo;  
controller1_send_Y            = WiimoteButtonStateA;
controller1_send_X            = WiimoteButtonStateHome;
controller1_send_rightbumper  = WiimoteButtonStatePlus;
controller1_send_leftbumper   = WiimoteButtonStateMinus;
controller1_send_lefttrigger  = WiimoteButtonStateOne;
controller1_send_righttrigger = WiimoteButtonStateTwo;