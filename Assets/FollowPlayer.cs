using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    /*public Transform player;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smootherPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = player.position + offset;

        //transform.LookAt(player);
    }*/
    //float FocalLenght;
   
    private Animation animation;
    private void Awake()
    {
       animation = this.GetComponent<Animation>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animation.Play("cameraanimacion");
        }
    }

}
