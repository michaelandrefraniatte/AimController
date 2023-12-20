#include <XInput.h>
 
void setup() {
  XInput.begin();
}
 
void loop() {
  XInput.press(BUTTON_A);
  delay(1000);
 
  XInput.release(BUTTON_A);
  delay(1000);
}
