using UnityEngine;

public abstract class UpgradeData : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Icon;
    public bool IsTimed;
    public float Duration;
    public bool IsStackable;
    public bool IsDurationExtending;
    public bool IsMaxStackLimited;
    public int MaxStack;

    public abstract Upgrade InitializeUpgrade(GameObject obj);
}