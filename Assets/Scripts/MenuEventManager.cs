using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEventManager : MonoBehaviour
{
    public GameObject platform, glass, hand, track;

    Animator platformAnim, glassAnim, handAnim, trackAnim;


    // Start is called before the first frame update
    void Start()
    {
        platformAnim = platform.GetComponent<Animator>();
        glassAnim = glass.GetComponent<Animator>();
        handAnim = hand.GetComponent<Animator>();
        trackAnim = track.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {/*
        if (platformAnim.GetCurrentAnimatorStateInfo(1).IsName("PlatformMove"))
        {
            gameObject.transform.parent = null;
        }
        */
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "PlatformTrigger")
        {
            Debug.Log("PlatformButton");
            //Move platform forwards
            gameObject.transform.parent = platform.transform;
            other.gameObject.SetActive(false);
            platformAnim.SetBool("Move", true);
        }

        if(other.gameObject.name == "GlassTrigger")
        {
            Debug.Log("GlassLift");
            glassAnim.SetBool("Lift", true);
        }

        if(other.gameObject.name == "HandTrigger")
        {
            handAnim.SetBool("Place", true);
        }

        if(other.gameObject.name == "DoorTrigger")
        {
            platformAnim.SetBool("Open", true);
            gameObject.transform.parent = null;
        }

        if (other.gameObject.name == "FinalTrigger")
        {
            glassAnim.SetBool("Drop", true);
            platformAnim.SetBool("Back", true);
            trackAnim.SetBool("Retract", true);
        }

    }

}
