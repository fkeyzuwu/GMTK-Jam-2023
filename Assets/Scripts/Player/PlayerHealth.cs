using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    private float currentHealth;
    public float critChance = 0.0f;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private HealthText healthText;


    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
        healthText.SetTextHealth(currentHealth, currentHealth);
    }

    public void TakeDamage(float amount)
    {
        if (critChance > 0.0f)
            if (Random.Range(0.0f, 100.0f) <= critChance)
                amount *= 2;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, currentHealth);
        healthBar.SetHealth(currentHealth);
        healthText.SetTextHealth(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            print("You win!");
        }
    }

    public void Heal(float amount) 
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, currentHealth, maxHealth);
        healthBar.SetHealth(currentHealth);
        healthText.SetTextHealth(currentHealth, maxHealth);
    }
}
