using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offSet;
    private void LateUpdate()
    {
        Vector3 desiredPositioon = target.position + offSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPositioon, smoothSpeed * Time.deltaTime);
        transform.position = new Vector3(target.position.x + offSet.x, offSet.y, target.position.z + offSet.z);
    }
}
