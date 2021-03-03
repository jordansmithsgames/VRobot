using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeRigDifference : MonoBehaviour
{ 
    //Robot rig IK targets
    public GameObject largeTargetL;
    public GameObject largeTargetR;

    //User rig IK targets
    public GameObject smallTargetL;
    public GameObject smallTargetR;

    //Robot movement speed
    public int speed = 4;

    void Update()
    {
        Vector3 posOneL = smallTargetL.transform.localPosition;
        Vector3 posOneR = smallTargetR.transform.localPosition;

        largeTargetL.transform.localPosition = Vector3.Lerp(largeTargetL.transform.localPosition, posOneL, Time.deltaTime * speed);
        largeTargetR.transform.localPosition = Vector3.Lerp(largeTargetR.transform.localPosition, posOneR, Time.deltaTime * speed);

        Quaternion rotOneL = smallTargetL.transform.localRotation;
        Quaternion rotOneR = smallTargetR.transform.localRotation;

        largeTargetL.transform.localRotation = Quaternion.Slerp(largeTargetL.transform.localRotation, rotOneL, Time.deltaTime * speed);
        largeTargetR.transform.localRotation = Quaternion.Slerp(largeTargetR.transform.localRotation, rotOneR, Time.deltaTime * speed);
    }
}