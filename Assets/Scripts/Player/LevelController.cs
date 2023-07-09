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
        UpdateUI();
    }

    private void Update()
    {

    }

    public void GainExperience(float exp)
    {
        float multiplier = (1 + (int)(level / levelScaleExpGain) * gainExpMultiplier);
        int gainedExp = (int)(exp * multiplier);
        int requiredExpToLevelUp = requiredExp - currentExp;

        if (gainedExp >= requiredExpToLevelUp)
        {
            LevelUp();
            currentExp = 0;
            GainExperience(gainedExp - requiredExpToLevelUp);
        }
        else
        {
            currentExp += gainedExp;
        }
        AudioManager.Instance.PlaySound("EXP");
        UpdateUI();
    }

    private void LevelUp()
    {
        AudioManager.Instance.PlaySound("Level Up");
        PlayerController.Instance.health.Heal(PlayerController.Instance.health.maxHealth * 0.3f);
        level++;
        requiredExp = CalculateRequiredExp();
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

    private void UpdateUI()
    {
        experienceBar.SetMaxExperience(requiredExp);
        experienceBar.SetExperience(currentExp);
        experienceText.SetTextExperience(currentExp, requiredExp);
        lvlText.SetTextLvL(level);
    }
}
