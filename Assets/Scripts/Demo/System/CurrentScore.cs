using UnityEngine;
using UnityEngine.UI;
using System;

public class CurrentScore : MonoBehaviour
{
    public static long score;
    [SerializeField] Text scoreText, highScoreText;

    void Start()
    {
        Events.gameOverEvent += OnGameOver;
        highScoreText.text = PlayerPrefs.GetString("HighScore", "0");
    }

    void OnGameOver()
    {
        string currHighScoreText = PlayerPrefs.GetString("HighScore", "0");
        long currHighScore = Convert.ToInt64(currHighScoreText);
        if (score > currHighScore)
        {
            PlayerPrefs.SetString("HighScore", score.ToString());
            highScoreText.text = score.ToString();
        }
    }

    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        scoreText.text = score.ToString();
    }

    void OnApplicationQuit()
    {
        OnGameOver();
    }
}
