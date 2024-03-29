using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab; 
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1; 
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerupPrefab, GenerateSpawnLocation(), powerupPrefab.transform.rotation);
        SpawnEnemyWave(waveNumber); 
    }

    private void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            Instantiate(powerupPrefab, GenerateSpawnLocation(), powerupPrefab.transform.rotation);
            waveNumber++; 
            SpawnEnemyWave(waveNumber); 
        }
    }

    private Vector3 GenerateSpawnLocation()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnLocation(), enemyPrefab.transform.rotation);
        }
    }
}
