using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float speed;
    private Vector2 direction;
    private Rigidbody2D rb;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!isLocalPlayer) return;

        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rb.velocity = direction * speed;

    }

    /*
    public float moveSpeed = 5f;

    void Update()
    {
        // Get input values
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        movement.Normalize(); // Normalize to ensure consistent speed in all directions

        // Move the player
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
    */
}
