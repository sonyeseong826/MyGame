using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class block : MonoBehaviour
{
    // Ray의 길이 (마우스 클릭 감지 거리)
    public float rayLength = 5;
    // 생성 가능한 최대 거리 (사용 안됨, 향후 확장 가능)
    public float maxDistance = 5;

    // 생성할 오브젝트와 생성 위치, 회전값
    GameObject objectSpawn;
    public Vector3 spawnPosition;
    public Quaternion spawnRotation = Quaternion.identity;

    // 생성 위치 좌표 값
    float x, y, z;

    // Raycast 결과 저장용
    GameObject gameObject; // Raycast로 감지된 오브젝트
    Transform hitTransform; // 감지된 오브젝트의 Transform
    Vector3 normal; // 감지된 면의 법선 벡터

    Inven inven; // Inven 클래스 참조 선언
    Test test; // Test 클래스 참조 선언

    // 초기화
    private void Start()
    {
        inven = FindObjectOfType<Inven>();
        test = FindObjectOfType<Test>();
    }

    void Update()
    {
        // 현재 파일에 있는 오브젝트를 찾아오긴
        // AssetDatabase : 모든 에셋 관련 파일 처리 클래스
        // FindAssets : 특정 에셋 검색 메서드
        // {test.prefabNames[inven.blocks - 1]} t:Prefab : Prefab 타입에 test.prefabNames[inven.blocks - 1] 이름을 가진 에셋을 검색
        // * 특정 폴더 내에서 특정 타입의 에셋을 검색
        string[] guids = AssetDatabase.FindAssets($"{test.prefabNames[inven.blocks - 1]} t:Prefab");

        // GUID를 실제 파일 경로로 변환
        // AssetDatabase : 모든 에셋 관련 파일 처리 클래스
        // GUIDToAssetPath : GUID를 실제 경로로 변환 메서드
        string path = AssetDatabase.GUIDToAssetPath(guids[0]);

        // 경로에서 프리팹 이름만 추출
        // AssetDatabase : 모든 에셋 관련 파일 처리 클래스
        // LoadAssetAtPath : 특정 결로에 위치한 에셋을 로드 메서드
        objectSpawn = AssetDatabase.LoadAssetAtPath<GameObject>(path);

        // 카메라에서 마우스 포인터의 위치를 기반으로 Ray 생성
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Raycast로 충돌 감지

        // ray : 레이의 시작점과 방향을 정의하는 객체
        // out hit : 레이캣트 충돌에 대한 정보를 저장하는 출력 매개변수
        // rayLength : 레이가 검사할 최대 거리
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            hitTransform = hit.transform; // hit.transform : 충돌된 객체 위치
            gameObject = hit.collider.gameObject; // hit.collider.gameObject : 충돌된 오브젝트 이벤트 처리
            normal = hit.normal; // hit.normal : 충돌된 면의 법선 벡터
        }
        else
        {
            // Raycast가 아무것도 감지하지 못한 경우
            hitTransform = null;
            gameObject = null;
            normal = Vector3.zero;
            // 값 초기화
        }

        // 마우스 왼쪽 버튼 클릭 시 감지된 오브젝트 제거
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }

        // 마우스 오른쪽 버튼 클릭 시 감지된 면에 따라 새 오브젝트 생성
        if (Input.GetMouseButtonDown(1))
        {
            // 생성할 오브젝트가 설정되어 있는 경우만 실행
            if (objectSpawn != null)
            {
                // 법선(normal)에 따라 생성 위치 계산 및 생성
                if (normal == Vector3.right) // 오른쪽 면
                {
                    x = hitTransform.position.x + 1;
                    y = hitTransform.position.y;
                    z = hitTransform.position.z;

                    spawnPosition = new Vector3(x, y, z);

                    Instantiate(objectSpawn, spawnPosition, spawnRotation);
                    // Instantiate(오브젝트, 위치, 각도);
                }
                else if (normal == Vector3.left) // 왼쪽 면
                {
                    x = hitTransform.position.x - 1;
                    y = hitTransform.position.y;
                    z = hitTransform.position.z;

                    spawnPosition = new Vector3(x, y, z);

                    Instantiate(objectSpawn, spawnPosition, spawnRotation);
                }
                else if (normal == Vector3.up) // 위쪽 면
                {
                    x = hitTransform.position.x;
                    y = hitTransform.position.y + 1;
                    z = hitTransform.position.z;

                    spawnPosition = new Vector3(x, y, z);

                    Instantiate(objectSpawn, spawnPosition, spawnRotation);
                }
                else if (normal == Vector3.down) // 아래쪽 면
                {
                    x = hitTransform.position.x;
                    y = hitTransform.position.y - 1;
                    z = hitTransform.position.z;

                    spawnPosition = new Vector3(x, y, z);

                    Instantiate(objectSpawn, spawnPosition, spawnRotation);
                }
                else if (normal == Vector3.forward) // 앞쪽 면
                {
                    x = hitTransform.position.x;
                    y = hitTransform.position.y;
                    z = hitTransform.position.z + 1;

                    spawnPosition = new Vector3(x, y, z);

                    Instantiate(objectSpawn, spawnPosition, spawnRotation);
                }
                else if (normal == Vector3.back) // 뒤쪽 면
                {
                    x = hitTransform.position.x;
                    y = hitTransform.position.y;
                    z = hitTransform.position.z - 1;

                    spawnPosition = new Vector3(x, y, z);

                    Instantiate(objectSpawn, spawnPosition, spawnRotation);
                }
                else
                {
                    return; // 다른 방향의 경우 아무 작업도 하지 않음
                }
            }
        }
    }
}
