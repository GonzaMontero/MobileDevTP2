using Scripts.Gameplay.Turrets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Gameplay.UI
{
    public class UpgradeUIHandler : MonoBehaviour
    {
        [Header("References")]
        public Turret ThisTurret;

        private void OnMouseDown()
        {
            ThisTurret.HandleUI();
        }
    }
}