#if defined(__MK20DX256__) // the CPU of the Teensy 3.1 / 3.2
    #if !defined(USB_SERIAL_HID)
        #error "Switch the compiler to USB Type = 'Serial + Keyboard + Mouse + Joystick'"
    #endif
    #if F_CPU < 72000000
        #error "Switch the compiler to CPU Speed = '72 MHz optimized'" 
    #endif
#else
    #error "This code must be compiled for Teensy 3.1 / 3.2"
#endif

// debugging
#define PRINT_RAW_SAMPLES  true  // true --> the intervals in µs of HIGH and LOW on the infrared input pin are printed to the Serial USB port.

// constants
#define MAX_SAMPLES    200       // Usually remote controls send less than 70 samples.
#define IR_INPUT_PIN   1         // You can chose any digital pin.
#define END_OF_COMAND  15000     // The time in µs that the IR input pin must stay high before this is detecetd as the end of the command.
#define MAX_BITLEN     4         // If a HIGH or LOW interval is longer than MAX_BITLEN bits, it is replaced with 'X' or 'x'.


// global variables
uint64_t    gu64_LastTick;
byte        gu8_LastState;
uint32_t    gu32_LastCommand;
int         gs32_Samples[MAX_SAMPLES];
int         gs32_SampleCount;

void setup(void) 
{
    gu64_LastTick    = 0;
    gu8_LastState    = HIGH;
    gu32_LastCommand = 0;
    gs32_SampleCount = 0;    
  
    pinMode(IR_INPUT_PIN, INPUT_PULLUP);
    pinMode(LED_BUILTIN,  OUTPUT);

    // Open USB Serial port (CDC)
    // The baudrate does not matter on Teensy 3.2 (it's always USB Full speed)
    Serial.begin(115200);   

    digitalWrite(LED_BUILTIN, HIGH);
    delay(250);
    digitalWrite(LED_BUILTIN, LOW);
}

// shortest loop cycle: 10 µs at 24 MHz CPU clock
// shortest loop cycle:  6 µs at 48 MHz CPU clock
// shortest loop cycle:  5 µs at 72 MHz CPU clock
// shortest loop cycle:  4 µs at 96 MHz CPU clock
void loop(void) 
{
    uint64_t u64_Tick = GetMicros64();
    int   s32_Elapsed = (int)(u64_Tick - gu64_LastTick);
  
    byte u8_IR = digitalRead(IR_INPUT_PIN);
    if  (u8_IR == gu8_LastState)
    {
        if (u8_IR == HIGH && s32_Elapsed > END_OF_COMAND && gs32_SampleCount > 0)
        {
            DecodeRawIntervals(); // The signal is complete -> decode
            gu64_LastTick    = 0;
            gs32_SampleCount = 0;
            digitalWrite(LED_BUILTIN, LOW);
        }
        return;
    }

    bool b_FirstSample = (gu64_LastTick == 0);

    gu8_LastState = u8_IR;
    gu64_LastTick = u64_Tick;

    if (b_FirstSample)
    {
        digitalWrite(LED_BUILTIN, HIGH);
        return; // The time that has elapsed before the start of the IR command does not interest.
    }

    if (gs32_SampleCount == MAX_SAMPLES - 2)
        Serial.println("Sample buffer overflow"); // Print this message only once

    if (gs32_SampleCount < MAX_SAMPLES)
        gs32_Samples[gs32_SampleCount++] = s32_Elapsed;
}

void DecodeRawIntervals()
{
    char s8_Temp[200];
    char s8_Decoded[MAX_SAMPLES] = {0};  
              
    // Get the shortest interval of all intervals separately for High and Low.
    int s32_ShortestHi = 999999999;
    int s32_ShortestLo = 999999999;

    for (int i=0; i<gs32_SampleCount; i++)
    {
        if ((i&1) == 1) // Hi (The first sample is always LOW)
        {
            if (gs32_Samples[i] < s32_ShortestHi)
                s32_ShortestHi = gs32_Samples[i];
        }  
        else // Lo
        {
            if (gs32_Samples[i] < s32_ShortestLo)
                s32_ShortestLo = gs32_Samples[i];
        }
    }

    // Get the average of all short intervals (which are shorter than s32_Shortest * 1.5)
    int s32_AverageLo  = 0;
    int s32_AverageHi  = 0;
    int s32_AvgCountLo = 0;
    int s32_AvgCountHi = 0;
    int s32_LimitLo    = s32_ShortestLo + s32_ShortestLo / 2;
    int s32_LimitHi    = s32_ShortestHi + s32_ShortestHi / 2;

    for (int i=0; i<gs32_SampleCount; i++)
    {
        if ((i&1) == 1) // Hi (The first sample is always LOW)
        {
            if (gs32_Samples[i] < s32_LimitHi)
            {
                s32_AverageHi += gs32_Samples[i];
                s32_AvgCountHi ++;
            }
        }
        else // Lo
        {
            if (gs32_Samples[i] < s32_LimitLo)
            {
                s32_AverageLo += gs32_Samples[i];
                s32_AvgCountLo ++;
            }
        }
    }

    // Avoid division by zero crash
    if (s32_AvgCountLo > 0) s32_AverageLo /= s32_AvgCountLo; 
    if (s32_AvgCountHi > 0) s32_AverageHi /= s32_AvgCountHi;

    // Very short signals (like the Yamaha repeater sequence) have only one short pulse which is Low.
    // ---         ---- -------------
    //       16     4  1   
    //    ---------    -
    // So the only Hi pulse of 4 cycles is detected as the shortest Hi pulse. But it is not a short pulse.
    bool b_HiValid = true;
    bool b_LoValid = true;
    if (s32_AverageHi > s32_AverageLo * 2) { s32_AverageHi = s32_AverageLo;  b_HiValid = false; }
    if (s32_AverageLo > s32_AverageHi * 2) { s32_AverageLo = s32_AverageHi;  b_LoValid = false; }    

    for (int i=0; i<gs32_SampleCount; i++)
    {
        bool b_High = (i&1) == 1; // The first sample is always LOW
      
        int s32_Interval = gs32_Samples[i];
        int s32_Average  = b_High ? s32_AverageHi : s32_AverageLo;
        int s32_BitLen   = (s32_Interval + s32_Average / 2) / s32_Average;

        // Convert LOW intervals into lowercase characters and HIGH intervals into upper case characters
        char s8_Char = (b_High ? 'A' : 'a') + max(0, s32_BitLen - 1); 

        // At the beginning of the IR command there are usually very long intervals of 5, 8 or 16 bits of HIGH or LOW.
        // These are used to wake up the microprocesser in the Hifi device / TV. 
        // They are not precise (not an integer multiple of the average short interval) so they may be for example one time 'p' and next time 'o'.
        // For that reason they are replaced with an 'X' or 'x' here.
        if (s32_BitLen > MAX_BITLEN)
            s8_Char = b_High ? 'X' : 'x';

        s8_Decoded[i] = s8_Char;

        #if PRINT_RAW_SAMPLES            
            int s32_Limit = b_High ? s32_LimitHi : s32_LimitLo;
            
            sprintf(s8_Temp, "%s: %5d us %s --> Len: %2d --> Char: '%c'", b_High ? "Hi" : "Lo",
                                                                          s32_Interval, 
                                                                          s32_Interval < s32_Limit ? "short" : "     ",
                                                                          s32_BitLen,
                                                                          s8_Char);
            Serial.println(s8_Temp);
        #endif            
    }

    #if PRINT_RAW_SAMPLES            
        if (b_LoValid)
        {
            sprintf(s8_Temp, "Lo: Shortest: %4d us, Limit: %4d us, Average over %2d short intervals: %4d us", s32_ShortestLo, s32_LimitLo, s32_AvgCountLo, s32_AverageLo);
            Serial.println(s8_Temp);
        }
        if (b_HiValid)
        {
            sprintf(s8_Temp, "Hi: Shortest: %4d us, Limit: %4d us, Average over %2d short intervals: %4d us", s32_ShortestHi, s32_LimitHi, s32_AvgCountHi, s32_AverageHi);
            Serial.println(s8_Temp);
        }
    #endif

    sprintf(s8_Temp, "Decoded: %s", s8_Decoded);
    Serial.println(s8_Temp);

    uint32_t u32_CRC = CalcCrc32(s8_Decoded);

    sprintf(s8_Temp, "CRC:     0x%08X", (unsigned int)u32_CRC);
    Serial.println(s8_Temp);

    ExecuteAction(u32_CRC);

    Serial.println("--------------------------\n");
}

void ExecuteAction(uint32_t u32_CRC)
{
    // If you for example increase the volume, most remote controls (not all) send once the command "Volume Up" and then 
    // they send only the repeater sequence until you release the button on the remote control.
    // The repeater must be replaced here with the last detected command, but ONLY if the command has to be repeated.
    // It makes sense to repeat the 'Volume Up' command but it does not make any sense to repeat the 'Pause' command 
    // which would toggle Play/Pause multiple times per second as long as you press the button on the remote control.
    
    if (u32_CRC == 0xBBBD520D || // Repeater "xCa"
        u32_CRC == 0xF4FCC4CA)   // Repeater "xDa"
    {
        u32_CRC = gu32_LastCommand;
    }

    bool b_Repeat = false; // By default do not repeat commands
    switch (u32_CRC)
    {
       // --------------------------------------------------------------
       case 0xA02397AF:
          Serial.println("Button:  Enter");          
          break;
       case 0x1856440C:
          Serial.println("Button:  Volume Up");
          // ATTENTION: This is only for testing. Let the volume on the computer always at 100%. Regulate the volume on the amplifier instead!
          // PressKey(0, 0, KEY_MEDIA_VOLUME_INC);  // Volume Up
          b_Repeat = true; // Repeat this command the next time when the repeater sequence is received
          break;
       case 0xA7336C7A:
          Serial.println("Button:  Volume Down");    
          // ATTENTION: This is only for testing. Let the volume on the computer always at 100%. Regulate the volume on the amplifier instead!
          // PressKey(0, 0, KEY_MEDIA_VOLUME_DEC);  // Volume Down
          b_Repeat = true; // Repeat this command the next time when the repeater sequence is received
          break;
       case 0x7F8101DE:
          Serial.println("Button:  Menu Left");      
          break;
       case 0xC0E429A8:
          Serial.println("Button:  Menu Right");     
          break;
       case 0xE62E0363:
          Serial.println("Button:  Menu Up");        
          break;
       case 0x594B2B15:
          Serial.println("Button:  Menu Down");      
          break;
       case 0xA9EBE518:
          Serial.println("Button:  Tuning Up");      
          PressKey(MODIFIERKEY_ALT,  KEY_RIGHT, 0);  // Next Track
          break;
       case 0x168ECD6E:
          Serial.println("Button:  Tuning Down");  
          PressKey(MODIFIERKEY_ALT,  KEY_LEFT,  0);  // Previous Track  
          break;
       case 0x8F21CFD3:
          Serial.println("Button:  Play");    
          PressKey(MODIFIERKEY_CTRL, KEY_P, 0);      // Play
          break;
       case 0x3044E7A5:
          Serial.println("Button:  Stop");           
          PressKey(MODIFIERKEY_CTRL, KEY_S, 0);      // Stop
          break;
       case 0x57041AEF:
          Serial.println("Button:  Pause");          
          PressKey(0, KEY_PAUSE, 0);                 // Pause
          break;
       // --------------------------------------------------------------   
       case 0x00000000:
          Serial.println("Repeater ignored"); 
          break;
       default:          
          Serial.println("Button:  Not recognized"); 
          break;
    }

    gu32_LastCommand = b_Repeat ? u32_CRC : 0;
}

// Send keystrokes to the computer via virtual USB keyboard.
// Obviously the program that you want to control must be the foreground window.
// u8_Modifier may be MODIFIERKEY_CTRL, MODIFIERKEY_SHIFT, MODIFIERKEY_ALT, MODIFIERKEY_GUI, etc..
// u8_Key may be KEY_A, KEY_ENTER, KEY_F1, KEY_LEFT, KEYPAD_1, etc..
// u8_MediaKey may be KEY_MEDIA_VOLUME_INC, KEY_MEDIA_PLAY_PAUSE, KEY_MEDIA_STOP, KEY_MEDIA_EJECT, etc..
// For a complete list see: ...\Arduino\hardware\teensy\avr\cores\teensy3\keylayouts.h
void PressKey(int s32_Modifier, int s32_Key, int s32_MediaKey)
{
    // press key
    Keyboard.set_modifier(s32_Modifier);
    Keyboard.set_key1    (s32_Key);
    Keyboard.set_media   (s32_MediaKey);
    Keyboard.send_now();
    
    // release key
    Keyboard.set_modifier(0);             
    Keyboard.set_key1    (0);
    Keyboard.set_media   (0);           
    Keyboard.send_now();
}

// Calculaters the CRC32 of a string
uint32_t CalcCrc32(const char* s8_Data)
{
    uint32_t u32_CRC = 0xFFFFFFFF;
    for (int i=0; s8_Data[i] != 0; i++)
    {
        u32_CRC ^= (byte)s8_Data[i];
        for (int b=0; b<8; b++)
        {
            bool b_Bit = (u32_CRC & 1) > 0;
            u32_CRC >>= 1;
            if (b_Bit) u32_CRC ^= 0xEDB88320;
        }
    }
    return u32_CRC;
}

// We need a special time counter that does not roll over after one hour (as micros() does) 
uint64_t GetMicros64()
{
    static uint32_t u32_High = 0;
    static uint32_t u32_Last = 0;

    uint32_t u32_Now = micros(); // starts at zero after CPU reset

    // Check for roll-over
    if (u32_Now < u32_Last) u32_High ++;
    u32_Last = u32_Now;

    uint64_t u64_Time = u32_High;
    u64_Time <<= 32;
    u64_Time |= u32_Now;
    return u64_Time;
}

