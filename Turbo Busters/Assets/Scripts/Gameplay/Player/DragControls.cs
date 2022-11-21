using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragControls : MonoBehaviour
{
    public float power = 10f;
    public float maxDrag = 15f;

    public Rigidbody2D rigidBody;
    public LineRenderer lineRenderer;

    public UnityEvent onDragReleaseEvent;

    private Vector3 dragStartPos;

    private Touch touch;

    private void Start()
    {
        if (onDragReleaseEvent == null)
            onDragReleaseEvent = new UnityEvent();

        rigidBody.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                Debug.Log("Started Dragging");
                DragStart();
            }
            if(touch.phase == TouchPhase.Moved)
            {
                Debug.Log("Still Dragging");
                Dragging();
            }
            if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("Ended Dragging");
                DragRelease();
            }

        }
    }

    void DragStart()
    {
        dragStartPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x,touch.position.y));
        dragStartPos.z = 0f;

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, dragStartPos);
    }

    void Dragging()
    {
        Vector3 draggingPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y));
        draggingPos.z = 0f;

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(1, draggingPos);
    }

    void DragRelease()
    {
        onDragReleaseEvent?.Invoke();

        lineRenderer.positionCount = 0;

        Vector3 dragReleasePosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y));
        dragReleasePosition.z = 0f;

        Vector3 force = dragStartPos - dragReleasePosition;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

        rigidBody.constraints = RigidbodyConstraints2D.None;
        rigidBody.AddForce(clampedForce, ForceMode2D.Impulse);
    }

    public void OnHitEvent()
    {
        rigidBody.constraints = RigidbodyConstraints2D.FreezePosition;
    }
}
