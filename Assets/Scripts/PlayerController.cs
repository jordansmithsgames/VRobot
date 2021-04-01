using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("IgnoreCollision"))
        {
            //Debug.Log(collision.gameObject.name);
            Physics.IgnoreCollision(this.GetComponent<Collider>(), collision.collider);
        }
    }
}
