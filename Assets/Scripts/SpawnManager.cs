using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private int waveNumber = 1;
    [SerializeField]
    private GameObject enemyPrefab;
    private float spawnRangeX = 15;
    private float spawnRangeY = 15;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = waveNumber;
        SpawnEnemy(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCount == 0)
        {
            SpawnEnemy(++waveNumber);
            enemyCount = waveNumber;
        }
    }

    private void SpawnEnemy(int wave)
    {
        for(int x = 0; x < wave; x++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector3 randomPos = new Vector3(spawnX, spawnY, 0);
        return randomPos;
    }
}
