using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inven : MonoBehaviour
{
    public RectTransform rect; // UI Transform ������Ʈ
    public int blocks; // �κ��丮 ��ȣ
    int hys = 1; // �� �κ��丮
    // Start is called before the first frame update
    void Start()
    {
        rect.anchoredPosition = new Vector2(-280, -490); // �κ��丮 UI ù ��ġ
        blocks = 1; // �κ��丮 ù ��ȣ
    }

    // Update is called once per frame
    void Update()
    {
        hy();

        // Ű���� 1���� �����ų� �� ��ȣ�� 1�� ���
        if (Input.GetKeyDown(KeyCode.Alpha1) || hys == 1)
        {
            // �κ��丮 UI�� �̵�
            rect.anchoredPosition = new Vector2(-280, -490);
            // �ι��丮 ��ȣ�� 1�� ����
            blocks = 1;
            // �� ��ȣ�� 1������ ����
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
        // ���콺 �Է��� ��
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");

        // ���� �ּ� �ִ밪
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
