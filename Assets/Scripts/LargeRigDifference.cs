﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeRigDifference : MonoBehaviour
{ 
    //Target IK
    public GameObject largeLArmTarget;
    public GameObject largeRArmTarget;
    public GameObject largeLLegTarget;
    public GameObject largeRLegTarget;

    //Controlling IK
    public GameObject smallLArmTarget;
    public GameObject smallRArmTarget;
    public GameObject smallLLegTarget;
    public GameObject smallRLegTarget;

    //Robot movement speed
    public int speed = 4;

    void Update()
    {
        largeLArmTarget.transform.localPosition = Vector3.Lerp(largeLArmTarget.transform.localPosition, smallLArmTarget.transform.localPosition, Time.deltaTime * speed);
        largeRArmTarget.transform.localPosition = Vector3.Lerp(largeRArmTarget.transform.localPosition, smallRArmTarget.transform.localPosition, Time.deltaTime * speed);
        largeLLegTarget.transform.localPosition = Vector3.Lerp(largeLLegTarget.transform.localPosition, smallLLegTarget.transform.localPosition, Time.deltaTime * speed);
        largeRLegTarget.transform.localPosition = Vector3.Lerp(largeRLegTarget.transform.localPosition, smallRLegTarget.transform.localPosition, Time.deltaTime * speed);

        largeLArmTarget.transform.localRotation = Quaternion.Slerp(largeLArmTarget.transform.localRotation, smallLArmTarget.transform.localRotation, Time.deltaTime * speed);
        largeRArmTarget.transform.localRotation = Quaternion.Slerp(largeRArmTarget.transform.localRotation, smallRArmTarget.transform.localRotation, Time.deltaTime * speed);
        largeLLegTarget.transform.localRotation = Quaternion.Slerp(largeLLegTarget.transform.localRotation, smallLLegTarget.transform.localRotation, Time.deltaTime * speed);
        largeRLegTarget.transform.localRotation = Quaternion.Slerp(largeRLegTarget.transform.localRotation, smallRLegTarget.transform.localRotation, Time.deltaTime * speed);
    }
}