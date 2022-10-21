using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnManager : MonoBehaviour
{
    public GameObject[] coinPrefabs;
    [SerializeField]
    public float spawnRangeX;
    [SerializeField]
    public float spawnPosY;
    public int spawnRateBig;
    public int bigSpawn = 0;
    private float startDelay = 3f;
    private float spawnInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCoin", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void SpawnCoin()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnPosY, spawnPosY), 0);

        int coinIndex = Random.Range (0, coinPrefabs.Length);
        if(bigSpawn < spawnRateBig && coinIndex == 0)
        {
             coinIndex = 1;
             bigSpawn +=1;
             Instantiate(coinPrefabs[coinIndex], spawnPos, coinPrefabs[coinIndex].transform.rotation);
        }
        else if(bigSpawn == spawnRateBig && coinIndex == 0)
        {
            Instantiate(coinPrefabs[coinIndex], spawnPos, coinPrefabs[coinIndex].transform.rotation);
            bigSpawn = 0;
        }
        else if(coinIndex == 1)
        {
            Instantiate(coinPrefabs[coinIndex], spawnPos, coinPrefabs[coinIndex].transform.rotation);
        }
    }
}
