using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Robot { User, Enemy}

public class HealthManager : MonoBehaviour
{
    [SerializeField] Robot robot;
    [SerializeField] float maxHealth = 150f;
    private float currHealth;

    private void Start()
    {
        currHealth = maxHealth;
    }

    private void CheckHealth()
    {
        if (currHealth > maxHealth) currHealth = maxHealth;
        else if (currHealth <= maxHealth / 2.0f) Debug.Log("Less than 50% health for the " + robot.ToString() + " robot!");
        else if (currHealth < 0) currHealth = 0;
        //Debug.Log("Current health of the " + robot.ToString() + " robot: " + currHealth);
    }

    public void UserDamaged()
    {
        currHealth += robot == Robot.User ? -1 : 1;
        CheckHealth();
    }

    public void EnemyDamaged()
    {
        currHealth += robot == Robot.User ? 1 : -1;
        CheckHealth();
    }

    public Robot GetRobotType() { 
        return robot; 
    }
}
