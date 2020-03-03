using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    public Rigidbody Objetin;
    public float Fuerza;
    public Vector3 direccion;
    void Start()
    {
        Objetin = gameObject.GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
        {
            AplicarFuerza(Fuerza);
        }
        
    }

    public void AplicarFuerza(float fuerza)
    {
        fuerza = Fuerza;
        Objetin.AddForce(direccion * fuerza, ForceMode.Impulse);
    }
}
