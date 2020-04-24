using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoveByClick : MonoBehaviour
{
    public GameObject Cubito;
    float FI;
    float FD;
    float FF;
    public Text FDtext;
    public Text FItext;
    public Text FFtext;
    Rigidbody rb;

    void Start()
    {
        rb = Cubito.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FF -= 0.5f;
            FI -= 0.5f;
        }
        if (Input.GetMouseButtonDown(1))
        {
            FF += 0.5f;
            FD += 0.5f;
        }
        rb.AddForce(new Vector3(FF, 0, 0), ForceMode.Force);
        FDtext.text = "Fuerza derecha: " + FD;
        FItext.text = "Fuerza izquierda: " + FI;
        FFtext.text = "Fuerza final: " + FF;
    }
}
