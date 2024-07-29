using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunctions : MonoBehaviour
{
    public void EnableGameObject(GameObject go)
    {
        if (go.activeSelf)
            return;

        go.SetActive(true);
    }

    public void DisableGameObject(GameObject go)
    {
        if(!go.activeSelf) 
            return;

        go.SetActive(false);
    }

    public void LoadScene(string sn)
    {
        SceneManager.LoadScene(sn, LoadSceneMode.Single);
    }
}
