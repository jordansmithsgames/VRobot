using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHand_Health : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player_hand")
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
