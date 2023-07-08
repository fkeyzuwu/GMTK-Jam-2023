using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Upgrades/Increase Size Upgrade")]

public class IncreaseSizeData : UpgradeData
{
    public float multiplier;

    public override Upgrade InitializeUpgrade(GameObject obj)
    {
        return new IncreaseSizeUpgrade(this, obj);
    }
}
