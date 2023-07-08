using UnityEngine;

public abstract class UpgradeData : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Icon;
    public float Duration;
    public bool IsTimed;
    public bool IsStackable;
    public bool IsDurationExtending;

    public abstract Upgrade InitializeUpgrade(GameObject obj);
}