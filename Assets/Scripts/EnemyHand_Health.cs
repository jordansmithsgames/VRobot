using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHand_Health : MonoBehaviour
{
    public int health;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player_Hand"))
        {
            health--;
            if(health <= 0)
            {
                health = 0;
            }
        }
    }

    public int getHealth()
    {
        return health;
    }
}
