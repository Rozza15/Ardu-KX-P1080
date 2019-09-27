int latchPin = 10;
int clockPin = 16;
int dataPin = 14;
int clearPin = 15;

const byte payloadArray[13] = {0x48,0x65,0x6C,0x6C,0x6F,0x2C,0x20,0x77,0x6F,0x72,0X6C,0x64,0x21};





const byte RESET[2] = {0x1B,0x40};
const byte MSB_R[2] = {0x1B,0x23};
const byte HOME[2] = {0x1B,0x3C};


void setup() {
  Serial.begin(9600);
}

void loop() {
  testPayload(payloadArray);
  while(true) {}
}

void testPayload(byte payload) {
  for (int i = 0; i < sizeof(MSB_R); i++) {
    Serial.print(MSB_R[i], HEX);
  }
  Serial.print(' ');
  for (int i = 0; i < sizeof(RESET); i++) {
    Serial.print(RESET[i], HEX);
  }
  Serial.print(' ');
  for (int i = 0; i < sizeof(payloadArray); i++) {
    Serial.print(payloadArray[i], HEX);
    Serial.print(' ');
  }
  Serial.print(CR, HEX);
  Serial.print(' ');
  Serial.print(LF, HEX);
  Serial.print(' ');
  for (int i = 0; i < sizeof(HOME); i++) {
    Serial.print(HOME[i], HEX);
  }
  Serial.println();
}

void shiftOut(int myDataPin, int myClockPin, byte myDataOut) {
  int i=0;
  int pinState;
  pinMode(myClockPin, OUTPUT);
  pinMode(myDataPin, OUTPUT);

  digitalWrite(myDataPin, 0);
  digitalWrite(myClockPin, 0);

  for (int i = 0; i <= 7; i++) {  // MSB first
    digitalWrite(myClockPin, 0);

    if (myDataOut & (1<<i)) {
      pinState = 1;
    }
    else {
      pinState = 0;
    }
    
    digitalWrite(myDataPin, pinState);
    digitalWrite(myClockPin, 1);
    digitalWrite(myDataPin, 0);
  }

  digitalWrite(myClockPin, 0);
}
