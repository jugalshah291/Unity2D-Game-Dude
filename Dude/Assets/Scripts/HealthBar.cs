using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image healthBar;
    private Boy b;

    void Start()
    {
        b = GameObject.FindGameObjectWithTag("Player").GetComponent<Boy>();
        healthBar = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = b.health / b.totalhealth; 
    }
}
