using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationController : MonoBehaviour
{
    [SerializeField] GameObject userRobot, rigController, rigControllerInit;
    [SerializeField] float walkingSpeed = 1.0f;
    private string initParent, rigControllerName;
    private bool inBounds;

    private void Start()
    {
        initParent = rigController.transform.parent.name;
        rigControllerName = rigController.name;
    }

    private void Update()
    {
        if (!rigController) rigController = GameObject.Find(rigControllerName);
        if (inBounds)
        {
            float offset = rigController.transform.position.y - rigControllerInit.transform.position.y;
            //Debug.Log("Now: " + rigController.transform.position.y + ", Then: " + rigControllerInit.transform.position.y);
            Debug.Log(offset);
            userRobot.transform.Translate(-offset * walkingSpeed, 0, 0);
        }
        else if (rigController.transform.parent.name == initParent) ResetController();
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
