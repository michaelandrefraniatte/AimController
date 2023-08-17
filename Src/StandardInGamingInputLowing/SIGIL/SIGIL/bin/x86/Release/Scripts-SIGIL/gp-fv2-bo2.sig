dzx         = 20f;
dzy         = 20f;
viewpower1x = 1f;
viewpower2x = 0f;
viewpower3x = 0f;
viewpower1y = 1f;
viewpower2y = 0f;
viewpower3y = 0f;
double irx  = (Joystick1AxisZ - 65535f / 2f);
double iry  = -(Joystick1RotationZ - 65535f / 2f);
if (irx >= 0f)
    statex = Scale(irx * irx * irx / 32767f / 32767f * viewpower3x + irx * irx / 32767f * viewpower2x + irx * viewpower1x, 0f, 32767f, (dzx / 100f) * 32767f, 32767f);
if (irx <= 0f)
    statex = Scale(-(-irx * -irx * -irx) / 32767f / 32767f * viewpower3x - (-irx * -irx) / 32767f * viewpower2x - (-irx) * viewpower1x, -32767f, 0f, -32767f, -(dzx / 100f) * 32767f);
if (iry >= 0f)
    statey = Scale(iry * iry * iry / 32767f / 32767f * viewpower3y + iry * iry / 32767f * viewpower2y + iry * viewpower1y, 0f, 32767f, (dzy / 100f) * 32767f, 32767f);
if (iry <= 0f)
    statey = Scale(-(-iry * -iry * -iry) / 32767f / 32767f * viewpower3y - (-iry * -iry) / 32767f * viewpower2y - (-iry) * viewpower1y, -32767f, 0f, -32767f, -(dzy / 100f) * 32767f);
mousex                        = statex;
mousey                        = statey;
statex                        = Math.Abs(mousex) <= 32767f ? mousex : Math.Sign(mousex) * 32767f;
statey                        = Math.Abs(mousey) <= 32767f ? mousey : Math.Sign(mousey) * 32767f;
controller1_send_rightstickx  = statex;
controller1_send_rightsticky  = statey;
mousex                        = (Joystick1AxisX - 65535f / 2f); 
mousey                        = -(Joystick1AxisY - 65535f / 2f);
statex                        = Math.Abs(mousex) <= 32767f ? mousex : Math.Sign(mousex) * 32767f;
statey                        = Math.Abs(mousey) <= 32767f ? mousey : Math.Sign(mousey) * 32767f;
controller1_send_leftstickx   = statex;
controller1_send_leftsticky   = statey;
controller1_send_up           = Joystick1PointOfViewControllers0 == 4500 | Joystick1PointOfViewControllers0 == 0 | Joystick1PointOfViewControllers0 == 31500;
controller1_send_left         = Joystick1PointOfViewControllers0 == 22500 | Joystick1PointOfViewControllers0 == 27000 | Joystick1PointOfViewControllers0 == 31500;
controller1_send_down         = Joystick1PointOfViewControllers0 == 22500 | Joystick1PointOfViewControllers0 == 18000 | Joystick1PointOfViewControllers0 == 13500;
controller1_send_right        = Joystick1PointOfViewControllers0 == 4500 | Joystick1PointOfViewControllers0 == 9000 | Joystick1PointOfViewControllers0 == 13500;
controller1_send_back         = Joystick1Buttons11;
controller1_send_start        = Joystick1Buttons12;
controller1_send_leftstick    = Joystick1Buttons13;
controller1_send_rightstick   = Joystick1Buttons14;
controller1_send_leftbumper   = Joystick1Buttons7;
controller1_send_rightbumper  = Joystick1Buttons8;
controller1_send_A            = Joystick1Buttons1;
controller1_send_B            = Joystick1Buttons2;
controller1_send_X            = Joystick1Buttons4;
controller1_send_Y            = Joystick1Buttons5;
controller1_send_lefttrigger  = Joystick1Buttons9;
controller1_send_righttrigger = Joystick1Buttons10;