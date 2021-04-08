using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : HealthManager
{
    [SerializeField] UserHealthManager user;
    [SerializeField] EnemyMovement enemyAI;

    void Start()
    {
        currHealth = maxHealth;
        enemyAI.criticalHealth = maxHealth / 2.0f;
    }

    public override void TakeDamage()
    {
        user.currHealth++;
        currHealth--;
        enemyAI.health = currHealth;
        enemyAI.dealDamage = true;
        //Debug.Log("Enemy robot's current health: " + currHealth);
    }

    public override void HalfHealth()
    {
        
    }
}
