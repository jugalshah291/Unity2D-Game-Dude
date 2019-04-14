﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    private GameObject player;
    private Vector2 target;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = new Vector2(player.transform.position.x, player.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=Vector2.MoveTowards(transform.position,target,speed*Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y) {
            DestroyProjectile();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            Sound.PlaySound("hit");
            player.GetComponent<Boy>().ReduceHealth(5);
            DestroyProjectile();

        }
    }

    void DestroyProjectile() {

        Destroy(gameObject);
    }
}