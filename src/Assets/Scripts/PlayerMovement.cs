using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMovement(InputValue inputValue)
    {
        movement = inputValue.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        int speed = 5;
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private float horizontal;

    public void Move(InputAction.CallbackContext callbackContext)
    {
        horizontal = callbackContext.ReadValue<Vector2>().x;
    }
}
