using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
   private Vector2 xInput;
   [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;
    private bool isGrounded;
    [SerializeField] private Transform groundCheckPosition;
    private Animator animator;

    [SerializeField] private float checkRadius = 0.2f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, checkRadius, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        if (Mathf.Abs(xInput.x) > 0.1f)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
        
    if(xInput.x <- 0.1)
        {
          transform.rotation = Quaternion.Euler(0, 180, 0);}
        else if(xInput.x < 0.1f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    
    }
    void FixedUpdate()
    {
        rb.linearVelocityX= xInput.x*speed;
    }
    public void OnMove(InputValue inputValue)
    {
        xInput = inputValue.Get<Vector2>();
    }
    public void OnJump()
    {
        if (isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
           animator.SetTrigger("IsJumping");
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheckPosition.position, checkRadius);
    }
}
