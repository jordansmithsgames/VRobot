using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject particlesLarge;

    public int pieceCountMax = 15;

    Queue pieceCount = new Queue();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        Debug.Log("Piece Queue count is: " + pieceCount.Count);
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
                Instantiate(particlesLarge, piece.transform.position, piece.transform.rotation);
            }

            queueHandler(piece);

            // Make objects move
            piece.GetComponent<Rigidbody>().useGravity = true;
            piece.GetComponent<Rigidbody>().isKinematic = false;
            //piece.AddComponent<DestructionRemove>();
        }
    }

    public void queueHandler(GameObject destructablePiece)
    {
        GameObject pieceObject = destructablePiece;

        pieceCount.Enqueue(pieceObject);

        //makes sure theres never more than 15 destruction particle effects in the scene
        if (pieceCount.Count > pieceCountMax)
        {
            Destroy((GameObject)pieceCount.Dequeue());
        }
    }
}
