using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    [SerializeField]
    private float spawnRangeX = 17.0f;
     [SerializeField]
    private float spawnPosZ;
    private float startDelay = 2f;
    private float spawnInterval = 2f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
    }

    void SpawnRandomEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        int enemyIndex = Random.Range(0,enemyPrefabs.Length);

        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }
}
