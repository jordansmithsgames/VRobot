using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyHeight : MonoBehaviour
{
    public GameObject leftLegTarget;
    public GameObject rightLegTarget;
    public GameObject body;
    public float height;
    public float bobSmoothness = 10;
    public LayerMask terrainLayer;

    Vector3 centerMag;

    float bobValue;
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

        bobValue = (originalBodyHeight + centerMag.y) / bobSmoothness;

        //Debug.Log("Feet Avg height " + centerMag.y);

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, (bobValue + terrainHeight()) - height, gameObject.transform.position.z);
    }

    public float terrainHeight()
    {
        Ray ray = new Ray(gameObject.transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, terrainLayer.value))
        {
            terrainH = hit.point.y;
        }
        //Debug.Log("TerrainHeight is: " + terrainH);
        Debug.DrawRay(gameObject.transform.position, Vector3.down, Color.white);
        return terrainH * 2;
    }
}
