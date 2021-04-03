using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LODKinda : MonoBehaviour
{
    public GameObject unfractured;
    public GameObject fractured;
    public GameObject interior;
    public GameObject brokenState;
    public GameObject user;
    public float distance;
    public bool hit;

    int startCount;
    List<GameObject> childrenCount = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //startCount = childrenCounter(fractured.transform);
        childrenCounter(fractured.transform);
        Debug.Log("startcount is  " + childrenCount.Count);
        fractured.SetActive(false);
        interior.SetActive(false);
        brokenState.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int currentCount = fractured.transform.childCount;
        if (Vector3.Distance(user.transform.position, gameObject.transform.position) < distance)
        {
            unfractured.SetActive(false);
            interior.SetActive(true);
            fractured.SetActive(true);
            Debug.Log(hit);
            if (hit == true)
            {
                Destroy(unfractured);
                unfractured = null;
            }
        }

        if (Vector3.Distance(user.transform.position, gameObject.transform.position) > distance && hit != true)
        {
            unfractured.SetActive(true);
            interior.SetActive(false);
            fractured.SetActive(false);
        }

        if (currentCount < startCount)
        {
            foreach (Transform child in fractured.transform)
            {
                child.GetComponent<Rigidbody>().isKinematic = false;
                child.GetComponent<Rigidbody>().useGravity = true;
                ;
            }
            //Destroy(fractured);
            //Destroy(interior);
            brokenState.SetActive(true);
        }
    }

    private void childrenCounter(Transform parent)
    {
        childrenCount.Add(parent.gameObject);

        foreach (Transform child in parent)
        {
            if (child.childCount == 0)
            {
                childrenCount.Add(child.gameObject);
            }
            if (child.childCount > 0)
            {
                childrenCounter(child);
            }
        }
    }
}
