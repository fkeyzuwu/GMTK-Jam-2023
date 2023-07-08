using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePicker : MonoBehaviour
{
    private UpgradeSystem upgradeSystem;

    public UpgradePick[] upgradePicks;

    private void Start()
    {
        upgradeSystem = PlayerController.Instance.upgradeSystem;
        GenerateUpgrades();
    }
    public void GenerateUpgrades()
    {
        List<UpgradeData> upgrades = upgradeSystem.GenerateRandomUpgrades(3);
        for (int i = 0; i < upgrades.Count; i++)
        {
            upgradePicks[i].UpdatePick(upgrades[i]);
        }
    }
}
