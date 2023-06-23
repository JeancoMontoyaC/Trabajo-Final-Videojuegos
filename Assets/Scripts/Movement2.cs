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
public GameObject sound;
void Start()
{
    rb = GetComponent<Rigidbody2D>();
    rb.constraints=RigidbodyConstraints2D.FreezeRotation;
}

void Update()
{
    
    Debug.DrawRay(transform.position,Vector3.down * 0.55f,Color.red);
    if (Physics2D.Raycast(transform.position,Vector3.down,0.55f)){
	floor=true;
	}
    else{
	floor=false;
	}
    if (floor && Input.GetKeyDown(KeyCode.W))
    {
        rb.AddForce(new Vector2(0f, jumpForce));
        floor = false;
	Instantiate(sound);
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

}
