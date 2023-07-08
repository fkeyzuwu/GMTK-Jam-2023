using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealth;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private HealthText healthText;


    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
        healthText.SetTextHealth(currentHealth, currentHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, currentHealth);
        healthBar.SetHealth(currentHealth);
        healthText.SetTextHealth(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            print("You win!");
        }
    }

    public void Heal(int amount) 
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, currentHealth, maxHealth);
        healthBar.SetHealth(currentHealth);
        healthText.SetTextHealth(currentHealth, maxHealth);
    }
}
