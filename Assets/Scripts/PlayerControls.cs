using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 5f; // Adjust the speed as needed.

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the player.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction and normalize it to avoid faster diagonal movement.
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        // Apply the movement to the player.
        rb2d.velocity = movement * moveSpeed;

        // If you want to flip the player sprite based on the movement direction:
        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
