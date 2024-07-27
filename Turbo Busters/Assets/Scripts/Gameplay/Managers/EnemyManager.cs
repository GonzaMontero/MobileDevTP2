using UnityEngine;
using UnityEngine.Events;
using Scripts.Utilities;
using System.Collections;

namespace Scripts.Gameplay.Managers
{
    public class EnemyManager : SingletonInScene<EnemyManager>
    {
        [Header("References")]
        public GameObject[] EnemyPrefabs;
        public GameObject EnemyHolder;

        [Header("Attributes")]
        public int BaseEnemies = 8;
        public float EnemiesPerSecond = 0.5f;
        public float TimeBetweenWaves = 5f;
        public float DifficultyScaling = 0.75f;

        [Header("Events")]
        public static UnityEvent OnEnemyDestroyed = new UnityEvent();

        private int currentWave = 1;
        private float timeSinceLastSpawn;
        private int enemiesAlive;
        private int enemiesLeftToSpawn;
        private bool isSpawning = false;

        public override void Awake()
        {
            base.Awake();
            OnEnemyDestroyed.AddListener(EnemyDestroyed);
        }

        private void Start()
        {
            StartCoroutine(StartWave());
        }

        private void Update()
        {
            if (!isSpawning)
                return;

            timeSinceLastSpawn += Time.deltaTime;

            if(timeSinceLastSpawn >= (1f / EnemiesPerSecond) && enemiesLeftToSpawn > 0)
            {
                SpawnEnemy();
                enemiesLeftToSpawn--;
                enemiesAlive++;
                timeSinceLastSpawn = 0f;
            }

            if(enemiesAlive ==0 && enemiesLeftToSpawn ==0)
            {
                EndWave();
            }
        }

        private IEnumerator StartWave()
        {
            yield return new WaitForSeconds(TimeBetweenWaves);

            isSpawning = true;
            enemiesLeftToSpawn = EnemiesPerWave();
        }

        private void EndWave()
        {
            isSpawning = false;
            timeSinceLastSpawn = 0f;
            currentWave++;
            StartCoroutine(StartWave());
        }

        private int EnemiesPerWave()
        {
            return Mathf.RoundToInt(BaseEnemies * Mathf.Pow(currentWave, DifficultyScaling));
        }

        private void SpawnEnemy()
        {
            GameObject prefabToSpawn = EnemyPrefabs[0];
            Instantiate(prefabToSpawn, PathManager.Get().StartPoint.position, Quaternion.identity, EnemyHolder.transform);
        }

        #region Events

        private void EnemyDestroyed()
        {
            enemiesAlive--;
        }

        #endregion
    }
}