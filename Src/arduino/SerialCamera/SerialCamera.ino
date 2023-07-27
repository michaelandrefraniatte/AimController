#include <Wire.h>

unsigned long data = 1024 * 1000000 + 768;

int IRsensorAddress = 0xB0;
//int IRsensorAddress = 0x58;
int slaveAddress;
int ledPin = 13;
boolean ledState = false;
byte data_buf[16];
int i;

int Ix[4];
int Iy[4];
int s;

int irx0, iry0, irx1, iry1, irxc, iryc, mWSIRSensors0X, mWSIRSensors0Y, mWSIRSensors1X, mWSIRSensors1Y, mWSIRSensors0Xcam, mWSIRSensors0Ycam, mWSIRSensors1Xcam, mWSIRSensors1Ycam, mWSIRSensorsXcam, mWSIRSensorsYcam;
bool mWSIR1found, mWSIR0found;

void Write_2bytes(byte d1, byte d2)
{
  Wire.beginTransmission(slaveAddress);
  Wire.write(d1); Wire.write(d2);
  Wire.endTransmission();
}

void setup()
{
  slaveAddress = IRsensorAddress >> 1;   // This results in 0x21 as the address to pass to TWI
  Serial.begin(9600);
  pinMode(ledPin, OUTPUT);      // Set the LED pin as output
  Wire.begin();
  // IR sensor initialize
  Write_2bytes(0x30, 0x01); delay(10);
  Write_2bytes(0x30, 0x08); delay(10);
  Write_2bytes(0x06, 0x90); delay(10);
  Write_2bytes(0x08, 0xC0); delay(10);
  Write_2bytes(0x1A, 0x40); delay(10);
  Write_2bytes(0x33, 0x33); delay(10);
  delay(100);
}

void loop()
{
  ledState = !ledState;
  if (ledState) {
    digitalWrite(ledPin, HIGH);
  } else {
    digitalWrite(ledPin, LOW);
  }

  //IR sensor read
  Wire.beginTransmission(slaveAddress);
  Wire.write(0x36);
  Wire.endTransmission();

  Wire.requestFrom(slaveAddress, 16);        // Request the 2 byte heading (MSB comes first)
  for (i = 0; i < 16; i++) {
    data_buf[i] = 0;
  }
  i = 0;
  while (Wire.available() && i < 16) {
    data_buf[i] = Wire.read();
    i++;
  }

  Ix[0] = data_buf[1];
  Iy[0] = data_buf[2];
  s   = data_buf[3];
  Ix[0] += (s & 0x30) << 4;
  Iy[0] += (s & 0xC0) << 2;

  Ix[1] = data_buf[4];
  Iy[1] = data_buf[5];
  s   = data_buf[6];
  Ix[1] += (s & 0x30) << 4;
  Iy[1] += (s & 0xC0) << 2;

  Ix[2] = data_buf[7];
  Iy[2] = data_buf[8];
  s   = data_buf[9];
  Ix[2] += (s & 0x30) << 4;
  Iy[2] += (s & 0xC0) << 2;

  Ix[3] = data_buf[10];
  Iy[3] = data_buf[11];
  s   = data_buf[12];
  Ix[3] += (s & 0x30) << 4;
  Iy[3] += (s & 0xC0) << 2;

  mWSIRSensors0X = int(Ix[0]);
  mWSIRSensors0Y = int(Iy[0]);
  mWSIRSensors1X = int(Ix[1]);
  mWSIRSensors1Y = int(Iy[1]);
  mWSIR0found = mWSIRSensors0X > 1 & mWSIRSensors0X < 1023;
  mWSIR1found = mWSIRSensors1X > 1 & mWSIRSensors1X < 1023;
  if (mWSIR0found)
  {
    mWSIRSensors0Xcam = mWSIRSensors0X - 512;
    mWSIRSensors0Ycam = mWSIRSensors0Y - 384;
  }
  if (mWSIR1found)
  {
    mWSIRSensors1Xcam = mWSIRSensors1X - 512;
    mWSIRSensors1Ycam = mWSIRSensors1Y - 384;
  }
  if (mWSIR0found & mWSIR1found)
  {
    mWSIRSensorsXcam = int((mWSIRSensors0Xcam + mWSIRSensors1Xcam) / 2);
    mWSIRSensorsYcam = int((mWSIRSensors0Ycam + mWSIRSensors1Ycam) / 2);
  }
  irx0 = 2 * mWSIRSensors0Xcam - mWSIRSensorsXcam;
  iry0 = 2 * mWSIRSensors0Ycam - mWSIRSensorsYcam;
  irx1 = 2 * mWSIRSensors1Xcam - mWSIRSensorsXcam;
  iry1 = 2 * mWSIRSensors1Ycam - mWSIRSensorsYcam;
  irxc = irx0 + irx1;
  iryc = iry0 + iry1;

  data = (irxc + 1360 + 1000) * 1000000 + (iryc + 1360);
  byte buf[4];
  buf[0] = data & 255;
  buf[1] = (data >> 8)  & 255;
  buf[2] = (data >> 16) & 255;
  buf[3] = (data >> 24) & 255;
  Serial.write(buf, sizeof(buf));
  delay(15);
}
