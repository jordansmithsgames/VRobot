﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkProcedural : MonoBehaviour
{
    float footSpace;
    float lerp;

    public Vector3 trackingRotationOffset;

    [SerializeField] float speed = 1;
    [SerializeField] float stepDistance = 4;
    [SerializeField] float stepLength = 4;
    [SerializeField] float stepHeight = 1;
    [SerializeField] float bodyHeight = 1;
    [SerializeField] GameObject body;
    [SerializeField] IkProcedural otherFoot;
    [SerializeField] Vector3 footOffset;
    [SerializeField] LayerMask terrainLayer = default;
    Vector3 oldPosition, currentPosition, newPosition;
    Vector3 oldNormal, currentNormal, newNormal;
   
    // Start is called before the first frame update
    void Start()
    {
        footSpace = transform.localPosition.z;
        currentPosition = newPosition = oldPosition = transform.position;
        currentNormal = newNormal = oldNormal = transform.up;
        lerp = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = currentPosition;
        transform.up = currentNormal;

        Map();

        Ray ray = new Ray(body.transform.position + (body.transform.forward * footSpace), Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit info, 50, terrainLayer.value))
        {
            // Remove this Distance function and detect only in local z direction
            if (Vector3.Distance(newPosition, info.point) > stepDistance && !otherFoot.IsMoving() && lerp >= 1)
            {
                lerp = 0;
                int direction = body.transform.InverseTransformPoint(info.point).x > body.transform.InverseTransformPoint(newPosition).x ? 1 : -1;
                newPosition = info.point - (body.transform.right * stepLength * direction) + footOffset;
                newNormal = info.normal;
            }           
        }

        if (lerp < 1)
        {
            Vector3 tempPosition = Vector3.Lerp(oldPosition, newPosition, lerp);
            tempPosition.y += Mathf.Sin(lerp * Mathf.PI) * stepHeight;

            currentPosition = tempPosition;
            currentNormal = Vector3.Lerp(oldNormal, newNormal, lerp);
            lerp += Time.deltaTime * speed;
        }
        else
        {
            oldPosition = newPosition;
            oldNormal = newNormal;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(newPosition, 0.5f);
    }

    public bool IsMoving()
    {
        return lerp < 1;
    }

    public void Map()
    {
        gameObject.transform.rotation = gameObject.transform.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}
