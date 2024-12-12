using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class block : MonoBehaviour
{
    // Ray�� ���� (���콺 Ŭ�� ���� �Ÿ�)
    public float rayLength = 5;
    // ���� ������ �ִ� �Ÿ� (��� �ȵ�, ���� Ȯ�� ����)
    public float maxDistance = 5;

    // ������ ������Ʈ�� ���� ��ġ, ȸ����
    GameObject objectSpawn;
    public Vector3 spawnPosition;
    public Quaternion spawnRotation = Quaternion.identity;

    // ���� ��ġ ��ǥ ��
    float x, y, z;

    // Raycast ��� �����
    GameObject gameObject; // Raycast�� ������ ������Ʈ
    Transform hitTransform; // ������ ������Ʈ�� Transform
    Vector3 normal; // ������ ���� ���� ����

    Inven inven; // Inven Ŭ���� ���� ����
    Test test; // Test Ŭ���� ���� ����

    // �ʱ�ȭ
    private void Start()
    {
        inven = FindObjectOfType<Inven>();
        test = FindObjectOfType<Test>();
    }

    void Update()
    {
        // ���� ���Ͽ� �ִ� ������Ʈ�� ã�ƿ���
        // AssetDatabase : ��� ���� ���� ���� ó�� Ŭ����
        // FindAssets : Ư�� ���� �˻� �޼���
        // {test.prefabNames[inven.blocks - 1]} t:Prefab : Prefab Ÿ�Կ� test.prefabNames[inven.blocks - 1] �̸��� ���� ������ �˻�
        // * Ư�� ���� ������ Ư�� Ÿ���� ������ �˻�
        string[] guids = AssetDatabase.FindAssets($"{test.prefabNames[inven.blocks - 1]} t:Prefab");

        // GUID�� ���� ���� ��η� ��ȯ
        // AssetDatabase : ��� ���� ���� ���� ó�� Ŭ����
        // GUIDToAssetPath : GUID�� ���� ��η� ��ȯ �޼���
        string path = AssetDatabase.GUIDToAssetPath(guids[0]);

        // ��ο��� ������ �̸��� ����
        // AssetDatabase : ��� ���� ���� ���� ó�� Ŭ����
        // LoadAssetAtPath : Ư�� ��ο� ��ġ�� ������ �ε� �޼���
        objectSpawn = AssetDatabase.LoadAssetAtPath<GameObject>(path);

        // ī�޶󿡼� ���콺 �������� ��ġ�� ������� Ray ����
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Raycast�� �浹 ����

        // ray : ������ �������� ������ �����ϴ� ��ü
        // out hit : ����ĹƮ �浹�� ���� ������ �����ϴ� ��� �Ű�����
        // rayLength : ���̰� �˻��� �ִ� �Ÿ�
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            hitTransform = hit.transform; // hit.transform : �浹�� ��ü ��ġ
            gameObject = hit.collider.gameObject; // hit.collider.gameObject : �浹�� ������Ʈ �̺�Ʈ ó��
            normal = hit.normal; // hit.normal : �浹�� ���� ���� ����
        }
        else
        {
            // Raycast�� �ƹ��͵� �������� ���� ���
            hitTransform = null;
            gameObject = null;
            normal = Vector3.zero;
            // �� �ʱ�ȭ
        }

        // ���콺 ���� ��ư Ŭ�� �� ������ ������Ʈ ����
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }

        // ���콺 ������ ��ư Ŭ�� �� ������ �鿡 ���� �� ������Ʈ ����
        if (Input.GetMouseButtonDown(1))
        {
            // ������ ������Ʈ�� �����Ǿ� �ִ� ��츸 ����
            if (objectSpawn != null)
            {
                // ����(normal)�� ���� ���� ��ġ ��� �� ����
                if (normal == Vector3.right) // ������ ��
                {
                    x = hitTransform.position.x + 1;
                    y = hitTransform.position.y;
                    z = hitTransform.position.z;

                    spawnPosition = new Vector3(x, y, z);

                    Instantiate(objectSpawn, spawnPosition, spawnRotation);
                    // Instantiate(������Ʈ, ��ġ, ����);
                }
                else if (normal == Vector3.left) // ���� ��
                {
                    x = hitTransform.position.x - 1;
                    y = hitTransform.position.y;
                    z = hitTransform.position.z;

                    spawnPosition = new Vector3(x, y, z);

                    Instantiate(objectSpawn, spawnPosition, spawnRotation);
                }
                else if (normal == Vector3.up) // ���� ��
                {
                    x = hitTransform.position.x;
                    y = hitTransform.position.y + 1;
                    z = hitTransform.position.z;

                    spawnPosition = new Vector3(x, y, z);

                    Instantiate(objectSpawn, spawnPosition, spawnRotation);
                }
                else if (normal == Vector3.down) // �Ʒ��� ��
                {
                    x = hitTransform.position.x;
                    y = hitTransform.position.y - 1;
                    z = hitTransform.position.z;

                    spawnPosition = new Vector3(x, y, z);

                    Instantiate(objectSpawn, spawnPosition, spawnRotation);
                }
                else if (normal == Vector3.forward) // ���� ��
                {
                    x = hitTransform.position.x;
                    y = hitTransform.position.y;
                    z = hitTransform.position.z + 1;

                    spawnPosition = new Vector3(x, y, z);

                    Instantiate(objectSpawn, spawnPosition, spawnRotation);
                }
                else if (normal == Vector3.back) // ���� ��
                {
                    x = hitTransform.position.x;
                    y = hitTransform.position.y;
                    z = hitTransform.position.z - 1;

                    spawnPosition = new Vector3(x, y, z);

                    Instantiate(objectSpawn, spawnPosition, spawnRotation);
                }
                else
                {
                    return; // �ٸ� ������ ��� �ƹ� �۾��� ���� ����
                }
            }
        }
    }
}
