using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 moveInput;
 [SerializeField] private int playerHP = 5;

    [SerializeField] private float jumpForce = 10f;
    private bool isGrounded;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheckPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, checkRadius, groundLayer);
        
    }

    void FixedUpdate()
    {
       rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump()
    {
        if (isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
           //animator.SetTrigger("IsJumping");
        }
    }

   
     public void TakeDamage(int amount)
        {
            playerHP -= amount;
            playerHP = Mathf.Max(playerHP, 0);
            Debug.Log("Player HP: " + playerHP);
            // Add death or UI update logic here if needed
        }
    

}
