// 초음파 센서 핀 설정
const int TRIG_PIN = 10;  // TRIG 핀 번호
const int ECHO_PIN = 9;   // ECHO 핀 번호

bool isInside = false;      // 거리 안에 있는지 여부
long previousDistance = 0;  // 이전 거리 값
bool readyToOut = false;    // 모터를 내릴 준비가 되었는지 확인

int distanceCounter = 0;    // 모터값이 튀는 경우가 있어 일정이하의 값이 일정 횟수 이상 나올때까지 대기

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

  //시리얼통신을 통해 문자열 수신 대기
  if (Serial.available()) {
    readString = Serial.readStringUntil('\n');
  }

  // 수신된 신호를 띄워쓰기 기준으로 분할
  int firstComma = readString.indexOf(' ');
  motorArrow = readString.substring(0, firstComma).toInt();
  motorMs = readString.substring(firstComma + 1, readString.length()).toInt();

  // 지정된 제어신호에 따라 동작
  switch (motorArrow) {
    case (1)://지정된 시간동안 모터를 내림
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
    case (2)://지정된 시간동안 모터를 올림
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
    case (3)://사용자가 키오스크를 사용 종료함
      {
        readyToOut = true;
        break;
      }
    case (4)://키오스크 소프트웨어가 종료됨
      {
        isInside = false;      // 거리 안에 있는지 여부
        previousDistance = 0;  // 이전 거리 값
        readyToOut = false;
        distanceCounter=0;
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


  //Serial.println(distance); //초음파센서 디버깅용

  if (distance != 0) { // 초음파 센서 불량으로 거리가 0으로 측정되는 경우가 간혹 있음
    if (distance < 30) { //사용자가 30cm안쪽에 있을시
      distanceCounter++;  //카운터 증가
    } else
      distanceCounter = 0; //밖이라면 카운터 초기화
  }

  // 거리가 50cm 미만이고 이전에 거리가 안에 없었을 때 그리고 가까이 있는것이 5회이상 측정될때
  if (distance <= 40 && !isInside && distanceCounter > 5) {
    //if (distance <=40  && !isInside) {0
    isInside = true;
    Serial.println("in");
    distanceCounter = 0;
  }
  // 거리가 60cm 이상이고 이전에 거리가 밖에 있었을 때, 사용자의 키오스크 사용이 종료되었을때
  else if (distance >= 80 && isInside && readyToOut) {
    isInside = false;
    readyToOut = false;
    Serial.println("out");
    distanceCounter = 0;
  }
  previousDistance = distance;
}
