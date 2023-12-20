// Program made by Jordon Milne
// December 19 2016

#include <Bounce.h>

// Creates Bounce objects which deals with button chatter

Bounce button_Dpad_Up = Bounce(0, 10);
Bounce button_Dpad_Down = Bounce(1, 10);
Bounce button_Dpad_Left = Bounce(2, 10);
Bounce button_Dpad_Right = Bounce(3, 10);

Bounce button_A = Bounce(4, 10);
Bounce button_B = Bounce(5, 10);
Bounce button_X = Bounce(6, 10);
Bounce button_Y = Bounce(7, 10);

Bounce button_Start = Bounce(8, 10);
Bounce button_Select = Bounce(9, 10);
Bounce button_Vol_Up = Bounce(10, 10);
Bounce button_Vol_Down = Bounce(11, 10);

Bounce button_L1 = Bounce(20, 10);
Bounce button_L2 = Bounce(21, 10);
Bounce button_R1 = Bounce(22, 10);
Bounce button_R2 = Bounce(23, 10);

int yAxis_Left = A0;
int xAxis_Left = A1;

int yAxis_Right = A2;
int xAxis_Right = A3;

void setup() {

  // Defines the pins on the Teensy to correspond with controller buttons.
  // Buttons use INPUT_PULLUP to activate the pullup resistor built into
  // the Teensy. Analog input only uses INPUT, no pullup resistor is needed.
  
  pinMode(0, INPUT_PULLUP); // Dpad Up
  pinMode(1, INPUT_PULLUP); // Dpad Down
  pinMode(2, INPUT_PULLUP); // Dpad Left
  pinMode(3, INPUT_PULLUP); // Dpad Right
  pinMode(4, INPUT_PULLUP); // Button A
  pinMode(5, INPUT_PULLUP); // Button B
  pinMode(6, INPUT_PULLUP); // Button X
  pinMode(7, INPUT_PULLUP); // Button Y
  pinMode(8, INPUT_PULLUP); // Button Start
  pinMode(9, INPUT_PULLUP); // Button Select
  pinMode(10, INPUT_PULLUP); // Button Vol Up
  pinMode(11, INPUT_PULLUP); // Button Vol Down
  pinMode(20, INPUT_PULLUP); // Button L1
  pinMode(21, INPUT_PULLUP); // Button L2
  pinMode(22, INPUT_PULLUP); // Button R1
  pinMode(23, INPUT_PULLUP); // Button R2

  pinMode(yAxis_Left, INPUT); // yAxis for left analog stick
  pinMode(xAxis_Left, INPUT); // xAxis for left analog stick
  pinMode(yAxis_Right, INPUT); // yAxis for right analog stick
  pinMode(xAxis_Right, INPUT); // xAxis for right analog stick
}

void loop() {

  // This updates all the buttons at a very fast rate
  
  button_Dpad_Up.update();
  button_Dpad_Down.update();
  button_Dpad_Left.update();
  button_Dpad_Right.update();
  button_A.update();
  button_B.update();
  button_X.update();
  button_Y.update();
  button_Start.update();
  button_Select.update();
  button_Vol_Up.update();
  button_Vol_Down.update();
  button_L1.update();
  button_L2.update();
  button_R1.update();
  button_R2.update();

  // Checks if button is pressed, and simulates a keyboard press.

  if(button_Dpad_Up.fallingEdge())
  {
    //Keyboard.press(KEY_W);
    Joystick.button(1, 1);
  }
  if(button_Dpad_Down.fallingEdge())
  {
    //Keyboard.press(KEY_S);
    Joystick.button(2, 1);
  }
  if(button_Dpad_Left.fallingEdge())
  {
    //Keyboard.press(KEY_A);
    Joystick.button(3, 1);
  }
  if(button_Dpad_Right.fallingEdge())
  {
    //Keyboard.press(KEY_D);
    Joystick.button(4, 1);
  }
  if(button_A.fallingEdge())
  {
    //Keyboard.press(KEY_Z);
    Joystick.button(5, 1);
  }
  if(button_B.fallingEdge())
  {
    //Keyboard.press(KEY_X);
    Joystick.button(6, 1);
  }
  if(button_X.fallingEdge())
  {
    //Keyboard.press(KEY_C);
    Joystick.button(7, 1);
  }
  if(button_Y.fallingEdge())
  {
    //Keyboard.press(KEY_V);
    Joystick.button(8, 1);
  }
  if(button_Start.fallingEdge())
  {
    //Keyboard.press(KEY_ENTER);
    Joystick.button(9, 1);
  }
  if(button_Select.fallingEdge())
  {
    //Keyboard.press(KEY_TAB);
    Joystick.button(10, 1);
  }
  if(button_Vol_Up.fallingEdge())
  {
    //Keyboard.press(KEY_9);
    Joystick.button(11, 1);
  }
  if(button_Vol_Down.fallingEdge())
  {
    //Keyboard.press(KEY_0);
    Joystick.button(12, 1);
  }
  if(button_L1.fallingEdge())
  {
    //Keyboard.press(KEY_K);
    Joystick.button(13, 1);
  }
  if(button_L2.fallingEdge())
  {
    //Keyboard.press(KEY_L);
    Joystick.button(14, 1);
  }
  if(button_R1.fallingEdge())
  {
    //Keyboard.press(KEY_N);
    Joystick.button(15, 1);
  }
  if(button_R2.fallingEdge())
  {
    //Keyboard.press(KEY_M);
    Joystick.button(16, 1);
  }

  // Check if button is released.

  if(button_Dpad_Up.risingEdge())
  {
    //Keyboard.release(KEY_W);
    Joystick.button(1, 0);
  }
  if(button_Dpad_Down.risingEdge())
  {
    //Keyboard.release(KEY_S);
    Joystick.button(2, 0);
  }
  if(button_Dpad_Left.risingEdge())
  {
    //Keyboard.release(KEY_A);
    Joystick.button(3, 0);
  }
  if(button_Dpad_Right.risingEdge())
  {
    //Keyboard.release(KEY_D);
    Joystick.button(4, 0);
  }
  if(button_A.risingEdge())
  {
    //Keyboard.release(KEY_Z);
    Joystick.button(5, 0);
  }
  if(button_B.risingEdge())
  {
    //Keyboard.release(KEY_X);
    Joystick.button(6, 0);
  }
  if(button_X.risingEdge())
  {
    //Keyboard.release(KEY_C);
    Joystick.button(7, 0);
  }
  if(button_Y.risingEdge())
  {
    //Keyboard.release(KEY_V);
    Joystick.button(8, 0);
  }
  if(button_Start.risingEdge())
  {
    //Keyboard.release(KEY_ENTER);
    Joystick.button(9, 0);
  }
  if(button_Select.risingEdge())
  {
    //Keyboard.release(KEY_TAB);
    Joystick.button(10, 0);
  }
  if(button_Vol_Up.risingEdge())
  {
    //Keyboard.release(KEY_9);
    Joystick.button(11, 0);
  }
  if(button_Vol_Down.risingEdge())
  {
    //Keyboard.release(KEY_0);
    Joystick.button(12, 0);
  }
  if(button_L1.risingEdge())
  {
    //Keyboard.release(KEY_K);
    Joystick.button(13, 0);
  }
  if(button_L2.risingEdge())
  {
    //Keyboard.release(KEY_L);
    Joystick.button(14, 0);
  }
  if(button_R1.risingEdge())
  {
    //Keyboard.release(KEY_N);
    Joystick.button(15, 0);
  }
  if(button_R2.risingEdge())
  {
    //Keyboard.release(KEY_M);
    Joystick.button(16, 0);
  }

  // Left analog stick
  Joystick.X(analogRead(xAxis_Left));
  Joystick.Y(analogRead(yAxis_Left));

  // Right analog stick
  Joystick.Z(analogRead(xAxis_Right));
  Joystick.Zrotate(analogRead(yAxis_Right));
}
