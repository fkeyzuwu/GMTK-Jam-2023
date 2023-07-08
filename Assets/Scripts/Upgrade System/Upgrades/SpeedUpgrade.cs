using System.Collections;
using UnityEngine;

public class SpeedUpgrade : Upgrade
{
    UpgradeSystem upgradeSystem;

    public SpeedUpgrade(UpgradeData data, GameObject obj) : base(data, obj) 
    {
        upgradeSystem = obj.GetComponent<UpgradeSystem>();
    }

    public override void ApplyEffect()
    {
       PlayerController.Instance.speed += ((SpeedData)upgradeData).speedAddition;
    }

    public override void EndEffect()
    {
        PlayerController.Instance.speed -= ((SpeedData)upgradeData).speedAddition;
    }


}
