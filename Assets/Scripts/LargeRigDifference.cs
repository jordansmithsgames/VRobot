using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeRigDifference : MonoBehaviour
{
    public GameObject largeTargetL;
    public GameObject largeTargetR;

    public GameObject smallTargetL;
    public GameObject smallTargetR;

    void Update()
    {
        largeTargetL.transform.localPosition = smallTargetL.transform.localPosition;
        largeTargetR.transform.localPosition = smallTargetR.transform.localPosition;
        
        largeTargetL.transform.localRotation = smallTargetL.transform.localRotation;
        largeTargetR.transform.localRotation = smallTargetR.transform.localRotation;
    }
}