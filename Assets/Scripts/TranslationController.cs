using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationController : MonoBehaviour
{
    [SerializeField] GameObject userRobot, target;//, rigController;
    [SerializeField] float walkingSpeed = 1.0f;
    private bool inBounds;
    private Vector3 initPos;

    private void Start()
    {
        initPos = target.transform.position;
    }

    private void Update()
    {
        if (inBounds)
        {
            float offset = target.transform.position.y - initPos.y;
            Debug.Log("Offset: " + offset);
            userRobot.transform.Translate(-offset * walkingSpeed, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target) inBounds = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target) inBounds = false;
    }
}
