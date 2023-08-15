viewpower1x = 0.08f;
viewpower2x = 0f;
viewpower3x = 0.92f;
viewpower1y = 0.08f;
viewpower2y = 0f;
viewpower3y = 0.92f;
dzx         = 0f;
dzy         = 0f;
sleeptime   = 12;
valchanged(0, WiimoteButtonStateOne);
if (wd[0] == 1 & !getstate[0]) 
{
    width  = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
    height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
    getstate[0] = true;
}
else 
{ 
    if (wd[0] == 1 & getstate[0]) 
    {
        int_1_deltaX         = 0;
        int_1_deltaY         = 0;
        MouseDesktopX        = 0;
        MouseDesktopY        = 0;
        int_1_x              = 0;
        int_1_y              = 0;
        int_1_SendD          = false;
        int_1_SendQ          = false;
        int_1_SendZ          = false;
        int_1_SendS          = false;
        int_1_SendEight      = false;
        int_1_SendSeven      = false;
        int_1_SendNine       = false;
        int_1_SendSix        = false;
        int_1_SendB          = false;  
        int_1_SendOne        = false;
        int_1_SendTwo        = false;
        int_1_SendThree      = false;
        int_1_SendFour       = false;
        int_1_SendSpace      = false;
        int_1_SendLeftShift  = false;
        int_1_SendE          = false;
        int_1_SendA          = false;
        int_1_SendV          = false;
        int_1_SendEscape     = false;
        int_1_SendTab        = false;
        int_1_SendR          = false;
        int_1_SendF          = false;
        int_1_SendT          = false;
        int_1_SendG          = false;
        int_1_SendY          = false; 
        int_1_SendU          = false;
        int_1_SendX          = false;
        int_1_SendC          = false;
        int_1_SendRightClick = false;
        int_1_SendLeftClick  = false;
        getstate[0]       = false;
    }
}
if (getstate[0]) 
{
    if (irx >= 0f)
        mousex = Scale(irx * irx * irx / 1024f / 1024f * viewpower3x + irx * irx / 1024f * viewpower2x + irx * viewpower1x, 0f, 1024f, (dzx / 100f) * 1024f, 1024f);
    if (irx <= 0f)
        mousex = Scale(-(-irx * -irx * -irx) / 1024f / 1024f * viewpower3x - (-irx * -irx) / 1024f * viewpower2x - (-irx) * viewpower1x, -1024f, 0f, -1024f, -(dzx / 100f) * 1024f);
    if (iry >= 0f)
        mousey = Scale(iry * iry * iry / 1024f / 1024f * viewpower3y + iry * iry / 1024f * viewpower2y + iry * viewpower1y, 0f, 1024f, (dzy / 100f) * 1024f, 1024f);
    if (iry <= 0f)
        mousey = Scale(-(-iry * -iry * -iry) / 1024f / 1024f * viewpower3y - (-iry * -iry) / 1024f * viewpower2y - (-iry) * viewpower1y, -1024f, 0f, -1024f, -(dzy / 100f) * 1024f);  
    int_1_deltaX        = -mousex * 600 / 1024f;
    int_1_deltaY        = mousey * 400 / 1024f;
    MouseDesktopX       = width / 2f - mousex * width / 2f / 1024f;
    MouseDesktopY       = height / 2f + mousey * height / 2f / 1024f;
    int_1_SendD         = WiimoteNunchuckStateRawJoystickX >= 60f; /* Droite */
    int_1_SendA         = WiimoteNunchuckStateRawJoystickX <= -60f; /* Gauche */
    int_1_SendW         = WiimoteNunchuckStateRawJoystickY >= 60f; /* Avancer */
    int_1_SendS         = WiimoteNunchuckStateRawJoystickY <= -60f; /* Reculer */
    int_1_SendSpace     = WiimoteNunchuckStateC; /* Frapper fort */
    int_1_SendLeftShift = WiimoteNunchuckStateZ; /* Courir */
    int_1_SendV         = WiimoteNunchuckStateRawValuesY > 33f; /* Coup de pieds */
    int_1_SendEscape    = WiimoteButtonStateTwo; /* Passer */
    int_1_SendTab       = WiimoteButtonStateOne; /* Map */
    int_1_SendR         = ((WiimoteRawValuesZ > 0 ? WiimoteRawValuesZ : -WiimoteRawValuesZ) >= 30f & (WiimoteRawValuesY > 0 ? WiimoteRawValuesY : -WiimoteRawValuesY) >= 30f & (WiimoteRawValuesX > 0 ? WiimoteRawValuesX : -WiimoteRawValuesX) >= 30f); /* Recharger */
    int_1_SendF         = WiimoteButtonStateHome; /* Action */
    int_1_SendT         = WiimoteButtonStateMinus; /* Soigner */
    int_1_SendG         = WiimoteButtonStatePlus; /* Utiliser objet */
    int_1_SendY         = WiimoteButtonStateLeft; /* Objet suivant */
    int_1_SendU         = WiimoteButtonStateRight; /* Arme suivante */
    int_1_SendX         = WiimoteButtonStateUp; /* Zoomer */
    int_1_SendC         = WiimoteButtonStateDown; /* A genoux */
    int_1_SendLeftClick = WiimoteButtonStateB; /* Tirer */
    valchanged(1, WiimoteButtonStateA);
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
    if (int_1_SendSpace | int_1_SendLeftShift | int_1_SendV | int_1_SendEscape | int_1_SendTab | int_1_SendR | int_1_SendF | int_1_SendT | int_1_SendG | int_1_SendY | int_1_SendU | int_1_SendX | int_1_SendC)
    {
        getstate[1] = false;
    }
    int_1_SendRightClick = getstate[1]; /* Viser */
}