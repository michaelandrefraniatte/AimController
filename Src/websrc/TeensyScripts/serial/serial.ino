// set this to the hardware serial port you wish to use
#define HWSERIAL Serial1

void setup() {
        HWSERIAL.begin(9600);
        delay(1000);
}

void loop() {        
    if (Serial.available() > 0) {    
        HWSERIAL.write(Serial.read());

    }
    if (HWSERIAL.available() > 0) {
        Serial.write(HWSERIAL.read());
    }
}
