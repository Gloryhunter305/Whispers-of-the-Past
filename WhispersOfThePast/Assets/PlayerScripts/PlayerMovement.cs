using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Components")]
    public float speed = 5.0f;
    private Rigidbody2D rb;

    [Header("Game Mechanics")]
    public int socialHealth = 50;
    public float currentHealth;
    public float drainRate = 1f;

    public SocialBarScript socialBar;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = socialHealth;
        socialBar.SetMaxHealth(socialHealth);
    }

    void Update()
    {
        
        if (currentHealth >= 0)
        {
            DrainHealth(drainRate * Time.deltaTime);
        }
        else
        {
            // Destroy(gameObject);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        rb.velocity = movement * speed;
    }


    void DrainHealth(float damage)
    {
        currentHealth -= damage;
        socialBar.SetHealth(currentHealth);
    }

    
}
