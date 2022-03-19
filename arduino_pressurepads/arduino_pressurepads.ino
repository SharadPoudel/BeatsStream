#define FORCE_SENSOR_PIN1 A0 
#define FORCE_SENSOR_PIN2 A1 
#define FORCE_SENSOR_PIN3 A2 
#define FORCE_SENSOR_PIN4 A3

int analogReading1, analogReading2, analogReading3, analogReading4;

void setup()
{
    Serial.begin(9600);
}

void loop()
{
    
   analogReading1 = analogRead(FORCE_SENSOR_PIN1);
   analogReading2 = analogRead(FORCE_SENSOR_PIN2);
   analogReading3 = analogRead(FORCE_SENSOR_PIN3);
   analogReading4 = analogRead(FORCE_SENSOR_PIN4);

   //if (analogReading1 > 50)
     Serial.println("Sensor1_" + String(analogReading1));
   //if (analogReading2 > 50)     
     Serial.println("Sensor2_" + String(analogReading2));
   //if (analogReading3 > 50)     
     Serial.println("Sensor3_" + String(analogReading3));
   //if (analogReading4 > 50)     
     Serial.println("Sensor4_" + String(analogReading4));

   
   delay(16);
}
