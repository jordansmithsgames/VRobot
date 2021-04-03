using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RotationController : MonoBehaviour
{
    [SerializeField] PhotonView photonView;
    [SerializeField] GameObject userRobot, target;
    [SerializeField] float rotationSpeed = 15f;
    private bool inBounds;
    private GameObject leftHand;
    private Vector3 initPos;

    private void Start()
    {
        initPos = target.transform.localPosition;
    }

    private void Update()
    {
        if (inBounds)
        {
            Debug.Log("Responding to player input for translation!");
            target.transform.position = leftHand.transform.position;
            float offset = target.transform.localPosition.z - initPos.z;
            Debug.Log("Rotation Offset: " + offset);
            userRobot.transform.Rotate(0, offset * rotationSpeed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("LeftHand"))
        {
            photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
            inBounds = true;
            leftHand = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("LeftHand"))
        {
            inBounds = false;
            leftHand = null;
        }
    }
}
