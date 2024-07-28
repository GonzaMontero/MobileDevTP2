using Scripts.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Gameplay.Managers
{
    public class CurrencyManager : SingletonInScene<CurrencyManager>
    {
        [Header("Attributes")]
        public int initialCurrency;

        private int currentCurrency = 0;

        private void Start()
        {
            currentCurrency = initialCurrency;
        }

        public int GetCurrentCurrency()
        {
            return currentCurrency; 
        }

        public void AddCurrentCurrency(int currencyToAdd)
        {
            currentCurrency += currencyToAdd;
        }

        public bool SpendCurrency(int currencyToRemove)
        {
            if(currencyToRemove <= currentCurrency)
            {
                currentCurrency -= currencyToRemove;
                return true;
            }
            else
            {
                Debug.Log("Not Enough Currency");
                return false;
            }
        }
    }
}