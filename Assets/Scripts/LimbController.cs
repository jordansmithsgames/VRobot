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
        if (other.gameObject.CompareTag(tag)) far = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(tag))
        {
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
        if (other.gameObject.CompareTag(tag)) far = true;
    }
}
