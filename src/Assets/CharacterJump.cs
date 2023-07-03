using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    private float jumpForce = 10f;

    private bool isGrounded;
    private bool canDoubleJump;

    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //// Check if the character is on the ground or touching a surface
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Handle regular jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        //// Handle double jump
        //if (!isGrounded && canDoubleJump && Input.GetButtonDown("Jump"))
        //{
        //    DoubleJump();
        //}
    }

    private void Jump()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Apply jump force
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        // Allow for double jump after regular jump
        canDoubleJump = true;
    }

    private void DoubleJump()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Apply double jump force
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        // Disable double jump until the character lands on the ground again
        canDoubleJump = false;
    }
}
