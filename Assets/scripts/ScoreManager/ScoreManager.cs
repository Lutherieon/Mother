using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    
    public static ScoreManager Instance;
    [SerializeField] Text scoreText;
    [SerializeField] Text highScoreText;
    public static int score;
    int highScore;
    float currentTime;




    private void Awake()
    {
        Instance = this;

    }
    void Start()
    {
        score = 0;
        highScoreText.text = "HighScore:" + highScore.ToString();
    }

    void Update()
    {
        currentTime = 60f - TimeScript.TimeLeft;

        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "HighScore:" + PlayerPrefs.GetInt("highScore").ToString();
        if (score > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", score);
        }

    }




    void CountScore()
    {
        score += ((int)(currentTime * 10));
    }

}
