using System.Collections;
using UnityEngine;

public class MagnetUpgrade : Upgrade
{
    UpgradeSystem upgradeSystem;

    public MagnetUpgrade(UpgradeData data, GameObject obj) : base(data, obj) 
    {
        upgradeSystem = obj.GetComponent<UpgradeSystem>();
    }

    public override void ApplyEffect()
    {
        upgradeSystem.transform.Find("MagnetRadius").GetComponent<MagnetFieldDrawer>().UpgradeMagnetField(((MagnetData)upgradeData).radius);
    }

    public override void EndEffect() { }
}
