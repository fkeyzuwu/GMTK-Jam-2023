using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = (int)health;
        slider.value = (int)health;
    }
    public void SetHealth(float health)
    {
        slider.value = (int)health;
    }
}


