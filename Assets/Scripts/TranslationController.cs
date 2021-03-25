using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationController : MonoBehaviour
{
    public GameObject controller, userRobot;
    public float walkingSpeed = 1.0f;
    private Vector3 initPosition;

    void Start()
    {
        initPosition = controller.transform.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == controller)
        {
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
                controller.GetComponent<MeshRenderer>().material.color = Color.red;

                float offset = controller.transform.localPosition.y - initPosition.y;
                // Debug.Log("Now: " + controller.transform.localPosition.y + ", Then: " + initPosition.y);
                if (offset != 0) userRobot.transform.Translate(0, 0, offset * walkingSpeed);
            }
            else
            {
                controller.GetComponent<MeshRenderer>().material.color = Color.blue;
                controller.transform.position = initPosition;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == controller)
        {
            other.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
            controller.transform.position = initPosition;
            Debug.Log("Controller has left the control zone!");
        }
    }
}
