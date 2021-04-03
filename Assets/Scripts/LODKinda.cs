using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LODKinda : MonoBehaviour
{
    public GameObject unfractured;
    public GameObject fractured;
    public GameObject brokenState;
    public GameObject user;
    public float distance;
    public bool hit;
    public float currentCount;

    float startCount;
    List<GameObject> childrenCount = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //startCount = childrenCounter(fractured.transform);
        childrenCounter(fractured.transform, 0);
        startCount = childrenCount.Count;
        currentCount = startCount;
        
        fractured.SetActive(false);
        brokenState.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("startcount is  " + startCount);
        
        // if user robot is close to object, show fractured building and hide unfractured
        if (Vector3.Distance(user.transform.position, gameObject.transform.position) < distance)
        {
            if (unfractured) unfractured.SetActive(false);            
            if (fractured) fractured.SetActive(true);

            //if Destructable script marks hit boolean as true, destroy unfractured building
            if (hit == true)
            {
                Destroy(unfractured);
                unfractured = null;
            }
        }

        // if user is no longer close to building and never touched it, bring back unfractured building
        if (Vector3.Distance(user.transform.position, gameObject.transform.position) > distance && hit != true)
        {
            if (unfractured) unfractured.SetActive(true);            
            if (fractured) fractured.SetActive(false);
        }

        // if current count is less than 50 % the original, let the building fall down completely
        if (currentCount < (startCount - 100))
        {
            Debug.Log("currentCount is " + currentCount);
            for (int i = 0; i < childrenCount.Count; i++)
            {
                // check if it actually has rigidbody, if so make it fall
                if (childrenCount[i].GetComponent<Rigidbody>() != null)
                {
                    childrenCount[i].GetComponent<Rigidbody>().isKinematic = false;
                    childrenCount[i].GetComponent<Rigidbody>().useGravity = true;
                }
            }
        }
    }

    private void childrenCounter(Transform parent, int level)
    {
        if (level != 0) childrenCount.Add(parent.gameObject);
        foreach (Transform child in parent)
        {
            if (child.childCount == 0) childrenCount.Add(child.gameObject);
            else if (child.childCount > 0) childrenCounter(child, level+1);
        }
    }
}
