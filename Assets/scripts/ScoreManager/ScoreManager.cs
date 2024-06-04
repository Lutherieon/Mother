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
    DialogueSystem dialogueSystem;
    [SerializeField] GameObject ScoreGameObjectCanvas;



    private void Awake()
    {
        dialogueSystem = GameObject.FindGameObjectWithTag("DialogueSystem").GetComponent<DialogueSystem>();   
        Instance = this;

    }
    void Start()
    {
        score = 0;
        highScoreText.text = "HighScore:" + highScore.ToString();
    }

    void Update()
    {
        SetActiveController();
        currentTime = 60f - TimeScript.TimeLeft;

        scoreText.text = score.ToString();
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

    private void SetActiveController()
    {
        if (dialogueSystem.isDialogue)
        {
            ScoreGameObjectCanvas.SetActive(false);
        }
        else
        {
            ScoreGameObjectCanvas.SetActive(true);
        }
    }

}
