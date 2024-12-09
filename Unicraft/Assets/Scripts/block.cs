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

    Inven inven;
    Test test;

    // 초기화
    private void Start()
    {
        inven = FindObjectOfType<Inven>();
        test = FindObjectOfType<Test>();
        // 초기화 작업이 필요하면 여기에 추가
    }

    void Update()
    {
        // 현재 파일에 있는 오브젝트를 찾아오긴
        string[] guids = AssetDatabase.FindAssets($"{test.prefabNames[inven.blocks - 1]} t:Prefab");

        // 찾아온 오브젝트 중에서 첫번째 블록만 사용
        string path = AssetDatabase.GUIDToAssetPath(guids[0]);
        // 오브젝트화를 해서 사용가능한 오브젝트로 저장
        objectSpawn = AssetDatabase.LoadAssetAtPath<GameObject>(path);

        // 카메라에서 마우스 포인터의 위치를 기반으로 Ray 생성
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Raycast로 충돌 감지
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            hitTransform = hit.transform; // 충돌된 Transform
            gameObject = hit.collider.gameObject; // 충돌된 오브젝트
            normal = hit.normal; // 충돌된 면의 법선 벡터
        }
        else
        {
            // Raycast가 아무것도 감지하지 못한 경우
            hitTransform = null;
            gameObject = null;
            normal = Vector3.zero;
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
