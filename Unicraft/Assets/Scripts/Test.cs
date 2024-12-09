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
        // 폴더 경로 설정
        string folderPath = "Assets/block";

        // 폴더 안의 모든 프리팹 파일 검색
        string[] prefabGUIDs = AssetDatabase.FindAssets("t:Prefab", new[] { folderPath });

        if (prefabGUIDs.Length == 0)
        {
            Debug.LogError($"프리팹이 해당 폴더에 없습니다: {folderPath}");
            return;
        }

        // 프리팹 이름을 저장할 배열
        prefabNames = new string[prefabGUIDs.Length];

        for (int i = 0; i < prefabGUIDs.Length; i++)
        {
            // GUID를 실제 파일 경로로 변환
            string prefabPath = AssetDatabase.GUIDToAssetPath(prefabGUIDs[i]);

            // 경로에서 프리팹 이름만 추출
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            prefabNames[i] = prefab != null ? prefab.name : "Unknown";
        }

        // 결과 출력
        Debug.Log($"총 {prefabNames.Length}개의 프리팹 이름이 배열에 저장되었습니다.");
        foreach (string name in prefabNames)
        {
            Debug.Log($"Prefab Name: {name}");
        }
    }
}
