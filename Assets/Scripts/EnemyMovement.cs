﻿using System.Collections;
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
    public float MaxDist; //Distance to start attacking
    public float MinDist; //How far before starting to move
    private bool isMoving = false;

    public float health, criticalHealth;

    public bool destroyed = true; //Both arms destroyed?
    bool defeated = false;

    private bool drawn = false; //Is weapon drawn?

    public bool dealDamage;

    private Animator anim;
    private Rigidbody rigidBody;

    public GameObject mainEnemy;

    private GameObject PlayerRobot;

    public Material[] healthState1 = new Material[7];
    public Material[] healthState2 = new Material[7];

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
            if (Vector3.Distance(transform.position, PlayerRobot.transform.position) >= MinDist && Vector3.Distance(transform.position, PlayerRobot.transform.position) <= 130)
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

        if (health <= criticalHealth && gameObject.GetComponent<EnemyBodyDestroy>().getRightStatus() && !drawn)
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

        if(health <= 65 && health > 25)
        {
            changeMats(healthState1);
        }

        if(health <= 25)
        {
            changeMats(healthState2);
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

        if(health <= 0 && !defeated)
        {
            anim.SetTrigger("Defeat");
            defeated = true;

        }
    }

    public void changeMats(Material[] healthChange)
    {

        for(int i = 0; i <8; i++)
        {
            GameObject.Find("RobotMesh").GetComponent<Renderer>().materials = healthChange;
        }
    }
}