#include <Mouse.h>

//Message_t magic number
#define MESSAGE_MAGIC 0xBEEF
typedef unsigned short ushort;
 
//Command/Response
enum Command_t: byte {
  InvalidMessage = 0,
    InvalidRequest,
    Ping,
    Pong,
    KeyboardPress,
    KeyboardRelease,
    MouseSetScreenSize,
    MouseMove,
    MouseMoveTo,
    MouseMoveAs,
    MouseSetButtons,
    MouseScroll
};
 
struct Data_t {
  int d1;
  int d2;
  int d3;
};
 
struct Message_t {
  ushort Magic;
  Command_t Command;
  //byte Parameter;
  union { //Payload
    Data_t Data;
  };
}
msgIn, msgOut;
 
bool MessageReady() {
  //Are there enough packets available to craft a message from?
  return Serial.available() >= sizeof(Message_t);
}
 
void ReadMessage() {
  byte * pdata = (byte * ) & msgIn;
 
  //Read message from serial one byte at a time
  for (int i = 0; i < sizeof(Message_t); i++)
    pdata[i] = (byte) Serial.read();
}
 
void SendMessage() {
  byte * pdata = (byte * ) & msgOut;
 
  //Write message to serial one byte at a time
  for (int i = 0; i < sizeof(Message_t); i++)
    Serial.write(pdata[i]);
}
 
//Clear serial input in case we ran into any problems
void ClearSerial() {
  while (Serial.available()) Serial.read();
}
 
const int led = LED_BUILTIN;
void Blink(int d) {
  digitalWrite(led, HIGH);
  delay(d);
  digitalWrite(led, LOW);
}
 
void setup() {
  Mouse.begin();
  msgOut.Magic = MESSAGE_MAGIC;
  Serial.begin(9600);
  pinMode(led, OUTPUT);
  Blink(300);
}
 
void loop() {
  //Did we receive enough bytes to read a message?
  if (MessageReady()) {
    ReadMessage();
    //Is this message valid? (=> the other computer assigned the correct magic number)
    if (msgIn.Magic == MESSAGE_MAGIC) {
      if (msgIn.Command == Command_t::Ping)
        msgOut.Command = Command_t::Pong;
      if (msgIn.Command == Command_t::KeyboardPress)
        Keyboard.press(msgIn.Data.d1);
      if (msgIn.Command == Command_t::KeyboardRelease)
        Keyboard.release(msgIn.Data.d1);
      if (msgIn.Command == Command_t::MouseSetScreenSize)
        Mouse.screenSize(1366, 768);
      if (msgIn.Command == Command_t::MouseMove)
        Mouse.move(msgIn.Data.d1, msgIn.Data.d2, 0);
      if (msgIn.Command == Command_t::MouseMoveTo)
        Mouse.moveTo((int)(1366 / 2 + (float)msgIn.Data.d1 * 1366 / 2 / 1024), (int)(768 / 2 + (float)msgIn.Data.d2 * 768 / 2 / 1024));
      if (msgIn.Command == Command_t::MouseMoveAs) {
        Mouse.move((int)((float)msgIn.Data.d1 * 127 / 1023), (int)((float)msgIn.Data.d2 * 127 / 1023));
        Mouse.moveTo((int)(1366 / 2 + (float)msgIn.Data.d1 * 1366 / 2 / 1024), (int)(768 / 2 + (float)msgIn.Data.d2 * 768 / 2 / 1024));
      }
      if (msgIn.Command == Command_t::MouseSetButtons)
        Mouse.set_buttons(msgIn.Data.d1, msgIn.Data.d2, msgIn.Data.d3);
      if (msgIn.Command == Command_t::MouseScroll)
        Mouse.scroll(msgIn.Data.d1);
    } else {
      ClearSerial();
      msgOut.Command = Command_t::InvalidMessage;
    }
    SendMessage();
  }
}
