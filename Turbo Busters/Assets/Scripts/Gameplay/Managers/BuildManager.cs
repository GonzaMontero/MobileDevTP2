using Scripts.Utilities;
using Scripts.Gameplay.Turrets;
using UnityEngine;

namespace Scripts.Gameplay.Managers
{
    public class BuildManager : SingletonInScene<BuildManager>
    {
        [Header("Referencies")]
        public TurretSerializable[] Towers;

        private int selectedTower = 0;

        public TurretSerializable GetSelectedTower()
        {
            return Towers[selectedTower];
        }

        public void SetSelectedTower(int _selectedTower)
        {
            selectedTower = _selectedTower;
        }
    }

}
