int Potenciometros[] = {0,0,0,0,0,0};

int valor = 0;
int kernelSize= 5;

void isort(int *a, int n)
{
  for (int i = 1; i < n; ++i)
  {
    int j = a[i];
    int k;
    for (k = i - 1; (k >= 0) && (j < a[k]); k--)
    {
      a[k + 1] = a[k];
    }
    a[k + 1] = j;
  }
}

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  Potenciometros[0] = 0;
  Potenciometros[1] = 0;
  Potenciometros[2] = 0;
  Potenciometros[3] = 0;
  Potenciometros[4] = 0;
  Potenciometros[5] = 0;
  for (int vent=0;vent<kernelSize;vent++){
    for (int index = 0;index<=5;index++){
      valor = analogRead(index);
      Potenciometros[index] = Potenciometros[index] + (valor/kernelSize);
    }
  }
  Serial.print(Potenciometros[0]);
  for(int i =1;i<6;i++){
    Serial.print(",");
    Serial.print(Potenciometros[i]);
  }
  Serial.println("");
}
