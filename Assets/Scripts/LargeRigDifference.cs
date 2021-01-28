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

    void Start()
    {
        oldPosL = smallTargetL.transform.position;
        oldPosR = smallTargetR.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(smallTargetR.transform.position);

        //Store new data
        newPosL = smallTargetL.transform.localPosition;
        newPosR = smallTargetR.transform.localPosition;
      
        //Calculate difference
        differenceL = newPosL - oldPosL;
        differenceR = newPosR - oldPosR;
      
        //Apply Difference
        largeTargetL.transform.localPosition = differenceL;
        largeTargetR.transform.localPosition = differenceR;
        
        largeTargetL.transform.localRotation = smallTargetL.transform.localRotation;
        largeTargetR.transform.localRotation = smallTargetR.transform.localRotation;

        //Reassign old position
        oldPosL = smallTargetL.transform.position;
        oldPosR = smallTargetR.transform.position;
    }
}



//Rotation variables
//Quaternion oldRotateL;
//Quaternion oldRotateR;
//Quaternion newRotateL;
//Quaternion newRotateR;
//Quaternion rotDifferenceR;
//Quaternion rotDifferenceL;

//oldRotateL = smallTargetL.transform.rotation;
//oldRotateR = smallTargetR.transform.rotation;


//newRotateL = smallTargetL.transform.rotation;
//newRotateR = smallTargetR.transform.rotation;
//rotDifferenceL = newRotateL * Quaternion.Inverse(oldRotateL);
//rotDifferenceR = newRotateR * Quaternion.Inverse(oldRotateR);
//largeTargetL.transform.rotation = oldRotateL * rotDifferenceL;
//largeTargetR.transform.rotation = oldRotateR * rotDifferenceR;