dzx                   = 20.0f;
dzy                   = 0.0f;
JoyconRightAccelCenter = JoyconRightButtonPLUS;
if (JoyconRightAccelX >= 1024f)
    JoyconRightAccelX = 1024f;
if (JoyconRightAccelX <= -1024f)
    JoyconRightAccelX = -1024f;
if (JoyconRightAccelY >= 1024f)
    JoyconRightAccelY = 1024f;
if (JoyconRightAccelY <= -1024f)
    JoyconRightAccelY = -1024f;
if (JoyconRightAccelX > 0f & JoyconRightAccelX <= 1024f)
    mousex = Scale(JoyconRightAccelX, 0f, 1024f, (dzx / 100f) * 1024f, 1024f);
if (JoyconRightAccelX < 0f & JoyconRightAccelX >= -1024f)
    mousex = Scale(JoyconRightAccelX, -1024f, 0f, -1024f, -(dzx / 100f) * 1024f);
if (JoyconRightAccelY > 0f & JoyconRightAccelY <= 1024f)
    mousey = Scale(JoyconRightAccelY, 0f, 1024f, (dzy / 100f) * 1024f, 1024f);
if (JoyconRightAccelY < 0f & JoyconRightAccelY >= -1024f)
    mousey = Scale(JoyconRightAccelY, -1024f, 0f, -1024f, -(dzy / 100f) * 1024f);
controller1_send_leftstickx   = -mousex * 32767f / 1024f;
controller1_send_leftsticky   = -mousey * 32767f / 1024f;
controller1_send_A            = JoyconRightButtonHOME;
controller1_send_lefttrigger  = JoyconRightButtonDPAD_RIGHT;
controller1_send_righttrigger = JoyconRightButtonDPAD_UP;
controller1_send_Y            = JoyconRightButtonDPAD_LEFT;
controller1_send_back         = JoyconRightButtonDPAD_DOWN;
controller1_send_start        = JoyconRightButtonPLUS;
controller1_send_rightstick   = JoyconRightButtonSTICK;
controller1_send_leftbumper   = JoyconRightButtonSHOULDER_1;
controller1_send_rightbumper  = JoyconRightButtonSHOULDER_2;
controller1_send_B            = JoyconRightButtonSL;
controller1_send_X            = JoyconRightButtonSR;
if (JoyconRightStickY > 0.35f) 
    controller1_send_rightstickx = 32767;
if (JoyconRightStickY < -0.35f) 
    controller1_send_rightstickx = -32767;
if (JoyconRightStickY <= 0.35f & JoyconRightStickY >= -0.35f) 
    controller1_send_rightstickx = 0;
if (JoyconRightStickX > 0.35f) 
    controller1_send_rightsticky = -32767;
if (JoyconRightStickX < -0.35f) 
    controller1_send_rightsticky = 32767;
if (JoyconRightStickX <= 0.35f & JoyconRightStickX >= -0.35f) 
    controller1_send_rightsticky = 0;