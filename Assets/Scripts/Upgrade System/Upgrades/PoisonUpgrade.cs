using System.Collections;
using UnityEngine;

public class PoisonUpgrade : Upgrade
{
    UpgradeSystem upgradeSystem;
    public bool isPoisoned = false;
    public float poisonPercentage = 0f;

    public PoisonUpgrade(UpgradeData data, GameObject obj) : base(data, obj)
    {
        upgradeSystem = obj.GetComponent<UpgradeSystem>();
    }

    private IEnumerator PoisonTick()
    {
        while (true)
        {
            if (!isPoisoned) break;
            float flatDamage = PlayerController.Instance.health.maxHealth * (poisonPercentage / 100);
            PlayerController.Instance.health.TakeDamage(flatDamage);

            yield return new WaitForSeconds(((PoisonData)upgradeData).tickIntervalSeconds);
        }
    }

    public override void ApplyEffect()
    {
        poisonPercentage += ((PoisonData)upgradeData).damagePercentPerTick;

        if (!isPoisoned)
        {
            isPoisoned = true;
            upgradeSystem.StartCoroutine(PoisonTick());
        }
    }

    public override void EndEffect()
    {
        if(isPoisoned)
            poisonPercentage -= ((PoisonData)upgradeData).damagePercentPerTick;

        if(poisonPercentage <= 0f)
            isPoisoned = false;
    }
}
