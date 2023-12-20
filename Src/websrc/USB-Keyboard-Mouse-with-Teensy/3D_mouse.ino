/* 3D Mouse
 * Created by Christian @ Core Electronics on 27/06/18
 * Buttons:
 * 1 Save                       1' Measure
 * 2 Redo                       2' Wheel
 * 3 Undo                       3' Orbit
 * 4 Delete                     4' Upload
 */

//  Include Relevant Libraries
#include <Bounce.h>

//  Declare Pin Assignments
  //  The linear slide pot is here
const int potSlider = A2;
  //  The x and y components from the joystick are here
const int yPin = A1;
const int xPin = A0;
  //  The internal built LED is here
const int ledPin = 13;
  //  The click functionality of the joystick is here
const int shiftPin = 12;
  //  The buttons are here 
const int buttonFour = 6;
const int buttonThree = 5;
const int buttonTwo = 4;
const int buttonOne = 3;

//  Declare Variables
bool shiftState = false;
float joySpeed = 0;
float xMovement = 0;
float yMovement = 0;

//  Define  Constants
  //  The debounce library constants are here
const int BUTTON_NUM = 4;
const int DEBOUNCE_TIME = 5;
  //  The normal (letter/number) keybinds are here for shift pressed (P) and
  //  shift not pressed (NP)
const int KEYBIND_SHIFT_P[BUTTON_NUM] = {KEY_S, KEY_Y, KEY_Z, KEY_DELETE};
const int KEYBIND_SHIFT_NP[BUTTON_NUM] = {KEY_M, KEY_W, 0, KEY_U};
  //  The modifier (shift, ctrl, etc.) keybinds are here for shift pressed (P)
  //  and shift not pressed (NP)
const int KEYBIND_MOD_SHIFT_P[BUTTON_NUM] = {MODIFIERKEY_CTRL, MODIFIERKEY_CTRL, MODIFIERKEY_CTRL, 0};
const int KEYBIND_MOD_SHIFT_NP[BUTTON_NUM] = {0, MODIFIERKEY_CTRL, 0, MODIFIERKEY_CTRL}; 

//  Create the push-button bounce instances
Bounce buttonArray[BUTTON_NUM] = {
  Bounce(buttonOne, DEBOUNCE_TIME),
  Bounce(buttonTwo, DEBOUNCE_TIME),
  Bounce(buttonThree, DEBOUNCE_TIME),
  Bounce(buttonFour, DEBOUNCE_TIME)
};

//  Create the joystick bounce instance
Bounce shiftButton = Bounce(shiftPin, DEBOUNCE_TIME);

void setup() {
  //  Define the Pullup configuration for each button
  pinMode(buttonOne, INPUT_PULLUP);
  pinMode(buttonTwo, INPUT_PULLUP);
  pinMode(buttonThree, INPUT_PULLUP);
  pinMode(buttonFour, INPUT_PULLUP);
  pinMode(shiftPin, INPUT_PULLUP);

  //  Define the pinMode for the led
  pinMode(ledPin, OUTPUT);  
}

void loop() {
  //  Update the button states
  shiftButton.update();
  for(int i = 0; i < BUTTON_NUM; i++){
    buttonArray[i].update();
  }

  //  Measure and scale the value of the slidePot
  //  and joystick
  joySpeed = map(analogRead(potSlider), 0 , 1023, 1, 3);
  xMovement = map(analogRead(xPin), 0, 1023, -2, 2);
  yMovement = map(analogRead(yPin), 0, 1023, -2, 2);
  
  //  Make the mouse move 
  Mouse.move(joySpeed*xMovement, -joySpeed*yMovement);

  //  For loop to scan through the buttons and apply the
  //  required state
  for(int i = 0; i < BUTTON_NUM; i++){
    if(buttonArray[i].fallingEdge()){
      //  Check to see if the shiftState is NOT active 
      if(!shiftState){
        //  Apply the normal state keybinds
        Keyboard.set_modifier(KEYBIND_MOD_SHIFT_P[i]);
        Keyboard.set_key1(KEYBIND_SHIFT_P[i]);
        Keyboard.send_now();
        Serial.println(KEYBIND_MOD_SHIFT_P[i]);
        Serial.println(KEYBIND_SHIFT_P[i]);
        }else{
        //  Apply the shift state keybinds
        Keyboard.set_modifier(KEYBIND_MOD_SHIFT_NP[i]);
        Keyboard.set_key1(KEYBIND_SHIFT_NP[i]);
        Keyboard.send_now();
        Serial.println(KEYBIND_MOD_SHIFT_NP[i]);
        Serial.println(KEYBIND_SHIFT_NP[i]);
      }
    }else if(buttonArray[i].risingEdge()){
      //  If no buttons are pressed, send nothing
      Keyboard.set_modifier(0);
      Keyboard.set_key1(0);
      Keyboard.send_now();
      Serial.println("Reset");
    }
  }

  //  For Orbit control. This is different as it includes a middle mouse click
  if(buttonArray[2].fallingEdge()){
    Keyboard.set_modifier(MODIFIERKEY_SHIFT);
    Keyboard.send_now();
    Mouse.set_buttons(0,1,0);
  } else if(buttonArray[2].risingEdge()){
    Keyboard.set_modifier(0);
    Keyboard.send_now();
    Mouse.set_buttons(0,0,0);    
  }
  
  //  Check the state of the 'shift' button
  if(shiftButton.fallingEdge()){
    shiftState = shiftState ^ 1;
    digitalWrite(ledPin, shiftState);
  }
}
