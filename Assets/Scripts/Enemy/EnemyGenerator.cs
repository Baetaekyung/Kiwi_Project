using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGenerator : Singleton<EnemyGenerator>
{
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private int maximumEnemy;
    [SerializeField]
    private int minimumEnemy;

    public void EnemySpawn(Vector3 spawnPos)
    {
        int spawnEnemy = Random.Range(minimumEnemy, maximumEnemy);
        for(int i = 0; i < spawnEnemy; i++)
        {
            Instantiate(enemies[0], spawnPos, Quaternion.identity);
        }
    }
}
