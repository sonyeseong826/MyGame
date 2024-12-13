using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{
    // ������ 3D ������ ��ǥ
    public Vector3 targetWorldPosition = new Vector3(0, 0, 0); // ��ǥ ��ǥ
    public float detectionRadius = 1f; // ���� �ݰ�

    public float TestX; // �� ������ X��ǥ
    public float TestZ; // �� ������ Z��ǥ

    public GameObject BadukW; // ��ġ�� ������Ʈ 1
    public GameObject BadukB;
    Vector3 spawnPosition; // ������ ������Ʈ ��ü�� ��ǥ
    Quaternion spawnRotation = Quaternion.identity; // ������ ������Ʈ ����

    int Bcount = 1; // ��ġ�� ���� �� ����
    int Wcount = 1; // ��ġ�� �� �� ����
    bool IsGame = true; // �� ������ ���� ī��Ʈ

    public GameObject WinUI; // �¸� UI
    public Text WinText; // �¸� Text
    public bool Win; // ���� �¸� ����
    public string WinName; // �¸��� �� ��

    private void Start()
    {
        // ���� �ʱ�ȭ
        Win = false;
        WinUI.SetActive(false);
    }

    void Update()
    {
        GameWin();

        if (!Win) // ���� �¸� ���� üũ
        {
            GetBaduk();
        }
        else
        {
            GameReStart();
        }
    }

    void GetBaduk()
    {
        // ���콺 ���� ��ư Ŭ�� ����
        if (Input.GetMouseButtonDown(0)) // 0: ���� Ŭ��
        {
            // ���� ���콺 ��ũ�� ��ǥ ���
            Vector3 mouseScreenPosition = Input.mousePosition;

            // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, Camera.main.nearClipPlane));

            // �ٵ��� ��ǥ�� ��ȯ
            Vector3 Baduk = mouseWorldPosition * 100;

            // ��ǥ �ݿø�
            TestX = Mathf.Round(Baduk.x);
            TestZ = Mathf.Round(Baduk.z);

            // * ������Ʈ ���� ��ġ ����
            // ��ǥ���� 2�� ���������� 0���� �� �������� ������
            // ��ǥ���� 1�� ����
            if (TestX % 2 != 0)
            {
                TestX--;
            }
            if (TestZ % 2 != 0)
            {
                TestZ--;
            }

            // ���콺 �浹 ��ġ
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // ���콺 �浹�� ������Ʈ ��������
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // * ������ ��ġ�� �ٵϵ��� �ִ��� üũ
                // ���콺�� �浹�� ������Ʈ �±� Black�Ǵ� White�� �ƴ϶��
                if (hit.transform.gameObject.tag != "Black" && hit.transform.gameObject.tag != "White")
                {
                    // ��� �ٵ� ����
                    if(IsGame)
                    {
                        // ������ ������Ʈ ��ġ�� ����
                        spawnPosition = new Vector3(TestX, 0f, TestZ);
                        // ������ ������Ʈ, ��ġ, ���� ����
                        GameObject spawn = Instantiate(BadukW, spawnPosition, spawnRotation);
                        // ������ ������Ʈ �̸� ����
                        string name = $"BadukW : {Wcount.ToString()}";
                        // ������Ʈ �̸��� �����Ͽ� ����
                        spawn.name = name;
                        // �ٵϾ� ������ Ȱ��ȭ
                        IsGame = false;
                        // �ٵ� ī��Ʈ
                        Wcount++;
                    }
                    // ������ �ٵ� ����
                    else
                    {
                        spawnPosition = new Vector3(TestX, 0f, TestZ);
                        GameObject spawn = Instantiate(BadukB, spawnPosition, spawnRotation);
                        string name = $"BadukB : {Bcount.ToString()}";
                        spawn.name = name;
                        IsGame = true;
                        Bcount++;
                    }
                }
                else
                {
                    //Debug.Log("�̹��ִ�");
                }
            }
        }
    }

    void GameWin()
    {
        if(Win) // ���� �¸� ���¶��
        {
            // �ؽ�Ʈ ����
            WinText.text = WinName + " Win";
            // UIȰ��ȭ
            WinUI.SetActive(true);
        }
    }

    void GameReStart()
    {
        // ���콺 ���� ��ư�� ������ ���� �����
        if (Win && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
