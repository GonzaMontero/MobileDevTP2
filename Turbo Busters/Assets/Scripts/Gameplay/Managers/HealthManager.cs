using Scripts.Gameplay.UI;
using Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Gameplay.Managers
{
    public class HealthManager : Singleton<HealthManager>
    {
        [Header("Attributes")]
        public int PlayerHealth;
        public GameEndUIHandler GameEndUIHandler;
        public Menu Menu;

        [Header("Unity Events")]
        public static UnityEvent OnEnemyPassed = new UnityEvent();

        private void Start()
        {
            OnEnemyPassed.AddListener(LoseHealth);
        }

        public void LoseHealth()
        {
            PlayerHealth--;

            if (PlayerHealth <= 0)
                LoseGame();
        }

        public void GainHealthRound5()
        {
            PlayerHealth++;
        }

        public void LoseGame()
        {
            GameEndUIHandler.gameObject.SetActive(true);
            EnemyManager.Get().gameObject.SetActive(false);
            Menu.CloseText();
        }

        private void EnemyPassed()
        {
            LoseHealth();
        }
    }
}

