using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : MonoBehaviour
{
    
    public bool grounded;
    public float speed = 50f;
    public float maxSpeed=3;
    public float jump_velocity = 200f;
    public bool jumpIndicator;
    Transform firepos;
    public bool facingRight = true;

    private Rigidbody2D rb;
    private Animator anime;

    public int health;
    public int totalhealth=100;

    public GameObject leftBullet;
    public GameObject rightBullet;

    // Start is called before the first frame update
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        anime = gameObject.GetComponent<Animator>();
        health = totalhealth;

        firepos = transform.FindChild("FirePos");

    }

    // Update is called once per frame
    void Update()
    {
        anime.SetBool("Grounded", grounded);
        anime.SetFloat("Speed",Mathf.Abs(rb.velocity.x)) ;

        if (Input.GetButtonDown("Fire2"))
        {
            Fire();
            Sound.PlaySound("shoot");
        }

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            facingRight = false;
            transform.localScale = new Vector3(-0.4249412f, 0.4206125f, 1);
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            facingRight = true;
            transform.localScale = new Vector3(0.4249412f, 0.4206125f, 1);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                Sound.PlaySound("jump");
                rb.AddForce(Vector2.up * jump_velocity);
                jumpIndicator = true;
            }
            else {
                if (jumpIndicator) {
                    jumpIndicator = false;
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(Vector2.up * jump_velocity);
                }
            }
        }

            if (health > totalhealth) {
            health = totalhealth;    
        }

        if (health <= 0) {
            Die();
        }
    }

    void FixedUpdate()
    {
        Vector3 ev = rb.velocity;
        ev.y = rb.velocity.y;
        ev.z = 0.0f;
        ev.x *= 0.75f;



        float inputaxis = Input.GetAxis("Horizontal");
        if (grounded)
        {
            rb.velocity = ev;
        }

        rb.AddForce(( Vector2.right * speed) * inputaxis);

        if (rb.velocity.x > maxSpeed) {

            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }

        if (rb.velocity.x < -maxSpeed)
        {

            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }

    }

    void Die() {

        Application.LoadLevel("Die");
    }

    public void ReduceHealth(int value) {
        health -= value;
        gameObject.GetComponent<Animation>().Play("Boy_Redflash");

    }

    public IEnumerator KnockBack(float duration, float power, Vector3 dir) {

        float timer = 0;
        while (duration > timer) {
            timer += Time.deltaTime;
            rb.AddForce(new Vector3(dir.x * -100, dir.y * power, transform.position.z));
    
        }
        yield return 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coin")) {
            ScoreScript.scoreValue += 10;
            Sound.PlaySound("coin");
            Destroy(collision.gameObject);
        }
    }

    void Fire()
    {
        if(!facingRight)
        {
            Instantiate(leftBullet, firepos.position, Quaternion.identity);
        }
        if(facingRight) {
            Instantiate(rightBullet, firepos.position, Quaternion.identity);
        }
    
    }
}
  