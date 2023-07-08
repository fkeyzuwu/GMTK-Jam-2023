using UnityEngine;

[CreateAssetMenu(menuName = "Player Upgrades/Speed Upgrade")]
public class SpeedData : UpgradeData
{
    public int speedAddition;

    public override Upgrade InitializeUpgrade(GameObject obj)
    {
        return new SpeedUpgrade(this, obj);
    }
}
