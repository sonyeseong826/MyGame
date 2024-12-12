using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Game : MonoBehaviour
{
    bool IsGame = true;
    Vector3 MyTransform;

    int[] count = new int[8];

    float[] X = new float[8];
    float Y;
    float[] Z = new float[8];
    private void Start()
    {
        MyTransform = transform.position;

        for(int i = 0; X.Length > i; i++)
        {
            X[i] = MyTransform.x;
            Y = MyTransform.y + 1.5f;
            Z[i] = MyTransform.z;

            count[i] = 2;
        }
    }

    private void Update()
    {
        for(int i = 0; X.Length > i; i++)
        {
            if (count[i] > 5)
            {
                Debug.Log(gameObject.name + "승리!");
                return;
            }
        }

        Top();
        Right();
        Left();
        TopRight();
        TopLeft();
        BottomRight();
        BottomLeft();
        Bottom();
    }

    private void Top()
    {
        Vector3 vector1 = new Vector3(X[0], Y, Z[0] + 2);

        Collider[] colls1 = Physics.OverlapSphere(vector1, 1f);

        if (colls1.Length == 0)
        {
            Debug.Log("충돌체 없음");
            return;
        }


        string a = colls1[0].tag;

        {
            if (a != gameObject.tag)
            {
                Debug.Log(gameObject.tag + "없다");
            }
            else if (a == gameObject.tag)
            {
                Debug.Log(count[0]);
                count[0]++;
                Z[0] += 2;
                Debug.Log(vector1 + gameObject.tag + "있다");
            }
        }
    }
    void TopRight()
    {
        Vector3 vector2 = new Vector3(X[1] + 2, Y, Z[1] + 2);

        Collider[] colls2 = Physics.OverlapSphere(vector2, 1f);

        if (colls2.Length == 0)
        {
            Debug.Log("충돌체 없음");
            return;
        }


        string a = colls2[0].tag;

        {
            if (a != gameObject.tag)
            {
                Debug.Log(gameObject.tag + "없다");
            }
            else if (a == gameObject.tag)
            {
                Debug.Log(count[1]);
                count[1]++;
                X[1] += 2;
                Z[1] += 2;
                Debug.Log(vector2 + gameObject.tag + "있다");
            }
        }
    }

    void TopLeft()
    {
        Vector3 vector3 = new Vector3(X - 2, Y, Z + 2);

        Collider[] colls3 = Physics.OverlapSphere(vector3, 1f);

        if (colls3.Length == 0)
        {
            Debug.Log("충돌체 없음");
            return;
        }


        string a = colls3[0].tag;

        {
            if (a != gameObject.tag)
            {
                Debug.Log(gameObject.tag + "없다");
            }
            else if (a == gameObject.tag)
            {
                Debug.Log(count1);
                count1++;
                X -= 2;
                Z += 2;
                Debug.Log(vector3 + gameObject.tag + "있다");
            }
        }
    }
    private void Right()
    {
        Vector3 vector4 = new Vector3(X + 2, Y, Z);

        Collider[] colls4 = Physics.OverlapSphere(vector4, 1f);

        if (colls4.Length == 0)
        {
            Debug.Log("충돌체 없음");
            return;
        }

        string a = colls4[0].tag;

        {
            if (a != gameObject.tag)
            {
                Debug.Log(gameObject.tag + "없다");
            }
            else if (a == gameObject.tag)
            {
                Debug.Log(count1);
                count1++;
                X += 2;
                Debug.Log(vector4 + gameObject.tag + "있다");
            }
        }
    }
    private void Left()
    {
        Vector3 vector5 = new Vector3(X - 2, Y, Z);

        Collider[] colls5 = Physics.OverlapSphere(vector5, 1f);

        if (colls5.Length == 0)
        {
            Debug.Log("충돌체 없음");
            return;
        }

        string a = colls5[0].tag;

        {
            if (a != gameObject.tag)
            {
                Debug.Log(gameObject.tag + "없다");
            }
            else if (a == gameObject.tag)
            {
                Debug.Log(count1);
                count1++;
                X -= 2;
                Debug.Log(vector1 + gameObject.tag + "있다");
            }
        }
    }

    private void Bottom()
    {
        Vector3 vector6 = new Vector3(X, Y, Z - 2);

        Collider[] colls6 = Physics.OverlapSphere(vector6, 1f);

        if (colls6.Length == 0)
        {
            Debug.Log("충돌체 없음");
            return;
        }


        string a = colls6[0].tag;

        {
            if (a != gameObject.tag)
            {
                Debug.Log(gameObject.tag + "없다");
            }
            else if (a == gameObject.tag)
            {
                Debug.Log(count1);
                count1++;
                Z -= 2;
                Debug.Log(vector1 + gameObject.tag + "있다");
            }
        }
    }

    void BottomRight()
    {
        Vector3 vector7 = new Vector3(X + 2, Y, Z - 2);

        Collider[] colls7 = Physics.OverlapSphere(vector7, 1f);

        if (colls7.Length == 0)
        {
            Debug.Log("충돌체 없음");
            return;
        }


        string a = colls7[0].tag;

        {
            if (a != gameObject.tag)
            {
                Debug.Log(gameObject.tag + "없다");
            }
            else if (a == gameObject.tag)
            {
                Debug.Log(count1);
                count1++;
                X += 2;
                Z -= 2;
                Debug.Log(vector1 + gameObject.tag + "있다");
            }
        }
    }

    void BottomLeft()
    {
        Vector3 vector8 = new Vector3(X - 2, Y, Z - 2);

        Collider[] colls8 = Physics.OverlapSphere(vector8, 1f);

        if (colls8.Length == 0)
        {
            Debug.Log("충돌체 없음");
            return;
        }


        string a = colls8[0].tag;

        {
            if (a != gameObject.tag)
            {
                Debug.Log(gameObject.tag + "없다");
            }
            else if (a == gameObject.tag)
            {
                Debug.Log(count1);
                count1++;
                X -= 2;
                Z -= 2;
                Debug.Log(vector1 + gameObject.tag + "있다");
            }
        }
    }

}
