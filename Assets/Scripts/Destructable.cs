using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject particlesLarge;
    public GameObject destructionHandler;
    DestructionQueue DQ;

    // Start is called before the first frame update
    void Start()
    {
        DQ = destructionHandler.gameObject.GetComponent<DestructionQueue>();
    }

    // Update is called once per frame
    void Update()
    {   
        Debug.Log("Piece Queue count is: " + DQ.pieceCount.Count);
        Debug.Log("Particle Count is: " + DQ.particleCount.Count);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destructable"))
        {
            Debug.Log("Hit");
            GameObject piece;
            GameObject particle;

            piece = collision.gameObject;
            
         
            //Check if object has already been hit
            if (piece.GetComponent<Rigidbody>().isKinematic == true)
            {
                particle = Instantiate(particlesLarge, piece.transform.position, piece.transform.rotation);
                queueHandler(piece, particle);
            }
         
            // Make objects move
            piece.GetComponent<Rigidbody>().useGravity = true;
            piece.GetComponent<Rigidbody>().isKinematic = false;
            //piece.AddComponent<DestructionRemove>();
        }
    }

    public void queueHandler(GameObject destructablePiece, GameObject particles)
    {
        GameObject pieceObject = destructablePiece;
        GameObject particleObject = particles;

        DQ.pieceCount.Enqueue(pieceObject);
        DQ.particleCount.Enqueue(particleObject);

        //removes object or particle if there are more than the max 
        if (DQ.pieceCount.Count > DQ.pieceCountMax)
        {
            Destroy((GameObject)DQ.pieceCount.Dequeue());
        }
        if (DQ.particleCount.Count > DQ.particleCountMax)
        {
            Destroy((GameObject)DQ.particleCount.Dequeue());
        }
    }
}
