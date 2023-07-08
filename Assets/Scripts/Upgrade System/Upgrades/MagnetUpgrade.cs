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
        CircleCollider2D collider = upgradeSystem.transform.Find("MagnetRadius").GetComponent<CircleCollider2D>();
        collider.radius += 1;
    }

    public override void EndEffect() { }
}
