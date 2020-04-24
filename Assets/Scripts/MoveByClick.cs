using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByClick : MonoBehaviour
{
    public GameObject Esferita;
    float FI;
    float FD;
    float FF;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = Esferita.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FI += 5.0f;
            rb.AddForce(new Vector3(FI*-1, 0, 0), ForceMode.Acceleration);
        }
        if (Input.GetMouseButtonDown(1))
        {
            FD += 5.0f;
            rb.AddForce(new Vector3(FD, 0, 0), ForceMode.Acceleration);
        }
        Debug.Log("Fuerza izquierda: "+FI);
        Debug.Log("Fuerza derecha: " + FD);
        FF = FD - FI;
        Debug.Log("Fuerza final: " +FF);
    }
}
