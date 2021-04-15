using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHitbox : MonoBehaviour
{
    private static float cooldown = 5f;
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
            if (robot == Robot.User && !other.CompareTag("EnemyRobot")) Physics.IgnoreCollision(other, this.GetComponent<Collider>());
            else if (robot == Robot.Enemy && !other.CompareTag("UserRobot")) Physics.IgnoreCollision(other, this.GetComponent<Collider>());
            else
            {
                //Debug.Log(other.gameObject.name);
                hm.TakeDamage();
                timer = cooldown;
            }
        }
    }
}
