#define FORCE_SENSOR_PIN1 A0 
#define FORCE_SENSOR_PIN2 A1 
#define FORCE_SENSOR_PIN3 A2 

void setup() {
  Serial.begin(9600);
}

void loop() {
  int analogReading1 = analogRead(FORCE_SENSOR_PIN1);
  int analogReading2 = analogRead(FORCE_SENSOR_PIN2);
  int analogReading3 = analogRead(FORCE_SENSOR_PIN3);

  if (analogReading1 > 5)     
    Serial.println("Sign1");
  if (analogReading2 > 5)     
    Serial.println("Sign2");
  if (analogReading3 > 5)     
    Serial.println("Sign3");
 

  delay(200);
}
