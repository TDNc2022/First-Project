using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FirstProject{
    public class WaveManager : MonoBehaviour
    {
        public enum SpawnState {spawning, waiting, counting };
        [System.Serializable]
        public class Wave
        {
            public string name;
            public Transform enemy;
            public int count;
            public float rate;
        }

        public Wave[] waves;
        private int nextWave = 0;

        public Transform[] spawnPoints;
        public GameObject[] currentEnemies;
        public float timeBetweenWaves = 5f;
        public float waveCountdown;

        private float searchCountdown = 1f;

        public SpawnState state = SpawnState.counting;
        private Transform _target;
        public string _currentWave;
        public string _currentState;

        void Start()
        {
            if (spawnPoints.Length == 0)
            {
                Debug.LogError("No spawn points referenced.");
            }
            waveCountdown = timeBetweenWaves;
        }

        void Update()
        {
            _target = PlayerController.Instance.transform;

            if (state == SpawnState.waiting)
            {
                if (!EnemyIsAlive())
                {
                    WaveCompleted();
                }
                else
                    return;
            }
            if (waveCountdown <= 0)
            {
                if (state != SpawnState.spawning)
                {
                    _currentState = "GOING";
                    StartCoroutine(SpawnWave(waves[nextWave]));
                }
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }
        }
        void WaveCompleted()
        {
            Debug.Log ("Wave Completed!");
            _currentState = "COMPLETED";
            state = SpawnState.counting;
            waveCountdown = timeBetweenWaves;

            if (nextWave + 1 > waves.Length - 1)
            {
                nextWave = 0;
                Debug.Log ("All waves complete! Looping...");
            }
            else
            {
                nextWave++;
            }
        }
        bool EnemyIsAlive()
        {
            searchCountdown -= Time.deltaTime;
            if (searchCountdown <= 0f)
            {
                searchCountdown = 1f;
                if (GameObject.FindGameObjectWithTag("Enemy")==null)
                {
                    return false;
                }
            }
            return true;
        }
        IEnumerator SpawnWave  (Wave _wave)
        {
            Debug.Log("Spawning Wave: " + _wave.name);
            _currentWave = _wave.name;
            state = SpawnState.spawning;
            for (int i = 0; i < _wave.count; i++)
            {
                SpawnEnemy(_wave.enemy);
                yield return new WaitForSeconds(1f/_wave.rate);
            }
            state = SpawnState.waiting;
            yield break;
        }
        void SpawnEnemy(Transform _enemy)
        {
            Transform _sp = spawnPoints[Random.Range (0, spawnPoints.Length)];
            Transform newEnemy = Instantiate(_enemy, _sp.position, _sp.rotation);
            newEnemy.GetComponent<IA_Enemy>().target = _target;
            Debug.Log("Spawning Enemy: " + _enemy.name);
        }
    }
}