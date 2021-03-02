using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyMovement : MonoBehaviour
{
    public float playerSpeed;
    public float walkSpeed = 1f;
    public float mouseSensitivity = 2f;
    private bool isMoving = false;
    private float yRot;

    private bool drawn = false;

    private Animator anim;
    private Rigidbody rigidBody;

    // Use this for initialization
    void Start()
    {

        playerSpeed = walkSpeed;
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isMoving = false;
        /*
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed);
            rigidBody.velocity += transform.right * Input.GetAxisRaw("Horizontal") * playerSpeed;
            isMoving = true;
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed);
            rigidBody.velocity += transform.forward * Input.GetAxisRaw("Vertical") * playerSpeed;
            isMoving = true;
        }
        */
        if (Keyboard.current.upArrowKey.isPressed)
        {
            rigidBody.velocity += transform.forward * playerSpeed;
            isMoving = true;
        }
        else
        {
            rigidBody.velocity = new Vector3(0, 0, 0);
        }

        if(Keyboard.current.leftArrowKey.isPressed)
        {
            rigidBody.velocity += transform.right * playerSpeed;
            isMoving = true;
        }
        else
        {
            rigidBody.velocity = new Vector3(0,0,0);
        }

        if(Keyboard.current.pKey.isPressed && drawn == false)
        {
            anim.SetTrigger("Attack");
        }
        else if (Keyboard.current.pKey.isPressed && drawn == true)
        {
            anim.SetTrigger("SwordAttack");
        }
        else if (Keyboard.current.oKey.isPressed && drawn == true)
        {
            anim.SetTrigger("SwordAttack_2");
        }

        if (Keyboard.current.dKey.isPressed)
        {
            anim.SetTrigger("Draw");
            drawn = true;
        }

        if (Keyboard.current.sKey.isPressed && drawn == true)
        {
            anim.SetTrigger("Stagger_Sword");
        }
        else if(Keyboard.current.sKey.isPressed && drawn == false)
        {
            anim.SetTrigger("Stagger");
        }

        if (!drawn)
        {
            anim.SetBool("Walk", isMoving);
        }
        else if (drawn)
        {
            anim.SetBool("Walk_Sword", isMoving);
        }
        

    }
}