using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("IgnoreCollision"))
            Physics.IgnoreCollision(this.GetComponent<Collider>(), collision.collider);
        else Debug.Log(collision.gameObject.name);
    }
}
