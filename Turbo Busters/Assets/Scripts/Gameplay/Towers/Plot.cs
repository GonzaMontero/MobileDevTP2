using Scripts.Gameplay.Managers;
using Scripts.Gameplay.Turrets;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts.Gameplay.Turrets
{
    public class Plot : MonoBehaviour
    {
        [Header("Attributes")]
        public Color StartingColor;
        public Color SelectedColor;

        private GameObject tower;
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            StartingColor = spriteRenderer.color;
        }

        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject()) 
                return;

            if (tower !=  null)
            {
                return;
            }
            else
            {
                TurretSerializable towerToBuild = BuildManager.Get().GetSelectedTower();

                if (!CurrencyManager.Get().SpendCurrency(towerToBuild.Cost))
                    return;

                tower = Instantiate(towerToBuild.Prefab, transform.position, Quaternion.identity);
                spriteRenderer.color = SelectedColor;
            }
        }
    }
}