using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySphereManager : MonoBehaviour
{
    public GameObject enemySpherePrefab;
    public int enemySphereCount;

    public Transform camTransform;

    void Start()
    {
        GameObject go;

        for(int i = 0; i < enemySphereCount; i++)
        {
            go = Instantiate(enemySpherePrefab);
            go.transform.position = camTransform.position + (Random.insideUnitSphere * 30);
            go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, 0f);
        }
    }
}
