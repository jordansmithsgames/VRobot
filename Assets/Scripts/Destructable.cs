using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject particlesLarge;
    public GameObject destructionHandler;
    DestructionHandler DQ;

    // Start is called before the first frame update
    void Start()
    {
        DQ = destructionHandler.gameObject.GetComponent<DestructionHandler>();
    }

    // Update is called once per frame
    void Update()
    {   
        //Debug.Log("Piece Queue count is: " + DQ.pieceCount.Count);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destructable"))
        {
            //Debug.Log("Hit");
            GameObject piece;
            GameObject particle;
            piece = collision.gameObject;
            
         
            //Check if object has already been hit
            if (piece.GetComponent<Rigidbody>().isKinematic == true)
            {
                particle = Instantiate(particlesLarge, piece.transform.position, piece.transform.rotation);
                particle.AddComponent<DestructionRemove>();

                queueHandler(piece, particle);
            }
          
            // Make objects move
            piece.GetComponent<Rigidbody>().useGravity = true;
            piece.GetComponent<Rigidbody>().isKinematic = false;
            piece.transform.root.GetComponent<LODKinda>().hit = true;
        }

    }

    public void queueHandler(GameObject destructablePiece, GameObject particleEffect)
    {
        GameObject pieceObject = destructablePiece;
        GameObject particles = particleEffect;

        DQ.pieceCount.Enqueue(pieceObject);
        DQ.particleCount.Enqueue(particles);

        //makes sure theres never more than 15 destruction particle effects in the scene
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
