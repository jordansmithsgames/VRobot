using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject particles;
    // Start is called before the first frame update
    void Start()
    {
        particles.AddComponent<DestructionRemove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destructable"))
        {
            Debug.Log("Hit");
            GameObject piece;
            piece = collision.gameObject;
            
            //Check if object has already been hit
            if (piece.GetComponent<Rigidbody>().isKinematic == true)
            {
                Instantiate(particles, transform.position, transform.rotation);
            }

            // Make objects move
            piece.GetComponent<Rigidbody>().useGravity = true;
            piece.GetComponent<Rigidbody>().isKinematic = false;
            piece.AddComponent<DestructionRemove>();
        }
    }
}
