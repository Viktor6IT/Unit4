using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject PowerUpPrefab;
    private float SpawnRange = 9.0f;
    public int EnemyCount = 3;
    private int WaveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(WaveNumber);
        spawnPowerUp();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCount = FindObjectsOfType<EnemyController>().Length;
        if (EnemyCount == 0)
        {
            WaveNumber++;
            SpawnEnemyWave(WaveNumber);
            spawnPowerUp();
        }
    }
    void SpawnEnemyWave(int EnemiesToSpawn)
    {
        for(int i = 0; i < EnemiesToSpawn; i++)
        {
            Instantiate(EnemyPrefab, GenerateSpawnPosition(), EnemyPrefab.transform.rotation);
        }
    }
    void spawnPowerUp()
    {
        Instantiate(PowerUpPrefab, GenerateSpawnPosition(), PowerUpPrefab.transform.rotation);
    }
    private Vector3 GenerateSpawnPosition()
    {
        float SpawnPosX = Random.Range(-SpawnRange, SpawnRange);
        float SpawnPosZ = Random.Range(-SpawnRange, SpawnRange);

        Vector3 RandomPosition = new Vector3(SpawnPosX, 0, SpawnPosZ);

        return RandomPosition;
    }
}
