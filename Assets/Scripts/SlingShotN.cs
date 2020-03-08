﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShotN : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool isPressed = false;
    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }
    void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
    }
}
