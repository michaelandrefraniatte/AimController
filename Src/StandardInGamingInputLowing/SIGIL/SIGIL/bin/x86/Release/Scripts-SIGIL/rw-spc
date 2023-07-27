ProControllerAccelCenter = ProControllerButtonPLUS;
mousex = ProControllerAccelY * 31.25f;
mousey = ProControllerLeftStickY * 32767f;
statex = Math.Abs(mousex) <= 32767f ? mousex : Math.Sign(mousex) * 32767f;
statey = Math.Abs(mousey) <= 32767f ? mousey : Math.Sign(mousey) * 32767f;
if (statex > 0f)
    mousestatex = Scale(statex, 0f, 32767f, dzx / 100f * 32767f, 32767f);
if (statex < 0f)
    mousestatex = Scale(statex, -32767f, 0f, -32767f, -(dzx / 100f) * 32767f);
if (statey > 0f)
    mousestatey = Scale(statey, 0f, 32767f, dzy / 100f * 32767f, 32767f);
if (statey < 0f)
    mousestatey = Scale(statey, -32767f, 0f, -32767f, -(dzy / 100f) * 32767f);
mousex = mousestatex + ProControllerLeftStickX * 32767f;
mousey = mousestatey;
statex = Math.Abs(mousex) <= 32767f ? mousex : Math.Sign(mousex) * 32767f;
statey = Math.Abs(mousey) <= 32767f ? mousey : Math.Sign(mousey) * 32767f;
controller1_send_leftstickx = statex;
controller1_send_leftsticky = statey;
mousex = ProControllerRightStickX * 1024f;
mousey = ProControllerRightStickY * 1024f;
controller1_send_rightstickx = Math.Abs(-mousex * 32767f / 1024f) <= 32767f ? -mousex * 32767f / 1024f : Math.Sign(-mousex) * 32767f;
controller1_send_rightsticky = Math.Abs(-mousey * 32767f / 1024f) <= 32767f ? -mousey * 32767f / 1024f : Math.Sign(-mousey) * 32767f;
controller1_send_down = ProControllerButtonDPAD_DOWN;
controller1_send_left = ProControllerButtonDPAD_LEFT;
controller1_send_right = ProControllerButtonDPAD_RIGHT;
controller1_send_up = ProControllerButtonDPAD_UP;
controller1_send_leftstick = ProControllerButtonSTICK_Left;
controller1_send_rightstick = ProControllerButtonSTICK_Right;
controller1_send_B = ProControllerButtonA;
controller1_send_A = ProControllerButtonB;
controller1_send_Y = ProControllerButtonX;
controller1_send_X = ProControllerButtonY;
controller1_send_lefttrigger = ProControllerButtonSHOULDER_Left_2;
controller1_send_righttrigger = ProControllerButtonSHOULDER_Right_2;
controller1_send_leftbumper = ProControllerButtonSHOULDER_Left_1;
controller1_send_rightbumper = ProControllerButtonSHOULDER_Right_1;
controller1_send_back = ProControllerButtonCAPTURE | ProControllerButtonMINUS;
controller1_send_start = ProControllerButtonHOME;