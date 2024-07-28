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

        private GameObject towerObject;
        private Turret turret;
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

            if (turret !=  null)
            {
                turret.HandleUI();
                return;
            }
            else
            {
                TurretSerializable towerToBuild = BuildManager.Get().GetSelectedTower();

                if (!CurrencyManager.Get().SpendCurrency(towerToBuild.Cost))
                    return;

                towerObject = Instantiate(towerToBuild.Prefab, transform.position, Quaternion.identity);
                turret = towerObject.GetComponentInChildren<Turret>();
                spriteRenderer.color = SelectedColor;
            }
        }
    }
}