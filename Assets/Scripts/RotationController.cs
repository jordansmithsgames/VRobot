using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField] GameObject userRobot, rigController, rigControllerInit;
    [SerializeField] float rotationSpeed = 15.0f;
    private string initParent, rigControllerName;
    private bool inBounds;

    private void Start()
    {
        initParent = rigController.transform.parent.name;
        rigControllerName = rigController.name;
    }

    private void Update()
    {
        if (inBounds)
        {
            float offset = rigController.transform.position.x - rigControllerInit.transform.position.x;
            userRobot.transform.Rotate(0, -offset * rotationSpeed, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == rigController)
        {
            inBounds = true;
            ColorController(Color.red);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == rigController)
        {
            inBounds = false;
            ColorController(Color.blue);
        }
    }

    private void ResetController()
    {
        rigController.transform.position = rigControllerInit.transform.position;
        ColorController(Color.red);
    }

    private void ColorController(Color color)
    {
        rigController.GetComponent<MeshRenderer>().material.color = color;
    }
}
