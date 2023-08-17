double viewpower05x = 0f, viewpower05y = 0f;
valchanged(0, Keyboard1KeyAdd);
if (wd[0] == 1 & !getstate[0]) 
{
    width    = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
    height   = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
    getstate[0] = true;
}
else 
{ 
    if (wd[0] == 1 & getstate[0]) 
    {
        getstate[0] = false;
    }
}
if (getstate[0])
{
    statex = -Mouse1AxisX * 50f;
    statey = Mouse1AxisY * 50f;
    if (statex >= 1024f)
        statex = 1024f;
    if (statex <= -1024f)
        statex = -1024f;
    if (statey >= 1024f)
        statey = 1024f;
    if (statey <= -1024f)
        statey = -1024f;
    if (statex >= 0f)
        mousex = Scale(Math.Pow(statex, 3f) / Math.Pow(1024f, 2f) * viewpower3x + Math.Pow(statex, 2f) / Math.Pow(1024f, 1f) * viewpower2x + Math.Pow(statex, 1f) / Math.Pow(1024f, 0f) * viewpower1x + Math.Pow(statex, 0.5f) * Math.Pow(1024f, 0.5f) * viewpower05x, 0f, 1024f, (dzx / 100f) * 1024f, 1024f);
    if (statex <= 0f)
        mousex = Scale(-Math.Pow(-statex, 3f) / Math.Pow(1024f, 2f) * viewpower3x - Math.Pow(-statex, 2f) / Math.Pow(1024f, 1f) * viewpower2x - Math.Pow(-statex, 1f) / Math.Pow(1024f, 0f) * viewpower1x - Math.Pow(-statex, 0.5f) * Math.Pow(1024f, 0.5f) * viewpower05x, -1024f, 0f, -1024f, -(dzx / 100f) * 1024f);
    if (statey >= 0f)
        mousey = Scale(Math.Pow(statey, 3f) / Math.Pow(1024f, 2f) * viewpower3y + Math.Pow(statey, 2f) / Math.Pow(1024f, 1f) * viewpower2y + Math.Pow(statey, 1f) / Math.Pow(1024f, 0f) * viewpower1y + Math.Pow(statey, 0.5f) * Math.Pow(1024f, 0.5f) * viewpower05y, 0f, 1024f, (dzy / 100f) * 1024f, 1024f);
    if (statey <= 0f)
        mousey = Scale(-Math.Pow(-statey, 3f) / Math.Pow(1024f, 2f) * viewpower3y - Math.Pow(-statey, 2f) / Math.Pow(1024f, 1f) * viewpower2y - Math.Pow(-statey, 1f) / Math.Pow(1024f, 0f) * viewpower1y - Math.Pow(-statey, 0.5f) * Math.Pow(1024f, 0.5f) * viewpower05y, -1024f, 0f, -1024f, -(dzy / 100f) * 1024f);
    controller1_send_rightstickx  = Math.Abs(-mousex * 32767f / 1024f) <= 32767f ? -mousex * 32767f / 1024f : Math.Sign(-mousex) * 32767f;
    controller1_send_rightsticky  = Math.Abs(-mousey * 32767f / 1024f) <= 32767f ? -mousey * 32767f / 1024f : Math.Sign(-mousey) * 32767f;
    controller1_send_left         = Keyboard1KeyZ;
    controller1_send_right        = Keyboard1KeyV;
    controller1_send_down         = Keyboard1KeyC;
    controller1_send_up           = Keyboard1KeyX;
    controller1_send_rightstick   = Keyboard1KeyE;
    controller1_send_leftstick    = Keyboard1KeyLeftShift;
    controller1_send_A            = Keyboard1KeySpace;
    controller1_send_back         = Keyboard1KeyTab;
    controller1_send_start        = Keyboard1KeyEscape;
    controller1_send_X            = Mouse1Buttons2 | Keyboard1KeyR;
    controller1_send_rightbumper  = Keyboard1KeyG | Mouse1Buttons4;
    controller1_send_leftbumper   = Keyboard1KeyT | Mouse1Buttons3;
    controller1_send_B            = Keyboard1KeyLeftControl | Keyboard1KeyQ;
    controller1_send_Y            = Mouse1AxisZ > 0 | Mouse1AxisZ < 0;
    controller1_send_righttrigger = Mouse1Buttons0;
    if (Keyboard1KeyW)
        controller1_send_leftsticky = 32767;
    if (Keyboard1KeyS)
        controller1_send_leftsticky = -32767;
    if ((!Keyboard1KeyW & !Keyboard1KeyS) | (Keyboard1KeyW & Keyboard1KeyS))
        controller1_send_leftsticky = 0;
    if (Keyboard1KeyD)
        controller1_send_leftstickx = 32767;
    if (Keyboard1KeyA)
        controller1_send_leftstickx = -32767;
    if ((!Keyboard1KeyD & !Keyboard1KeyA) | (Keyboard1KeyD & Keyboard1KeyA))
        controller1_send_leftstickx = 0;
    valchanged(1, Mouse1Buttons1);
    if (wd[1] == 1 & !getstate[1]) 
    {
        getstate[1] = true;
    }
    else 
    { 
        if (wd[1] == 1 & getstate[1]) 
        {
            getstate[1] = false;
        }
    }
    if (controller1_send_X | controller1_send_Y | controller1_send_rightbumper | controller1_send_leftbumper | controller1_send_rightstick | controller1_send_leftstick | controller1_send_back | controller1_send_start)
    {
        getstate[1] = false;
    }
    controller1_send_lefttrigger = getstate[1];
}
else 
{
    controller1_send_rightstickx  = 0;
    controller1_send_rightsticky  = 0;
    controller1_send_leftstickx   = 0;
    controller1_send_leftsticky   = 0;
    controller1_send_left         = false;
    controller1_send_right        = false;
    controller1_send_down         = false;
    controller1_send_up           = false;
    controller1_send_rightstick   = false;
    controller1_send_leftstick    = false;
    controller1_send_A            = false;
    controller1_send_back         = false;
    controller1_send_start        = false;
    controller1_send_X            = false;
    controller1_send_rightbumper  = false;
    controller1_send_leftbumper   = false;
    controller1_send_B            = false;
    controller1_send_Y            = false;
    controller1_send_lefttrigger  = false;
    controller1_send_righttrigger = false;
}