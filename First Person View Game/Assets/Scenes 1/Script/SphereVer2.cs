using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereVer2 : MonoBehaviour
{
    public Vector3 Max = new Vector3(3.5f, 0.7f, 7.5f); // ���� �̵��� �ִ� ��
    public Vector3 Min = new Vector3(-3.5f, 5.3f, 7.5f); // ���� �̵��� �ּ� ��

    bool IsGame = true; // ���� ���� ����

    Game game; // Game ��ũ��Ʈ
    
    void Start()
    {
        game = FindObjectOfType<Game>(); // �ΰ��ӿ� Game ��ũ��Ʈ�� ������ �ִ� ������Ʈ�� �Ҵ�
    }

    void Update()
    {
        if(!IsGame) return; // ���ӻ��°� false ��� ���� ����
    }

    private void OnMouseDown()
    {
        if (IsGame == true)
        {
            float RandomX = Random.Range(Max.x, Min.x); // Max.x Min.x ���̿� ������ ���� �Ҵ�
            float RandomY = Random.Range(Max.y, Min.y); // Max.y Min.y ���̿� ������ ���� �Ҵ�

            transform.position = new Vector3(RandomX, RandomY, 7.5f); // ���� ������Ʈ ��ġ�� RandomX RandomY ������ �̵�

            game.Scores(); // Game ��ũ��Ʈ�� Score �޼��� ����
        }
    }

    public void TimeOver()
    {
        IsGame = false; // ���ӻ��¸� false�� ����
    }
}
