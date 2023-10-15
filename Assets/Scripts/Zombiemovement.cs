using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public GameObject Player;
    private Vector2 direction;
    private bool isStunned = false;
    public float stunCooldown = 3.0f; // Adjust the cooldown duration as needed
    private float stunTimer = 0.0f;

    void Start()
    {
        stunTimer = 0.0f;
    }

    void Update()
    {
        if (!isStunned)
        {
            direction = Player.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        }
    }

    public void StunZombie()
    {
        if (!isStunned)
        {
            isStunned = true;
            stunTimer = stunCooldown;
        }
    }

    void FixedUpdate()
    {
        // If the zombie is stunned, count down the stun timer
        if (isStunned)
        {
            stunTimer -= Time.fixedDeltaTime;

            if (stunTimer <= 0.0f)
            {
                isStunned = false;
            }
        }
    }
}
