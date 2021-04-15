using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserHealthManager : HealthManager
{
    [SerializeField] EnemyHealthManager enemy;

    void Start()
    {
        currHealth = maxHealth;
    }

    public override void TakeDamage(float damage)
    {
        enemy.currHealth += damage;
        currHealth -= damage;

        CheckHealth();
    }
}
