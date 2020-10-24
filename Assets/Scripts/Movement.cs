using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform camPivot;
    public Transform cam;
    float heading = 0;
    Vector2 input;

    float speed = 4;
    float rotSpeed = 80;
    float rot = 0f;
    float gravity = 8;

    private Rigidbody rigb;
    private float moveSpeed = 10f;
    CharacterController controller;
    public bool IsGrounded;


    Vector3 moveDir = Vector3.zero;

    Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }
    

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        Vector3 movement = transform.TransformDirection(direction) * moveSpeed;
        IsGrounded = controller.SimpleMove(movement);

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("Idle", false);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("Idle", true);
            animator.SetBool("isWalking", false);
        }

    }

    private void Update()
    {
        heading += Input.GetAxis("Mouse X") * Time.deltaTime * 180;
        camPivot.rotation = Quaternion.Euler(0, heading, 0);
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);

        Vector3 camF = cam.forward; ;
        Vector3 camR = cam.right;
        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        transform.position += (camF*input.y + camR * input.x) * Time.deltaTime * 5;

    }

    //void Moxement()
    //{
    //    if (controller.isGrounded)
    //    {
    //        animator.SetBool("Idle", true);
    //        if (Input.GetKey(KeyCode.W))
    //        {
    //            animator.SetBool("isWalking", true);
    //            animator.SetBool("Idle", false);
    //            moveDir = new Vector3(0, 0, 1);
    //            moveDir *= speed;
    //            moveDir = transform.TransformDirection(moveDir);
    //        }
    //        if (Input.GetKeyUp(KeyCode.W))
    //        {
    //            animator.SetBool("isWalking", false);
    //            moveDir = new Vector3(0, 0, 0);
    //        }
    //    }
    //    rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
    //    transform.eulerAngles = new Vector3(0, rot, 0);

    //    moveDir.y -= gravity * Time.deltaTime;
    //    controller.Move(moveDir * Time.deltaTime);

    //}
}
