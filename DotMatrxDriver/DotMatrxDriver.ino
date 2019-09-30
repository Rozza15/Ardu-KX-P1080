/*  KX-P1081 Control  */
//  Ard->Prn
int STROBE = 9; //  Active Low
int AFXT = 4; //  Active Low
int PRIME = 3;  //  Active Low
//  Ard<-Prn
int ACK = 8;  //  Active Low
int BUSY = 7; //  Active High
int PE = 6; //  Active High
int SLCT = 5; //  Active High
int ERR = 2;  //  Active Low


/*  595 Register Control  */
int dataPin = 10;	//	595_DS
int outPin = 16;	//	595_OE - active low. Write high to blank, write low to show
int latchPin = 14;	//	595_ST_CP
int clockPin = 15;	//	595_SH_CP
int clearPin = 18;	//	595_MR

const byte payloadArray[18] = {0x48,0x65,0x6C,0x6C,0x6F,0x2C,0x20,0x77,0x6F,0x72,0X6C,0x64,0x21,0x1B,0x3C,0x0A,0x0D,0x00}; //H,e,l,l,o,,, ,w,o,r,l,d,!,CR,LF



byte data;
byte dataArray[10];
int attempt = 0;
int i = 0;

int valACK;
int valBUSY;
int valPE;
int valSLCT;
int valERR;

int discon = 0;

void setup() {
  Serial.begin(9600);

/*  Initialise control ouputs */
//  595 Shift Lines
  pinMode(dataPin, OUTPUT);
  pinMode(outPin, OUTPUT);
  pinMode(latchPin, OUTPUT);
  pinMode(clockPin, OUTPUT);
  pinMode(clearPin, OUTPUT);

//  Printer input controls
  pinMode(STROBE, OUTPUT);
  pinMode(AFXT, OUTPUT);
  pinMode(PRIME, OUTPUT);

/*  Initialise control inputs */
//  Printer output controls
  pinMode(ACK, INPUT);
  pinMode(BUSY, INPUT);
  pinMode(PE, INPUT);
  pinMode(SLCT, INPUT);
  pinMode(ERR, INPUT);


  digitalWrite(outPin, 1);
  digitalWrite(clearPin, 1);

  
  digitalWrite(STROBE, 1);
  digitalWrite(AFXT, 1);
  digitalWrite(PRIME, 1);

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
  while(!Serial){}
  if(isOnline(SLCT)){
    discon = 0;
    valACK = digitalRead(ACK);
    valBUSY = digitalRead(BUSY);
    valPE = digitalRead(PE);
    valSLCT = digitalRead(SLCT);
    valERR = digitalRead(ERR);
    Serial.print(data);
    Serial.print("\t");
    Serial.println(i);
    Serial.print("ACK:\t");
    Serial.println(valACK);
    Serial.print("BUSY:\t");
    Serial.println(valBUSY);
    Serial.print("PE:\t");
    Serial.println(valPE);
    Serial.print("SLCT:\t");
    Serial.println(valSLCT);
    Serial.print("ERR:\t");
    Serial.println(valERR);
    Serial.println();
    attempt = 0;
    while(!(valBUSY == 0 && valACK == 1)){
      Serial.println("Waiting for Printer");
      break;  
    }
    if(i<sizeof(payloadArray)){
      if(valBUSY == 0 && valACK == 1) {
        data = payloadArray[i];
        digitalWrite(outPin, 0);
        digitalWrite(latchPin, 0);
        shiftOut(dataPin, clockPin, data);
        digitalWrite(latchPin, 1);
        delayMicroseconds(50);
        delayMicroseconds(50);
        digitalWrite(STROBE, 0);
        delayMicroseconds(50);
        digitalWrite(STROBE, 1);
        delayMicroseconds(50);
        digitalWrite(latchPin, 0);
        valBUSY = digitalRead(BUSY);
        Serial.println("Printing");
        i++;
      }
    } else {
      Serial.println("Printing Complete");
      i = 0; 
    }
  } else {
    Serial.println("Printer Offline");
    Serial.print("Attempt:\t");
    Serial.println(attempt);
    attempt++;
    delay(500);
  }
  while(digitalRead(PE) == 1){
    discon = 0;
    Serial.println();
    Serial.println("Paper Out, printing complete");
    delay(500);
    break;
  }
  while((digitalRead(ACK) + digitalRead(BUSY) + digitalRead(PE) + digitalRead(SLCT) + digitalRead(ERR) + discon) == 0) {
    Serial.println("Printer Not Connected");
    delay(1000);
    discon++;
    while((digitalRead(ACK) + digitalRead(BUSY) + digitalRead(PE) + digitalRead(SLCT) + digitalRead(ERR)) == 0) {}
    break;
  }
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

void sendData(byte myData) {
  digitalWrite(latchPin, 0);
  shiftOut(dataPin, clockPin, myData);
  digitalWrite(latchPin, 1);
  delayMicroseconds(50);
  digitalWrite(outPin, 0);
  delayMicroseconds(50);
  digitalWrite(STROBE, 0);
  delayMicroseconds(50);
  digitalWrite(STROBE, 1);
  delayMicroseconds(50);
  digitalWrite(outPin, 1);
}

bool isOnline(int selectPin) {
  if(digitalRead(selectPin) == 1) {
    return true;
  } else {
    return false;
  }
}

bool paperOut(int paperPin) {
  if(digitalRead(paperPin == 1)) {
    return true;
  } else {
    return false;
  }
}

void getConts() {
  valACK = digitalRead(ACK);
  valBUSY = digitalRead(BUSY);
  valPE = digitalRead(PE);
  valSLCT = digitalRead(SLCT);
  valERR = digitalRead(ERR);
}
