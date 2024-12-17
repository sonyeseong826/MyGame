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

    public Text text;
    public RectTransform rectTransform;



    // Y : 190, -140, -470, -800 : -330
    // X : -500, -165, 165, 500 : +330

    int Count;
    void Start()
    {
        Count = 0;

        v2 = rectTransform.localPosition;

        Debug.Log(v2);

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
        CubeMove();

        if(Input.GetKeyDown(KeyCode.W))
        {
            Test();
        }
    }

    async void CubeMove()
    {
        // 아래클릭
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            while (v2.y > -800)
            {
                v2.y -= 30;

                rectTransform.localPosition = v2;

                await Task.Delay(1);
            }
        }

        // 위클릭
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            while (v2.y < 190)
            {
                v2.y += 30;

                rectTransform.localPosition = v2;

                await Task.Delay(1);
            }
        }

        // 오른쪽 클릭
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            while (v2.x < 495)
            {
                if (v2.x > 495)
                {
                    v2.x = 495;
                    rectTransform.localPosition = v2;
                }
                else if (v2.x < 495)
                {
                    v2.x += 50;

                    rectTransform.localPosition = v2;

                    await Task.Delay(5);
                }
            }

        }

        // 왼쪽 클릭
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            while (v2.x > -495)
            {
                v2.x -= 50;

                rectTransform.localPosition = v2;

                await Task.Delay(5);
            }
        }
    }

    void Test()
    {

        for(float x = rectTransform.localPosition.x; x <= 495; x += 330)
        {
            Debug.Log(x);
        }
    }
}
