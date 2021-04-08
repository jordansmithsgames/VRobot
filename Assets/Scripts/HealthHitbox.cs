using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHitbox : MonoBehaviour
{
    private HealthManager hm;
    private Robot robot;

    private void Start()
    {
        hm = transform.parent.GetComponent<HealthManager>();
        robot = hm.GetRobotType();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (robot == Robot.User && !other.CompareTag("EnemyRobot")) Physics.IgnoreCollision(other, this.GetComponent<Collider>());
        else if (robot == Robot.Enemy && !other.CompareTag("UserRobot")) Physics.IgnoreCollision(other, this.GetComponent<Collider>());
        else
        {
            //Debug.Log(other.gameObject.name);
            hm.TakeDamage();
        }
    }
}
