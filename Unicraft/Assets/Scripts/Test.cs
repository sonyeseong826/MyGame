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
        // AssetDatabase : ��� ���� ���� ���� ó�� Ŭ����
        // FindAssets : Ư�� ���� �˻� �޼���
        // t:Prefab : Ÿ���� Prefab�� ���ϸ� �˻�
        // new[] { folderPath } : ������� �迭�� ����
        // * ������Ʈ ��ü���� Ư�� �̸��� ������ �˻�
        string[] prefabGUIDs = AssetDatabase.FindAssets("t:Prefab", new[] { folderPath });

        // ���� ���
        if (prefabGUIDs.Length == 0)
        {
            Debug.LogError($"�������� �ش� ������ �����ϴ�: {folderPath}");
            return;
        }

        // ������ �̸��� ������ �迭
        // prefabGUIDs �迭�� ũ�⸸ŭ ����
        prefabNames = new string[prefabGUIDs.Length];

        for (int i = 0; i < prefabGUIDs.Length; i++)
        {
            // GUID�� ���� ���� ��η� ��ȯ
            // AssetDatabase : ��� ���� ���� ���� ó�� Ŭ����
            // GUIDToAssetPath : GUID�� ���� ��η� ��ȯ �޼���
            string prefabPath = AssetDatabase.GUIDToAssetPath(prefabGUIDs[i]);

            // ��ο��� ������ �̸��� ����
            // AssetDatabase : ��� ���� ���� ���� ó�� Ŭ����
            // LoadAssetAtPath : Ư�� ��ο� ��ġ�� ������ �ε� �޼���
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);

            // prefab�� null�� �ƴ϶�� - true : prebfab.name ���� || false : Unknown ����
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
