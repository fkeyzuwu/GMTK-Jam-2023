using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [Header("iFrame")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numberOfFlahses;
    [SerializeField] private Color damageColor;
    [SerializeField] private Color healColor;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] public float maxHealth;
    private float currentHealth;
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
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, currentHealth);
        healthBar.SetHealth(currentHealth);
        healthText.SetTextHealth(currentHealth, maxHealth);
        StopAllCoroutines();
        StartCoroutine(ChangePlayerColor(damageColor));
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
        StopAllCoroutines();
        StartCoroutine(ChangePlayerColor(healColor));
    }

    private IEnumerator ChangePlayerColor(Color color)
    {
        for (int i = 0; i < numberOfFlahses; i++)
        {
            spriteRenderer.color = new Color(color.r, color.g, color.b, 1f);
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlahses * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlahses * 2));
        }
    }

    public void StartHealOverTime(float amount, int amountToRepeat, int waitTimeBetweenIntervals)
    {
        StartCoroutine(HealOverTime(amount,amountToRepeat,waitTimeBetweenIntervals));
    }

    public IEnumerator HealOverTime(float amount,int amountToRepeat ,int waitTimeBetweenIntervals)
    {
        for (int i = 0; i < amountToRepeat; i++)
        {
            Heal(amount);
            yield return new WaitForSeconds(waitTimeBetweenIntervals);
        }
        yield return null;
    }
}