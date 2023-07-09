using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poition : Pickable
{
    [SerializeField] private int waitTimeBetweenIntervals = 3;
    [SerializeField] private int amountToRepeat = 3;
    [SerializeField] private float HealAmount = 100;


    public override void OnPickUpEffect()
    {
        PlayerController.Instance.health.StartHealOverTime(HealAmount, amountToRepeat, waitTimeBetweenIntervals);      
    }
}
