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

    public override void TakeDamage()
    {
        enemy.currHealth++;
        currHealth--;
        Debug.Log("User robot's health: " + currHealth);
    }

    public override void HalfHealth()
    {
        
    }
}
