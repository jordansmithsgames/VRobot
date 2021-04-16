using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHitbox : MonoBehaviour
{
    private static float cooldown = 2.5f;
    private HealthManager hm;
    private Robot robot;
    private float timer;

    private void Start()
    {
        hm = transform.parent.GetComponent<HealthManager>();
        robot = hm.GetRobotType();
    }

    private void Update()
    {
        if (0 < timer && timer <= cooldown) timer -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (timer <= 0)
        {
            bool isUser = robot == Robot.User;
            bool isEnemy = robot == Robot.Enemy;
            bool otherUser = other.CompareTag("UserRobot");
            bool otherEnemy = other.CompareTag("EnemyRobot");


            if (isUser && !otherEnemy) Physics.IgnoreCollision(other, this.GetComponent<Collider>());
            else if (isEnemy && !otherUser) Physics.IgnoreCollision(other, this.GetComponent<Collider>());
            else if ((isUser && otherEnemy) || (isEnemy && otherUser))
            {
                float damage = 10;
                hm.TakeDamage(damage);
                timer = cooldown;
            }
        }
    }
}
