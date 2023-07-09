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
        foreach (Upgrade upgrade in activeUpgrades.Values)
        {
            if (upgrade.upgradeData.IsTimed)
                upgrade.Tick(Time.deltaTime);

            if (upgrade.isFinished)
                activeUpgrades.Remove(upgrade.upgradeData);
        }
    }

    public List<int> GenerateRandomUniqueNumbers(int amount, int maxNum)
    {
        if(maxNum <= 0)
        {
            Debug.LogError("[UpgradeSystem] No possible upgrades available");
            return null;
        }

        List<int> randomNumbers = new List<int>();

        if (amount >= maxNum)
        {
            for(int i=0 ; i < amount; i++)
            {
                if (i > maxNum - 1)
                    randomNumbers.Add(maxNum - 1);
                else
                    randomNumbers.Add(i);
            }
        }
        else
        {
            while (randomNumbers.Count < amount)
            {
                int randomNum = Random.Range(0, maxNum);

                if (!randomNumbers.Contains(randomNum))
                    randomNumbers.Add(randomNum);
            }
        }

        return randomNumbers;
    }
    
    public List<UpgradeData> GenerateRandomUpgrades(int amount)
    {
        if (possibleUpgrades.Count > 0)
        {
            List<UpgradeData> randomUpgrades = new List<UpgradeData>();
            List<int> randomNumbers = GenerateRandomUniqueNumbers(amount, possibleUpgrades.Count);

            if (randomNumbers == null)
            {
                Debug.LogError("[UpgradeSystem] Failed to receive random upgrades");
                return null;
            }

            foreach (int num in randomNumbers)
            {
                randomUpgrades.Add(possibleUpgrades[num]);
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

    public void RemoveUpgradeFromList(UpgradeData upgradeData)
    {
        possibleUpgrades.Remove(upgradeData);
    }
}
