using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    
    Text health;
    private Boy b;

    // Start is called before the first frame update
    void Start()
    {
        b= GameObject.FindGameObjectWithTag("Player").GetComponent<Boy>();
        health = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        health.text = "Health: " + b.health;
    }
}
