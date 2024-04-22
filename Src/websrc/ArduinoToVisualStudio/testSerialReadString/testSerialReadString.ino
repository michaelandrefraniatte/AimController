int led = 13;
String ordre = "";
void setup() {
  // put your setup code here, to run once:
 Serial.begin(9600);
 pinMode(led,OUTPUT);
}

void loop() {
  if(Serial.available()>0)
  {
     ordre = Serial.readStringUntil('\n');
      
     if(ordre=="ON")  
     {
      digitalWrite(led,HIGH);
      Serial.println(ordre);
     }
     if(ordre=="OFF") 
     {
      digitalWrite(led,LOW);
      Serial.println(ordre);
     }
     if(ordre=="STATUS")
     {
      if(digitalRead(led)==LOW)  Serial.println("OFF");
      if(digitalRead(led)==HIGH) Serial.println("ON"); 
     }
     
  }

}
