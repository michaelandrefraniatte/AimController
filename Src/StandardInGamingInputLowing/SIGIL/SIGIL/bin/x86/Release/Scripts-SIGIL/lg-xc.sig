KeyboardMouseDriverType = "kmevent";
sleeptime               = 21;
double limit            = 127f;
valchanged(0, Controller1ButtonBackPressed);
if (wd[0] == 1 & !getstate[0]) 
{
    getstate[0] = true;
}
else 
{ 
    if (wd[0] == 1 & getstate[0]) 
    {
        MouseMoveX     = 0;
        MouseMoveY     = 0;
        MouseDesktopX  = 0;
        MouseDesktopY  = 0;
        MouseAbsX      = 0;
        MouseAbsY      = 0;
        SendD          = false;
        SendQ          = false;
        SendZ          = false;
        SendS          = false;
        Send8          = false;
        Send7          = false;
        Send9          = false;
        Send6          = false;
        SendB          = false;  
        Send1          = false;
        Send2          = false;
        Send3          = false;
        Send4          = false;
        SendSpace      = false;
        SendLeftShift  = false;
        SendE          = false;
        SendA          = false;
        SendV          = false;
        SendEscape     = false;
        SendTab        = false;
        SendR          = false;
        SendF          = false;
        SendT          = false;
        SendG          = false;
        SendY          = false; 
        SendU          = false;
        SendX          = false;
        SendC          = false;
        SendRightClick = false;
        SendLeftClick  = false;
        getstate[0]       = false;
    }
}
if (getstate[0]) 
{
    statex = Math.Abs(Controller1ThumbRightX / 32767f * limit) <= limit ? Controller1ThumbRightX / 32767f * limit : Math.Sign(Controller1ThumbRightX) * limit;
    statey = Math.Abs(Controller1ThumbRightY / 32767f * limit) <= limit ? Controller1ThumbRightY / 32767f * limit : Math.Sign(Controller1ThumbRightY) * limit;
    if (statex >= (dzx / 100f) * limit & statex <= limit)
        mousex = Scale(statex, (dzx / 100f) * limit, limit, 0f, limit);
    if (statex <= -(dzx / 100f) * limit & statex >= -limit)
        mousex = Scale(statex, -limit, -(dzx / 100f) * limit, -limit, 0f);
    if (statex <= (dzx / 100f) * limit & statex >= -(dzx / 100f) * limit)
        mousex = 0f;
    if (statey >= (dzy / 100f) * limit & statey <= limit)
        mousey = Scale(statey, (dzy / 100f) * limit, limit, 0f, limit);
    if (statey <= -(dzy / 100f) * limit & statey >= -limit)
        mousey = Scale(statey, -limit, -(dzy / 100f) * limit, -limit, 0f);
    if (statey <= (dzy / 100f) * limit & statey >= -(dzy / 100f) * limit)
        mousey = 0f;
    MouseMoveX     = Math.Sign(Controller1ThumbRightX) * (Math.Abs(statex * statex * statex) / limit / limit * viewpower3x + Math.Abs(statex * statex) / limit * viewpower2x + Math.Abs(statex) * viewpower1x);
    MouseMoveY     = -Math.Sign(Controller1ThumbRightY) * (Math.Abs(statey * statey * statey) / limit / limit * viewpower3y + Math.Abs(statey * statey) / limit * viewpower2y + Math.Abs(statey) * viewpower1y);
    SendD          = Controller1ThumbLeftX > 32767f / 5f;
    SendQ          = Controller1ThumbLeftX < -32767f / 5f;
    SendZ          = Controller1ThumbLeftY > 32767f / 5f;
    SendS          = Controller1ThumbLeftY < -32767f / 5f;
    Send0          = Controller1ButtonDownPressed;
    Send1          = Controller1ButtonLeftPressed;
    Send2          = Controller1ButtonRightPressed;
    Send3          = Controller1ButtonUpPressed;
    SendSpace      = Controller1ButtonShoulderLeftPressed;
    SendLeftShift  = Controller1ButtonShoulderRightPressed;
    SendB          = Controller1ThumbpadRightPressed;  
    SendR          = Controller1ButtonXPressed;
    SendF          = Controller1ButtonYPressed;
    SendX          = Controller1ButtonAPressed;
    SendC          = Controller1ButtonBPressed;
    SendRightClick = Controller1TriggerLeftPosition >= 250f;
    SendLeftClick  = Controller1TriggerRightPosition >= 250f;
    SendH          = Controller1ThumbpadLeftPressed;
    SendEscape     = Controller1ButtonStartPressed;
}