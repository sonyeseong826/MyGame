using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    int[] num = { 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048 };

    Image Color1, Color2, Color3, Color4, Color5
        , Color6, Color7, Color8, Color9, Color10, Color11;
    Image image;

    Vector2 v2;
    public bool test;

    public Text text;

    // X : -1.6039, -0.5344, 0.5351, 1.6046 : +1.0695
    // Y : 0.631, -0.4378, -1.5066, -2.5754 : -1.0688

    int Count;
    void Start()
    {
        test = false;

        Count = 0;

        //Color1.color = new Color(238, 228, 218, 255);
        //Color2.color = new Color(238, 225, 201, 255);
        //Color3.color = new Color(243, 178, 122, 255);
        //Color4.color = new Color(246, 150, 100, 255);
        //Color5.color = new Color(247, 124, 95, 255);
        //Color6.color = new Color(247, 95, 59, 255);
        //Color7.color = new Color(237, 208, 115, 255);
        //Color8.color = new Color(236, 203, 98, 255);
        //Color9.color = new Color(237, 201, 80, 255);
        //Color10.color = new Color(237, 197, 63, 255);
        //Color11.color = new Color(237, 194, 46, 255);


        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        v2 = transform.position;
        CubeMove();

        if(Input.GetMouseButtonDown(0))
        {
            papa();
        }
    }

    async void CubeMove()
    {
        // 아래클릭
        if (Input.GetKeyDown(KeyCode.DownArrow) && !test)
        {
            test = true;
            while (test)
            {
                v2.y -= 0.05344f;

                if (transform.position.y <= -2.5754f)
                {
                    transform.position = new Vector2(transform.position.x, -2.5754f);
                    test = false;
                }
                else
                {
                    transform.position = v2;
                }
                await Task.Delay(1);
            }

        }
        // 위클릭
        else if (Input.GetKeyDown(KeyCode.UpArrow) && !test)
        {
            test = true;
            while (test)
            {
                v2.y += 0.05344f;

                if (transform.position.y >= 0.631f)
                {
                    transform.position = new Vector2(transform.position.x, 0.631f);
                    test = false;
  
                }
                else
                {
                    transform.position = v2;
                }
                await Task.Delay(1);
            }

        }
        // 오른쪽 클릭
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !test)
        {
            test = true;
            while (test)
            {
                v2.x += 0.053475f;

                if (transform.position.x >= 1.6046f)
                {
                    transform.position = new Vector2(1.6046f, transform.position.y);
                    test = false;
                }
                else
                {
                    transform.position = v2;
                }

                await Task.Delay(1);
            }

        }
        // 왼쪽 클릭
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !test)
        {
            test = true;
            while (test)
            {
                v2.x -= 0.053475f;

                if(transform.position.x <= -1.6039f)
                {
                    transform.position = new Vector2(-1.6039f , transform.position.y);
                    test = false;
                }
                else
                {
                    transform.position = v2;
                }

                await Task.Delay(1);
            }

        }
    }

    void papa()
    {
        float[] RightX = { 0, 0, 0, 0 };
        int X = 0;

        for (float i = transform.position.x; i < 2.6741f; i += 1.0695f)
        {
            RightX[X] = i;
            Debug.Log(RightX[X]);
            X++;
        }
    }
}
