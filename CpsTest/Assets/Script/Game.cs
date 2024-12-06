using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private int count = 0; // Ŭ���� Ƚ��
    public TextMeshPro COUNT; // �ΰ��� �ǽð����� ���� COUNT text ������Ʈ

    private float Timer = 10f; // �⺻ ī��Ʈ
    public Text time; // ī��Ʈ UI ������Ʈ

    public TextMeshPro text; // Ÿ�ӿ��� ���� ī��Ʈ
    public GameObject TimeOver; // Ÿ�ӿ��� ������Ʈ

    public bool IsGame = true; // ���� ���� ����
    void Start()
    {
        TimeOver.SetActive(false); // Ÿ�ӿ��� ������Ʈ ��Ȱ��ȭ
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer > 0) // ���� ī��Ʈ�� 0 ���� ũ�ٸ�
        {
            Timer -= Time.deltaTime; // �ð��� ������ ������ ����
            time.text = string.Format("{0:N2}", Timer); // ���� �ð��� time ������Ʈ�� ǥ��
        }
        else
        {
            Time.timeScale = 0f; // ���� �ð��� 0���� ����
            Timer = 0f; // ���� �ð��� ������ ���°��� ����
            TimeOver.SetActive(true); // Ÿ�ӿ��� ������Ʈ�� Ȱ��ȭ
            IsGame = false; // ���� ���¸� false�� ����
        }
    }

    public void Count()
    {
        count++; // ī��Ʈ�� 1���ϱ�
        text.text = "SCORE : " + count; // count�� text ������Ʈ�� ǥ��
        COUNT.text = count.ToString();  // ������ �� ������ COUNT text ������Ʈ�� ǥ��
    }
}
