using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;

    // Rotate
    public float mouseSpeed = 30f; // 마우스 감도
    float xRotation;
    float yRotation;
    Camera cam;

    // Move
    public float moveSpeed = 5f;
    float h;
    float v;

    // Jump
    public float JumpForce = 10f; // 점프 힘 (높이를 고정시킬 값)
    public float MaxHeight = 1.3f; // 최대 점프 높이
    private bool isJumping = false; // 점프 중인지 여부

    // Ground check
    bool IsGrounded;

    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked; // 마우스 커서 잠금
        UnityEngine.Cursor.visible = false; // 커서 숨김

        rb = GetComponent<Rigidbody>(); // 인게임에서 라지드바디 컴포넌트 할당
        rb.freezeRotation = true; // 물리에 의한 회전 잠금

        transform.rotation = Quaternion.Euler(0, 0, 0); // 초반 각도를 0,0,0 으로 설정

        cam = Camera.main; // 현재 씬에 있는 메인 카메라를 할당
    }

    void Update()
    {
        Rotate();

        // 점프
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            Jump();
        }

        // 낙하 속도 조정 (자연스럽게 떨어지도록)
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (2.5f - 1) * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = transform.forward * v + transform.right * h;
        moveDirection.Normalize(); // 이동 방향 정규화

        // 카메라 시야 조정 관련 변수
        Vector3 originalCameraPosition = new Vector3(0, 0.3f, 0); // 기본 카메라 위치
        float crouchCameraOffset = -0.15f; // 웅크리기 시 카메라가 낮아지는 정도

        // 캐릭터 높이 조정 변수
        float originalHeight = 2f; // 기본 높이
        float crouchHeight = 1f; // 웅크렸을 때 높이
        CapsuleCollider capsule = GetComponent<CapsuleCollider>(); // 캐릭터 충돌 박스

        // 웅크리기 상태
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // 이동 속도 감소
            Vector3 targetPosition = rb.position + moveDirection * (moveSpeed - 2f) * Time.deltaTime;

            // 발 아래에서 떨어지지 않도록 체크
            if (CheckEdgeSafety())
            {
                transform.position = targetPosition;
            }

            // 카메라 시야 낮추기
            cam.transform.localPosition = originalCameraPosition + new Vector3(0, crouchCameraOffset, 0);

            // 충돌 박스 높이 줄이기
            capsule.height = crouchHeight;
            capsule.center = new Vector3(0, crouchHeight / 2, 0); // 충돌 박스 중심도 조정
        }
        else
        {
            // 기본 이동 속도
            Vector3 targetPosition = rb.position + moveDirection * moveSpeed * Time.deltaTime;
            transform.position = targetPosition;

            // 카메라 시야 원래대로
            cam.transform.localPosition = originalCameraPosition;

            // 충돌 박스 높이 원래대로
            capsule.height = originalHeight;
            capsule.center = new Vector3(0, originalHeight / 2, 0);
        }
    }

    // 블록 가장자리에서 떨어지지 않도록 체크하는 함수
    bool CheckEdgeSafety()
    {
        // 캐릭터의 발 아래 방향으로 Raycast를 발사
        Ray ray = new Ray(transform.position + Vector3.down * 0.5f, Vector3.down);
        float rayLength = 0.6f; // 발 아래를 감지하는 레이의 길이

        // 충돌 여부 검사
        if (Physics.Raycast(ray, rayLength))
        {
            // 땅이 있는 경우 안전
            return true;
        }

        // 땅이 없는 경우 이동을 막지 않지만, 블록을 벗어나지 않도록
        return false;
    }




    void Rotate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSpeed * Time.deltaTime; // 마우스의 X축 움직임을 저장
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSpeed * Time.deltaTime;

        yRotation += mouseX; // 마우스의 X축 움직임 누적값을 저장
        xRotation += mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // xRotation에 최대최소 값을 지정

        cam.transform.rotation = Quaternion.Euler(-xRotation, yRotation, 0); // 메인 카메라에 각도를 지정
        transform.rotation = Quaternion.Euler(0, yRotation, 0); // 현재 오브젝트에 각도를 지정
    }

    void Jump()
    {
        if (IsGrounded) // 바닥에 있을 때만 점프
        {
            isJumping = true; // 점프 상태로 변경
            IsGrounded = false; // 바닥에서 떠났다고 표시

            // 원하는 최대 높이에 도달하기 위한 초기 속도 계산
            float jumpHeight = MaxHeight;
            float initialJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(Physics.gravity.y) * jumpHeight); // 초기 속도 계산

            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // 기존 수직 속도 초기화
            rb.AddForce(Vector3.up * initialJumpVelocity, ForceMode.Impulse); // 계산된 초기 속도로 점프
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // 바닥에 닿았을 때
        {
            IsGrounded = true; // 바닥에 닿았음을 표시
            isJumping = false; // 점프 상태 해제
        }
    }
}
