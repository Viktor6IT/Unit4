using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject EnemyPrefab;
    private float SpawnRange = 9.0f;
    // Start is called before the first frame update
    void Start()
    {

        Instantiate(EnemyPrefab, GenerateSpawnPosition(), EnemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Vector3 GenerateSpawnPosition()
    {
        float SpawnPosX = Random.Range(-SpawnRange, SpawnRange);
        float SpawnPosZ = Random.Range(-SpawnRange, SpawnRange);

        Vector3 RandomPosition = new Vector3(SpawnPosX, 0, SpawnPosZ);

        return RandomPosition;
    }
}
