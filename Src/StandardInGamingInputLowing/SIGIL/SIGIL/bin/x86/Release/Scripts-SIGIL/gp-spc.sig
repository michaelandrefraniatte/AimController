sleeptime = 8;
dzx       = 8.0f;
dzy       = 8.0f;
if (ProControllerButtonPLUS)
{
    mousexp[0] = 0f;
    mouseyp[0] = 0f;
}
mousexp[0] += Math.Round(ProControllerGyroX / 200f, 0) * 2f;
mouseyp[0] += Math.Round(ProControllerGyroY / 200f, 0) * 2f;
if (mousexp[0] >= 1024f) 
    mousexp[0] = 1024f;
if (mousexp[0] <= -1024f) 
    mousexp[0] = -1024f;
if (mouseyp[0] >= 1024f) 
    mouseyp[0] = 1024f;
if (mouseyp[0] <= -1024f) 
    mouseyp[0] = -1024f;
mousex = mousexp[0] + Math.Round(ProControllerGyroX / 200f, 0) * 2f;
mousey = mouseyp[0] + Math.Round(ProControllerGyroY / 200f, 0) * 2f;
statex = Math.Abs(-mousex * 32767f / 1024f) <= 32767f ? -mousex * 32767f / 1024f : Math.Sign(-mousex) * 32767f;
statey = Math.Abs(-mousey * 32767f / 1024f) <= 32767f ? -mousey * 32767f / 1024f : Math.Sign(-mousey) * 32767f;
if (statex > 0f)
    mousestatex = Scale(statex, 0f, 32767f, (dzx / 100f) * 32767f, 32767f);
if (statex < 0f)
    mousestatex = Scale(statex, -32767f, 0f, -32767f, -(dzx / 100f) * 32767f);
if (statey > 0f)
    mousestatey = Scale(statey, 0f, 32767f, (dzy / 100f) * 32767f, 32767f);
if (statey < 0f)
    mousestatey = Scale(statey, -32767f, 0f, -32767f, -(dzy / 100f) * 32767f);
mousex                        = mousestatex - ProControllerRightStickX * 32767f;
mousey                        = mousestatey - ProControllerRightStickY * 32767f;
statex                        = Math.Abs(mousex) <= 32767f ? mousex : Math.Sign(mousex) * 32767f;
statey                        = Math.Abs(mousey) <= 32767f ? mousey : Math.Sign(mousey) * 32767f;
controller1_send_rightstickx  = statex;
controller1_send_rightsticky  = statey;
mousex                        = -ProControllerLeftStickX * 1024f;
mousey                        = -ProControllerLeftStickY * 1024f;
controller1_send_leftstickx   = Math.Abs(-mousex * 32767f / 1024f) <= 32767f ? -mousex * 32767f / 1024f : Math.Sign(-mousex) * 32767f;
controller1_send_leftsticky   = Math.Abs(-mousey * 32767f / 1024f) <= 32767f ? -mousey * 32767f / 1024f : Math.Sign(-mousey) * 32767f;
controller1_send_down         = ProControllerButtonDPAD_DOWN;
controller1_send_left         = ProControllerButtonDPAD_LEFT;
controller1_send_right        = ProControllerButtonDPAD_RIGHT;
controller1_send_up           = ProControllerButtonDPAD_UP;
controller1_send_A            = ProControllerButtonB;
controller1_send_B            = ProControllerButtonA;  
controller1_send_Y            = ProControllerButtonX;
controller1_send_X            = ProControllerButtonY;
controller1_send_lefttrigger  = ProControllerButtonSHOULDER_Left_2;
controller1_send_righttrigger = ProControllerButtonSHOULDER_Right_2;
controller1_send_leftbumper   = ProControllerButtonSHOULDER_Left_1;
controller1_send_rightbumper  = ProControllerButtonSHOULDER_Right_1;
controller1_send_leftstick    = ProControllerButtonSTICK_Left;
controller1_send_rightstick   = ProControllerButtonSTICK_Right;
controller1_send_start        = ProControllerButtonHOME;
controller1_send_back         = ProControllerButtonCAPTURE;