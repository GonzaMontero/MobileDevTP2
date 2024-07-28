using Scripts.Gameplay.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Gameplay.Turrets
{
    public class Turret : MonoBehaviour
    {
        [Header("References")]
        public GameObject BulletPrefab;
        public Transform FiringPoint;
        public Transform BulletParent;
        public GameObject UpgradeUI;
        public Button UpgradeButton;
        
        [Header("Attributes")]
        public float TargetingRange = 5f;
        public float RotationSpeed = 5f;
        public LayerMask EnemyMask;
        public float BulletsPerSecond = 1f;
        public int BaseUpgradeCost = 100;

        private float bulletsPerSecondBase;
        private float targetingRangeBase;

        private Transform target = null;
        private float timeUntilFire;

        private int level = 1;

        private void Start()
        {
            bulletsPerSecondBase = BulletsPerSecond;
            targetingRangeBase = TargetingRange;

            UpgradeButton.onClick.AddListener(Upgrade);
        }

        private void Update()
        {
            if(target == null)
            {
                FindTarget();
                return;
            }

            RotateTowardsTarget();

            if(!CheckTargetIsInRange())
            {
                target = null;
            }
            else
            {
                timeUntilFire += Time.deltaTime;

                if(timeUntilFire >= 1f / BulletsPerSecond)
                {
                    Shoot();
                    timeUntilFire = 0;
                }
            }
        }

        private void Shoot()
        {
            GameObject bulletObj = Instantiate(BulletPrefab, FiringPoint.position, Quaternion.identity, BulletParent);
            Bullet bulletScript = bulletObj.GetComponent<Bullet>();
            bulletScript.SetTarget(target);
            
        }

        private bool CheckTargetIsInRange()
        {
            return Vector2.Distance(target.position, transform.position) <= TargetingRange;
        }

        private void RotateTowardsTarget()
        {
            float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) *
                Mathf.Rad2Deg - 90f;

            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        }

        private void FindTarget()
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, TargetingRange, (Vector2)transform.position, 0f,
                EnemyMask);
            if (hits.Length > 0) 
            {
                target = hits[0].transform;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Handles.color = Color.cyan;
            Handles.DrawWireDisc(transform.position,transform.forward, TargetingRange);
        }

        public void HandleUI()
        {
            if(UpgradeUI.activeSelf)
                UpgradeUI.SetActive(false);
            else
                UpgradeUI.SetActive(true);
        }

        public void Upgrade()
        {
            if (!CurrencyManager.Get().SpendCurrency(CalculateCost()))
                return;
            else
            {
                level++;
                BulletsPerSecond = CalculateBPS();
                TargetingRange = CalculateRange();
                HandleUI();
                Debug.Log("New Cost " + BaseUpgradeCost);
            }           
        }

        private int CalculateCost()
        {
            return Mathf.RoundToInt(BaseUpgradeCost * Mathf.Pow(level, 0.8f));
        }

        private float CalculateBPS()
        {
            return bulletsPerSecondBase * Mathf.Pow(level, 0.6f);
        }

        private float CalculateRange()
        {
            return targetingRangeBase * Mathf.Pow(level, 0.4f);
        }
    }
}

