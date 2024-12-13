using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{
    // 감지할 3D 공간의 좌표
    public Vector3 targetWorldPosition = new Vector3(0, 0, 0); // 목표 좌표
    public float detectionRadius = 1f; // 감지 반경

    public float TestX; // 돌 생성할 X좌표
    public float TestZ; // 돌 생성할 Z좌표

    public GameObject BadukW; // 설치할 오브젝트 1
    public GameObject BadukB;
    Vector3 spawnPosition; // 생성할 오브젝트 전체적 좌표
    Quaternion spawnRotation = Quaternion.identity; // 생성할 오브젝트 각도

    int Bcount = 1; // 설치된 검은 돌 갯수
    int Wcount = 1; // 설치된 흰 돌 갯수
    bool IsGame = true; // 돌 교차로 생성 카운트

    public GameObject WinUI; // 승리 UI
    public Text WinText; // 승리 Text
    public bool Win; // 게임 승리 여부
    public string WinName; // 승리한 돌 색

    private void Start()
    {
        // 시작 초기화
        Win = false;
        WinUI.SetActive(false);
    }

    void Update()
    {
        GameWin();

        if (!Win) // 게임 승리 상태 체크
        {
            GetBaduk();
        }
        else
        {
            GameReStart();
        }
    }

    void GetBaduk()
    {
        // 마우스 왼쪽 버튼 클릭 감지
        if (Input.GetMouseButtonDown(0)) // 0: 왼쪽 클릭
        {
            // 현재 마우스 스크린 좌표 출력
            Vector3 mouseScreenPosition = Input.mousePosition;

            // 마우스 위치를 월드 좌표로 변환
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, Camera.main.nearClipPlane));

            // 바둑판 좌표로 변환
            Vector3 Baduk = mouseWorldPosition * 100;

            // 좌표 반올림
            TestX = Mathf.Round(Baduk.x);
            TestZ = Mathf.Round(Baduk.z);

            // * 오브젝트 생성 위치 조정
            // 좌표값을 2로 나누었을때 0으로 딱 떨어지지 않으면
            // 좌표값을 1을 뺀다
            if (TestX % 2 != 0)
            {
                TestX--;
            }
            if (TestZ % 2 != 0)
            {
                TestZ--;
            }

            // 마우스 충돌 위치
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // 마우스 충돌된 오브젝트 가져오기
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // * 선택한 위치에 바둑돌이 있는지 체크
                // 마우스로 충돌된 오브젝트 태그 Black또는 White가 아니라면
                if (hit.transform.gameObject.tag != "Black" && hit.transform.gameObject.tag != "White")
                {
                    // 희색 바둑 생성
                    if(IsGame)
                    {
                        // 생성할 오브젝트 위치를 저장
                        spawnPosition = new Vector3(TestX, 0f, TestZ);
                        // 생성할 오브젝트, 위치, 각도 지정
                        GameObject spawn = Instantiate(BadukW, spawnPosition, spawnRotation);
                        // 생성할 오브젝트 이름 설정
                        string name = $"BadukW : {Wcount.ToString()}";
                        // 오브젝트 이름을 변경하여 생성
                        spawn.name = name;
                        // 바둑알 교차로 활성화
                        IsGame = false;
                        // 바둑 카운트
                        Wcount++;
                    }
                    // 검은색 바둑 생성
                    else
                    {
                        spawnPosition = new Vector3(TestX, 0f, TestZ);
                        GameObject spawn = Instantiate(BadukB, spawnPosition, spawnRotation);
                        string name = $"BadukB : {Bcount.ToString()}";
                        spawn.name = name;
                        IsGame = true;
                        Bcount++;
                    }
                }
                else
                {
                    //Debug.Log("이미있다");
                }
            }
        }
    }

    void GameWin()
    {
        if(Win) // 게임 승리 상태라면
        {
            // 텍스트 지정
            WinText.text = WinName + " Win";
            // UI활성화
            WinUI.SetActive(true);
        }
    }

    void GameReStart()
    {
        // 마우스 왼쪽 버튼을 누르면 게임 재시작
        if (Win && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
