using UnityEngine;

[CreateAssetMenu(menuName = "Player Upgrades/Magnet Upgrade")]
public class MagnetData : UpgradeData
{
    public float radius;

    public override Upgrade InitializeUpgrade(GameObject obj)
    {
        return new MagnetUpgrade(this, obj);
    }
}
