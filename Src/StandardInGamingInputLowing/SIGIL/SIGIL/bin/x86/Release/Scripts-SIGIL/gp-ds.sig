statex = PS5ControllerGyroX * 15f; 
statey = PS5ControllerGyroY * 15f;
if (statex > 0f)
    mousestatex = Scale(statex, 0f, 32767f, dzx / 100f * 32767f, 32767f);
if (statex < 0f)
    mousestatex = Scale(statex, -32767f, 0f, -32767f, -(dzx / 100f) * 32767f);
if (statey > 0f)
    mousestatey = Scale(statey, 0f, 32767f, dzy / 100f * 32767f, 32767f);
if (statey < 0f)
    mousestatey = Scale(statey, -32767f, 0f, -32767f, -(dzy / 100f) * 32767f);
mousex = mousestatex + PS5ControllerRightStickX * 32767f;
mousey = mousestatey + PS5ControllerRightStickY * 32767f;
statex = Math.Abs(mousex) <= 32767f ? mousex : Math.Sign(mousex) * 32767f;
statey = Math.Abs(mousey) <= 32767f ? mousey : Math.Sign(mousey) * 32767f;
controller1_send_rightstickx = -statex;
controller1_send_rightsticky = -statey;
mousex = -PS5ControllerLeftStickX * 1024f;
mousey = -PS5ControllerLeftStickY * 1024f;
controller1_send_leftstickx = Math.Abs(-mousex * 32767f / 1024f) <= 32767f ? -mousex * 32767f / 1024f : Math.Sign(-mousex) * 32767f;
controller1_send_leftsticky = Math.Abs(-mousey * 32767f / 1024f) <= 32767f ? -mousey * 32767f / 1024f : Math.Sign(-mousey) * 32767f;
controller1_send_down = PS5ControllerButtonDPadDownPressed;
controller1_send_left = PS5ControllerButtonDPadLeftPressed;
controller1_send_right = PS5ControllerButtonDPadRightPressed;
controller1_send_up = PS5ControllerButtonDPadUpPressed;
controller1_send_leftstick = PS5ControllerButtonL3Pressed;
controller1_send_rightstick = PS5ControllerButtonR3Pressed;
controller1_send_B = PS5ControllerButtonCrossPressed;
controller1_send_A = PS5ControllerButtonCirclePressed;
controller1_send_Y = PS5ControllerButtonSquarePressed;
controller1_send_X = PS5ControllerButtonTrianglePressed;
controller1_send_lefttriggerposition = PS5ControllerLeftTriggerPosition * 255;
controller1_send_righttriggerposition = PS5ControllerRightTriggerPosition * 255;
controller1_send_leftbumper = PS5ControllerButtonL1Pressed;
controller1_send_rightbumper = PS5ControllerButtonR1Pressed;
controller1_send_back = PS5ControllerButtonLogoPressed;
controller1_send_start = PS5ControllerButtonTouchpadPressed;