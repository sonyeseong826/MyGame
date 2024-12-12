using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Game : MonoBehaviour
{
    Vector3 MyTransform; // 현재 돌 위치 

    int[] count = new int[8]; // 나열된 돌 카운트
    float[] X = new float[8]; // X 좌표 감지
    float Y;                  // Y 좌표 감지
    float[] Z = new float[8]; // Z 좌표 감지

    Test test;

    private void Start()
    {
        // 현재 돌 위치를 저장
        MyTransform = transform.position;

        test = FindObjectOfType<Test>();

        for (int i = 0; X.Length > i; i++)
        {
            // 현재 돌 좌표를 나누어 저장
            X[i] = MyTransform.x;
            Y = MyTransform.y + 1.5f;
            Z[i] = MyTransform.z;

            // 카운트를 2로 저장
            count[i] = 2;
        }
    }

    private void Update()
    {
        for (int i = 0; X.Length > i; i++)
        {
            // 나열된 돌 갯수가 5개가 된다면 승리 메세지 출력
            if (count[i] > 5)
            {
                test.Win = true;
                test.WinName = gameObject.tag;
                //Debug.Log(gameObject.name + "Win");
            }
        }

        // 나열된 돌 갯수 감지 매서드
        Top();
        Right();
        Left();
        TopRight();
        TopLeft();
        BottomRight();
        BottomLeft();
        Bottom();

    }

    private void Top() // 상
    {
        // 감지할 초기위치 지정
        Vector3 vector1 = new Vector3(X[0], Y, Z[0] + 2);

        // vector1 위치에서 1좌표에 있는 오브젝트를 저장
        Collider[] colls1 = Physics.OverlapSphere(vector1, 1f);

        // 오류 방지
        if (colls1.Length == 0)
        {
            //Debug.Log("충돌체 없음");
            return;
        }

        // 감지한 오브젝트 태그를 문자열 타입으로 저장
        string a1 = colls1[0].tag;

        {
            // 감지한 오브젝트가 현재 오브젝트와 태그가 같지 않다면
            if (a1 != gameObject.tag)
            {
                // 콘솔창에 "없다" 출력
                //Debug.Log(gameObject.tag + "없다");
            }
            // 감지한 오브젝트가 현재 오브젝트와 태그가 같다면
            else if (a1 == gameObject.tag)
            {
                // 카운트에 1을 더하고
                // 감지할 좌표를 2더한다
                //Debug.Log(count[0]);
                count[0]++;
                Z[0] += 2;
                //Debug.Log(vector1 + gameObject.tag + "있다");
            }
        }
    }
    void TopRight() // 상우
    {
        Vector3 vector2 = new Vector3(X[1] + 2, Y, Z[1] + 2);

        Collider[] colls2 = Physics.OverlapSphere(vector2, 1f);

        if (colls2.Length == 0)
        {
            //Debug.Log("충돌체 없음");
            return;
        }


        string a2 = colls2[0].tag;

        {
            if (a2 != gameObject.tag)
            {
                //Debug.Log(gameObject.tag + "없다");
            }
            else if (a2 == gameObject.tag)
            {
                //Debug.Log(count[1]);
                count[1]++;
                X[1] += 2;
                Z[1] += 2;
                //Debug.Log(vector2 + gameObject.tag + "있다");
            }
        }
    }

    void TopLeft() // 상좌
    {
        Vector3 vector3 = new Vector3(X[2] - 2, Y, Z[2] + 2);

        Collider[] colls3 = Physics.OverlapSphere(vector3, 1f);

        if (colls3.Length == 0)
        {
            //Debug.Log("충돌체 없음");
            return;
        }


        string a3 = colls3[0].tag;

        {
            if (a3 != gameObject.tag)
            {
                //Debug.Log(gameObject.tag + "없다");
            }
            else if (a3 == gameObject.tag)
            {
                //Debug.Log(count[2]);
                count[2]++;
                X[2] -= 2;
                Z[2] += 2;
               //Debug.Log(vector3 + gameObject.tag + "있다");
            }
        }
    }
    private void Right() // 우
    {
        Vector3 vector4 = new Vector3(X[3] + 2, Y, Z[3]);

        Collider[] colls4 = Physics.OverlapSphere(vector4, 1f);

        if (colls4.Length == 0)
        {
            //Debug.Log("충돌체 없음");
            return;
        }

        string a4 = colls4[0].tag;

        {
            if (a4 != gameObject.tag)
            {
                //Debug.Log(gameObject.tag + "없다");
            }
            else if (a4 == gameObject.tag)
            {
                //Debug.Log(count[3]);
                count[3]++;
                X[3] += 2;
                //Debug.Log(vector4 + gameObject.tag + "있다");
            }
        }
    }
    private void Left() // 좌
    {
        Vector3 vector5 = new Vector3(X[4] - 2, Y, Z[4]);

        Collider[] colls5 = Physics.OverlapSphere(vector5, 1f);

        if (colls5.Length == 0)
        {
            //Debug.Log("충돌체 없음");
            return;
        }

        string a5 = colls5[0].tag;

        {
            if (a5 != gameObject.tag)
            {
                //Debug.Log(gameObject.tag + "없다");
            }
            else if (a5 == gameObject.tag)
            {
               //Debug.Log(count[4]);
                count[4]++;
                X[4] -= 2;
                //Debug.Log(vector5 + gameObject.tag + "있다");
            }
        }
    }

    private void Bottom() // 하
    {
        Vector3 vector6 = new Vector3(X[5], Y, Z[5] - 2);

        Collider[] colls6 = Physics.OverlapSphere(vector6, 1f);

        if (colls6.Length == 0)
        {
            //Debug.Log("충돌체 없음");
            return;
        }


        string a6 = colls6[0].tag;

        {
            if (a6 != gameObject.tag)
            {
                //Debug.Log(gameObject.tag + "없다");
            }
            else if (a6 == gameObject.tag)
            {
                //Debug.Log(count[5]);
                count[5]++;
                Z[5] -= 2;
                //Debug.Log(vector6 + gameObject.tag + "있다");
            }
        }
    }

    void BottomRight() // 하우
    {
        Vector3 vector7 = new Vector3(X[6] + 2, Y, Z[6] - 2);

        Collider[] colls7 = Physics.OverlapSphere(vector7, 1f);

        if (colls7.Length == 0)
        {
            //Debug.Log("충돌체 없음");
            return;
        }


        string a7 = colls7[0].tag;

        {
            if (a7 != gameObject.tag)
            {
                //Debug.Log(gameObject.tag + "없다");
            }
            else if (a7 == gameObject.tag)
            {
               //Debug.Log(count[6]);
                count[6]++;
                X[6] += 2;
                Z[6] -= 2;
                //Debug.Log(vector7 + gameObject.tag + "있다");
            }
        }
    }

    void BottomLeft() // 하좌
    {
        Vector3 vector8 = new Vector3(X[7] - 2, Y, Z[7] - 2);

        Collider[] colls8 = Physics.OverlapSphere(vector8, 1f);

        if (colls8.Length == 0)
        {
            //Debug.Log("충돌체 없음");
            return;
        }


        string a8 = colls8[0].tag;

        {
            if (a8 != gameObject.tag)
            {
                //Debug.Log(gameObject.tag + "없다");
            }
            else if (a8 == gameObject.tag)
            {
                //Debug.Log(count[7]);
                count[7]++;
                X[7] -= 2;
                Z[7] -= 2;
                //Debug.Log(vector8 + gameObject.tag + "있다");
            }
        }
    }

}
