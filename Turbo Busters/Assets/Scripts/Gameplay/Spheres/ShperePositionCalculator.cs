using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShperePositionCalculator : MonoBehaviour
{
    Transform camTransform;

    private void Start()
    {
        camTransform = Camera.main.transform;
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, camTransform.position) > 30)
        {
            transform.position = camTransform.position + (Random.insideUnitSphere * 30);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        }
    }
}
