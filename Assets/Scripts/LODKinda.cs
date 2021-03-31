using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LODKinda : MonoBehaviour
{
    public GameObject unfractured;
    public GameObject fractured;
    public GameObject interior;
    public GameObject user;
    public float distance;

    public bool hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(hit);
        if (Vector3.Distance(user.transform.position, gameObject.transform.position) < distance)
        {
            Debug.Log(hit);
        }
    }
}
