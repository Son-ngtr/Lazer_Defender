using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{

    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefabs;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;

    public Transform GetStartingWavepoint()
    {
        return pathPrefabs.GetChild(0).transform;
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefabs)
        {
            waypoints.Add(child.transform);
        }

        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    // Return Howmany enemies
    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    // Get the enemy
    public GameObject GetEnemyPrefabs(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance,
                                        timeBetweenEnemySpawns + spawnTimeVariance);       
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue); 
    }
}
