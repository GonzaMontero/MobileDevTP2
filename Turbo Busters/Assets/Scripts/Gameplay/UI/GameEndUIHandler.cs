using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Scripts.Gameplay.Managers;

namespace Scripts.Gameplay.UI
{
    public class GameEndUIHandler : MonoBehaviour
    {
        [Header("References")]
        public TextMeshProUGUI WaveText;
        public Button ReplayButton;
        public Button ReturnToMenuButton;

        private void OnEnable()
        {
            WaveText.text = "Wave: " + EnemyManager.Get().GetCurrentWave();

            ReplayButton.onClick.AddListener(
                () =>
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                });
        }
    }
}
