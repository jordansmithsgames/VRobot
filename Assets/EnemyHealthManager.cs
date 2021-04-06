using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : HealthManager
{
    [SerializeField] UserHealthManager user;

    void Start()
    {
        currHealth = maxHealth;
    }

    public override void TakeDamage()
    {
        user.currHealth++;
        currHealth--;
    }

    public override void HalfHealth()
    {
        Debug.Log("You");
    }
}
