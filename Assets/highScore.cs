using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class highScore : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI highScoreText;
    public runTimer timer;

    void Start()
    {
        if(maxScoreTimer.bestScoreTime != float.MaxValue)
        {
            highScoreText.text = "High Score: " + timer.GetTimeFormat(maxScoreTimer.bestScoreTime);
        }
        else
        {
            highScoreText.text = "";
        }
    }
}
