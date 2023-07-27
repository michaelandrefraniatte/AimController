unsigned long data1 = 1024 * 1000000 + 1768;
unsigned long data2 = 1001 * 1000000 + 1252;

void setup() {
  Serial.begin(9600);
}

void loop() {
  byte buf[4];
  buf[0] = data1 & 255;
  buf[1] = (data1 >> 8)  & 255;
  buf[2] = (data1 >> 16) & 255;
  buf[3] = (data1 >> 24) & 255;
  Serial.write(buf, sizeof(buf));
  data1 -= 1;
  delay(400);
  buf[0] = data2 & 255;
  buf[1] = (data2 >> 8)  & 255;
  buf[2] = (data2 >> 16) & 255;
  buf[3] = (data2 >> 24) & 255;
  Serial.write(buf, sizeof(buf));
  data2 -= 2;
  delay(400);
}
