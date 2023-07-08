using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Upgrades/Summon Upgrade")]
public class SummonData : UpgradeData
{
    public float tickIntervalSeconds;
    public int amount;
    public GameObject prefab;

    public override Upgrade InitializeUpgrade(GameObject obj)
    {
        return new SummonUpgrade(this, obj);
    }

}
