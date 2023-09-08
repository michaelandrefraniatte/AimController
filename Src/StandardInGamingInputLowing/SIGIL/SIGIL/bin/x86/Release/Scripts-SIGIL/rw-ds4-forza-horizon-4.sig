viewpower1x = 0f;
viewpower2x = 1f;
viewpower3x = 0f;
viewpower1y = 1f;
viewpower2y = 0f;
viewpower3y = 0f;
dzx         = 22f;
dzy         = 0f;
mousex      = PS4ControllerAccelY * 35f; 
mousey      = PS4ControllerLeftStickY * 32767f;
statex      = Math.Abs(mousex) <= 32767f ? mousex : Math.Sign(mousex) * 32767f;
statey      = Math.Abs(mousey) <= 32767f ? mousey : Math.Sign(mousey) * 32767f;
if (statex > 0f)
    mousestatex = Scale(statex * statex * statex / 32767f / 32767f * viewpower3x + statex * statex / 32767f * viewpower2x + statex * viewpower1x, 0f, 32767f, dzx / 100f * 32767f, 32767f);
if (statex < 0f)
    mousestatex = Scale(-(-statex * -statex * -statex) / 32767f / 32767f * viewpower3x - (-statex * -statex) / 32767f * viewpower2x - (-statex) * viewpower1x, -32767f, 0f, -32767f, -(dzx / 100f) * 32767f);
if (statey > 0f)
    mousestatey = Scale(statey * statey * statey / 32767f / 32767f * viewpower3y + statey * statey / 32767f * viewpower2y + statey * viewpower1y, 0f, 32767f, dzy / 100f * 32767f, 32767f);
if (statey < 0f)
    mousestatey = Scale(-(-statey * -statey * -statey) / 32767f / 32767f * viewpower3y - (-statey * -statey) / 32767f * viewpower2y - (-statey) * viewpower1y, -32767f, 0f, -32767f, -(dzy / 100f) * 32767f);
mousex                                = mousestatex + PS4ControllerLeftStickX * 32767f;
mousey                                = mousestatey;
statex                                = Math.Abs(mousex) <= 32767f ? mousex : Math.Sign(mousex) * 32767f;
statey                                = Math.Abs(mousey) <= 32767f ? mousey : Math.Sign(mousey) * 32767f;
controller1_send_leftstickx           = statex;
controller1_send_leftsticky           = statey;
mousex                                = PS4ControllerRightStickX * 1024f;
mousey                                = PS4ControllerRightStickY * 1024f;
controller1_send_rightstickx          = Math.Abs(-mousex * 32767f / 1024f) <= 32767f ? -mousex * 32767f / 1024f : Math.Sign(-mousex) * 32767f;
controller1_send_rightsticky          = Math.Abs(-mousey * 32767f / 1024f) <= 32767f ? -mousey * 32767f / 1024f : Math.Sign(-mousey) * 32767f;
controller1_send_down                 = PS4ControllerButtonDPadDownPressed;
controller1_send_left                 = PS4ControllerButtonDPadLeftPressed;
controller1_send_right                = PS4ControllerButtonDPadRightPressed;
controller1_send_up                   = PS4ControllerButtonDPadUpPressed;
controller1_send_leftstick            = PS4ControllerButtonL3Pressed;
controller1_send_rightstick           = PS4ControllerButtonR3Pressed;
controller1_send_A                    = PS4ControllerButtonCrossPressed;
controller1_send_B                    = PS4ControllerButtonCirclePressed;
controller1_send_X                    = PS4ControllerButtonSquarePressed;
controller1_send_Y                    = PS4ControllerButtonTrianglePressed;
controller1_send_lefttriggerposition  = PS4ControllerLeftTriggerPosition * 255;
controller1_send_righttriggerposition = PS4ControllerRightTriggerPosition * 255;
controller1_send_leftbumper           = PS4ControllerButtonL1Pressed;
controller1_send_rightbumper          = PS4ControllerButtonR1Pressed;
controller1_send_back                 = PS4ControllerButtonLogoPressed;
controller1_send_start                = PS4ControllerButtonTouchpadPressed;
controller1_send_xbox                 = PS4ControllerButtonMicPressed;
PS4ControllerAccelCenter              = PS4ControllerButtonMenuPressed;