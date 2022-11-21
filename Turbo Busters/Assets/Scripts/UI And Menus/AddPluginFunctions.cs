using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddPluginFunctions : MonoBehaviour
{
    AlertDialogueManager adm;

    public Button alertButton;
    public TextMeshProUGUI logText;

    private void Start()
    {
        adm = AlertDialogueManager.instance;

        alertButton.onClick.AddListener(adm.ShowAlert);
    }

    private void OnEnable()
    {
        logText.text = LoggerManager.instance.GetFile();
    }
}
