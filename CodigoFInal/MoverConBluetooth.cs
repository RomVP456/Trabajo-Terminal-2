using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoverConBluetooth : MonoBehaviour
{
    public GameObject valoresPotenciometros;
    public BluetoothUIManager valores;
    public int[] intValores;
    public GameObject[] ejes;
    float dato;
    private Vector3 rotacion = Vector3.zero;
    private int[] cualEje = {1,1,2,2,1,0};
    [SerializeField] int[] offset = {46,0,0,0,0,0};
    private float[] buffer;
    [SerializeField] int windowSize = 7;
    void Start()
    {
        valores = valoresPotenciometros.GetComponent<BluetoothUIManager>();
        buffer = new float[windowSize];
        print("Si se inicio");
    }

    // Update is called once per frame
    void Update()
    {
        intValores = Array.ConvertAll(valores.SeisValores,int.Parse);
        
        for (int axis = 0;axis<6;axis++){
            dato = map(0,1023,-135,135,intValores[axis]+offset[axis]);
            // dato = ApplyMedianFilter(dato);
            rotacion[cualEje[axis]] = dato;
            ejes[axis].transform.localRotation = Quaternion.Euler(rotacion);
            rotacion = Vector3.zero;
        }
    }
    public float map(float OldMin, float OldMax, float NewMin, float NewMax, int OldValue){ 
        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin; 
        return(NewValue);
    }
    private float ApplyMedianFilter(float newValue)
    {
        // Mover los valores en el buffer hacia la izquierda
        for (int i = 0; i < buffer.Length - 1; i++)
        {
            buffer[i] = buffer[i + 1];
        }

        // Agregar el nuevo valor al buffer
        buffer[buffer.Length - 1] = newValue;

        // Calcular el valor medio en el buffer
        float sum = 0f;
        for (int i = 0; i < buffer.Length; i++)
        {
            sum += buffer[i];
        }
        float average = sum / buffer.Length;

        return average;
    }
}
