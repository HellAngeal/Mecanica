using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Examen : MonoBehaviour
{
    public InputField Sonic;
    public InputField Knuckles;

    float VSonic;
    float VKnuckles;
    float VFinal;
    float Tiempo;
    float DSonic;
    float DKnuckles;

    public void Calcular()
    {
        VSonic = float.Parse(Sonic.text);
        VKnuckles = float.Parse(Knuckles.text);
        VFinal = VSonic + VKnuckles;
        Tiempo = 500 / VFinal;
        DSonic = Tiempo * VSonic;
        DKnuckles = Tiempo * VKnuckles;
        Debug.Log("Chocan en la distancia: "+DSonic+"de Sonic y la distancia: "+DKnuckles+"de Knuckles, teniendo en cuenta que ambos avanzan al centro.");
    }
}
