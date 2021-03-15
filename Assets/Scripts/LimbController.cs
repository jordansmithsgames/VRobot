using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbController : MonoBehaviour
{
    public GameObject controller;
    public GameObject target;
    public bool far;

    void Start()
    {
        // Initialize to be at same location
        //controller.transform.position = transform.position;
        //target.transform.position = transform.position;
        far = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == controller)
        {
            far = false;
            other.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            Debug.Log("Controller in the control zone!");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == controller)
        {
            if (other.bounds.Contains(controller.transform.position))
            {
                far = false;
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                target.transform.position = controller.transform.position;
            }
            else
            {
                far = true;
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == controller)
        {
            far = true;
            other.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
            Debug.Log("Controller has left the control zone!");
        }
    }
}
