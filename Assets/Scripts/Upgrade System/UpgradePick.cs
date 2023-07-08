using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePick : MonoBehaviour
{
    public UpgradeData currentUpgradeData;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public Image image;
    public Image descriptionBack;

    public void UpdatePick(UpgradeData upgradeData)
    {
        currentUpgradeData = upgradeData;
        titleText.text = upgradeData.Name;
        descriptionText.text = upgradeData.Description;
        image.sprite = upgradeData.Icon;
    }
}
