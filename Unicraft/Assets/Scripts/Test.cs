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
        // AssetDatabase : 모든 에셋 관련 파일 처리 클래스
        // FindAssets : 특정 에셋 검색 메서드
        // t:Prefab : 타입이 Prefab인 파일만 검색
        // new[] { folderPath } : 결과들을 배열에 저장
        // * 프로젝트 전체에서 특정 이름의 에셋을 검색
        string[] prefabGUIDs = AssetDatabase.FindAssets("t:Prefab", new[] { folderPath });

        // 오류 출력
        if (prefabGUIDs.Length == 0)
        {
            Debug.LogError($"프리팹이 해당 폴더에 없습니다: {folderPath}");
            return;
        }

        // 프리팹 이름을 저장할 배열
        // prefabGUIDs 배열에 크기만큼 생성
        prefabNames = new string[prefabGUIDs.Length];

        for (int i = 0; i < prefabGUIDs.Length; i++)
        {
            // GUID를 실제 파일 경로로 변환
            // AssetDatabase : 모든 에셋 관련 파일 처리 클래스
            // GUIDToAssetPath : GUID를 실제 경로로 변환 메서드
            string prefabPath = AssetDatabase.GUIDToAssetPath(prefabGUIDs[i]);

            // 경로에서 프리팹 이름만 추출
            // AssetDatabase : 모든 에셋 관련 파일 처리 클래스
            // LoadAssetAtPath : 특정 결로에 위치한 에셋을 로드 메서드
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);

            // prefab이 null이 아니라면 - true : prebfab.name 저장 || false : Unknown 저장
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
