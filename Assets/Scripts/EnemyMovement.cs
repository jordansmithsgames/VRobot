using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


/* | Buttons for Animations |
 * | Up Arrow = Move        |
 * | D = draw weapon        |
 * | P = Attack             |
 * | O = Alternate Attack   |
 * | S = Stagger            |
 */

public class EnemyMovement : MonoBehaviour
{
    public float playerSpeed;
    public float walkSpeed = 1f;
    public float mouseSensitivity = 2f;
    private bool isMoving = false;

    public bool destroyed = true; //Both arms destroyed?

    private bool drawn = false; //Is weapon drawn?

    private Animator anim;
    private Rigidbody rigidBody;

    public GameObject mainEnemy;

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
        

        if (Keyboard.current.upArrowKey.isPressed) //Make enemy move forward
        {
            rigidBody.velocity += transform.forward * playerSpeed;
            isMoving = true;
        }
        else
        {
            rigidBody.velocity = new Vector3(0, 0, 0);
        }

        if(Keyboard.current.leftArrowKey.isPressed) //Make enemy move sideways
        {
            rigidBody.velocity += transform.right * playerSpeed;
            isMoving = true;
        }
        else
        {
            rigidBody.velocity = new Vector3(0,0,0);
        }

        if (Keyboard.current.pKey.isPressed && drawn == false) { anim.SetTrigger("Attack");} //Basic punch attack
        else if (Keyboard.current.pKey.isPressed && drawn == true){anim.SetTrigger("SwordAttack");} //Sword attack if weapon drawn
        else if (Keyboard.current.oKey.isPressed && drawn == true){anim.SetTrigger("SwordAttack_2");} //Alternative sword attack

        if(!mainEnemy.GetComponent<EnemyBodyDestroy>().getRightStatus()){drawn = false;} //If arm breaks, reset to sheathed weapon

        if (Keyboard.current.dKey.isPressed && mainEnemy.GetComponent<EnemyBodyDestroy>().getRightStatus()) //Draw weapon
        {
            anim.SetTrigger("Draw");
            drawn = true;
        }

        if (Keyboard.current.sKey.isPressed && drawn == true){anim.SetTrigger("Stagger_Sword");} //Stagger with sword
        else if(Keyboard.current.sKey.isPressed && drawn == false){anim.SetTrigger("Stagger");} //Stagger without sword

        if (!drawn){anim.SetBool("Walk", isMoving);} //Walk regular
        else if (drawn){anim.SetBool("Walk_Sword", isMoving);} //Walk with sword

        if(!mainEnemy.GetComponent<EnemyBodyDestroy>().getRightStatus() && !mainEnemy.GetComponent<EnemyBodyDestroy>().getLeftStatus() && destroyed)//Triggers defeat animation
        {
            anim.SetTrigger("Defeat");
            destroyed = false;
        }
        

    }
}