using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotT : MonoBehaviour
{
    private bool isPressed;
    private float releaseDelay;
    private float maxDragDistance = 2f;
    private Rigidbody2D slingrb;
    private Rigidbody2D rb;
    private SpringJoint2D sp;
    private LineRenderer lr;
    private TrailRenderer tr;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpringJoint2D>();
        lr = GetComponent<LineRenderer>();
        tr = GetComponent<TrailRenderer>();
        slingrb = sp.connectedBody;
        lr.enabled = false;
        tr.enabled = false;
        releaseDelay = 1 / (sp.frequency * 4);
    }
    void Update()
    {
        if (isPressed)
        {
            rb.position=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    private void DragBall()
    {
        SetLineRendererPosition();

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(mousePosition, slingrb.position);

        if (distance > maxDragDistance)
        {
            Vector2 direction = (mousePosition - slingrb.position).normalized;
            rb.position = slingrb.position * direction * maxDragDistance;
        }
        else
        {
            rb.position = mousePosition;
        }
    }
    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
        lr.enabled = true;
    }
    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
        lr.enabled = false;
    }
    private void SetLineRendererPosition()
    {
        Vector3[] linePositions = new Vector3[2];
        linePositions[0] = transform.position;
        linePositions[1] = slingrb.position;
        lr.SetPositions(linePositions);
    }
    private IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseDelay);
        sp.enabled = false;
        tr.enabled = true;
    }
}
