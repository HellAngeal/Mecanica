using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2 : MonoBehaviour {

    public float maxDragDistance = 2f;

    private bool isPressed = false;
    private Rigidbody2D rb;
    private Rigidbody2D hookRb;
    private SpringJoint2D sj;
    private LineRenderer lr;
    private TrailRenderer tr;

    private float releaseDelay = 1f;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sj = GetComponent<SpringJoint2D>();
        lr = GetComponent<LineRenderer>();
        tr = GetComponent<TrailRenderer>();
        hookRb = sj.connectedBody;

        lr.enabled = false;
        tr.enabled = false;
        releaseDelay = 1 / (sj.frequency * 4);
    }

	void Update () {
		if(isPressed) {
            DragBall();
        }
	}

    private void OnMouseDown() {
        isPressed = true;
        rb.isKinematic = true;
        lr.enabled = true;
    }

    private void OnMouseUp() {
        isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
        lr.enabled = false;
    }

    private void DragBall() {
        SetLineRendererPosition();

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(mousePosition, hookRb.position);

        if(distance > maxDragDistance) {
            Vector2 direction = (mousePosition - hookRb.position).normalized;
            rb.position = hookRb.position + direction * maxDragDistance;
        } else {
            rb.position = mousePosition;
        }
    }

    private void SetLineRendererPosition() {
        Vector3[] linePositions = new Vector3[2];
        linePositions[0] = transform.position;
        linePositions[1] = hookRb.position;
        lr.SetPositions(linePositions);
    }

    private IEnumerator Release() {
        yield return new WaitForSeconds(releaseDelay);
        sj.enabled = false;
        tr.enabled = true;
    }
}
