using UnityEngine;

public abstract class UpgradeData : ScriptableObject
{
    public string Name;
    public string Description;
    public float Duration;
    public int MaxStack;
    public Sprite Icon;
    public bool IsTimed;
    public bool IsStackable;
    public bool IsDurationExtending;
    public bool IsMaxStackLimited;

    public abstract Upgrade InitializeUpgrade(GameObject obj);
}