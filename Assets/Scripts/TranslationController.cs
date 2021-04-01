using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationController : MonoBehaviour
{
    [SerializeField] GameObject userRobot, target;
    [SerializeField] float walkingSpeed = 1.0f;
    private bool inBounds;
    private GameObject rightHand;
    private Vector3 initPos;

    private void Start()
    {
        initPos = target.transform.localPosition;
    }

    private void Update()
    {
        if (inBounds)
        {
            target.transform.position = rightHand.transform.position;
            float offset = target.transform.localPosition.y - initPos.y;
            // Debug.Log("Offset: " + offset);
            userRobot.transform.Translate(-offset * walkingSpeed * Time.deltaTime, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("RightHand"))
        {
            inBounds = true;
            rightHand = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("RightHand"))
        {
            inBounds = false;
            rightHand = null;
        }
    }
}
