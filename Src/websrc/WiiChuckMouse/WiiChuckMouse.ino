/**
   WiiChuckMouse - Uses a teensy to map the input from a Wii nunchuck
   controller to mouse clicks and movement.

   ---Controls---
   Accelerometer = mouse move
   Z = left click
   C = right click
   Joystick Y-axis = scroll wheel

   Holding Z+C for ~3 seconds will disable the wiichuck so that you
   can set it down and type or whatever. Holding Z+C again will
   re-enable the wiichuck.


   Created by Sean Hickey (Wisellama), 2014
   Licensed under the GPLv3 (see LICENSE.txt)
 */

#include <Wire.h>
#include <Wiichuck.h>

// define our value ranges, these might vary between wiichucks
#define MAX_JOYSTICK 95
#define MIN_JOYSTICK -95
#define MAX_ACC 210
#define MIN_ACC -180

// define deadzones to ignore minor twitches
#define JOY_DEADZONE 5
#define ACC_DEADZONE 10

// defined time to hold buttons to enable/disable wiichuck
#define ENABLE_TIME 5

// make our wiichuck object
Wiichuck chuck = Wiichuck();

// Whether the wiichuck input is used for mouse input or not
int enabled = 1;
int enabled_counter = 0;

// initialize wiichuck
void setup() {
  Wire.flush();
  chuck.init(0,0);
  chuck.poll();
}

// get input
void loop() {
  delay(1);
  
  // update values
  chuck.poll(); 

  // check for button presses
  // (mouse buttons)
  int left = chuck.buttonZ();
  int right = chuck.buttonC();
  int middle = 0;

  // check for enable/disable signal
  if (left && right) {
    enabled_counter++;
  } else {
    enabled_counter = 0;
  }
  if (enabled_counter > ENABLE_TIME) {
    enabled = !enabled;
    enabled_counter = 0;
  }

  // don't perform mouse clicks if disabled
  if (!enabled) {
    left = 0;
    right = 0;
  }

  // note: this needed to be outside the if(enabled) section in order
  // for normal mouse clicks from other mice to still work while the
  // wiichuck is disabled.
  Mouse.set_buttons(left, middle, right);

  // Don't move the mouse if disabled
  if (enabled) {

    // check for joystick movement
    // (scrollwheel)
    int scroll = chuck.joyY();
    if (abs(scroll) - JOY_DEADZONE > 0) {
      scroll = scroll*10 / MAX_JOYSTICK;
      Mouse.scroll(scroll);
    }

    // check for accelerometer movement
    // (mouse move)
    int acc_x = chuck.accelX();
    if (abs(acc_x) - ACC_DEADZONE > 0) {
      acc_x = acc_x*100 / MAX_ACC;
    } else {
      acc_x = 0;
    }
    int acc_y = chuck.accelY();
    if (abs(acc_y) - ACC_DEADZONE > 0) {
      acc_y = acc_y*100 / MAX_ACC;
    } else {
      acc_y = 0;
    }
    Mouse.move(acc_x, acc_y);
  }
}
