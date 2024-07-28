using Scripts.Gameplay.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Gameplay.Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Enemy : MonoBehaviour
    {
        [Header("Attributes")]
        public float MoveSpeed = 2f;
        public int Health = 2;
        public int CurrencyWorth = 50;

        private Rigidbody2D rb;
        private Transform targetPoint;
        private int pathIndex = 0;
        private bool isDead = false;

        private float baseSpeed;

        private void Start()
        {
            targetPoint = PathManager.Get().PathPoints[pathIndex];
            rb = GetComponent<Rigidbody2D>();
            baseSpeed = MoveSpeed;
        }

        private void Update()
        {
            if(Vector2.Distance(targetPoint.position, transform.position) <= 0.1f)
            {
                pathIndex++;

                if(pathIndex == PathManager.Get().PathPoints.Length)
                {
                    EnemyManager.OnEnemyDestroyed.Invoke();
                    HealthManager.OnEnemyPassed.Invoke();
                    Destroy(gameObject);
                    return;
                }
                else
                {
                    targetPoint = PathManager.Get().PathPoints[pathIndex];
                }
            }
        }

        private void FixedUpdate()
        {
            Vector2 direction = (targetPoint.position - transform.position).normalized;

            rb.velocity = direction * MoveSpeed;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;

            if(Health <= 0 && !isDead)
            {
                Destroy(gameObject);
                isDead = true;
                CurrencyManager.Get().AddCurrentCurrency(CurrencyWorth);
                EnemyManager.OnEnemyDestroyed.Invoke();
            }
        }

        public void UpdateSpeed(float newSpeed)
        {
            MoveSpeed = newSpeed;
        }

        public void ResetSpeed()
        {
            MoveSpeed = baseSpeed;
        }
    }
}

