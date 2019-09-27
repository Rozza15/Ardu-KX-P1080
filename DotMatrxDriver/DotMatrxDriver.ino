/*  KX-P1081 Control  */
//  Ard->Prn
int STROBE = 9;
int AFXT = 4;
int PRIME = 3;
//  Ard<-Prn
int ACK = 8;
int BUSY = 7;
int PE = 6;
int SLCT = 5;
int ERR = 2;


/*  595 Register Control  */
int dataPin = 10;	//	595_DS
int outPin = 16;	//	595_OE
int latchPin = 14;	//	595_ST_CP
int clockPin = 15;	//	595_SH_CP
int clearPin = 18;	//	595_MR

const byte payloadArray[13] = {0x48,0x65,0x6C,0x6C,0x6F,0x2C,0x20,0x77,0x6F,0x72,0X6C,0x64,0x21};



byte data;
byte dataArray[10];

void setup() {
  Serial.begin(9600);
  pinMode(dataPin, OUTPUT);
  pinMode(outPin, OUTPUT);
  pinMode(latchPin, OUTPUT);
  pinMode(clockPin, OUTPUT);
  pinMode(clearPin, OUTPUT);

  digitalWrite(outPin, 0);
  digitalWrite(clearPin, 1);

  dataArray[0] = 0xFF; //0b11111111
  dataArray[1] = 0xFE; //0b11111110
  dataArray[2] = 0xFC; //0b11111100
  dataArray[3] = 0xF8; //0b11111000
  dataArray[4] = 0xF0; //0b11110000
  dataArray[5] = 0xE0; //0b11100000
  dataArray[6] = 0xC0; //0b11000000
  dataArray[7] = 0x80; //0b10000000
  dataArray[8] = 0x00; //0b00000000
  dataArray[9] = 0xE0; //0b11100000
}

void loop() {
  byte j = 0x00;
  for(int i=0;i<256;i++) {
    data = j+i;
    digitalWrite(latchPin, 0);
    shiftOut(dataPin, clockPin, data);
    digitalWrite(latchPin, 1);
    delay(300);
  }
  
//  testPayload(payloadArray);
//  while(true) {}
}

//void testPayload(byte payload) {
//  for (int i = 0; i < sizeof(MSB_R); i++) {
//    Serial.print(MSB_R[i], HEX);
//  }
//  Serial.print(' ');
//  for (int i = 0; i < sizeof(RESET); i++) {
//    Serial.print(RESET[i], HEX);
//  }
//  Serial.print(' ');
//  for (int i = 0; i < sizeof(payloadArray); i++) {
//    Serial.print(payloadArray[i], HEX);
//    Serial.print(' ');
//  }
//  Serial.print(CR, HEX);
//  Serial.print(' ');
//  Serial.print(LF, HEX);
//  Serial.print(' ');
//  for (int i = 0; i < sizeof(HOME); i++) {
//    Serial.print(HOME[i], HEX);
//  }
//  Serial.println();
//}

void shiftOut(int myDataPin, int myClockPin, byte myDataOut) {
  int i=0;
  int pinState;
  pinMode(myClockPin, OUTPUT);
  pinMode(myDataPin, OUTPUT);

  digitalWrite(myDataPin, 0);
  digitalWrite(myClockPin, 0);

  for (int i = 7; i >= 0; i--) {  // LSB first
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
