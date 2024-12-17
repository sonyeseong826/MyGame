using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public GameObject StairsObject;
    public Vector2 v2;
    public Vector2 SpawnPosition;
    public string name;
    public int count;
    public bool TF;

    public Text text;

    Stairs st;

    public float X;
    public float Y;
    // Start is called before the first frame update
    void Start()
    {
        st = FindObjectOfType<Stairs>();
        TF = false;

        name = "Stairs 0";
        StairsObject = GameObject.Find(name);
        count = 0;

        X = StairsObject.transform.position.x + 0.8f;
        Y = StairsObject.transform.position.y + 0.4f;

        SpawnPosition = new Vector2(X, Y);
    }

    private void Update()
    {
        text.text = count.ToString();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Stairs")
        {
            Debug.Log("닿았음");
        }
        else
        {
            Debug.Log("떨어짐");
        }
    }

    public void Rotation()
    {
        if (!TF) // 회전 상태가 false인 상태에서 회전
        {
            st.StairsSpawn(); // 계단 하나 생성

            count++; // 카운트 증가

            // 계단오브젝트 넣기
            StairsObject = GameObject.Find(name);

            // 계단 상승값 저장
            X -= 0.8f;
            Y += 0.4f;


            // 계단 오브젝트 좌표 저장
            SpawnPosition = new Vector2(X, Y);

            // 플레이어 저장한 좌표에 넣기
            transform.position = new Vector2(X, Y);

            // 계단 오브젝트 지정
            name = $"Stairs {count.ToString()}";
            Debug.Log(TF);

            // 좌우전화이 true로 저장
            TF = true;

        }
        else // 회전 상태가 true인 상태에서 회전
        {
            st.StairsSpawn();

            count++;

            StairsObject = GameObject.Find(name);

            X += 0.8f;
            Y += 0.4f;

            SpawnPosition = new Vector2(X, Y);

            transform.position = new Vector2(X, Y);
            Debug.Log(TF);

            name = $"Stairs {count.ToString()}";

            TF = false;
        }
    }

    public void EVE()
    {
        if (TF)
        {
            if (count < 1)
            {
                st.StairsSpawn();

                count++;

                StairsObject = GameObject.Find(name);

                X = StairsObject.transform.position.x;
                Y = StairsObject.transform.position.y + 0.9f; ;

                SpawnPosition = new Vector2(X, Y);

                transform.position = new Vector2(X, Y);

                name = $"Stairs {count.ToString()}";
            }
            else // 회전 상태가 true인 상태에서 직진
            {
                st.StairsSpawn();

                count++;

                StairsObject = GameObject.Find(name);

                X -= 0.8f;
                Y += 0.4f; ;

                SpawnPosition = new Vector2(X, Y);

                transform.position = new Vector2(X, Y);

                name = $"Stairs {count.ToString()}";
            }
        }

        if (!TF) //회전 상태가 true인 상태에서 직진
        {
            if (count < 1) // 처음 최초로 직진시 무조건 첫계단으로 이동
            {
                st.StairsSpawn();

                count++;

                StairsObject = GameObject.Find(name);

                X = StairsObject.transform.position.x;
                Y = StairsObject.transform.position.y + 0.9f; ;

                SpawnPosition = new Vector2(X, Y);

                transform.position = new Vector2(X, Y);

                name = $"Stairs {count.ToString()}";
            }
            else // 그후로 계속 직진
            {
                st.StairsSpawn();

                count++;

                StairsObject = GameObject.Find(name);

                X += 0.8f;
                Y += 0.4f; ;

                SpawnPosition = new Vector2(X, Y);

                transform.position = new Vector2(X, Y);

                name = $"Stairs {count.ToString()}";
            }
        }
    }
}
