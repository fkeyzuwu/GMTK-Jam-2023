using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class runTimer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;

    void Update()
    {
        currentTime += Time.deltaTime;
        timerText.text = GetTimeFormat(currentTime);
    }

    public string GetTimeFormat(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float miliseconds = Mathf.FloorToInt((time - minutes * 60 - seconds) * 1000);
        if (miliseconds == 999f)
        {
            miliseconds = 0f;
        }
        String text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + miliseconds.ToString("000");
        return text;
    }

    public string CheckForHighscore()
    {
        if (maxScoreTimer.bestScoreTime < currentTime)
        {
            maxScoreTimer.bestScoreTime = currentTime;
        }
        string text = GetTimeFormat(currentTime);
        return text;
    }
}
