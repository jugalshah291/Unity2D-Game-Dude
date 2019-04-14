using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 speed;
    Rigidbody2D rb;
    private GameObject player;
    private GameObject boss;
    private GameObject enemy;
    public bool isfinal=true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("FinalBoss");
        enemy= GameObject.FindGameObjectWithTag("Enemy");
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed;

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            enemy.GetComponent<Enemy>().hp -= 1;
            if(enemy.GetComponent<Enemy>().hp <=0 )
            {
                Destroy(collision.gameObject);
            }


            Destroy(gameObject);
            
        }
        if (collision.gameObject.CompareTag("Monster"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
        if (collision.gameObject.CompareTag("FinalBoss") && isfinal)
        {
            boss.GetComponent<Kraken>().ReduceHealth(20);
            Destroy(gameObject);

        }
        if (collision.CompareTag("Player") && !isfinal)
        {
            player.GetComponent<Boy>().ReduceHealth(5);
            Destroy(gameObject);

        }


    }
}
