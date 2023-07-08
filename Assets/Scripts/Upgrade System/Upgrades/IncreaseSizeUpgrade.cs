using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSizeUpgrade : Upgrade
{
    UpgradeSystem upgradeSystem;
    IncreaseSizeData data;

    public IncreaseSizeUpgrade(IncreaseSizeData data, GameObject obj) : base(data, obj)
    {
        upgradeSystem = obj.GetComponent<UpgradeSystem>();
        this.data = data;
    }

    public override void ApplyEffect()
    {
        Vector3 localScale = PlayerController.Instance.transform.localScale;
        PlayerController.Instance.transform.localScale = new Vector3(localScale.x * data.multiplier, localScale.y * data.multiplier, localScale.z);
    }

    public override void EndEffect()
    {
        
    }
}
