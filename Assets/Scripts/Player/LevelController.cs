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

    private float currentExp;
    private float requiredExp;

    private void Start()
    {
        currentExp = 0;
        requiredExp = CalculateRequiredExp();
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
        currentExp += exp * multiplier;
    }

    private void LevelUp()
    {
        level++;
        currentExp = Mathf.RoundToInt(currentExp - requiredExp);
        requiredExp = CalculateRequiredExp();
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
