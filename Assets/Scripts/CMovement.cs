using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMovement : MonoBehaviour
{
    float timeCounter = 0;
    public float speed;
    public float width;
    public float height;
    public float y1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime*speed;
        float x = Mathf.Cos(timeCounter)*width;
        float y = y1;
        float z = Mathf.Sin(timeCounter) * height; 
        transform.position = new Vector3(x, y, z);
    }
}
