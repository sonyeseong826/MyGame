using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    // �ð�
    public int minutes = 0; // ��
    public int seconds = 30; // ��

    //�ΰ���
    public Text timerText; // ī��Ʈ text ������Ʈ
    public Text Score; // ���� text ������Ʈ

    // Ÿ�� ������
    public Text BestScore; // �ְ� ���� text ������Ʈ
    public Text MyScore; // �� ���� ���� text ������Ʈ
    public GameObject TimeOver; // ���ӿ��� ������Ʈ

    private float timeRemaining; // ���� ī��Ʈ ��� ��ü
    public int score; // ���� ��ü
    public bool IsGame; // ���� ���� ����

    SphereVer2 sh;  // SphereVer2 ��ũ��Ʈ

    void Start()
    {
        TimeOver.SetActive(false); // Ÿ�ӿ��� ������Ʈ ��Ȱ��ȭ
        score = 0; // ������ 0���� �ʱ�ȭ
        IsGame = true; // ���� ���� ���¸� true�� ����

        timeRemaining = minutes * 60 + seconds; // ī��Ʈ �ð��� �ʷ� ��ȯ�ϱ�

        sh = FindObjectOfType<SphereVer2>(); // SphereVer2 ��ũ��Ʈ�� ������ �ִ� ������Ʈ �Ҵ�

    }

    // Update is called once per frame
    void Update()
    {
        if (IsGame == true)
        {
            if (timeRemaining > 0.0f)
            {
                // ���� ���� �ð��� 0.0�ʺ��� ũ�ٸ�
                // timeRemaining �� ������ ���� ����
                timeRemaining -= Time.deltaTime;
            }
            else
            { 
                TimeOver.SetActive(true); // Ÿ�ӿ��� ������Ʈ Ȱ��ȭ
                IsGame = false; // ���� ���� ���¸� false�� ����

                Time.timeScale = 0f; // ���� �ð���  0���� ����

                float bestScores = PlayerPrefs.GetFloat("BestScore"); // PlayerPrefs�ȿ� BestScsore�� ����� float���� �Ҵ�

                sh.TimeOver(); // SphereVer2 ��ũ��Ʈ �ȿ��ִ� TimeOver �޼��带 ����

                if(score > bestScores) // ���� ������ �ְ� �������� ũ�ٸ�
                {
                    bestScores = score; // ���� ������ �ְ� �����ȿ� ����

                    PlayerPrefs.SetFloat("BestScore", bestScores); // PlayerPrefs�ȿ� BestScoreŰ�� bestScore���� ����
                }
                BestScore.text = "Best-Score : " + bestScores; // �ְ������� BestScore text �� ǥ��
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                // SceneManager : ���� �ε�, ��ε��ϰų� ������ �������� �� ���
                // LoadScene : Ư�� �̸��� ���� �ε��Ѵ�
                // SceneManager.GetActiveScene().name : ���� �������� ���� �̸��� �����´�

                // ���� �������� ���� �ٽ� ����
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1f; // ���� �ð��� 1�� ����
            }
        }
        // timeRemaining�� 60���� ������ ������ ��ȯ�� ���� ����
        int displayMinutes = (int)(timeRemaining / 60);
        // timeRemaining�� 60���� ���� ������ ���� �ʷ� ����
        int displaySeconds = (int)(timeRemaining % 60);

        // �� : �ʸ� timerText �� ǥ��
        timerText.text = $"{displayMinutes:00}:{displaySeconds:00}";
    }

    public void Scores()
    {
        // score�� 1���ϱ�
        score = score + 1;
        // Score text�� ��ȯ
        Score.text = "Score : " + score;
        // MyScsore text�� ��ȯ
        MyScore.text = "MyScore-Score : " + score;
    }

    public void timeOver()
    {
        // IsGame�� false�� ��ȯ
        IsGame = false;
    }
}
