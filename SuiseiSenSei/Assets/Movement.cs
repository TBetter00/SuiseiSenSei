using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get input from arrow keys or WASD
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;

        // Move the player
        rb.velocity = movement * moveSpeed;
    }
}
