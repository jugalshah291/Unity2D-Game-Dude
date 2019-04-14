using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public int hp = 2;
    private float shottime;
    public float starttime;
    public float shootrange;
    public float distance;

    public bool shootflag= false;
    public GameObject bullet;
    private GameObject player;
    private bool facingRight = false;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        shottime = starttime;

        
    }

    // Update is called once per frame
    void Update()
    {
        RangeCheck();

        if (shottime <= 0 && shootflag)
        {

            if (facingRight == false && player.transform.position.x >= transform.position.x)
            {
                Flip();
            }
            else if (facingRight == true && player.transform.position.x <= transform.position.x)
            {
                Flip();
            }

            Instantiate(bullet,transform.position,Quaternion.identity);
            shottime = starttime;

        }
        else {
            shottime -= Time.deltaTime;
        }


    }

    void RangeCheck() {

        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= shootrange) {

            shootflag = true;
        }
        if (distance > shootrange) {
            shootflag = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }
} 
