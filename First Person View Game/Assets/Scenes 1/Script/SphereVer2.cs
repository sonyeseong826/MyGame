using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereVer2 : MonoBehaviour
{
    public Vector3 Max = new Vector3(3.5f, 0.7f, 7.5f); // 공이 이동할 최대 값
    public Vector3 Min = new Vector3(-3.5f, 5.3f, 7.5f); // 공이 이동할 최소 값

    bool IsGame = true; // 현재 게임 상태

    Game game; // Game 스크립트
    
    void Start()
    {
        game = FindObjectOfType<Game>(); // 인게임에 Game 스크립트를 가지고 있는 오브젝트를 할당
    }

    void Update()
    {
        if(!IsGame) return; // 게임상태가 false 라면 실행 안함
    }

    private void OnMouseDown()
    {
        if (IsGame == true)
        {
            float RandomX = Random.Range(Max.x, Min.x); // Max.x Min.x 사이에 랜덤한 값을 할당
            float RandomY = Random.Range(Max.y, Min.y); // Max.y Min.y 사이에 랜덤한 값을 할당

            transform.position = new Vector3(RandomX, RandomY, 7.5f); // 현재 오브젝트 위치를 RandomX RandomY 위에로 이동

            game.Scores(); // Game 스크립트에 Score 메서드 실행
        }
    }

    public void TimeOver()
    {
        IsGame = false; // 게임상태를 false로 변경
    }
}
