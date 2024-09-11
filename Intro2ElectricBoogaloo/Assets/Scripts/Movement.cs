using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jumpPower;
    public float doubleJumpBoost;
    public int jumpCount;
    public int maxJumpCount;
    public KeyCode jump;
    private float horizontal;

    public LayerMask floor;
    public Transform groundcheck;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(jump) && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpCount = jumpCount + 1;  
        }

        else if (Input.GetKeyDown(jump) && jumpCount < maxJumpCount)
        {
            rb.velocity = new Vector2(rb.velocity.x, doubleJumpBoost);
            jumpCount = jumpCount + 1;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            jumpCount = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 2f, floor);
    }
}
