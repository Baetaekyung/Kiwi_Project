using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyStats
{
    void InitHealth();
    void EnemyDeath();
    void DecreaseHealth(int damage);
}
