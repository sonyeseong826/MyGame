using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;

    // Rotate
    public float mouseSpeed = 30f; // ���콺 ����
    float xRotation;
    float yRotation;
    Camera cam;

    // Move
    public float moveSpeed = 5f;
    float h;
    float v;

    // Jump
    public float JumpForce = 10f; // ���� �� (���̸� ������ų ��)
    public float MaxHeight = 1.3f; // �ִ� ���� ����
    private bool isJumping = false; // ���� ������ ����

    // Ground check
    bool IsGrounded;

    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked; // ���콺 Ŀ�� ���
        UnityEngine.Cursor.visible = false; // Ŀ�� ����

        rb = GetComponent<Rigidbody>(); // �ΰ��ӿ��� ������ٵ� ������Ʈ �Ҵ�
        rb.freezeRotation = true; // ������ ���� ȸ�� ���

        transform.rotation = Quaternion.Euler(0, 0, 0); // �ʹ� ������ 0,0,0 ���� ����

        cam = Camera.main; // ���� ���� �ִ� ���� ī�޶� �Ҵ�
    }

    void Update()
    {
        Rotate();

        // ����
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            Jump();
        }

        // ���� �ӵ� ���� (�ڿ������� ����������)
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
        moveDirection.Normalize(); // �̵� ���� ����ȭ

        // ī�޶� �þ� ���� ���� ����
        Vector3 originalCameraPosition = new Vector3(0, 0.3f, 0); // �⺻ ī�޶� ��ġ
        float crouchCameraOffset = -0.15f; // ��ũ���� �� ī�޶� �������� ����

        // ĳ���� ���� ���� ����
        float originalHeight = 2f; // �⺻ ����
        float crouchHeight = 1f; // ��ũ���� �� ����
        CapsuleCollider capsule = GetComponent<CapsuleCollider>(); // ĳ���� �浹 �ڽ�

        // ��ũ���� ����
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // �̵� �ӵ� ����
            Vector3 targetPosition = rb.position + moveDirection * (moveSpeed - 2f) * Time.deltaTime;

            // �� �Ʒ����� �������� �ʵ��� üũ
            if (CheckEdgeSafety())
            {
                transform.position = targetPosition;
            }

            // ī�޶� �þ� ���߱�
            cam.transform.localPosition = originalCameraPosition + new Vector3(0, crouchCameraOffset, 0);

            // �浹 �ڽ� ���� ���̱�
            capsule.height = crouchHeight;
            capsule.center = new Vector3(0, crouchHeight / 2, 0); // �浹 �ڽ� �߽ɵ� ����
        }
        else
        {
            // �⺻ �̵� �ӵ�
            Vector3 targetPosition = rb.position + moveDirection * moveSpeed * Time.deltaTime;
            transform.position = targetPosition;

            // ī�޶� �þ� �������
            cam.transform.localPosition = originalCameraPosition;

            // �浹 �ڽ� ���� �������
            capsule.height = originalHeight;
            capsule.center = new Vector3(0, originalHeight / 2, 0);
        }
    }

    // ��� �����ڸ����� �������� �ʵ��� üũ�ϴ� �Լ�
    bool CheckEdgeSafety()
    {
        // ĳ������ �� �Ʒ� �������� Raycast�� �߻�
        Ray ray = new Ray(transform.position + Vector3.down * 0.5f, Vector3.down);
        float rayLength = 0.6f; // �� �Ʒ��� �����ϴ� ������ ����

        // �浹 ���� �˻�
        if (Physics.Raycast(ray, rayLength))
        {
            // ���� �ִ� ��� ����
            return true;
        }

        // ���� ���� ��� �̵��� ���� ������, ����� ����� �ʵ���
        return false;
    }




    void Rotate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSpeed * Time.deltaTime; // ���콺�� X�� �������� ����
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSpeed * Time.deltaTime;

        yRotation += mouseX; // ���콺�� X�� ������ �������� ����
        xRotation += mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // xRotation�� �ִ��ּ� ���� ����

        cam.transform.rotation = Quaternion.Euler(-xRotation, yRotation, 0); // ���� ī�޶� ������ ����
        transform.rotation = Quaternion.Euler(0, yRotation, 0); // ���� ������Ʈ�� ������ ����
    }

    void Jump()
    {
        if (IsGrounded) // �ٴڿ� ���� ���� ����
        {
            isJumping = true; // ���� ���·� ����
            IsGrounded = false; // �ٴڿ��� �����ٰ� ǥ��

            // ���ϴ� �ִ� ���̿� �����ϱ� ���� �ʱ� �ӵ� ���
            float jumpHeight = MaxHeight;
            float initialJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(Physics.gravity.y) * jumpHeight); // �ʱ� �ӵ� ���

            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // ���� ���� �ӵ� �ʱ�ȭ
            rb.AddForce(Vector3.up * initialJumpVelocity, ForceMode.Impulse); // ���� �ʱ� �ӵ��� ����
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // �ٴڿ� ����� ��
        {
            IsGrounded = true; // �ٴڿ� ������� ǥ��
            isJumping = false; // ���� ���� ����
        }
    }
}
