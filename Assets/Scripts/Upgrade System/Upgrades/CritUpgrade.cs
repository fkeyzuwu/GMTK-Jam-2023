using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritUpgrade : Upgrade
{
    UpgradeSystem upgradeSystem;

    public CritUpgrade(CritData data, GameObject obj) : base(data, obj)
    {
        upgradeSystem = obj.GetComponent<UpgradeSystem>();
    }

    public override void ApplyEffect()
    {
        PlayerController.Instance.health.critChance += ((CritData)upgradeData).critChance;
    }

    public override void EndEffect()
    {
        PlayerController.Instance.health.critChance -= ((CritData)upgradeData).critChance;
    }
}
