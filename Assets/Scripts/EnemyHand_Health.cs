﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHand_Health : MonoBehaviour
{
    public int health;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("UserRobot") && health > 0)
        {
            Debug.Log("Enemy shoulder health: " + health);
            health -= 5;
        }
    }

    public int getHealth()
    {
        return health;
    }
}
