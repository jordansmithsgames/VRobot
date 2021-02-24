using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
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
        Debug.Log("Hit");
        GameObject piece;
        piece = collision.gameObject;
        piece.GetComponent<Rigidbody>().useGravity = true;
        piece.GetComponent<Rigidbody>().isKinematic = false;
        
    }
}
