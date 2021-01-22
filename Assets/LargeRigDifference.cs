using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeRigDifference : MonoBehaviour
{
    // Start is called before the first frame update

    //Public gameobjects
    public GameObject largeTargetL;
    public GameObject largeTargetR;

    public GameObject smallTargetL;
    public GameObject smallTargetR;

    //Position variables
    Vector3 differenceL;
    Vector3 differenceR;
    Vector3 oldPosL;
    Vector3 oldPosR;
    Vector3 newPosL;
    Vector3 newPosR;

    //Rotation variables
    Quaternion oldRotateL;
    Quaternion oldRotateR;
    Quaternion newRotateL;
    Quaternion newRotateR;
    Quaternion rotDifferenceR;
    Quaternion rotDifferenceL;

    void Start()
    {
        oldPosL = smallTargetL.transform.position;
        oldPosR = smallTargetR.transform.position;
        oldRotateL = smallTargetL.transform.rotation;
        oldRotateR = smallTargetR.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(smallTargetR.transform.position);

        //Store new data
        newPosL = smallTargetL.transform.position;
        newPosR = smallTargetR.transform.position;

        newRotateL = smallTargetL.transform.rotation;
        newRotateR = smallTargetR.transform.rotation;

        //Calculate difference
        differenceL = newPosL - oldPosL;
        differenceR = newPosR - oldPosR;

        rotDifferenceL = newRotateL * Quaternion.Inverse(oldRotateL);
        rotDifferenceR = newRotateR * Quaternion.Inverse(oldRotateR);

        //Apply Difference
        largeTargetL.transform.position += differenceL * 10;
        largeTargetR.transform.position += differenceR * 10;

        largeTargetL.transform.rotation = oldRotateL * rotDifferenceL;
        largeTargetR.transform.rotation = oldRotateR * rotDifferenceR;

        //Reassign old position
        oldPosL = smallTargetL.transform.position;
        oldPosR = smallTargetR.transform.position;
    }
}
