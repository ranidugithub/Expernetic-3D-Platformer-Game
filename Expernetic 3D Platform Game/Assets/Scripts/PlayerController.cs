using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movespeed = 5f;
    [SerializeField] float rotationSpeed = 500f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float gravity = -9.81f;

    [Header("Ground Check Settings")]
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] Vector3 groundCheckOffset;
    [SerializeField] LayerMask groundLayer;

    bool isGrounded;
    float yspeed;

    Quaternion targetRotation;

    CameraController cameraController;
    Animator animator;
    CharacterController characterController;

    private void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float moveAmount = Mathf.Clamp01(Mathf.Abs(h) + Mathf.Abs(v));

        var moveInput = (new Vector3(h, 0, v)).normalized;

        var moveDir = cameraController.PlanerRotation * moveInput;

        GroundCheck();
        if (isGrounded)
        {
            yspeed = -0.5f;
            if (Input.GetButtonDown("Jump"))
            {
                yspeed = jumpForce;
                animator.SetTrigger("Jump");
            }
        }
        else
        {
            yspeed += gravity * Time.deltaTime;
        }

        var velocity = moveDir * movespeed;
        velocity.y = yspeed;

        characterController.Move(velocity * Time.deltaTime);

        if (moveAmount > 0)
        {
            targetRotation = Quaternion.LookRotation(moveDir);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,
            rotationSpeed * Time.deltaTime);

        animator.SetFloat("moveAmount", moveAmount, 0.2f, Time.deltaTime);
        animator.SetBool("isGrounded", isGrounded);
    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius);
    }
}
