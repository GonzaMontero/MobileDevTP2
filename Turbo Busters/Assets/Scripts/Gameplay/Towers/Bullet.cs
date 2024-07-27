using Scripts.Gameplay.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Gameplay.Turrets
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [Header("Attributes")]
        public float BulletSpeed = 5f;
        public int BulletDamage = 1;

        private Transform target;
        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (!target)
                return;

            Vector2 direction = (target.position - transform.position).normalized;

            rb.velocity = direction * BulletSpeed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(BulletDamage);
            Destroy(gameObject);
        }

        public void SetTarget(Transform _target)
        {
            target = _target;
        }
    }
}