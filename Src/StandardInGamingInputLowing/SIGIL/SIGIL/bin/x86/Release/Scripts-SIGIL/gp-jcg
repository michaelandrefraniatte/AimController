JoyconLeftAccelCenter  = JoyconRightButtonPLUS;
JoyconRightAccelCenter = JoyconRightButtonPLUS;
mousex                 = (JoyconLeftAccelY - JoyconRightAccelY) * 13.5f;
mousey                 = JoyconLeftStickY * 32767f * 1.2f;
statex                 = Math.Abs(mousex) <= 32767f ? mousex : Math.Sign(mousex) * 32767f;
statey                 = Math.Abs(mousey) <= 32767f ? mousey : Math.Sign(mousey) * 32767f;
if (statex > 0f)
    mousestatex = Scale(statex, 0f, 32767f, dzx / 100f * 32767f, 32767f);
if (statex < 0f)
    mousestatex = Scale(statex, -32767f, 0f, -32767f, -(dzx / 100f) * 32767f);
if (statey > 0f)
    mousestatey = Scale(statey, 0f, 32767f, dzy / 100f * 32767f, 32767f);
if (statey < 0f)
    mousestatey = Scale(statey, -32767f, 0f, -32767f, -(dzy / 100f) * 32767f);
mousex                        = mousestatex + JoyconLeftStickX * 32767f * 1.2f;
mousey                        = mousestatey;
statex                        = Math.Abs(mousex) <= 32767f ? mousex : Math.Sign(mousex) * 32767f;
statey                        = Math.Abs(mousey) <= 32767f ? mousey : Math.Sign(mousey) * 32767f;
controller1_send_leftstickx   = statex;
controller1_send_leftsticky   = statey;
mousex                        = JoyconRightStickX * 1400f;
mousey                        = JoyconRightStickY * 1400f;
controller1_send_rightstickx  = Math.Abs(-mousex * 32767f / 1024f) <= 32767f ? -mousex * 32767f / 1024f : Math.Sign(-mousex) * 32767f;
controller1_send_rightsticky  = Math.Abs(-mousey * 32767f / 1024f) <= 32767f ? -mousey * 32767f / 1024f : Math.Sign(-mousey) * 32767f;
controller1_send_up           = JoyconLeftButtonDPAD_UP;
controller1_send_left         = JoyconLeftButtonDPAD_LEFT;
controller1_send_down         = JoyconLeftButtonDPAD_DOWN;
controller1_send_right        = JoyconLeftButtonDPAD_RIGHT;
controller1_send_back         = JoyconLeftButtonMINUS | JoyconRightButtonHOME;
controller1_send_start        = JoyconLeftButtonCAPTURE | JoyconRightButtonPLUS;
controller1_send_leftstick    = JoyconLeftButtonSTICK;
controller1_send_leftbumper   = JoyconLeftButtonSL | JoyconLeftButtonSHOULDER_1 | JoyconRightButtonSL;
controller1_send_rightbumper  = JoyconLeftButtonSR | JoyconRightButtonSHOULDER_1 | JoyconRightButtonSR;
controller1_send_A            = JoyconRightButtonDPAD_DOWN;
controller1_send_B            = JoyconRightButtonDPAD_RIGHT;
controller1_send_X            = JoyconRightButtonDPAD_LEFT;
controller1_send_Y            = JoyconRightButtonDPAD_UP;
controller1_send_rightstick   = JoyconRightButtonSTICK;
controller1_send_lefttrigger  = JoyconLeftButtonSHOULDER_2;
controller1_send_righttrigger = JoyconRightButtonSHOULDER_2;