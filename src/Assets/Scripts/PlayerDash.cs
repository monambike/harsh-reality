using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private float[] lastKeyPressTime = new float[4];

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            int keyIndex = GetKeyIndex();

            var timeSinceLastKeyPress = Time.time - lastKeyPressTime[keyIndex];
            if (timeSinceLastKeyPress < 0.2f) // Adjust the time threshold as needed
                Dash();

            lastKeyPressTime[keyIndex] = Time.time;
        }
    }

    private void Dash()
    {
        InflictBodyDamage();

        float dashSpeed = PlayerStats.speed * 2f; // Adjust the dash speed as needed

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        var directionInput = horizontalInput;
        if (horizontalInput == 0)
            directionInput = verticalInput;

        float dashDirection = Mathf.Sign(directionInput);

        Vector2 dashVelocity = new Vector2(dashSpeed * horizontalInput, 0f);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = dashVelocity;

        // Optionally, you can disable input during the dash to prevent additional movement inputs
        // by adding the following line:
        // enabled = false;

        // Add any additional logic or effects for the dash
    }

    private Material originalMaterial;
    private Material dashMaterial;
    private float dashDuration = 0.2f;
    private void InflictBodyDamage()
    {
        // Store the original material
        originalMaterial = GetComponent<Renderer>().material;

        // Apply the dash material
        GetComponent<Renderer>().material = dashMaterial;

        // Start the coroutine to revert the material color after the specified duration
        StartCoroutine(RevertMaterialColorAfterDelay(dashDuration));
    }

    private IEnumerator RevertMaterialColorAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Revert back to the original material
        GetComponent<Renderer>().material = originalMaterial;
    }

    private int GetKeyIndex()
    {
        Dictionary<KeyCode, int> keyToIndex = new Dictionary<KeyCode, int>()
        {
            { KeyCode.W, 0 },
            { KeyCode.A, 1 },
            { KeyCode.S, 2 },
            { KeyCode.D, 3 }
        };

        foreach (var pair in keyToIndex)
            if (Input.GetKeyDown(pair.Key))
                return pair.Value;

        return -1; // Invalid key
    }
}
