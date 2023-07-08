using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealth;
    [SerializeField] private TextMeshProUGUI healthText;
    
    private void Start()
    {
        currentHealth = maxHealth;
        healthText.text = currentHealth.ToString();
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, currentHealth);
        healthText.text = currentHealth.ToString();
        if (currentHealth <= 0)
        {
            print("You win!");
        }
    }

    public void Heal(int amount) 
    {
        currentHealth += amount;
        healthText.text = currentHealth.ToString();
    }
}
