dzx                   = 20.0f;
dzy                   = 0.0f;
JoyconLeftAccelCenter = JoyconLeftButtonMINUS;
if (JoyconLeftAccelX >= 1024f)
    JoyconLeftAccelX = 1024f;
if (JoyconLeftAccelX <= -1024f)
    JoyconLeftAccelX = -1024f;
if (JoyconLeftAccelY >= 1024f)
    JoyconLeftAccelY = 1024f;
if (JoyconLeftAccelY <= -1024f)
    JoyconLeftAccelY = -1024f;
if (JoyconLeftAccelX > 0f & JoyconLeftAccelX <= 1024f)
    mousex = Scale(JoyconLeftAccelX, 0f, 1024f, (dzx / 100f) * 1024f, 1024f);
if (JoyconLeftAccelX < 0f & JoyconLeftAccelX >= -1024f)
    mousex = Scale(JoyconLeftAccelX, -1024f, 0f, -1024f, -(dzx / 100f) * 1024f);
if (JoyconLeftAccelY > 0f & JoyconLeftAccelY <= 1024f)
    mousey = Scale(JoyconLeftAccelY, 0f, 1024f, (dzy / 100f) * 1024f, 1024f);
if (JoyconLeftAccelY < 0f & JoyconLeftAccelY >= -1024f)
    mousey = Scale(JoyconLeftAccelY, -1024f, 0f, -1024f, -(dzy / 100f) * 1024f);
controller1_send_leftstickx   = mousex * 32767f / 1024f;
controller1_send_leftsticky   = -mousey * 32767f / 1024f;
controller1_send_A            = JoyconLeftButtonCAPTURE;
controller1_send_lefttrigger  = JoyconLeftButtonDPAD_LEFT;
controller1_send_righttrigger = JoyconLeftButtonDPAD_DOWN;
controller1_send_Y            = JoyconLeftButtonDPAD_RIGHT;
controller1_send_back         = JoyconLeftButtonDPAD_UP;
controller1_send_start        = JoyconLeftButtonMINUS;
controller1_send_rightstick   = JoyconLeftButtonSTICK;
controller1_send_leftbumper   = JoyconLeftButtonSHOULDER_1;
controller1_send_rightbumper  = JoyconLeftButtonSHOULDER_2;
controller1_send_B            = JoyconLeftButtonSR;
controller1_send_X            = JoyconLeftButtonSL;
if (JoyconLeftStickY > 0.35f) 
    controller1_send_rightstickx = -32767;
if (JoyconLeftStickY < -0.35f) 
    controller1_send_rightstickx = 32767;
if (JoyconLeftStickY <= 0.35f & JoyconLeftStickY >= -0.35f) 
    controller1_send_rightstickx = 0;
if (JoyconLeftStickX > 0.35f) 
    controller1_send_rightsticky = 32767;
if (JoyconLeftStickX < -0.35f) 
    controller1_send_rightsticky = -32767;
if (JoyconLeftStickX <= 0.35f & JoyconLeftStickX >= -0.35f) 
    controller1_send_rightsticky = 0;