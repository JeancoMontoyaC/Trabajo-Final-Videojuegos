using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
public float maxSpeed = 15f;
public float slideForce = 0.05f;
public float jumpForce = 400f;

private Rigidbody2D rb;
private bool floor = false;

void Start()
{
    rb = GetComponent<Rigidbody2D>();
    rb.constraints=RigidbodyConstraints2D.FreezeRotation;
}

void Update()
{
    if (floor && Input.GetKeyDown(KeyCode.W))
    {
        rb.AddForce(new Vector2(0f, jumpForce));
        floor = false;
    }
}

void FixedUpdate()
{
    float moveInput = Input.GetAxis("HorizontalWASD");

    Vector2 velocity = rb.velocity;
    velocity.x *= 1f - slideForce;
    rb.velocity = velocity;

    if (Mathf.Abs(rb.velocity.x) < maxSpeed)
    {
        rb.AddForce(new Vector2(moveInput * 20f, 0f));
    }
}

void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.tag == "Floor")
    {
        floor = true;
    }
}

void OnCollisionExit2D(Collision2D collision)
{
    if (collision.gameObject.tag == "Floor")
    {
        floor = false;
    }
}
}
