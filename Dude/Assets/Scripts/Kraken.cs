using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//  ref: https://pixelnest.io/tutorials/2d-game-unity/player-and-enemies/

public class Kraken : MonoBehaviour
{
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nextPos;
    public float bullettime;
    public float starttime;
    public GameObject bullet;
    public Slider healthslider;
    public int health;
    public Sprite angryBoss;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;

    Transform firepos1;
    Transform firepos2;
    Transform firepos3;


    // Start is called before the first frame update
    void Start()
    {
        
        posB = transformB.localPosition;
        posA = childTransform.localPosition;
        nextPos = posB;
        bullettime = starttime;
        healthslider.value = health;
        firepos1 = transform.FindChild("FirePos1");
        firepos2 = transform.FindChild("FirePos2");
        firepos3 = transform.FindChild("FirePos3");
 
    }

    // Update is called once per frame
    void Update()
    {
        healthslider.value = health;
        if(health <= 200)
        {
            //this.gameObject.GetComponent<SpriteRenderer>().sprite=angryBoss;
            //transform.localScale= new Vector3(0.6127546f, 0.7817734f, 0.91935f);
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (health <=0)
        {
            Win();
        }
        Move();
        if(bullettime <= 0) {


            bullettime = starttime;
            if(health <= 200)
            {
                Instantiate(bullet,firepos1.position, Quaternion.identity);
                Instantiate(bullet, firepos2.position, Quaternion.identity);
                Instantiate(bullet, firepos3.position, Quaternion.identity);
            }
            else
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
            
        }
        else {

            bullettime -= Time.deltaTime;
        }



    }
    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPos, speed * Time.deltaTime);
        if (Vector3.Distance(childTransform.localPosition, nextPos) <= 0.1)
        {
            ChangeDestination();
        }
    }
    private void ChangeDestination()
    {
        nextPos = nextPos != posA ? posA : posB;
    }

    public void ReduceHealth(int value)
    {
        health -= value;


    }
    void Win()
    {

        Application.LoadLevel("Win");
    }
}
