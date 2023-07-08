using UnityEngine;

public abstract class Upgrade
{
    public float duration;
    public int stacks;
    public UpgradeData upgradeData { get; }
    public GameObject obj;
    public bool isFinished;

    public Upgrade(UpgradeData data, GameObject obj)
    {
        this.upgradeData = data; 
        this.obj=obj;
    }

    public void Tick(float delta)
    {
        duration -= delta;
        if(duration <= 0)
        {
            EndEffect();
            isFinished = true;
        }
    }

    public void Activate()
    {
        if(upgradeData.IsStackable || isFinished || stacks == 0)
        {
            ApplyEffect();
            stacks++;
        }
        
        if(upgradeData.IsDurationExtending || isFinished)
        {
            duration += upgradeData.Duration;
        }
    }

    public abstract void ApplyEffect();
    public abstract void EndEffect();
}
