using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public float swordLength = 1.0f; // Adjust the sword length to bring it closer to the player

    void Update()
    {
        // Ensure the player reference is valid
        if (player == null)
        {
            Debug.LogWarning("Player reference is not assigned.");
            return;
        }

        // Get the 2D mouse position in screen coordinates
        Vector2 mousePosition = Input.mousePosition;

        // Convert mouse position to world coordinates using the player's Z position
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, player.position.z));

        // Calculate the direction from the player to the mouse
        Vector2 direction = (mousePosition - (Vector2)player.position).normalized;

        // Set the position of the sword's other end
        transform.position = player.position;

        // Offset the sword position based on the direction and adjusted sword length
        transform.position += (Vector3)direction * swordLength;

        // Correct the rotation of the sword to point at the mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
}
