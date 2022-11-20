using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    PlayerManager pm;

    private void Start()
    {
        pm = PlayerManager.instance;

        GameObject go = Instantiate(pm.selectedGO, transform);
        go.transform.position = Vector3.zero;
    }
}
