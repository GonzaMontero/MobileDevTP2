using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShperePositionCalculator : MonoBehaviour
{
    Transform camTransform;

    public SpriteRenderer img;
    public ParticleSystem system;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        img.enabled = false;
        system.Play();

        StartCoroutine(WaitForFinishPlay());
    }

    IEnumerator WaitForFinishPlay()
    {
        if (system.isPlaying)
            yield return null;

        transform.position = camTransform.position + (Random.insideUnitSphere * 30);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        img.enabled = true;
    }
}
