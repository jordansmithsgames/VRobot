using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkProcedural : MonoBehaviour
{
    float footSpace;
    public float speed = 1;
    [SerializeField] float stepDistance = 4;
    [SerializeField] float stepLength = 4;
    [SerializeField] float stepHeight = 1;
    float lerp;
    public GameObject body;

    [SerializeField] IkProcedural otherFoot;
    [SerializeField] Vector3 footOffset;

    Vector3 oldPosition, currentPosition, newPosition;
    Vector3 oldNormal, currentNormal, newNormal;

    public LayerMask terrainLayer = default;
    
    // Start is called before the first frame update
    void Start()
    {
        footSpace = transform.localPosition.x;
        currentPosition = newPosition = oldPosition = transform.position;
        currentNormal = newNormal = oldNormal = transform.up;
        lerp = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = currentPosition;
        transform.up = currentNormal;


        Ray ray = new Ray(body.transform.position + (body.transform.right * footSpace), Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit info, 10, terrainLayer.value))
        {
            if (Vector3.Distance(newPosition, info.point) > stepDistance && !otherFoot.IsMoving() && lerp >= 1)
            {
                lerp = 0;
                int direction = body.transform.InverseTransformPoint(info.point).z > body.transform.InverseTransformPoint(newPosition).z ? 1 : -1;
                newPosition = info.point + (body.transform.forward * stepLength * direction) + footOffset;
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
}
