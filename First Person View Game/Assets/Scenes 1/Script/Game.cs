using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    // 시간
    public int minutes = 0; // 분
    public int seconds = 30; // 초

    //인게임
    public Text timerText; // 카운트 text 컴포넌트
    public Text Score; // 점수 text 컴포넌트

    // 타임 오버후
    public Text BestScore; // 최고 점수 text 컴포넌트
    public Text MyScore; // 내 현재 점수 text 컴포넌트
    public GameObject TimeOver; // 게임오버 오브젝트

    private float timeRemaining; // 실제 카운트 담당 객체
    public int score; // 점수 객체
    public bool IsGame; // 현재 게임 상태

    SphereVer2 sh;  // SphereVer2 스크립트

    void Start()
    {
        TimeOver.SetActive(false); // 타임오버 오브젝트 비활성화
        score = 0; // 점수를 0으로 초기화
        IsGame = true; // 현재 게임 상태를 true로 설정

        timeRemaining = minutes * 60 + seconds; // 카운트 시간을 초로 변환하기

        sh = FindObjectOfType<SphereVer2>(); // SphereVer2 스크립트를 가지고 있는 오브젝트 할당

    }

    // Update is called once per frame
    void Update()
    {
        if (IsGame == true)
        {
            if (timeRemaining > 0.0f)
            {
                // 현재 남은 시간이 0.0초보다 크다면
                // timeRemaining 을 프레임 단위 감소
                timeRemaining -= Time.deltaTime;
            }
            else
            { 
                TimeOver.SetActive(true); // 타임오버 오브젝트 활성화
                IsGame = false; // 현재 게임 상태를 false로 변경

                Time.timeScale = 0f; // 게임 시간을  0으로 설정

                float bestScores = PlayerPrefs.GetFloat("BestScore"); // PlayerPrefs안에 BestScsore에 저장된 float값을 할당

                sh.TimeOver(); // SphereVer2 스크립트 안에있는 TimeOver 메서드를 실행

                if(score > bestScores) // 현재 점수가 최고 점수보다 크다면
                {
                    bestScores = score; // 현재 점수를 최고 점수안에 저장

                    PlayerPrefs.SetFloat("BestScore", bestScores); // PlayerPrefs안에 BestScore키에 bestScore값을 저장
                }
                BestScore.text = "Best-Score : " + bestScores; // 최고점수를 BestScore text 에 표시
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                // SceneManager : 씬을 로드, 언로드하거나 정보를 가져오는 데 사용
                // LoadScene : 특정 이름의 씬을 로드한다
                // SceneManager.GetActiveScene().name : 현재 실행중인 씬에 이름을 가져온다

                // 현재 실행중인 씬을 다시 실행
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1f; // 게임 시간을 1로 설정
            }
        }
        // timeRemaining을 60으로 나누어 분으로 변환한 값을 저장
        int displayMinutes = (int)(timeRemaining / 60);
        // timeRemaining을 60으로 나눈 나머지 값을 초로 저장
        int displaySeconds = (int)(timeRemaining % 60);

        // 분 : 초를 timerText 에 표시
        timerText.text = $"{displayMinutes:00}:{displaySeconds:00}";
    }

    public void Scores()
    {
        // score에 1더하기
        score = score + 1;
        // Score text를 변환
        Score.text = "Score : " + score;
        // MyScsore text를 변환
        MyScore.text = "MyScore-Score : " + score;
    }

    public void timeOver()
    {
        // IsGame를 false로 변환
        IsGame = false;
    }
}
