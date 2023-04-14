using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour
{
public float maxSpeed = 10f;
public float slideForce = 0.1f;
public float jumpForce = 500f;

private Rigidbody2D rb;
private bool floor = false;

void Start()
{
    rb = GetComponent<Rigidbody2D>();
}

void Update()
{
    if (floor && Input.GetKeyDown(KeyCode.UpArrow))
    {
        rb.AddForce(new Vector2(0f, jumpForce));
        floor = false;
    }
}

void FixedUpdate()
{
    float moveInput = Input.GetAxis("HorizontalArrow");

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