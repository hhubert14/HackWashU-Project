using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    bool isTouchingZombie = false;
    float lastLifeLossTime = 0.0f;
    float timeBetweenLifeLoss = 0.5f; // Adjust this value as needed.
    public int maxHearts = 3; // Set the maximum number of hearts.
    public int currentHearts; // The player's current number of hearts.

    public Image[] heartImages; // An array to store the UI images representing hearts.

    private void Start()
    {
        currentHearts = maxHearts;
        UpdateUI();
    }

    void Update()
    {
    if (isTouchingZombie && Time.time - lastLifeLossTime >= timeBetweenLifeLoss)
    {
        // Reduce the number of lives and update the UI.
        LoseHeart();
        lastLifeLossTime = Time.time;
    }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    if (collision.gameObject.CompareTag("Zombie"))
    {
        // Reduce the number of lives and update the UI.
        isTouchingZombie = true;
    }
    }

    void OnCollisionExit2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Zombie"))
    {
        isTouchingZombie = false;
    }
}

    private void LoseHeart()
    {
        if (currentHearts > 0)
        {
            currentHearts--;
            UpdateUI();
        }

        if (currentHearts <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < maxHearts; i++)
        {
            if (i < currentHearts)
            {
                heartImages[i].enabled = true; // Show filled hearts.
            }
            else
            {
                heartImages[i].enabled = false; // Hide empty hearts.
            }
        }
    }
}
