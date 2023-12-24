using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private float jumpForce = 10f;

    public bool isGrounded;

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
        // Handle regular jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Apply jump force
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if the character is collided with the groud
        isGrounded = collision.gameObject.CompareTag("Ground");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Since the character already stop colliding with the ground
        // makes it false
        isGrounded = false;
    }
}
