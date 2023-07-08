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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //GenerateRandomUpgrade();
        }

        foreach(Upgrade upgrade in activeUpgrades.Values)
        {
            if(upgrade.upgradeData.IsTimed)
                upgrade.Tick(Time.deltaTime);

            if (upgrade.isFinished) 
                activeUpgrades.Remove(upgrade.upgradeData);
        }
    }
    
    public List<UpgradeData> GenerateRandomUpgrades(int amount)
    {
        if (possibleUpgrades.Count > 0)
        {
            List<UpgradeData> randomUpgrades = new List<UpgradeData>();

            for (int i = 0; i < amount; i++)
            {
                int randomUpgradeIndex = UnityEngine.Random.Range(0, possibleUpgrades.Count);
                randomUpgrades.Add(possibleUpgrades[randomUpgradeIndex]);
            }
            
            return randomUpgrades;
        } 
        else
        {
            Debug.LogError("[UpgradeSystemError] No upgrades attached to the 'Possible Upgrades List' on the upgrade system attached to the player.");
            return null;
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
}
