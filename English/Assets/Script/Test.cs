using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{
    // 감지할 3D 공간의 좌표
    public Vector3 targetWorldPosition = new Vector3(0, 0, 0); // 목표 좌표
    public float detectionRadius = 1f; // 감지 반경

    public float TestX;
    public float TestZ;

    public GameObject BadukW;
    public GameObject BadukB;
    Vector3 spawnPosition;
    Quaternion spawnRotation = Quaternion.identity;

    int Bcount = 1;
    int Wcount = 1;
    int IsGame = 0;

    private void Start()
    {
    }

    void Update()
    {
        GetBaduk();
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

            if (TestX % 2 != 0)
            {
                TestX--;
            }
            if (TestZ % 2 != 0)
            {
                TestZ--;
            }


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag != "Baduk W" && hit.transform.gameObject.tag != "Baduk B")
                {
                    if(IsGame == 0)
                    {
                        spawnPosition = new Vector3(TestX, 0f, TestZ);
                        GameObject spawn = Instantiate(BadukW, spawnPosition, spawnRotation);
                        string name = $"BadukW : {Wcount.ToString()}";
                        spawn.name = name;
                        IsGame = 1;
                        Wcount++;
                    }
                    else
                    {
                        spawnPosition = new Vector3(TestX, 0f, TestZ);
                        GameObject spawn = Instantiate(BadukB, spawnPosition, spawnRotation);
                        string name = $"BadukB : {Bcount.ToString()}";
                        spawn.name = name;
                        IsGame = 0;
                        Bcount++;
                    }
                }
                else
                {
                    Debug.Log("이미있다");
                }
            }
        }
    }
}
