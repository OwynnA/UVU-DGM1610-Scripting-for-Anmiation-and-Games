using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawnManager : MonoBehaviour
{
    public GameObject[] fireworkPrefabs;
    [SerializeField]
    public float spawnRangeX;
    [SerializeField]
    public float spawnPosY;
    private float startDelay = 0f;
    private float spawnInterval = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFirework", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void SpawnFirework()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnPosY, spawnPosY), 0);

        int fireworkIndex = Random.Range (0, fireworkPrefabs.Length);
        Instantiate(fireworkPrefabs[fireworkIndex], spawnPos, fireworkPrefabs[fireworkIndex].transform.rotation);
    }
}
