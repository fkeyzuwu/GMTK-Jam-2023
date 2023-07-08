using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    #region Upgrade Handlers

    [SerializeField] public List<UpgradeData> possibleUpgrades;
    public Dictionary<UpgradeData, Upgrade> activeUpgrades = new Dictionary<UpgradeData, Upgrade>();

    #endregion

    #region Stats Handlers

    [System.Serializable]
    public struct BaseUpgradeStats
    {
        public float magnetRadius;
    }

    public BaseUpgradeStats playerBaseUpgradeStats = new BaseUpgradeStats()
    {
        magnetRadius = 0f
    };

    #endregion

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GenerateRandomUpgrade();
        }

        foreach(Upgrade upgrade in activeUpgrades.Values)
        {
            if(upgrade.upgradeData.IsTimed)
                upgrade.Tick(Time.deltaTime);

            if (upgrade.isFinished) 
                activeUpgrades.Remove(upgrade.upgradeData);
        }
    }
    
    public void GenerateRandomUpgrade()
    {
        int randomUpgradeIndex = UnityEngine.Random.Range(0, possibleUpgrades.Count);

        AddUpgrade(possibleUpgrades[randomUpgradeIndex]);
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
