using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour
{
public float maxSpeed = 15f;
public float slideForce = 0.05f;
public float jumpForce = 400f;
public GameObject sound;
public Animator animator;
private Rigidbody2D rb;
private bool floor = false;

void Start()
{
    rb = GetComponent<Rigidbody2D>();
    rb.constraints=RigidbodyConstraints2D.FreezeRotation;
	animator=GetComponent<Animator>();
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
    if (floor && Input.GetKeyDown(KeyCode.UpArrow))
    {
        rb.AddForce(new Vector2(0f, jumpForce));
        floor = false;
	Instantiate(sound);
    animator.SetBool("jump",true);
    }
    else{
	animator.SetBool("jump",false);
	}
}

void FixedUpdate()
{
    float moveInput = Input.GetAxis("HorizontalArrow");
   if (moveInput<0.0f){
	transform.localScale=new Vector3(-4.5f,4.5f,1.0f);
	}
    else if(moveInput>0.0f){
	transform.localScale=new Vector3(4.5f,4.5f,1.0f);
}
	animator.SetBool("running",moveInput !=0.0f);
    Vector2 velocity = rb.velocity;
    velocity.x *= 1f - slideForce;
    rb.velocity = velocity;

    if (Mathf.Abs(rb.velocity.x) < maxSpeed)
    {
        rb.AddForce(new Vector2(moveInput * 20f, 0f));
	
    }
}

}