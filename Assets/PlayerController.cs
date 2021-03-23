using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    /*
    public float speed;
    public XRNode inputSource;
    private Vector2 inputAxis;
    private CharacterController character;

    private void Start()
    {
        character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(inputAxis.x, 0, inputAxis.y);

        character.Move(direction * Time.fixedDeltaTime * speed);
    }
    */

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("IgnoreCollision"))
            Physics.IgnoreCollision(this.GetComponent<Collider>(), collision.collider);
    }
}
