using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inven : MonoBehaviour
{
    public RectTransform rect; // UI Transform 컴포넌트
    public int blocks; // 인벤토리 번호
    int hys = 1; // 휠 인벤토리
    // Start is called before the first frame update
    void Start()
    {
        rect.anchoredPosition = new Vector2(-280, -490); // 인벤토리 UI 첫 위치
        blocks = 1; // 인벤토리 첫 번호
    }

    // Update is called once per frame
    void Update()
    {
        hy();

        // 키보드 1번을 누르거나 휠 번호가 1일 경우
        if (Input.GetKeyDown(KeyCode.Alpha1) || hys == 1)
        {
            // 인벤토리 UI를 이동
            rect.anchoredPosition = new Vector2(-280, -490);
            // 인번토리 번호를 1로 지정
            blocks = 1;
            // 휠 번호를 1번으로 지정
            hys = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || hys == 2)
        {
            rect.anchoredPosition = new Vector2(-160, -490);
            blocks = 2;
            hys = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || hys == 3)
        {
            rect.anchoredPosition = new Vector2(-40, -490);
            blocks = 3;
            hys = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || hys == 4)
        {
            rect.anchoredPosition = new Vector2(80, -490);
            blocks = 4;
            hys = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) || hys == 5)
        {
            rect.anchoredPosition = new Vector2(200, -490);
            blocks = 5;
            hys = 5;
        }
    }
    void hy()
    {
        // 마우스 입력축 값
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");

        // 휠이 최소 최대값
        if (wheelInput > 0)
        {
            hys--;
            if(hys < 1)
            {
                hys = 5;
            }
        }
        else if (wheelInput < 0)

        {
            hys++;
            if (hys > 5)
            {
                hys = 1;
            }
        }
    }
}
