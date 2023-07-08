using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExperienceText : MonoBehaviour
{

    public TextMeshProUGUI expText;

    public void  SetTextExperience(int experience, int requiredExp)
    {
        expText.text = experience.ToString() + " / " + requiredExp.ToString();
    }
}
