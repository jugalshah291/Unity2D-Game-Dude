using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // Start is called before the first frame update
    private Boy b; 

    void Start()
    {
        b = gameObject.GetComponentInParent<Boy>();
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        b.grounded = true;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        b.grounded = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        b.grounded = false;
    }
}
