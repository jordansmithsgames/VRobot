using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbController : MonoBehaviour
{
    public GameObject target;
    public GameObject visual;

    void Start()
    {
        // Initialize to be at same location
        target.transform.position = transform.position;
        visual.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == visual)
        {
            Debug.Log("Controller in the control zone!");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == visual)
        {
            target.transform.position = visual.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == visual)
        {
            Debug.Log("Controller has left the control zone!");
        }
    }
}
