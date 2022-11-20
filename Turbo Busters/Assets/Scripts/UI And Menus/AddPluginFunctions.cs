using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPluginFunctions : MonoBehaviour
{
    AlertDialogueManager adm;

    public Button alertButton;
    public Text logText;

    private void Start()
    {
        adm = AlertDialogueManager.instance;

        alertButton.onClick.AddListener(adm.ShowAlert);
    }
}
