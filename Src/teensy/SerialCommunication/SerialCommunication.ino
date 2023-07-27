#define MESSAGE_MAGIC 0xBEEF
typedef unsigned short ushort;
 
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
  MouseScroll,
  JoystickPress,
  JoystickRelease,
  JoystcickSetHat,
  JoystickX,
  JoystickY,
  JoystickZ,
  JoystickZRotate,
  JoystickSliderLeft,
  JoystickSliderRight
};
 
struct Data_t {
  int d1;
  int d2;
  int d3;
  int d4;
};
 
struct Message_t {
  ushort Magic;
  Command_t Command;
  union { 
    Data_t Data;
  };
}
msgIn, msgOut;
 
void ReadMessage() {
  byte * pdata = (byte * ) & msgIn;
  for (int i = 0; i < sizeof(Message_t); i++)
    pdata[i] = (byte) Serial.read();
}
 
void SendMessage() {
  byte * pdata = (byte * ) & msgOut;
  for (int i = 0; i < sizeof(Message_t); i++)
    Serial.write(pdata[i]);
}

bool MessageReady() {
  return Serial.available() >= sizeof(Message_t);
}

void setup() {
  msgOut.Magic = MESSAGE_MAGIC;
  Serial.begin(9600);
}
 
void loop() { 
  if (MessageReady()) {
    ReadMessage();  
    if (msgIn.Magic == MESSAGE_MAGIC) {
      if (msgIn.Command == Command_t::Ping) {
          msgOut.Command = Command_t::Pong;
          msgOut.Data.d1 = 1;
          msgOut.Data.d2 = 2;
          msgOut.Data.d3 = 3;
          msgOut.Data.d4 = 4;
          SendMessage();
      }
      if (msgIn.Command == Command_t::KeyboardPress)
          Keyboard.press(msgIn.Data.d1);
      if (msgIn.Command == Command_t::KeyboardRelease)
          Keyboard.release(msgIn.Data.d1);
      if (msgIn.Command == Command_t::MouseSetScreenSize)
          Mouse.screenSize(msgIn.Data.d1, msgIn.Data.d2);
      if (msgIn.Command == Command_t::MouseMove) {
          Mouse.move(msgIn.Data.d1, msgIn.Data.d2);
      }
      if (msgIn.Command == Command_t::MouseMoveTo)
          Mouse.moveTo(msgIn.Data.d1, msgIn.Data.d2);
      if (msgIn.Command == Command_t::MouseMoveAs) {
          Mouse.move(msgIn.Data.d1, msgIn.Data.d2);
          Mouse.moveTo(msgIn.Data.d3, msgIn.Data.d4);
      }
      if (msgIn.Command == Command_t::MouseSetButtons)
          Mouse.set_buttons(msgIn.Data.d1, msgIn.Data.d2, msgIn.Data.d3);
      if (msgIn.Command == Command_t::MouseScroll)
          Mouse.scroll(msgIn.Data.d1);
      if (msgIn.Command == Command_t::JoystickPress)
          Joystick.button(msgIn.Data.d1, msgIn.Data.d2);
      if (msgIn.Command == Command_t::JoystickRelease)
          Joystick.button(msgIn.Data.d1, msgIn.Data.d2);
      if (msgIn.Command == Command_t::JoystcickSetHat)
          Joystick.hat(msgIn.Data.d1);
      if (msgIn.Command == Command_t::JoystickX)
          Joystick.X(msgIn.Data.d1 + 512);
      if (msgIn.Command == Command_t::JoystickY)
          Joystick.Y(msgIn.Data.d1 + 512);
      if (msgIn.Command == Command_t::JoystickZ)
          Joystick.Z(msgIn.Data.d1 + 512);
      if (msgIn.Command == Command_t::JoystickZRotate)
          Joystick.Zrotate(msgIn.Data.d1 + 512);
      if (msgIn.Command == Command_t::JoystickSliderLeft)
          Joystick.sliderLeft(msgIn.Data.d1 + 512);
      if (msgIn.Command == Command_t::JoystickSliderRight)
          Joystick.sliderRight(msgIn.Data.d1 + 512);
    }
  }
}
