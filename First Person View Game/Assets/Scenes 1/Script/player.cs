using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class player : MonoBehaviour
{
    Rigidbody rb; // Rigidbody 컴포넌트         

    [Header("Rotate")]
    public float mouseSpeed = 3f; // 마우스 감도 3으로 설정
    float yRotation; // Y각도
    float xRotation; // X각도
    Camera cam; // 카메라 객체 할당

    [Header("Move")]
    public float moveSpeed = 3f; // 움직임 속도
    float h; // 좌우 움직임 값을 받을 객체
    float v; // 상하 움직임 값을 받을 객체

    [Header("Jump")]
    public float jumpForce; // 점프힘

    [Header("Ground Check")]
    public float playerHeight; // 플레이어 높이
    bool grounded; // 바닥에 닿았는지에 대한 객체

    void Start()
    {
        // Cursor.lockState : 게임 내에 커서 동작 제어
        // CousorLockMode.Locked : 커서를 중앙에 고정하고 보이지 않게
        // 마우스 커서를 화면 중앙에 고정시키고 보이지 않게 설정
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

        // 커서가 보이지 않게만 설정
        UnityEngine.Cursor.visible = false;

        rb = GetComponent<Rigidbody>(); //현재 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 반환
        rb.freezeRotation = true;  // 물리적인 상호작용을 할 때 회전을 하지 않게 설정

        transform.rotation = Quaternion.Euler(0, 0, 0); // 현재 각도를 0,0,0 으로 설정

        cam = Camera.main; // 메인카메라를 할당
    }

    void Update()
    {
        // 메서드 실행
        Rotate();
        Move();


        if(Input.GetKeyDown(KeyCode.Space))
        {
            // 마우스 스페이스바를 누르면 메서드 실행
            Jump();
        }
    }

    void Move()
    {
        h = Input.GetAxisRaw("Horizontal"); // 좌우 움직임 값 저장
        v = Input.GetAxisRaw("Vertical"); // 상화 움직임 값 저장

        // moveVec 객체 안에 움직임 값을 Z,X 값으로 변환하여 저장
        Vector3 moveVec = transform.forward * v + transform.right * h; 
        // 현재 오브젝트를 moveVec(방향)으로 moveSpeed(속도) 만큼 이동한다
        // * TIme.deltaTime은 프레임 단위로 계산 하기 위한 함수이다
        transform.position += moveVec.normalized * moveSpeed * Time.deltaTime; 
    }

    void Rotate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSpeed * Time.deltaTime; // 마우스 좌우 움직임 값을 저장
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSpeed * Time.deltaTime; // 미우스 상하 움직임 값을 저장

        yRotation += mouseX;// 마우스 좌우 움직임 값을 누적
        xRotation += mouseY;// 마우스 상하 움직임 값을 누적

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // 마우스 좌우 움직임 값을 -90, 90 이상 가지 못하게 지정

        cam.transform.rotation = Quaternion.Euler(-xRotation, yRotation, 0); // 카메라에 각도 지정
        transform.rotation = Quaternion.Euler(0, yRotation, 0); // 플레이어 오브젝트 각도 지정
    }

    void Jump()
    {
        // AddForce : Rigidbody에 힘을 가하는 함수
        // Vector3.up : 위쪽에 힘을 가한다
        // ForceMode.Impulse : 힘을 순간 적으로 가하게 하는 함수
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // 위쪽에 jumpForce 만큼에 힘을 가한다
    }
}
