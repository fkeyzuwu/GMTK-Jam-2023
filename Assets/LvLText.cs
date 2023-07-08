using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LvLText : MonoBehaviour
{
    public TextMeshProUGUI lvlText;

    public void SetTextLvL(int lvl)
    {
        lvlText.text = "LvL: " + lvl.ToString();
    }
}
