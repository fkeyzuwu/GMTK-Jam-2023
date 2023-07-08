using System.Collections;
using UnityEngine;

public class SpeedUpgrade : Upgrade
{
    UpgradeSystem upgradeSystem;

    public SpeedUpgrade(UpgradeData data, GameObject obj) : base(data, obj) 
    {
        upgradeSystem = obj.GetComponent<UpgradeSystem>();
    }

    public override void ApplyEffect() // TODO: Apply Magnet Addition Logic
    {
       PlayerController.Instance.speed += ((SpeedData)upgradeData).speedAddition;
    }

    public override void EndEffect() // TODO: Apply Magnet Removal Logic
    {
        PlayerController.Instance.speed -= ((SpeedData)upgradeData).speedAddition;
    }


}
