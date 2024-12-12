using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Game : MonoBehaviour
{
    Vector3 MyTransform; // ���� �� ��ġ 

    int[] count = new int[8]; // ������ �� ī��Ʈ
    float[] X = new float[8]; // X ��ǥ ����
    float Y;                  // Y ��ǥ ����
    float[] Z = new float[8]; // Z ��ǥ ����

    Test test;

    private void Start()
    {
        // ���� �� ��ġ�� ����
        MyTransform = transform.position;

        test = FindObjectOfType<Test>();

        for (int i = 0; X.Length > i; i++)
        {
            // ���� �� ��ǥ�� ������ ����
            X[i] = MyTransform.x;
            Y = MyTransform.y + 1.5f;
            Z[i] = MyTransform.z;

            // ī��Ʈ�� 2�� ����
            count[i] = 2;
        }
    }

    private void Update()
    {
        for (int i = 0; X.Length > i; i++)
        {
            // ������ �� ������ 5���� �ȴٸ� �¸� �޼��� ���
            if (count[i] > 5)
            {
                test.Win = true;
                test.WinName = gameObject.tag;
                //Debug.Log(gameObject.name + "Win");
            }
        }

        // ������ �� ���� ���� �ż���
        Top();
        Right();
        Left();
        TopRight();
        TopLeft();
        BottomRight();
        BottomLeft();
        Bottom();

    }

    private void Top() // ��
    {
        // ������ �ʱ���ġ ����
        Vector3 vector1 = new Vector3(X[0], Y, Z[0] + 2);

        // vector1 ��ġ���� 1��ǥ�� �ִ� ������Ʈ�� ����
        Collider[] colls1 = Physics.OverlapSphere(vector1, 1f);

        // ���� ����
        if (colls1.Length == 0)
        {
            //Debug.Log("�浹ü ����");
            return;
        }

        // ������ ������Ʈ �±׸� ���ڿ� Ÿ������ ����
        string a1 = colls1[0].tag;

        {
            // ������ ������Ʈ�� ���� ������Ʈ�� �±װ� ���� �ʴٸ�
            if (a1 != gameObject.tag)
            {
                // �ܼ�â�� "����" ���
                //Debug.Log(gameObject.tag + "����");
            }
            // ������ ������Ʈ�� ���� ������Ʈ�� �±װ� ���ٸ�
            else if (a1 == gameObject.tag)
            {
                // ī��Ʈ�� 1�� ���ϰ�
                // ������ ��ǥ�� 2���Ѵ�
                //Debug.Log(count[0]);
                count[0]++;
                Z[0] += 2;
                //Debug.Log(vector1 + gameObject.tag + "�ִ�");
            }
        }
    }
    void TopRight() // ���
    {
        Vector3 vector2 = new Vector3(X[1] + 2, Y, Z[1] + 2);

        Collider[] colls2 = Physics.OverlapSphere(vector2, 1f);

        if (colls2.Length == 0)
        {
            //Debug.Log("�浹ü ����");
            return;
        }


        string a2 = colls2[0].tag;

        {
            if (a2 != gameObject.tag)
            {
                //Debug.Log(gameObject.tag + "����");
            }
            else if (a2 == gameObject.tag)
            {
                //Debug.Log(count[1]);
                count[1]++;
                X[1] += 2;
                Z[1] += 2;
                //Debug.Log(vector2 + gameObject.tag + "�ִ�");
            }
        }
    }

    void TopLeft() // ����
    {
        Vector3 vector3 = new Vector3(X[2] - 2, Y, Z[2] + 2);

        Collider[] colls3 = Physics.OverlapSphere(vector3, 1f);

        if (colls3.Length == 0)
        {
            //Debug.Log("�浹ü ����");
            return;
        }


        string a3 = colls3[0].tag;

        {
            if (a3 != gameObject.tag)
            {
                //Debug.Log(gameObject.tag + "����");
            }
            else if (a3 == gameObject.tag)
            {
                //Debug.Log(count[2]);
                count[2]++;
                X[2] -= 2;
                Z[2] += 2;
               //Debug.Log(vector3 + gameObject.tag + "�ִ�");
            }
        }
    }
    private void Right() // ��
    {
        Vector3 vector4 = new Vector3(X[3] + 2, Y, Z[3]);

        Collider[] colls4 = Physics.OverlapSphere(vector4, 1f);

        if (colls4.Length == 0)
        {
            //Debug.Log("�浹ü ����");
            return;
        }

        string a4 = colls4[0].tag;

        {
            if (a4 != gameObject.tag)
            {
                //Debug.Log(gameObject.tag + "����");
            }
            else if (a4 == gameObject.tag)
            {
                //Debug.Log(count[3]);
                count[3]++;
                X[3] += 2;
                //Debug.Log(vector4 + gameObject.tag + "�ִ�");
            }
        }
    }
    private void Left() // ��
    {
        Vector3 vector5 = new Vector3(X[4] - 2, Y, Z[4]);

        Collider[] colls5 = Physics.OverlapSphere(vector5, 1f);

        if (colls5.Length == 0)
        {
            //Debug.Log("�浹ü ����");
            return;
        }

        string a5 = colls5[0].tag;

        {
            if (a5 != gameObject.tag)
            {
                //Debug.Log(gameObject.tag + "����");
            }
            else if (a5 == gameObject.tag)
            {
               //Debug.Log(count[4]);
                count[4]++;
                X[4] -= 2;
                //Debug.Log(vector5 + gameObject.tag + "�ִ�");
            }
        }
    }

    private void Bottom() // ��
    {
        Vector3 vector6 = new Vector3(X[5], Y, Z[5] - 2);

        Collider[] colls6 = Physics.OverlapSphere(vector6, 1f);

        if (colls6.Length == 0)
        {
            //Debug.Log("�浹ü ����");
            return;
        }


        string a6 = colls6[0].tag;

        {
            if (a6 != gameObject.tag)
            {
                //Debug.Log(gameObject.tag + "����");
            }
            else if (a6 == gameObject.tag)
            {
                //Debug.Log(count[5]);
                count[5]++;
                Z[5] -= 2;
                //Debug.Log(vector6 + gameObject.tag + "�ִ�");
            }
        }
    }

    void BottomRight() // �Ͽ�
    {
        Vector3 vector7 = new Vector3(X[6] + 2, Y, Z[6] - 2);

        Collider[] colls7 = Physics.OverlapSphere(vector7, 1f);

        if (colls7.Length == 0)
        {
            //Debug.Log("�浹ü ����");
            return;
        }


        string a7 = colls7[0].tag;

        {
            if (a7 != gameObject.tag)
            {
                //Debug.Log(gameObject.tag + "����");
            }
            else if (a7 == gameObject.tag)
            {
               //Debug.Log(count[6]);
                count[6]++;
                X[6] += 2;
                Z[6] -= 2;
                //Debug.Log(vector7 + gameObject.tag + "�ִ�");
            }
        }
    }

    void BottomLeft() // ����
    {
        Vector3 vector8 = new Vector3(X[7] - 2, Y, Z[7] - 2);

        Collider[] colls8 = Physics.OverlapSphere(vector8, 1f);

        if (colls8.Length == 0)
        {
            //Debug.Log("�浹ü ����");
            return;
        }


        string a8 = colls8[0].tag;

        {
            if (a8 != gameObject.tag)
            {
                //Debug.Log(gameObject.tag + "����");
            }
            else if (a8 == gameObject.tag)
            {
                //Debug.Log(count[7]);
                count[7]++;
                X[7] -= 2;
                Z[7] -= 2;
                //Debug.Log(vector8 + gameObject.tag + "�ִ�");
            }
        }
    }

}
