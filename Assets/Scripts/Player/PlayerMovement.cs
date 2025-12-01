using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputSystem_Actions actions;

    public float speed;

    public float jumpForce;

    private float move;

    private Rigidbody2D rb;

    public Transform groundCheckTransform;
    
    public float groundCheckRadius;
    
    public LayerMask groundLayer;

    private bool isGrounded;

    public Animator animator;

    private void Awake()
    {
        actions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        actions.Player.Enable();
        actions.Player.Move.performed += Movement;
        actions.Player.Jump.performed += Jumping;
        
        actions.Player.Move.canceled += Movement;
        actions.Player.Jump.canceled += Jumping;
    }

    private void OnDisable()
    {
        actions.Player.Disable();
        actions.Player.Move.performed -= Movement;
        actions.Player.Jump.performed -= Jumping;
    }

    void Movement(InputAction.CallbackContext ctx)
    {
        move = ctx.ReadValue<Vector2>().x;
    }
    
    void Jumping(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (isGrounded)
            {
                rb.linearVelocityY = jumpForce;
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundLayer);
        
        rb.linearVelocityX = move * speed;
        animator.SetFloat("xVelocity", Math.Abs(rb.linearVelocityX));
        Debug.Log(rb.linearVelocityX);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckTransform.position, groundCheckRadius);
    }
}
