using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ExperienceBar : MonoBehaviour
{
    public Slider slider;
    

    public void SetMaxExperience(int requiredExp)
    {
        slider.maxValue = requiredExp;
    }
    public void SetExperience(int experience)
    {
        slider.value = experience;
    }
}
