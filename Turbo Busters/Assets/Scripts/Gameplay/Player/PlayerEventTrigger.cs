using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEventTrigger : MonoBehaviour
{
    public UnityEvent onHitEvent;

    void Start()
    {
        if (onHitEvent == null)
            onHitEvent = new UnityEvent();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy Sphere")
            onHitEvent.Invoke();
    }
}
