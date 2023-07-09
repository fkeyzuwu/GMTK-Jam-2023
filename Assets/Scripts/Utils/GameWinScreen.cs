using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinScreen : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI highScoreText;
    public runTimer timer;
    public void UpdateTimer()
    {
        timer.CheckForHighscore();
        timerText.text = "Time: " + timer.GetTimeFormat(timer.currentTime);
        highScoreText.text = "High Score: " + timer.GetTimeFormat(maxScoreTimer.bestScoreTime);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
