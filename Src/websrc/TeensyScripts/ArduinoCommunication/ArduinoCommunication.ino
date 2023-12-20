//Message_t magic number
#define MESSAGE_MAGIC 0xBEEF
typedef unsigned short ushort;
 
//Command/Response
enum Command_t : byte {
  InvalidMessage = 0,
  InvalidRequest,
  Ping,
  Pong,
  CalcResult,
  CalcPlusF
};
 
struct Vec3f_t {
  float X;
  float Y;
  float Z;
};
 
struct Vec3i_t {
  int X;
  int Y;
  int Z;
};
 
struct Message_t {
  ushort Magic;
  Command_t Command;
  byte Parameter;
  union { //Payload
    byte Data[12];
    Vec3f_t Vec3f;
    Vec3i_t Vec3i;
  };
} msgIn, msgOut;
 
bool MessageReady() {
  //Are there enough packets available to craft a message from?
  return Serial.available() >= sizeof(Message_t);
}
 
void ReadMessage() {
  byte *pdata = (byte*)&msgIn;
 
  //Read message from serial one byte at a time
  for (int i = 0; i < sizeof(Message_t); i++)
    pdata[i] = (byte)Serial.read();
}
 
void SendMessage() {
  byte *pdata = (byte*)&msgOut;
 
  //Write message to serial one byte at a time
  for (int i = 0; i < sizeof(Message_t); i++)
    Serial.write(pdata[i]);
}
 
//Clear serial input in case we ran into any problems
void ClearSerial() {
  while (Serial.available()) Serial.read();
}
 
void setup() {
  msgOut.Magic = MESSAGE_MAGIC;
  Serial.begin(9600);
}
 
void loop() {
  //Did we receive enough bytes to read a message?
  if (MessageReady()) {
    ReadMessage();
    //Is this message valid? (=> the other computer assigned the correct magic number)
    if (msgIn.Magic == MESSAGE_MAGIC) {
      switch (msgIn.Command) {
        case Command_t::Ping:
          //Send a pong in case we received a ping
          msgOut.Command = Command_t::Pong;
          break;
        case Command_t::CalcPlusF:
          //Perform a simple calvulation
          msgOut.Command = Command_t::CalcResult;
          msgOut.Vec3f.X = msgIn.Vec3f.X;
          msgOut.Vec3f.Y = msgIn.Vec3f.Y;
          msgOut.Vec3f.Z = msgIn.Vec3f.X + msgIn.Vec3f.Y;
          break;
        default:
          //Other commands were not implemented yet => this request is invalid
          msgOut.Command = Command_t::InvalidRequest;
          break;
      }
    } else {
      ClearSerial();
      //Magic number didn't match => this message is invalid
      msgOut.Command = Command_t::InvalidMessage;
    }
    SendMessage();
  }
}
