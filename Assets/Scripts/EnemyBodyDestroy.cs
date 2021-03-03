using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBodyDestroy : MonoBehaviour
{
    public bool hr, hl, chest;

    public GameObject hr_, hl_, chest_, katana;
    public GameObject hr_re, hl_re, chest_re;

    private string hrStatus, hlStatus, chStatus;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        hrStatus = "Working";
        hlStatus = "Working";
        chStatus = "Working";
    }

    // Update is called once per frame
    void Update()
    {
        if(hr_.GetComponent<EnemyHand_Health>().getHealth() == 0)
        {
            hr = false;
        }
        if (!hr)
        {
            katana.transform.localScale = new Vector3(0, 0, 0);
            destroySetup(hr_, hr_re);
            hr = true;
            hrStatus = "Destroyed";
            anim.SetBool("RHand", false);
            anim.SetTrigger("Stagger");
        }

        if(hl_.GetComponent<EnemyHand_Health>().getHealth() == 0)
        {
            hl = false;
        }
        if (!hl)
        {
            destroySetup(hl_, hl_re);
            hl = true;
            hlStatus = "Destroyed";
            anim.SetTrigger("Stagger");
        }
    }
    public void destroySetup(GameObject pre, GameObject post)
    {
        pre.transform.localScale = new Vector3(0, 0, 0);
        post.SetActive(true);
        post.transform.parent = GameObject.Find("DestroyedParent").transform;
    }

    public string getRightStatus()
    {
        return hrStatus;
    }
    public string getLeftStatus()
    {
        return hlStatus;
    }
}
