using UnityEngine;

[CreateAssetMenu(menuName = "Player Upgrades/Poison Upgrade")]
public class PoisonData : UpgradeData
{
    public float damagePercentPerTick;
    public float tickIntervalSeconds;

    public override Upgrade InitializeUpgrade(GameObject obj)
    {
        return new PoisonUpgrade(this, obj);
    }
}
