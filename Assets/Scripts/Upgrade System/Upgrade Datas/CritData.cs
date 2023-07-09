using UnityEngine;

[CreateAssetMenu(menuName = "Player Upgrades/Crit Upgrade")]

public class CritData : UpgradeData
{
    public float critChance;

    public override Upgrade InitializeUpgrade(GameObject obj)
    {
        return new CritUpgrade(this, obj);
    }
}
