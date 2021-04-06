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
    public float MoveSpeed = 1f;
    public float MaxDist = 10;
    public float MinDist = 5;
    private bool isMoving = false;

    public int health = 100;

    public bool destroyed = true; //Both arms destroyed?

    private bool drawn = false; //Is weapon drawn?

    public bool dealDamage;

    private Animator anim;
    private Rigidbody rigidBody;

    public GameObject mainEnemy;

    private GameObject PlayerRobot;

    // Use this for initialization
    void Start()
    {
        PlayerRobot = GameObject.Find("User Robot");

        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(PlayerRobot.transform);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("Walk") || anim.GetCurrentAnimatorStateInfo(0).IsName("Walk_Sword") || anim.GetCurrentAnimatorStateInfo(0).IsName("Idle_Sword"))
        {
            if (Vector3.Distance(transform.position, PlayerRobot.transform.position) >= MinDist && Vector3.Distance(transform.position, PlayerRobot.transform.position) <= 100)
            {
                isMoving = true;
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            }
            else
            {
                isMoving = false;
            }
        }

        if (Vector3.Distance(transform.position, PlayerRobot.transform.position) < MaxDist && !drawn)
        {
            anim.SetTrigger("Attack");
        }
        else if (Vector3.Distance(transform.position, PlayerRobot.transform.position) < (MaxDist) && Vector3.Distance(transform.position, PlayerRobot.transform.position) > 4 && drawn)
        {
            anim.SetTrigger("SwordAttack");
        }
        else if (Vector3.Distance(transform.position, PlayerRobot.transform.position) < (4) && drawn)
        {
            anim.SetTrigger("SwordAttack_2");
        }

        if (health <= 50 && gameObject.GetComponent<EnemyBodyDestroy>().getRightStatus() && !drawn)
        {
            anim.SetTrigger("Draw");
            drawn = true;
        }

        if (dealDamage)
        {
            health -= 10;
            if (!drawn)
            {
                anim.SetTrigger("Stagger");
                isMoving = false;
            }
            else anim.SetTrigger("Stagger_Sword"); isMoving = false;

            dealDamage = !dealDamage;
        }

        /*
        if (Keyboard.current.pKey.isPressed && drawn == false) { anim.SetTrigger("Attack"); } //Basic punch attack
        else if (Keyboard.current.pKey.isPressed && drawn == true) { anim.SetTrigger("SwordAttack"); } //Sword attack if weapon drawn
        else if (Keyboard.current.oKey.isPressed && drawn == true) { anim.SetTrigger("SwordAttack_2"); } //Alternative sword attack

        if (Keyboard.current.dKey.isPressed && gameObject.GetComponent<EnemyBodyDestroy>().getRightStatus()) //Draw weapon
        {
            anim.SetTrigger("Draw");
            drawn = true;
        }

        if (Keyboard.current.sKey.isPressed && drawn == true) { anim.SetTrigger("Stagger_Sword"); } //Stagger with sword
        else if (Keyboard.current.sKey.isPressed && drawn == false) { anim.SetTrigger("Stagger"); } //Stagger without sword
        */

        if (!gameObject.GetComponent<EnemyBodyDestroy>().getRightStatus()) { drawn = false; } //If arm breaks, reset to sheathed weapon
        if (!drawn) { anim.SetBool("Walk", isMoving); } //Walk regular
        else if (drawn) { anim.SetBool("Walk_Sword", isMoving); } //Walk with sword

        if (!gameObject.GetComponent<EnemyBodyDestroy>().getRightStatus() && !gameObject.GetComponent<EnemyBodyDestroy>().getLeftStatus() && destroyed)//Triggers defeat animation
        {
            anim.SetTrigger("Defeat");
            destroyed = false;
        }
    }
}