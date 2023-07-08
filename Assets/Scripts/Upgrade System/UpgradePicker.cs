using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePicker : MonoBehaviour
{
    private UpgradeSystem upgradeSystem;

    private void Start()
    {
        upgradeSystem = PlayerController.Instance.upgradeSystem;
    }
    public void GenerateUpgrades()
    {
        List<UpgradeData> upgrades = upgradeSystem.GenerateRandomUpgrades(3);
        for (int i = 0; i < upgrades.Count; i++)
        {
            PopulateUpgradeCard(upgrades[i], i);
        }
    }

    private void PopulateUpgradeCard(UpgradeData upgrade, int index)
    {

    }
}
