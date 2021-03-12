using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[System.Serializable]

public class VRRigMap
{
    public Transform controllerTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void Map()
    {
        rigTarget.position = controllerTarget.TransformPoint(trackingPositionOffset);
        rigTarget.rotation = controllerTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}

public class VRRigConnector : MonoBehaviour
{
    public VRRigMap head;
    public VRRigMap leftControl;
    public VRRigMap rightControl;

    public Transform headConstraint;
    public Vector3 headBodyOffset;
    public float turnSmoothness;

    // Start is called before the first frame update
    void Start()
    {
        headBodyOffset = transform.position - headConstraint.position;
    }

    private void Update()
    {
/*        if (PhotonNetwork.IsMasterClient)
        {*/
            Debug.Log("Tracking player 1!");
            transform.position = headConstraint.position;
            transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized, Time.deltaTime * turnSmoothness);

            head.Map();
            leftControl.Map();
            rightControl.Map();
/*        }
        else Debug.Log("Tracking player 2!");*/
    }
}
