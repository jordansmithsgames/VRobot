using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegController : MonoBehaviour
{
    [SerializeField] GameObject controller;
    public bool grabbing;
    private void Update()
    {
        if (grabbing)
        {
            this.transform.position = controller.transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == controller)
        {
            HandPresence hand = controller.transform.GetChild(0).GetComponent<HandPresence>();
            grabbing = hand.grabbing;
        }
    }
}
