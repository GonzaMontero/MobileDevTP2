using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    PlayerManager pm;

    private void Start()
    {
        pm = PlayerManager.instance;

        GameObject go = Instantiate(pm.characterPrefab, transform);
        go.GetComponentInChildren<SpriteRenderer>().color = pm.selectedColor;
        go.transform.position = Vector3.zero;
    }
}
