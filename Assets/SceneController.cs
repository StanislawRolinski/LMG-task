using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;
    [SerializeField] Text highestScoreText;
    [SerializeField] PlayerHealth playerHealth;

    public static SceneController current;

    private int lives;
    private int score = 0;
    private int highestScore = 0;

    private void Awake()
    {
        current = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
        SetLives();
        SetHighestScore();
    }

    private void SetHighestScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highestScore = PlayerPrefs.GetInt("HighScore");
        }
        highestScoreText.text = "The Highest Score: " + highestScore;
    }

    public void SetLives()
    {
        lives = playerHealth.Health;
        livesText.text = "Lives: " + lives;
    }

    public void AddToScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void CheckScore()
    {
            if (score > highestScore)
            {
                PlayerPrefs.SetInt("HighScore", score);
                //highestScoreText.text += "    Congratulations! You have set new highest score! " + score;
            }
            else
            {
               // highestScoreText.text += "    Highest score is: " + highScore + ". Try one more time!";
            }
    }
}
