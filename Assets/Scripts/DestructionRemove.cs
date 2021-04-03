using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionRemove : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay = 15f;

    float countdown;
    public bool hit;
    bool removed = false;
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        
            countdown -= Time.deltaTime;
            if (countdown <= 0f && removed == false)
            {
                Destroy(this.gameObject);
                removed = true;
            }    
    }
}
