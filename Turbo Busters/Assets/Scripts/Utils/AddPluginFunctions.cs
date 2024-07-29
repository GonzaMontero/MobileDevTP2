using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Utilities
{
    public class AddPluginFunctions : MonoBehaviour
    {
        AlertDialogueManager alertDialogueManager;

        [Header("References")]
        public Button AlertButton;
        public TextMeshProUGUI LogText;

        private void Start()
        {
            alertDialogueManager = AlertDialogueManager.Get();

            AlertButton.onClick.AddListener(alertDialogueManager.ShowAlert);
        }

        private void OnEnable()
        {
            LogText.text = LoggerManager.Get().GetFile();
        }
    }
}