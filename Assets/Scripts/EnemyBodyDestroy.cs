using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBodyDestroy : MonoBehaviour
{
    public bool handRight, handLeft; //Debug to make hands explode (Not necessary in build)

    public GameObject hrOriginal, hlOriginal, katana; //Base model of Hands and Katana
    public GameObject hrDestroyed, hlDestroyed; //Replacement for destroyed hands

    private bool hrStatus, hlStatus; //To check if hands are destroyed or not

    public Animator anim;

    public GameObject L_sparks, R_sparks;

    // Start is called before the first frame update
    void Start()
    {
        hrStatus = true;
        hlStatus = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(hrOriginal.GetComponent<EnemyHand_Health>().getHealth() == 0 && hrStatus) //Hand health = 0 + Not Destroyed
        {
            handRight = false;
        }
        if (!handRight)
        {
            katana.transform.localScale = new Vector3(0, 0, 0);
            destroySetup(hrOriginal, hrDestroyed);
            handRight = true;
            hrStatus = false;
            anim.SetBool("RHand", false); //To pull animation state back from drawn weapon
            R_sparks.SetActive(true);
            anim.SetTrigger("Stagger");
        }

        if(hlOriginal.GetComponent<EnemyHand_Health>().getHealth() == 0 && hlStatus)
        {
            handLeft = false;
        }
        if (!handLeft)
        {
            destroySetup(hlOriginal, hlDestroyed);
            handLeft = true;
            hlStatus = false;
            L_sparks.SetActive(true);
            anim.SetTrigger("Stagger");
        }
    }
    public void destroySetup(GameObject pre, GameObject post) //Replace hand with breaking hand
    {
        pre.transform.localScale = new Vector3(0, 0, 0);
        post.SetActive(true);
        post.transform.parent = GameObject.Find("DestroyedParent").transform; //Places destroyed hand pieces in World Space
    }

    public bool getRightStatus()
    {
        return hrStatus;
    }
    public bool getLeftStatus()
    {
        return hlStatus;
    }
}
