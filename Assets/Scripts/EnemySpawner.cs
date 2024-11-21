using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping = true;
    WaveConfigSO currentWave;

    private void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }
        
    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    // Spawn different Enemy Wa

    // Using coroutine to Spawn enemies at different time
    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefabs(i),
                            currentWave.GetStartingWavepoint().position,
                            Quaternion.Euler(0, 0, 180),
                            transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
    }
}



/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping = true;
    WaveConfigSO currentWave;

    // Dictionary to hold pools for each enemy type
    private Dictionary<GameObject, Queue<GameObject>> enemyPools;

    private void Start()
    {
        enemyPools = new Dictionary<GameObject, Queue<GameObject>>();
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    // Method to get an enemy from the pool
    private GameObject GetEnemyFromPool(GameObject enemyPrefab)
    {
        if (!enemyPools.ContainsKey(enemyPrefab))
        {
            enemyPools[enemyPrefab] = new Queue<GameObject>();
        }

        if (enemyPools[enemyPrefab].Count == 0)
        {
            // Instantiate a new enemy if the pool is empty
            GameObject newEnemy = Instantiate(enemyPrefab);
            newEnemy.SetActive(false);
            enemyPools[enemyPrefab].Enqueue(newEnemy);
        }

        GameObject enemy = enemyPools[enemyPrefab].Dequeue();
        enemy.SetActive(true);
        return enemy;
    }

    // Method to return an enemy to the pool
    public void ReturnEnemyToPool(GameObject enemy, GameObject enemyPrefab)
    {
        enemy.SetActive(false);
        enemyPools[enemyPrefab].Enqueue(enemy);
    }

    // Using coroutine to Spawn enemies at different time
    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    GameObject enemyPrefab = currentWave.GetEnemyPrefabs(i);
                    GameObject enemy = GetEnemyFromPool(enemyPrefab);
                    enemy.transform.position = currentWave.GetStartingWavepoint().position;
                    enemy.transform.rotation = Quaternion.Euler(0, 0, 180);
                    enemy.transform.parent = transform;
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
    }
}*/