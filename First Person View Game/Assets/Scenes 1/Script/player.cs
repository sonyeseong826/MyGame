using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class player : MonoBehaviour
{
    Rigidbody rb;

    [Header("Rotate")]
    public float mouseSpeed = 3f;
    float yRotation;
    float xRotation;
    Camera cam;

    [Header("Move")]
    public float moveSpeed = 3f;
    float h;
    float v;

    [Header("Jump")]
    public float jumpForce;

    [Header("Ground Check")]
    public float playerHeight;
    bool grounded;

    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        transform.rotation = Quaternion.Euler(0, 0, 0);

        cam = Camera.main;
    }

    void Update()
    {
        Rotate();
        Move();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        Vector3 moveVec = transform.forward * v + transform.right * h;
        transform.position += moveVec.normalized * moveSpeed * Time.deltaTime;
    }

    void Rotate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSpeed * Time.deltaTime;

        yRotation += mouseX;
        xRotation += mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.rotation = Quaternion.Euler(-xRotation, yRotation, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
