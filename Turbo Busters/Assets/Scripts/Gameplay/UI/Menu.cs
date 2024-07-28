using Scripts.Gameplay.Managers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Gameplay.UI
{
    public class Menu : MonoBehaviour
    {
        [Header("References")]
        public TextMeshProUGUI CurrencyText;
        public TextMeshProUGUI WaveText;
        public TextMeshProUGUI HealthText;
        public GameObject ButtonPrototype;
        public Transform ButtonHolder;

        private void Start()
        {
            for (short i = 0; i < BuildManager.Get().Towers.Length; i++)
            {
                GameObject tempButton = Instantiate(ButtonPrototype, ButtonHolder);
                int capturedIndex = i; 
                tempButton.GetComponent<Button>().onClick.AddListener(
                    () =>
                    {
                        BuildManager.Get().SetSelectedTower(capturedIndex);
                    }
                );
                tempButton.GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = BuildManager.Get().Towers[i].Name;
            }

            ButtonPrototype.SetActive(false);
        }

        private void OnGUI()
        {
            CurrencyText.text = CurrencyManager.Get().GetCurrentCurrency() + "$";
            WaveText.text = "Wave " + EnemyManager.Get().GetCurrentWave();
            HealthText.text = "Health " + HealthManager.Get().PlayerHealth;
        }

        public void InteractMenu()
        {
            if(ButtonHolder.gameObject.activeSelf)
                ButtonHolder.gameObject.SetActive(false);
            else
                ButtonHolder.gameObject.SetActive(true);
        }

        public void CloseText()
        {
            CurrencyText.gameObject.SetActive(false);
            WaveText.gameObject.SetActive(false);
            HealthText.gameObject.SetActive(false);
        }
    }
}

