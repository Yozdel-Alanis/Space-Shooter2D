using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private int scoreValue;

    public void Start()
    {
        scoreText.text = "Score " + scoreValue;
        
    }

    public void AddPoints(int points)
    {
        scoreValue += points;
        scoreText.text = "Score " + scoreValue;
    }

    private void ReducePoints(int points)
    {
        scoreValue -= points;
        scoreText.text = "Score " + scoreValue;
    }

    public int GetScore()
    {
        return scoreValue;
    }
}
