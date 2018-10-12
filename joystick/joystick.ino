
// Pin Definitions
const int JOYSTICK_PIN_VRX = 32;
const int JOYSTICK_PIN_VRY = 33;
const int JOYSTICK_PIN_SW =	0;



// Setup the essentials for your circuit to work. It runs first every time your circuit is powered with electricity.
void setup() 
{
    //pinMode(JOYSTICK_PIN_SW, INPUT);
    //digitalWrite(JOYSTICK_PIN_SW, HIGH);
    Serial.begin(115200);
    
}

// Main logic of your circuit. It defines the interaction between the components you selected. After setup, it runs over and over again, in an eternal loop.
void loop() 
{
  Serial.print("x:");
  Serial.print(analogRead(JOYSTICK_PIN_VRX));
  Serial.print("|");
  Serial.print("y:");
  Serial.print(analogRead(JOYSTICK_PIN_VRY));
  Serial.print("|");
  delay(100);
}
