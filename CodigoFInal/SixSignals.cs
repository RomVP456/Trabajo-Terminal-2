using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
public class SixSignals : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM3", 9600);
    public string[] SeisValores;
    [SerializeField] List<int> bufferDatos = new List<int>(3);
    
    void Start()
    {
        try{
            serialPort.Open();
            serialPort.ReadTimeout = 10;
            // print(bufferDatos[0]);
        }
        catch{
            print("Falla o conexion ya realizada");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (serialPort.IsOpen) //comprobamos que el puerto esta abierto
		{
			try //utilizamos el bloque try/catch para detectar una posible excepción.
			{
				string value = serialPort.ReadLine(); //leemos una linea del puerto serie y la almacenamos en un string
				// print(value); //printeamos la linea leida para verificar que leemos el dato que manda nuestro Arduino
				string[] vec6 = value.Split(','); //Separamos el String leido valiendonos
                SeisValores = value.Split(',');
                // print(vec6);
			}
			catch
			{		
			}
		}
    }
    
}
