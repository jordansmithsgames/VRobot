using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationController : MonoBehaviour
{
    [SerializeField] GameObject userRobot, controller, controllerInit;
    [SerializeField] float walkingSpeed = 1.0f;
    private string initParent, controllerName;
    private bool inBounds;

    private void Start()
    {
        initParent = controller.transform.parent.name;
        controllerName = controller.name;
    }

    private void Update()
    {
        //if (!controller) controller = GameObject.Find(controllerName);
        if (inBounds)
        {
            float offset = controller.transform.position.y - controllerInit.transform.position.y;
            //Debug.Log("Now: " + controller.transform.position.y + ", Then: " + controllerInit.transform.position.y);
            Debug.Log(offset);
            userRobot.transform.Translate(-offset * walkingSpeed, 0, 0);
        }
        //else if (controller.transform.parent.name == initParent) ResetController();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == controller)
        {
            inBounds = true;
            ColorController(Color.red);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == controller)
        {
            //if (offset != 0) userRobot.transform.Translate(0, 0, offset * walkingSpeed);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == controller)
        {
            inBounds = false;
            ColorController(Color.blue);
        }
    }

    private void ResetController()
    {
        controller.transform.localPosition = controllerInit.transform.position;
        ColorController(Color.red);
    }

    private void ColorController(Color color)
    {
        controller.GetComponent<MeshRenderer>().material.color = color;
    }
}
