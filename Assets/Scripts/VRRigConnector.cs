using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[System.Serializable]

public class VRRigMap
{
    public LimbController limbController;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void Map()
    {
        limbController.target.transform.position = limbController.controller.transform.TransformPoint(trackingPositionOffset);
        limbController.target.transform.rotation = limbController.controller.transform.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}

public class VRRigConnector : MonoBehaviour
{
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
        //transform.position = headConstraint.position;
        //transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized, Time.deltaTime * turnSmoothness);*/

        if (!leftControl.limbController.far) leftControl.Map();
        if (!rightControl.limbController.far) rightControl.Map();
    }
}
