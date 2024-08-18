using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dart_Movement : MonoBehaviour
{

    [SerializeField] public Rigidbody2D rbdart;
    
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float jumpSpeed = 10f;

    float horizontalMovement;

    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    [SerializeField] private LayerMask groundLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rbdart = GetComponent<Rigidbody2D>();
        //OnEnable();
    }

    // Update is called once per frame
    void Update()
    {
        rbdart.linearVelocity = new Vector2(horizontalMovement * runSpeed, rbdart.linearVelocity.y);
    }

    //private void FixedUpdate()
    //{
    //    rbdart.linearVelocity = new Vector2(horizontalMovement * runSpeed, rbdart.linearVelocity.y);
    //    //rbdart.MovePosition(rbdart.position + movement)
    //    //rbdart.linearVelocity = new Vector2(moveInput.x * runSpeed, moveInput.y * jumpSpeed);
    //}

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded())
        {
            if (context.performed)
            {
                rbdart.linearVelocity = new Vector2(rbdart.linearVelocity.x, jumpSpeed);
            }
            else if (context.canceled)
            {
                rbdart.linearVelocity = new Vector2(rbdart.linearVelocity.x, rbdart.linearVelocity.y * 0.5f);
            }
        }

    }
    private bool isGrounded()
    {
        if(Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
            {
                return true;
            }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }
}
