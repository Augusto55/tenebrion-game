using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float spawnChance = 4f / 10f;
    public GameObject enemyPrefab;

    void Start()
    {
        Debug.Log(spawnChance);
        Spawn();
    }

    void Spawn()
    {
        if (Random.Range(0f, 1f) <= spawnChance)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
