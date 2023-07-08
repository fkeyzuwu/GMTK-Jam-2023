using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private int level = 1;

    [Header("Multipliers")]
    [SerializeField] 
    [Range(1f, 300f)]
    private float additionalMultiplier = 300f;

    [SerializeField] 
    [Range(2f, 4f)] 
    private float powerMultiplier = 2f;

    [SerializeField]
    [Range(7f, 14f)] 
    private float divisionMultiplier = 7f;

    [SerializeField]
    [Range(0f, 1f)]
    private float gainExpMultiplier = 0.1f;

    [SerializeField]
    private int levelScaleExpGain = 5;

    private int currentExp;
    private int requiredExp;

    [SerializeField] private ExperienceBar experienceBar;
    [SerializeField] private ExperienceText experienceText;
    [SerializeField] private LvLText lvlText;

    private void Start()
    {
        currentExp = 0;
        requiredExp = CalculateRequiredExp();
        experienceBar.SetMaxExperience(requiredExp);
        experienceBar.SetExperience(currentExp);
        experienceText.SetTextExperience(currentExp, requiredExp);
        lvlText.SetTextLvL(level);
    }

    private void Update()
    {
        if (currentExp >= requiredExp)
        {
            LevelUp();
        }
    }

    public void GainExperience(float exp)
    {
        float multiplier = (1 + (int)(level / levelScaleExpGain) * gainExpMultiplier);
        currentExp += (int)(exp * multiplier);
        experienceBar.SetMaxExperience(requiredExp);
        experienceBar.SetExperience(currentExp);
        experienceText.SetTextExperience(currentExp, requiredExp);
        lvlText.SetTextLvL(level);
    }

    private void LevelUp()
    {
        level++;
        currentExp = Mathf.RoundToInt(currentExp - requiredExp);
        requiredExp = CalculateRequiredExp();
        experienceBar.SetExperience(currentExp);
        experienceText.SetTextExperience(currentExp, requiredExp);

        PlayerController.Instance.ActivateUpgradePicker();
    }

    private int CalculateRequiredExp()
    {
        int calculatedRequiredExp = 0;
        for (int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            calculatedRequiredExp += (int)Mathf.Floor(levelCycle + additionalMultiplier * Mathf.Pow(powerMultiplier, levelCycle / divisionMultiplier));
        }
        return calculatedRequiredExp / 4;
    }
}
