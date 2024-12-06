using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private int count = 0; // 클릭한 횟수
    public TextMeshPro COUNT; // 인게임 실시간으로 변할 COUNT text 컴포넌트

    private float Timer = 10f; // 기본 카운트
    public Text time; // 카운트 UI 컴포넌트

    public TextMeshPro text; // 타임오버 최종 카운트
    public GameObject TimeOver; // 타임오버 오브젝트

    public bool IsGame = true; // 현재 게임 상태
    void Start()
    {
        TimeOver.SetActive(false); // 타임오버 오브젝트 비활성화
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer > 0) // 현재 카운트가 0 보다 크다면
        {
            Timer -= Time.deltaTime; // 시간을 프레임 단위로 감소
            time.text = string.Format("{0:N2}", Timer); // 현재 시간을 time 오브젝트에 표시
        }
        else
        {
            Time.timeScale = 0f; // 게임 시간을 0으로 변경
            Timer = 0f; // 현재 시간이 음수로 가는것을 방지
            TimeOver.SetActive(true); // 타임오버 오브젝트를 활정화
            IsGame = false; // 게임 상태를 false로 변경
        }
    }

    public void Count()
    {
        count++; // 카운트에 1더하기
        text.text = "SCORE : " + count; // count를 text 오브젝트에 표시
        COUNT.text = count.ToString();  // 마지막 내 점수를 COUNT text 오브젝트에 표시
    }
}
