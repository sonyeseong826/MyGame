using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Test : MonoBehaviour
{
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

        if (prefabGUIDs.Length == 0)
        {
            Debug.LogError($"�������� �ش� ������ �����ϴ�: {folderPath}");
            return;
        }

        // ������ �̸��� ������ �迭
        prefabNames = new string[prefabGUIDs.Length];

        for (int i = 0; i < prefabGUIDs.Length; i++)
        {
            // GUID�� ���� ���� ��η� ��ȯ
            string prefabPath = AssetDatabase.GUIDToAssetPath(prefabGUIDs[i]);

            // ��ο��� ������ �̸��� ����
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            prefabNames[i] = prefab != null ? prefab.name : "Unknown";
        }

        // ��� ���
        Debug.Log($"�� {prefabNames.Length}���� ������ �̸��� �迭�� ����Ǿ����ϴ�.");
        foreach (string name in prefabNames)
        {
            Debug.Log($"Prefab Name: {name}");
        }
    }
}
