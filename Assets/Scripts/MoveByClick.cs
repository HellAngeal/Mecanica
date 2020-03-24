using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByClick : MonoBehaviour
{
    public GameObject Esferita;
    int FI;
    int FD;
    int FF;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FI += 1;
        }
        if (Input.GetMouseButtonDown(1))
        {
            FD += 1;
        }
        FF = FD - FI;
        Esferita.transform.position =new Vector3 (FF, 0, 0);
    }
}
