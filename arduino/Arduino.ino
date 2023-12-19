// 초음파 센서 핀 설정
const int TRIG_PIN = 10;  // TRIG 핀 번호
const int ECHO_PIN = 9;   // ECHO 핀 번호

bool isInside = false;      // 거리 안에 있는지 여부
long previousDistance = 0;  // 이전 거리 값
bool readyToOut = false;

int distanceCounter = 0;
void setup() {
  Serial.begin(9600);
  pinMode(TRIG_PIN, OUTPUT);
  pinMode(ECHO_PIN, INPUT);

  pinMode(5, OUTPUT);
  pinMode(6, OUTPUT);
  pinMode(7, OUTPUT);
  pinMode(8, OUTPUT);

  digitalWrite(8, HIGH);
  digitalWrite(7, HIGH);
  digitalWrite(6, HIGH);
  digitalWrite(5, HIGH);
}

void loop() {
  long duration, distance;

  String readString;
  int motorMs = 0;
  int motorArrow = 0;
  if (Serial.available()) {
    readString = Serial.readStringUntil('\n');
  }

  int firstComma = readString.indexOf(' ');
  motorArrow = readString.substring(0, firstComma).toInt();
  motorMs = readString.substring(firstComma + 1, readString.length()).toInt();


  switch (motorArrow) {
    case (1):
      {

        digitalWrite(7, HIGH);
        digitalWrite(8, HIGH);
        delay(100);
        digitalWrite(5, LOW);
        digitalWrite(6, LOW);
        delay(motorMs);
        digitalWrite(5, HIGH);
        digitalWrite(6, HIGH);

        break;
      }
    case (2):
      {

        digitalWrite(5, HIGH);
        digitalWrite(6, HIGH);
        delay(100);
        digitalWrite(7, LOW);
        digitalWrite(8, LOW);
        delay(motorMs);
        digitalWrite(7, HIGH);
        digitalWrite(8, HIGH);
        break;
      }
    case (3):
      {
        readyToOut = true;
        break;
      }
    case (4):
      {
        isInside = false;      // 거리 안에 있는지 여부
        previousDistance = 0;  // 이전 거리 값
        readyToOut = false;

         digitalWrite(5, HIGH);
        digitalWrite(6, HIGH);
        delay(100);
        digitalWrite(7, LOW);
        digitalWrite(8, LOW);
        delay(4000);
        digitalWrite(7, HIGH);
        digitalWrite(8, HIGH);
      }
    default:
      {
        break;
      }
  }

  // 초음파 발신기 작동
  digitalWrite(TRIG_PIN, LOW);
  delayMicroseconds(10);
  digitalWrite(TRIG_PIN, HIGH);
  delayMicroseconds(10);
  digitalWrite(TRIG_PIN, LOW);

  // 초음파 수신 시간 측정
  duration = pulseIn(ECHO_PIN, HIGH);
  distance = duration * 17 / 1000;  // 시간을 거리로 변환 (단위: 센티미터)

  //Serial.println(distance);

  if (distance < 40) {
    distanceCounter++;
  }
  // 거리가 50cm 미만이고 이전에 거리가 안에 없었을 때
  if (distance <= 40 && (!isInside)) {
    if (distanceCounter > 5) {
      isInside = true;
      Serial.println("in");
      distanceCounter = 0;
    }
  } else if (distance > 1000) {
  }
  // 거리가 60cm 이상이고 이전에 거리가 밖에 있었을 때
  else if (distance >= 80 && isInside && readyToOut) {
    isInside = false;
    readyToOut = false;
    Serial.println("out");
    distanceCounter = 0;
  } else {
    distanceCounter = 0;
  }

  previousDistance = distance;
}
