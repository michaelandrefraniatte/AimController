sleeptime = 1;
valchanged(0, Keyboard1KeyAdd);
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
        pollcount[0] = 0;
        pollcount[1] = 0;
        pollcount[2] = 0;
        pollcount[3] = 0;
        pollcount[4] = 0;
        pollcount[5] = height;
        SendLeftClick = false;
        MouseDesktopX = 0;
        MouseDesktopY = 0;
        MouseMoveX    = 0;
        MouseMoveY    = 0;
        getstate[0] = false;
    }
}
if (getstate[0]) 
{
    if ((pollcount[1] < width | pollcount[2] < height) & Keyboard1KeyPageDown)
    {
        pollcount[0]++;
        if (pollcount[0] == 1)
        {
            pollcount[1] = pollcount[1] + 6;
            if (pollcount[1] > width)
            {
                pollcount[1] = 0;
                pollcount[2] = pollcount[2] + 6;
            }
            MouseDesktopX = pollcount[1];
            MouseDesktopY = pollcount[2];
        }
        if (pollcount[0] == 2)
        {
            SendLeftClick = true;
        }
        if (pollcount[0] >= 3)
        {
            pollcount[0] = 0;
            SendLeftClick = false;
        }
    }
    if ((pollcount[4] < width | pollcount[5] > 0) & Keyboard1KeyPageUp)
    {
        pollcount[3]++;
        if (pollcount[3] == 1)
        {
            pollcount[4] = pollcount[4] + 6;
            if (pollcount[4] > width)
            {
                pollcount[4] = 0;
                pollcount[5] = pollcount[5] - 6;
            }
            MouseDesktopX = pollcount[4];
            MouseDesktopY = pollcount[5];
        }
        if (pollcount[3] == 2)
        {
            SendLeftClick = true;
        }
        if (pollcount[3] >= 3)
        {
            pollcount[3] = 0;
            SendLeftClick = false;
        }
    }
}