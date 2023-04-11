using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] float runSpeed = 5f;

    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        //Debug.Log(moveInput);
        //left: -1,0
        //right: 1,0
        //up: 0,1
        //down: 0,-1
        //stay: 0,0
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, moveInput.y * runSpeed);
        rb.velocity = playerVelocity;

        //run right animation
        bool isRunningRight = rb.velocity.x > 0f;
        animator.SetBool("isRunningRight", isRunningRight);

        //run left animation
        bool isRunningLeft = rb.velocity.x < 0f;
        animator.SetBool("isRunningLeft", isRunningLeft);

        //run up animation
        bool isRunningUp = rb.velocity.y > 0f;
        animator.SetBool("isRunningUp", isRunningUp);

        //run down animation
        bool isRunningDown = rb.velocity.y < 0f;
        animator.SetBool("isRunningDown", isRunningDown);


    }

    public void StopMove()
    {
        runSpeed = 0f;
        // Animation Detected
        animator.SetBool("isDetected", true);

    }

}
