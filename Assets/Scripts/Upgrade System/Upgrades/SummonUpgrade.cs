using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonUpgrade : Upgrade
{
    UpgradeSystem upgradeSystem;
    SummonData data;

    public SummonUpgrade(SummonData data, GameObject obj) : base(data, obj)
    {
        upgradeSystem = obj.GetComponent<UpgradeSystem>();
        this.data = data;
    }

    IEnumerator SummonTick()
    {
        while (true)
        {
            SpawnManager.Instance.SpawnSpawnable(
                new GameObject[] { data.prefab },
                data.amount * stacks,
                0,
                0,
                true
            );
            yield return new WaitForSeconds(data.tickIntervalSeconds);
        }
    }

    public override void ApplyEffect()
    {
        if (stacks == 1)
            upgradeSystem.StartCoroutine( SummonTick() );
    }

    public override void EndEffect()
    {
        
    }
}
