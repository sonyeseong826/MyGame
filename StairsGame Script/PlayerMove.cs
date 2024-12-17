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
            Debug.Log("�����");
        }
        else
        {
            Debug.Log("������");
        }
    }

    public void Rotation()
    {
        if (!TF) // ȸ�� ���°� false�� ���¿��� ȸ��
        {
            st.StairsSpawn(); // ��� �ϳ� ����

            count++; // ī��Ʈ ����

            // ��ܿ�����Ʈ �ֱ�
            StairsObject = GameObject.Find(name);

            // ��� ��°� ����
            X -= 0.8f;
            Y += 0.4f;


            // ��� ������Ʈ ��ǥ ����
            SpawnPosition = new Vector2(X, Y);

            // �÷��̾� ������ ��ǥ�� �ֱ�
            transform.position = new Vector2(X, Y);

            // ��� ������Ʈ ����
            name = $"Stairs {count.ToString()}";
            Debug.Log(TF);

            // �¿���ȭ�� true�� ����
            TF = true;

        }
        else // ȸ�� ���°� true�� ���¿��� ȸ��
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
            else // ȸ�� ���°� true�� ���¿��� ����
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

        if (!TF) //ȸ�� ���°� true�� ���¿��� ����
        {
            if (count < 1) // ó�� ���ʷ� ������ ������ ù������� �̵�
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
            else // ���ķ� ��� ����
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
