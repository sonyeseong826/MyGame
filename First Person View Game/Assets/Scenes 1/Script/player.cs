using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class player : MonoBehaviour
{
    Rigidbody rb; // Rigidbody ������Ʈ         

    [Header("Rotate")]
    public float mouseSpeed = 3f; // ���콺 ���� 3���� ����
    float yRotation; // Y����
    float xRotation; // X����
    Camera cam; // ī�޶� ��ü �Ҵ�

    [Header("Move")]
    public float moveSpeed = 3f; // ������ �ӵ�
    float h; // �¿� ������ ���� ���� ��ü
    float v; // ���� ������ ���� ���� ��ü

    [Header("Jump")]
    public float jumpForce; // ������

    [Header("Ground Check")]
    public float playerHeight; // �÷��̾� ����
    bool grounded; // �ٴڿ� ��Ҵ����� ���� ��ü

    void Start()
    {
        // Cursor.lockState : ���� ���� Ŀ�� ���� ����
        // CousorLockMode.Locked : Ŀ���� �߾ӿ� �����ϰ� ������ �ʰ�
        // ���콺 Ŀ���� ȭ�� �߾ӿ� ������Ű�� ������ �ʰ� ����
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

        // Ŀ���� ������ �ʰԸ� ����
        UnityEngine.Cursor.visible = false;

        rb = GetComponent<Rigidbody>(); //���� ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� ��ȯ
        rb.freezeRotation = true;  // �������� ��ȣ�ۿ��� �� �� ȸ���� ���� �ʰ� ����

        transform.rotation = Quaternion.Euler(0, 0, 0); // ���� ������ 0,0,0 ���� ����

        cam = Camera.main; // ����ī�޶� �Ҵ�
    }

    void Update()
    {
        // �޼��� ����
        Rotate();
        Move();


        if(Input.GetKeyDown(KeyCode.Space))
        {
            // ���콺 �����̽��ٸ� ������ �޼��� ����
            Jump();
        }
    }

    void Move()
    {
        h = Input.GetAxisRaw("Horizontal"); // �¿� ������ �� ����
        v = Input.GetAxisRaw("Vertical"); // ��ȭ ������ �� ����

        // moveVec ��ü �ȿ� ������ ���� Z,X ������ ��ȯ�Ͽ� ����
        Vector3 moveVec = transform.forward * v + transform.right * h; 
        // ���� ������Ʈ�� moveVec(����)���� moveSpeed(�ӵ�) ��ŭ �̵��Ѵ�
        // * TIme.deltaTime�� ������ ������ ��� �ϱ� ���� �Լ��̴�
        transform.position += moveVec.normalized * moveSpeed * Time.deltaTime; 
    }

    void Rotate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSpeed * Time.deltaTime; // ���콺 �¿� ������ ���� ����
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSpeed * Time.deltaTime; // �̿콺 ���� ������ ���� ����

        yRotation += mouseX;// ���콺 �¿� ������ ���� ����
        xRotation += mouseY;// ���콺 ���� ������ ���� ����

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // ���콺 �¿� ������ ���� -90, 90 �̻� ���� ���ϰ� ����

        cam.transform.rotation = Quaternion.Euler(-xRotation, yRotation, 0); // ī�޶� ���� ����
        transform.rotation = Quaternion.Euler(0, yRotation, 0); // �÷��̾� ������Ʈ ���� ����
    }

    void Jump()
    {
        // AddForce : Rigidbody�� ���� ���ϴ� �Լ�
        // Vector3.up : ���ʿ� ���� ���Ѵ�
        // ForceMode.Impulse : ���� ���� ������ ���ϰ� �ϴ� �Լ�
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // ���ʿ� jumpForce ��ŭ�� ���� ���Ѵ�
    }
}
