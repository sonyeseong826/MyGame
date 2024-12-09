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
        // 폴더 경로 설정
        string folderPath = "Assets/block";

        // 폴더 안의 모든 프리팹 파일 검색
        string[] prefabGUIDs = AssetDatabase.FindAssets("t:Prefab", new[] { folderPath });
        // AssetDatabase.FindAssets :
        // 검색 필터와 폴더 경로 배열을 입력으로 받아, 해당 조건을 만족하는 오브젝트를 반환

        // t:Prefab : Prefab 타입만 가져오기
        // new[] {folderPath} : folderPath에서만 오브젝트 검색

        // 프리팹 이름을 저장할 배열
        // 오브젝트 갯수에 따라 배열 크기 지정
        prefabNames = new string[prefabGUIDs.Length];
        
        // 오브젝트 객수에 따라 반복문 실행
        for (int i = 0; i < prefabGUIDs.Length; i++)
        {
            // GUID를 실제 파일 경로로 변환
            string prefabPath = AssetDatabase.GUIDToAssetPath(prefabGUIDs[i]);

            // 경로에서 프리팹 이름만 추출  
            prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            // prefab이 Null이 아닐경우 이름을 저장 null이라면 Unknown으로 저장
            prefabNames[i] = prefab != null ? prefab.name : "Unknown";
        }

        // 결과 출력
        Debug.Log($"총 {prefabNames.Length}개의 프리팹 이름이 배열에 저장되었습니다.");
        foreach (string name in prefabNames)
        {
            Debug.Log($"Block Name: {name}");
        }
    }
}
