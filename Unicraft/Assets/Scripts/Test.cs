using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Test : MonoBehaviour
{
    GameObject prefab;
    public string[] prefabNames;
    void Start()
    {
        CollectPrefabNames();
    }

    void CollectPrefabNames()
    {
        // ���� ��� ����
        string folderPath = "Assets/block";

        // ���� ���� ��� ������ ���� �˻�
        string[] prefabGUIDs = AssetDatabase.FindAssets("t:Prefab", new[] { folderPath });
        // AssetDatabase.FindAssets :
        // �˻� ���Ϳ� ���� ��� �迭�� �Է����� �޾�, �ش� ������ �����ϴ� ������Ʈ�� ��ȯ

        // t:Prefab : Prefab Ÿ�Ը� ��������
        // new[] {folderPath} : folderPath������ ������Ʈ �˻�

        // ������ �̸��� ������ �迭
        // ������Ʈ ������ ���� �迭 ũ�� ����
        prefabNames = new string[prefabGUIDs.Length];
        
        // ������Ʈ ������ ���� �ݺ��� ����
        for (int i = 0; i < prefabGUIDs.Length; i++)
        {
            // GUID�� ���� ���� ��η� ��ȯ
            string prefabPath = AssetDatabase.GUIDToAssetPath(prefabGUIDs[i]);

            // ��ο��� ������ �̸��� ����  
            prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            // prefab�� Null�� �ƴҰ�� �̸��� ���� null�̶�� Unknown���� ����
            prefabNames[i] = prefab != null ? prefab.name : "Unknown";
        }

        // ��� ���
        Debug.Log($"�� {prefabNames.Length}���� ������ �̸��� �迭�� ����Ǿ����ϴ�.");
        foreach (string name in prefabNames)
        {
            Debug.Log($"Block Name: {name}");
        }
    }
}
