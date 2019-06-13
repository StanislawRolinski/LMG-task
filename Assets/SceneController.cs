using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;
    [SerializeField] Text highestScoreText;
    [SerializeField] PlayerHealth playerHealth;

    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject endGamePanel;
    [SerializeField] Text endGameHighestScoreText;


    [SerializeField] Text colorText;
    private string chosenColorText = "Your color is: ";

    public static SceneController current;

    private int lives;
    private int score = 0;
    private int highestScore = 0;
    private List<Color> colors;

    private Color chosenPlayerColor;

    public Color ChosenPlayerColor { get => chosenPlayerColor; set => chosenPlayerColor = value; }

    private void Awake()
    {
        current = this;
        colors = new List<Color>();
        colors.Add(Color.red);
        colors.Add(Color.yellow);
        colors.Add(Color.green);
        colors.Add(Color.blue);
        startPanel.SetActive(true);
        mainPanel.SetActive(false);
        endGamePanel.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
        SetLives();
        SetHighestScore();
        SetPreviusChosenColor();
        Time.timeScale = 0;
    }

    public void SetPlayerColor(int colorIndex)
    {
        ChosenPlayerColor = colors[colorIndex];
        colorText.text = chosenColorText + colors[colorIndex].ToString();
    }

    public void SetPreviusChosenColor()
    {

        if (PlayerPrefs.HasKey("ChosenColor"))
        {
            ChosenPlayerColor = colors[PlayerPrefs.GetInt("ChosenColor")];
            colorText.text = chosenColorText + colors[PlayerPrefs.GetInt("ChosenColor")].ToString();
        }
        else
        {
            PlayerPrefs.SetInt("ChosenColor", 0);
            colorText.text = chosenColorText + colors[0].ToString();
        }
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
            endGameHighestScoreText.text = "Congratulations! You have set new highest score! " + score;
            }
            else
            {
            endGameHighestScoreText.text = "Highest score is: " + highestScore + ". Try one more time!";
            }
    }
    public void StartGame()
    {
        BulletsPoller.current.SetBulletsCollor();
        startPanel.SetActive(false);
        mainPanel.SetActive(true);
        Time.timeScale = 1;
        PlayerPrefs.SetInt("ChosenColor", colors.IndexOf(ChosenPlayerColor));
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void SetActiveEndGamePanel()
    {
        CheckScore();
        startPanel.SetActive(false);
        mainPanel.SetActive(false);
        endGamePanel.SetActive(true);
    }
}
