using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    public void SetTextHealth(int currentHealth, int maxHealth)
    {
        healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }
}
