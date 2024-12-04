using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public int minutes = 0;
    public int seconds = 30;

    //인게임
    public Text timerText;
    public Text Score;

    // 타임 오버후
    public Text BestScore;
    public Text MyScore;
    public GameObject TimeOver;

    private float timeRemaining;
    public int score;
    public bool IsGame;

    SphereVer2 sh;
    // Start is called before the first frame update
    void Start()
    {
        TimeOver.SetActive(false);
        score = 0;
        IsGame = true;

        timeRemaining = minutes * 60 + seconds;

        sh = FindObjectOfType<SphereVer2>();

    }

    // Update is called once per frame
    void Update()
    {
        if (IsGame == true)
        {
            if (timeRemaining > 0.0f)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            { 
                TimeOver.SetActive(true);
                IsGame = false;

                Time.timeScale = 0f;

                float bestScores = PlayerPrefs.GetFloat("BestScore");

                sh.TimeOver();

                if(score > bestScores)
                {
                    bestScores = score;

                    PlayerPrefs.SetFloat("BestScore", bestScores);
                }
                BestScore.text = "Best-Score : " + bestScores;
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1f;
            }
        }
        int displayMinutes = (int)(timeRemaining / 60);
        int displaySeconds = (int)(timeRemaining % 60);

        timerText.text = $"{displayMinutes:00}:{displaySeconds:00}";
    }

    public void Scores()
    {
        score = score + 1;
        Score.text = "Score : " + score;
        MyScore.text = "MyScore-Score : " + score;
    }

    public void timeOver()
    {
        IsGame = false;
    }
}
