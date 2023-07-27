#include <Keyboard.h>
#include <Mouse.h>
#include <AbsMouse.h>

struct Data_t {
  int d1;
  int d2;
  int d3;
  int d4;
  int d5;
  int d6;
};

struct Message_t {
  union {
    Data_t Data;
  };
}
msgIn;

void ReadMessage() {
  byte * pdata = (byte * ) & msgIn;
  for (int i = 0; i < sizeof(Message_t); i++)
    pdata[i] = (byte) Serial.read();
}

bool MessageReady() {
  return Serial.available() >= sizeof(Message_t);
}

void setup() {
  Serial.begin(9600);
}

void loop() {
  if (MessageReady()) {
    ReadMessage();
    if (msgIn.Data.d1 == -1)
      Serial.print('1');
    if (msgIn.Data.d1 == 1)
      Keyboard.press(Key(msgIn.Data.d3));
    if (msgIn.Data.d1 == 2)
      Keyboard.release(Key(msgIn.Data.d3));
    if (msgIn.Data.d1 == 3)
      Mouse.move(msgIn.Data.d5, msgIn.Data.d3);
    if (msgIn.Data.d1 == 4)
      Mouse.move(0, 0, msgIn.Data.d3);
    if (msgIn.Data.d1 == 5)
      Mouse.press(Key(msgIn.Data.d3));
    if (msgIn.Data.d1 == 6)
      Mouse.release(Key(msgIn.Data.d3));
    if (msgIn.Data.d1 == 7)
      AbsMouse.init(msgIn.Data.d5, msgIn.Data.d3);
    if (msgIn.Data.d1 == 8)
      AbsMouse.move(msgIn.Data.d5, msgIn.Data.d3);
  }
}

char Key(int kc) {
  if (kc == 0)
    return MOUSE_LEFT;
  if (kc == 1)
    return MOUSE_RIGHT;
  if (kc == 2)
    return MOUSE_MIDDLE;
  if (kc == 3)
    return KEY_LEFT_CTRL;
  if (kc == 4)
    return KEY_LEFT_SHIFT;
  if (kc == 5)
    return KEY_LEFT_ALT;
  if (kc == 6)
    return KEY_RIGHT_CTRL;
  if (kc == 7)
    return KEY_RIGHT_SHIFT;
  if (kc == 8)
    return KEY_RIGHT_ALT;
  if (kc == 9)
    return KEY_UP_ARROW;
  if (kc == 10)
    return KEY_DOWN_ARROW;
  if (kc == 11)
    return KEY_LEFT_ARROW;
  if (kc == 12)
    return KEY_RIGHT_ARROW;
  if (kc == 13)
    return KEY_BACKSPACE;
  if (kc == 14)
    return ' ';
  if (kc == 15)
    return KEY_TAB;
  if (kc == 16)
    return KEY_RETURN;
  if (kc == 17)
    return KEY_ESC;
  if (kc == 18)
    return KEY_INSERT;
  if (kc == 19)
    return KEY_DELETE;
  if (kc == 20)
    return KEY_PAGE_UP;
  if (kc == 21)
    return KEY_PAGE_DOWN;
  if (kc == 22)
    return KEY_HOME;
  if (kc == 23)
    return KEY_END;
  if (kc == 24)
    return KEY_CAPS_LOCK;
  if (kc == 25)
    return KEY_F1;
  if (kc == 26)
    return KEY_F2;
  if (kc == 27)
    return KEY_F3;
  if (kc == 28)
    return KEY_F4;
  if (kc == 29)
    return KEY_F5;
  if (kc == 30)
    return KEY_F6;
  if (kc == 31)
    return KEY_F7;
  if (kc == 32)
    return KEY_F8;
  if (kc == 33)
    return KEY_F9;
  if (kc == 34)
    return KEY_F10;
  if (kc == 35)
    return KEY_F11;
  if (kc == 36)
    return KEY_F12;
  if (kc == 37)
    return KEY_F13;
  if (kc == 38)
    return KEY_F14;
  if (kc == 39)
    return KEY_F15;
  if (kc == 40)
    return KEY_F16;
  if (kc == 41)
    return KEY_F17;
  if (kc == 42)
    return KEY_F18;
  if (kc == 43)
    return KEY_F19;
  if (kc == 44)
    return KEY_F20;
  if (kc == 45)
    return KEY_F21;
  if (kc == 46)
    return KEY_F22;
  if (kc == 47)
    return KEY_F23;
  if (kc == 48)
    return KEY_F24;
  if (kc == 49)
    return 'a';
  if (kc == 50)
    return 'b';
  if (kc == 51)
    return 'c';
  if (kc == 52)
    return 'd';
  if (kc == 53)
    return 'e';
  if (kc == 54)
    return 'f';
  if (kc == 55)
    return 'g';
  if (kc == 56)
    return 'h';
  if (kc == 57)
    return 'i';
  if (kc == 58)
    return 'j';
  if (kc == 59)
    return 'k';
  if (kc == 60)
    return 'l';
  if (kc == 61)
    return 'm';
  if (kc == 62)
    return 'n';
  if (kc == 63)
    return 'o';
  if (kc == 64)
    return 'p';
  if (kc == 65)
    return 'q';
  if (kc == 66)
    return 'r';
  if (kc == 67)
    return 's';
  if (kc == 68)
    return 't';
  if (kc == 69)
    return 'u';
  if (kc == 70)
    return 'v';
  if (kc == 71)
    return 'w';
  if (kc == 72)
    return 'x';
  if (kc == 73)
    return 'y';
  if (kc == 74)
    return 'z';
  if (kc == 75)
    return '1';
  if (kc == 76)
    return '2';
  if (kc == 77)
    return  '3';
  if (kc == 78)
    return '4';
  if (kc == 79)
    return '5';
  if (kc == 80)
    return '6';
  if (kc == 81)
    return '7';
  if (kc == 82)
    return '8';
  if (kc == 83)
    return '9';
  if (kc == 84)
    return '0';
}
