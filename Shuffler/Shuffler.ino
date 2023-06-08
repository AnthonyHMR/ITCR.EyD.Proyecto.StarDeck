#include <Servo.h>

Servo servo;
long randNumber;
int resolution = 100; // Resolucion en ms

// Baja la ventosa para coger la carga
void pen_down(){
  servo.write(0);
  delay(1000);
  Serial.print("bajo");
}

// Sube la ventosa para soltar la carta
void pen_up(){
  servo.write(180);
  delay(1000);
  Serial.print("suelta");
}

// Pone la ventosa en posicion inicial
void pen_stop(){
  servo.write(100);
  delay(1000);
  Serial.print("normal");
}

// Para todos lo motores
void stop_motors(){
  digitalWrite(2,LOW);
  digitalWrite(3,HIGH);
  digitalWrite(4,LOW);
  digitalWrite(5,HIGH);
}

// Funcion encargada de ir a la posicion para soltar la carta
void move_up(int ms){
  digitalWrite(3,LOW);
  delay(ms);
  stop_motors();
}

// Funcion encargada de regresar a la posicion inicial
void move_down(int ms){
  digitalWrite(2,HIGH);
  delay(ms);
  stop_motors();
}

void setup() {
  pinMode(2,OUTPUT);
  pinMode(3,OUTPUT);
  pinMode(4,OUTPUT);
  pinMode(5,OUTPUT);
  servo.attach(6);
  Serial.begin(9600);
  stop_motors();// Apaga los motores
  pen_stop();// Pone la ventosa en posicion inicial
}

void loop() {
  if (Serial.available() > 0) {
    int incomingByte = Serial.read();
    switch (incomingByte) {
      case 119: // w
        randNumber=random(2); // Elige un numero random, 1 o 0
        if(randNumber == 1){// se mueve a la primera posicion
          pen_down();// Coge la carta
          pen_stop();
          move_up(100*resolution);// Se mueve a la posicion
          pen_up();// Suelta la carta
          pen_stop();
          move_down(100*resolution);// Regresa a la posicion inicial
        }else{// se mueve a la segunda posicion
          pen_down();// Coge la carta
          pen_stop();
          move_up(200*resolution);// Se mueve a la posicion
          pen_up();// Suelta la carta
          pen_stop();
          move_down(200*resolution);// Regresa a la posicion inicial
        }
        break;
      case 97:
          pen_up();// a
          Serial.print("up");// Suelta la carta
        break;
      case 115:// s
          pen_stop();
          Serial.print("stop");
        break;
      case 100:
          pen_down();// d
          Serial.print("down");// Coge la carta
        break;
      default:
        // No hace nada
        break;
    }
  }
}
