using System.Collections;
using UnityEngine;

public class MagnetUpgrade : Upgrade
{
    UpgradeSystem upgradeSystem;

    public MagnetUpgrade(UpgradeData data, GameObject obj) : base(data, obj) 
    {
        upgradeSystem = obj.GetComponent<UpgradeSystem>();
    }

    public override void ApplyEffect() // TODO: Apply Magnet Addition Logic
    {
        upgradeSystem.playerBaseUpgradeStats.magnetRadius += ((MagnetData)upgradeData).radius;
    }

    public override void EndEffect() // TODO: Apply Magnet Removal Logic
    {
        upgradeSystem.playerBaseUpgradeStats.magnetRadius -= ((MagnetData)upgradeData).radius;
    }


}
