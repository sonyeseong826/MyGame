using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sphere : MonoBehaviour
{
    public Vector2 Max = new Vector2(0.5f, 0.5f); // 버튼이 움직일 최대 좌표
    public Vector2 Min = new Vector2(-0.5f, -0.5f); // 버튼이 움직일 최소 좌표

    Game game; // 게임 스트립트

    private void Start()
    {
        game = FindObjectOfType<Game>(); // 인게임에 Game 스크립트가 붙어있는 오브잭트 할당
    }

    private void OnMouseDown()
    {
        if (game.IsGame) // 게임 상태가 true라면
        {
            StartCoroutine(MoveRandomly()); // MoveRandomIy를 코루틴으로 실행

            // * 코루틴 : 시간에 따라 작업을 나누어 처리하기 위해 사용되는 특수 함수
        }
        else
        {
            return;
            // 아니라면 실행 안함
        }
    }

    // IEnumerator을 사용하여 프레임 단위로 나뉘어 실행하는 작업을 구현 가능
    private IEnumerator MoveRandomly()
    {
        for (int i = 0; i < 5; i++)
        {
            float RandomX = Random.Range(Max.x, Min.x); // Max.x 와 Min,x 사이에 랜덤한 숫자를 할당
            float RandomY = Random.Range(Max.y, Min.y); // Max.y 와 Min,y 사이에 랜덤한 숫자를 할당

            transform.position = new Vector2(RandomX, RandomY); // 현재 오브젝트에 위치를 RandomX RandomY로 이동
            yield return new WaitForSeconds(0.01f); // 0.01초를 기다린다
        }
        transform.position = new Vector2(0, 0); // 반복문이 끝나면 현재 오브젝트에 위치를 초기화
        game.Count(); // Game 스크립트에 Count 메서드를 실행한다
    }
}
