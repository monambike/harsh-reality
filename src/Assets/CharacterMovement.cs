using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    void Start()
    {
        
    }

    private void Update()
    {
        Walk();
    }

    private void Walk()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        float this_speed = CharacterStats.speed;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            this_speed *= 2;
         transform.Translate(horizontalInput * this_speed * Time.deltaTime * Vector2.right);
    }
}
