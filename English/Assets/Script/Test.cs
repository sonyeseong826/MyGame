using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{
    // ������ 3D ������ ��ǥ
    public Vector3 targetWorldPosition = new Vector3(0, 0, 0); // ��ǥ ��ǥ
    public float detectionRadius = 1f; // ���� �ݰ�

    public float TestX;
    public float TestZ;

    public GameObject BadukW;
    public GameObject BadukB;
    Vector3 spawnPosition;
    Quaternion spawnRotation = Quaternion.identity;

    int Bcount = 1;
    int Wcount = 1;
    int IsGame = 0;

    private void Start()
    {
    }

    void Update()
    {
        GetBaduk();
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

            if (TestX % 2 != 0)
            {
                TestX--;
            }
            if (TestZ % 2 != 0)
            {
                TestZ--;
            }


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag != "Baduk W" && hit.transform.gameObject.tag != "Baduk B")
                {
                    if(IsGame == 0)
                    {
                        spawnPosition = new Vector3(TestX, 0f, TestZ);
                        GameObject spawn = Instantiate(BadukW, spawnPosition, spawnRotation);
                        string name = $"BadukW : {Wcount.ToString()}";
                        spawn.name = name;
                        IsGame = 1;
                        Wcount++;
                    }
                    else
                    {
                        spawnPosition = new Vector3(TestX, 0f, TestZ);
                        GameObject spawn = Instantiate(BadukB, spawnPosition, spawnRotation);
                        string name = $"BadukB : {Bcount.ToString()}";
                        spawn.name = name;
                        IsGame = 0;
                        Bcount++;
                    }
                }
                else
                {
                    Debug.Log("�̹��ִ�");
                }
            }
        }
    }
}
