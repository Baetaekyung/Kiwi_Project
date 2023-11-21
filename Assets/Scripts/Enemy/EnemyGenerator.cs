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
    [SerializeField]
    private GameObject ghost;

    private void Start()
    {
        GhostSpawn();
    }

    public void EnemySpawn(Vector3 spawnPos)
    {
        int spawnEnemy = Random.Range(minimumEnemy, maximumEnemy);
        int spawnOrNot = Random.Range(0, 6);
        if(spawnOrNot == 3)
        {
            for (int i = 0; i < spawnEnemy; i++)
            {
                Instantiate(enemies[0], spawnPos, Quaternion.identity);
            }
        }
    }
    public void GhostSpawn()
    {
        Instantiate(ghost, Vector3.zero, Quaternion.identity);
    }
}
