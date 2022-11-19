using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragControls : MonoBehaviour
{
    public float power = 10f;
    public float maxDrag = 5f;

    public Rigidbody2D rigidBody;
    public LineRenderer lineRenderer;

    private Vector3 dragStartPos;

    private Touch touch;


    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                DragStart();
            }
            if(touch.phase == TouchPhase.Moved)
            {
                Dragging();
            }
            if (touch.phase == TouchPhase.Ended)
            {
                DragRelease();
            }

        }
    }

    void DragStart()
    {
        dragStartPos = Camera.main.ScreenToWorldPoint(touch.position);
        dragStartPos.z = 0f;

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, dragStartPos);
    }

    void Dragging()
    {
        Vector3 draggingPos = Camera.main.ScreenToWorldPoint(touch.position);
        draggingPos.z = 0f;

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(1, draggingPos);
    }

    void DragRelease()
    {
        lineRenderer.positionCount = 0;

        Vector3 dragReleasePosition = Camera.main.ScreenToWorldPoint(touch.position);
        dragReleasePosition.z = 0f;

        Vector3 force = dragStartPos - dragReleasePosition;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

        rigidBody.AddForce(clampedForce, ForceMode2D.Impulse);
    }
}
