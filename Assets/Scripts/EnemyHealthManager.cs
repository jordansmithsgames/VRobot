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

    public override void TakeDamage(float damage)
    {
        // Update robots' health
        user.currHealth += damage;
        currHealth -= damage;

        // Update AI and play hitstun animation
        enemyAI.health = currHealth;
        enemyAI.dealDamage = true;

        CheckHealth();
    }
}
