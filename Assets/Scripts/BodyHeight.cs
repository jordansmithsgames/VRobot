using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyHeight : MonoBehaviour
{
    public GameObject leftLegTarget;
    public GameObject rightLegTarget;
    public GameObject body;
    public float desiredHeight;
    public LayerMask terrainLayer;

    Vector3 centerMag;

    float heightDifference;
    float originalBodyHeight;
    float terrainH;

    // Start is called before the first frame update
    void Start()
    {
        originalBodyHeight = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {      
        centerMag = leftLegTarget.transform.position + rightLegTarget.transform.position;

        heightDifference = originalBodyHeight + centerMag.y;

        //Debug.Log("Feet Avg height " + centerMag.y);

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, heightDifference/10 + terrainHeight(), gameObject.transform.position.z);
    }

    public float terrainHeight()
    {
        Ray ray = new Ray(gameObject.transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, terrainLayer.value))
        {
            terrainH = hit.point.y;
        }
        Debug.Log("TerrainHeight is: " + terrainH);
        Debug.DrawRay(gameObject.transform.position, Vector3.down, Color.white);
        return terrainH;
    }
}
