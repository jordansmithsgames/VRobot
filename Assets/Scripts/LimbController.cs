using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbController : MonoBehaviour
{
    enum Hand { RightHand, LeftHand}
    [SerializeField] Hand hand;
    public GameObject target, controller;
    public bool far;
    private string tag;

    void Start()
    {
        far = true;
        tag = hand == Hand.RightHand ? "RightHand" : "LeftHand";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains(tag)) far = false;
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name + " is touching the control zone!");
        if (other.gameObject.name.Contains(tag))
        {
            Debug.Log(other.gameObject.name + " is touching the control zone!");
            controller = other.gameObject;
            if (other.bounds.Contains(other.gameObject.transform.position))
            {
                far = false;
                target.transform.position = other.gameObject.transform.position;
            }
            else far = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains(tag)) far = true;
    }
}
