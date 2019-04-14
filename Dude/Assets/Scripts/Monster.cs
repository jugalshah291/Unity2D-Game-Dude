using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    private Boy b;

    void Start()
    {
        b = GameObject.FindGameObjectWithTag("Player").GetComponent<Boy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {

            b.ReduceHealth(5);
            Sound.PlaySound("hit");
            //StartCoroutine(b.KnockBack(0.02f,100,b.transform.position));
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
