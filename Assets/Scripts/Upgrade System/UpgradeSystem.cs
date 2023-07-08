using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    #region Upgrade Handlers

    [SerializeField] public List<UpgradeData> possibleUpgrades;
    public Dictionary<UpgradeData, Upgrade> activeUpgrades = new Dictionary<UpgradeData, Upgrade>();

    #endregion

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateRandomUpgrade();
        }

        foreach (Upgrade upgrade in activeUpgrades.Values)
        {
            if (upgrade.upgradeData.IsTimed)
                upgrade.Tick(Time.deltaTime);

            if (upgrade.isFinished)
                activeUpgrades.Remove(upgrade.upgradeData);
        }
    }

    public void GenerateRandomUpgrade()
    {
        if (possibleUpgrades.Count > 0)
        {
            int randomUpgradeIndex = UnityEngine.Random.Range(0, possibleUpgrades.Count);

            AddUpgrade(possibleUpgrades[randomUpgradeIndex]);
        }
        else
        {
            Debug.LogError("[UpgradeSystemError] No upgrades attached to the 'Possible Upgrades List' on the upgrade system attached to the player.");
        }
    }

    public void AddUpgrade(UpgradeData upgradeData)
    {
        if (!activeUpgrades.ContainsKey(upgradeData))
        {
            activeUpgrades.Add(upgradeData, upgradeData.InitializeUpgrade(this.gameObject));
        }

        activeUpgrades[upgradeData].Activate();
    }

    public void RemoveUpgradeFromList(UpgradeData upgradeData)
    {
        possibleUpgrades.Remove(upgradeData);
    }
}
