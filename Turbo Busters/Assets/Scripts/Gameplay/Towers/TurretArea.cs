using Scripts.Gameplay.Enemies;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Scripts
{
    public class TurretArea : MonoBehaviour
    {
        [Header("Attributes")]
        public float TargetingRange = 5f;
        public LayerMask EnemyMask;
        public float BurstsPerSecond = 0.5f;
        public float FreezeTime = 1f;

        private float timeUntilFire;

        private void Update()
        {
            timeUntilFire += Time.deltaTime;

            if(timeUntilFire >= 1f / BurstsPerSecond)
            {
                FreezeEnemies();
                timeUntilFire = 0f;
            }
        }

        private void FreezeEnemies()
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, TargetingRange, (Vector2)transform.position, 0f,
                EnemyMask);

            if (hits.Length > 0)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    RaycastHit2D hit = hits[i];
                    
                    Enemy enemy = hit.transform.GetComponent<Enemy>();
                    enemy.UpdateSpeed(.5f);

                    StartCoroutine(ResetEnemySpeed(enemy));
                }
            }
        }

        private IEnumerator ResetEnemySpeed(Enemy enemy)
        {
            yield return new WaitForSeconds(FreezeTime);

            enemy.ResetSpeed();
        }
    }
}

