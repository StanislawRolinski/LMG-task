using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    //MainGame Panel
    [SerializeField] GameObject mainPanel;
    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;
    [SerializeField] Text highestScoreText;
    [SerializeField] PlayerHealth playerHealth;

    private int lives;
    private int score = 0;
    private int highestScore = 0;

    //Start Panel
    [SerializeField] GameObject startPanel;
    [SerializeField] Text colorText;

    private List<Color> colors;
    private string chosenColorText = "Your color is: ";

    private Color chosenPlayerColor;
    public Color ChosenPlayerColor { get => chosenPlayerColor; set => chosenPlayerColor = value; }

    //EndGame Panel
    [SerializeField] GameObject endGamePanel;
    [SerializeField] Text endGameHighestScoreText;


    public static SceneController current;

    private void Awake()
    {
        current = this;
        SetColorsAvailable();
        startPanel.SetActive(true);
        mainPanel.SetActive(false);
        endGamePanel.SetActive(false);
    }

    private void Start()
    {
        scoreText.text = "Score: " + score;
        SetLives();
        SetHighestScore();
        SetPreviusChosenColor();
        Time.timeScale = 0;
    }
    private void SetColorsAvailable()
    {
        colors = new List<Color>();
        colors.Add(Color.red);
        colors.Add(Color.yellow);
        colors.Add(Color.green);
        colors.Add(Color.blue);
    }
    public void SetPlayerColor(int colorIndex)
    {
        ChosenPlayerColor = colors[colorIndex];
        colorText.text = chosenColorText + GetColorName(colorIndex);
    }

    public void SetPreviusChosenColor()
    {

        if (PlayerPrefs.HasKey("ChosenColor"))
        {
            ChosenPlayerColor = colors[PlayerPrefs.GetInt("ChosenColor")];
            colorText.text = chosenColorText + GetColorName(PlayerPrefs.GetInt("ChosenColor"));
        }
        else
        {
            PlayerPrefs.SetInt("ChosenColor", 0);
            colorText.text = chosenColorText + GetColorName(0);
        }
    }

    private string GetColorName(int colorToNameIndex)
    {
        switch (colorToNameIndex)
        {
            case 0:
                return "Red";
            case 1:
                return "Yellow";
            case 2:
                return "Green";
            case 3:
                return "Blue";
        }
        return "";
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
