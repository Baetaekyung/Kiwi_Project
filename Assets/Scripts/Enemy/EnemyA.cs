using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : EnemyHealth, IEnemyStats
{
    void Start()
    {
        InitHealth();
    }

    public void DecreaseHealth(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            EnemyDeath();
        }
    }

    public void EnemyDeath()
    {
        Destroy(gameObject);
    }

    public void InitHealth()
    {
        currentHealth = maxHealth;
    }

}
