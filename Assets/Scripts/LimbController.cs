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

    private void Update()
    {
        if (!far)  target.transform.position = controller.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains(tag))
        {
            far = false;
            controller = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains(tag))
        {
            far = true;
            controller = null;
        }
    }
}
