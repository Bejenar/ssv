using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public Slider healthBar;

    private int currenHealth;
    
    
    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = maxHealth;
        healthBar.wholeNumbers = true;
        healthBar.value = maxHealth;

        currenHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currenHealth -= damage;
        healthBar.value = Math.Max(0, currenHealth);

        if (currenHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("Lose");
    }
}
