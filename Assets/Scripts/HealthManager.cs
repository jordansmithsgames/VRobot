using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Robot { User, Enemy}

public abstract class HealthManager : MonoBehaviour
{
    public Robot robot;
    public float maxHealth = 150f;
    public float currHealth;

    public void CheckHealth()
    {
        if (currHealth > maxHealth) currHealth = maxHealth;
        else if (currHealth < 0) currHealth = 0;
        Debug.Log("Current health of the " + robot.ToString() + " robot: " + currHealth);
    }

    public Robot GetRobotType()
    {
        return robot;
    }

    //public abstract void HitRobot();

    public abstract void TakeDamage(float damage);
}
