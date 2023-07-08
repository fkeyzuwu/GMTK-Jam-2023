using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    public void SetTextHealth(float currentHealth, float maxHealth)
    {
        healthText.text = ((int)currentHealth).ToString() + " / " + ((int)maxHealth).ToString();
    }
}
