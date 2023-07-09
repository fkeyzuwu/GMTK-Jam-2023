using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePicker : MonoBehaviour
{
    public UpgradePick[] upgradePicks;
    public void GenerateUpgrades()
    {
        UpgradeSystem upgradeSystem = PlayerController.Instance.upgradeSystem;
        List<UpgradeData> upgrades = upgradeSystem.GenerateRandomUpgrades(3);
        for (int i = 0; i < upgrades.Count; i++)
        {
            upgradePicks[i].UpdatePick(upgrades[i]);
        }
    }
}
