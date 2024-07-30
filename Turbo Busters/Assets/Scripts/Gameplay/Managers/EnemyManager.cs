using UnityEngine;
using UnityEngine.Events;
using Scripts.Utilities;
using System.Collections;
using GooglePlayGames;

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
        public float MaxEnemiesPerSecond = 15f;

        [Header("Events")]
        public static UnityEvent OnEnemyDestroyed = new UnityEvent();

        private int currentWave = 1;
        private float timeSinceLastSpawn;
        private float enemiesPerSecond;
        private int enemiesAlive;
        private int enemiesLeftToSpawn;
        private bool isSpawning = false;

        public override void Awake()
        {
            base.Awake();
            OnEnemyDestroyed.AddListener(EnemyDestroyed);
            enemiesPerSecond = EnemiesPerSecond;
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

            if(timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
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
            enemiesPerSecond = EnemieSPerSecond();
        }

        private void EndWave()
        {
            isSpawning = false;
            timeSinceLastSpawn = 0f;
            currentWave++;

            if(currentWave == 5)
                AchievementManagers.Get().UnlockFirstAchievement();
            else if (currentWave == 10)
                AchievementManagers.Get().UnlockSecondAchievement();
            else if (currentWave == 15)
                AchievementManagers.Get().UnlockThirdAchievement();

            if (PlayGamesPlatform.Instance.IsAuthenticated())
                Social.ReportScore(currentWave, GPGSIds.leaderboard_global_leaderboard, LeaderBoardUpdate);

            StartCoroutine(StartWave());
        }

        private void LeaderBoardUpdate(bool success)
        {
            if (success)
            {
                Debug.Log("Leaderboard Updated");
            }
            else
            {
                Debug.Log("Leaderboard Not Updated");
            }
        }

        private int EnemiesPerWave()
        {
            return Mathf.RoundToInt(BaseEnemies * Mathf.Pow(currentWave, DifficultyScaling));
        }

        private float EnemieSPerSecond()
        {
            return Mathf.Clamp(enemiesPerSecond * Mathf.Pow(currentWave, DifficultyScaling), 
                0f, MaxEnemiesPerSecond);
        }

        private void SpawnEnemy()
        {
            int index = Random.Range(0, EnemyPrefabs.Length);

            GameObject prefabToSpawn = EnemyPrefabs[index];
            Instantiate(prefabToSpawn, PathManager.Get().StartPoint.position, Quaternion.identity, EnemyHolder.transform);
        }

        public int GetCurrentWave()
        {
            return currentWave;        
        }

        #region Events

        private void EnemyDestroyed()
        {            
            enemiesAlive--;
        }

        #endregion
    }
}