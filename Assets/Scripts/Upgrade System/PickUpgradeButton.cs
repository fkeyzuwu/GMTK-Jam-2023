using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PickUpgradeButton : MonoBehaviour
{
    private UpgradePick upgradePick;
    private void Start()
    {
        upgradePick = GetComponentInParent<UpgradePick>();
    }
    public void OnUpgradeClicked()
    {
        PlayerController.Instance.UpgradePicked(upgradePick.currentUpgradeData);
    }
}
