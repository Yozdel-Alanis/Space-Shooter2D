using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{

    public Score score;

    public Text scoreLabel;
    public Text highScoreLabel;

    private void OnEnable()
    {
        int currentScore = score.GetScore();
        scoreLabel.text = "Score: " + score.GetScore();

        int highscore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreLabel.text = "Highscore: " + highscore;
        if(currentScore > highscore)
            PlayerPrefs.SetInt("HighScore", score.GetScore());

    }

    public void RestartGame()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
