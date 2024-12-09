using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sphere : MonoBehaviour
{
    public Vector2 Max = new Vector2(0.5f, 0.5f); // ��ư�� ������ �ִ� ��ǥ
    public Vector2 Min = new Vector2(-0.5f, -0.5f); // ��ư�� ������ �ּ� ��ǥ

    Game game; // ���� ��Ʈ��Ʈ

    private void Start()
    {
        game = FindObjectOfType<Game>(); // �ΰ��ӿ� Game ��ũ��Ʈ�� �پ��ִ� ������Ʈ �Ҵ�
    }

    private void OnMouseDown()
    {
        if (game.IsGame) // ���� ���°� true���
        {
            StartCoroutine(MoveRandomly()); // MoveRandomIy�� �ڷ�ƾ���� ����

            // * �ڷ�ƾ : �ð��� ���� �۾��� ������ ó���ϱ� ���� ���Ǵ� Ư�� �Լ�
        }
        else
        {
            return;
            // �ƴ϶�� ���� ����
        }
    }

    // IEnumerator�� ����Ͽ� ������ ������ ������ �����ϴ� �۾��� ���� ����
    private IEnumerator MoveRandomly()
    {
        for (int i = 0; i < 5; i++)
        {
            float RandomX = Random.Range(Max.x, Min.x); // Max.x �� Min,x ���̿� ������ ���ڸ� �Ҵ�
            float RandomY = Random.Range(Max.y, Min.y); // Max.y �� Min,y ���̿� ������ ���ڸ� �Ҵ�

            transform.position = new Vector2(RandomX, RandomY); // ���� ������Ʈ�� ��ġ�� RandomX RandomY�� �̵�
            yield return new WaitForSeconds(0.01f); // 0.01�ʸ� ��ٸ���
        }
        transform.position = new Vector2(0, 0); // �ݺ����� ������ ���� ������Ʈ�� ��ġ�� �ʱ�ȭ
        game.Count(); // Game ��ũ��Ʈ�� Count �޼��带 �����Ѵ�
    }
}
