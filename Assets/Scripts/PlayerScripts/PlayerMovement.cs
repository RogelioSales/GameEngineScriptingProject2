using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private Transform groundCheck;

    [HideInInspector]
    public bool DoubleJumped
    {
        get { return doubleJumped; }
        set { doubleJumped = value; }
    }
    private float groundCheckRadius = 0.2f;
    private bool isGround = false;
    private bool doubleJumped = true;
    private Rigidbody2D playerrigid;
	// Use this for initialization
	private void Start ()
    {
        playerrigid = GetComponent<Rigidbody2D>();
        doubleJumped = true;
	}	
	// Update is called once per frame
	private void FixedUpdate ()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);
        Debug.Log(isGround);
        Move();
        Jump();
	}
    private void Move()
    {
        float movement = Input.GetAxis("Horizontal");

        if (movement > 0.5f || movement < -0.5f)
        {
            transform.Translate(new Vector2(movement * moveSpeed * Time.deltaTime, 0f));

            //Using Rigidbody2D to move game Object.
            //playerrigid.velocity = new Vector2(movement * moveSpeed * Time.deltaTime, playerrigid.velocity.y);
        }
    }
    private void Jump()
    {
        float jumping = Input.GetAxis("Jump");

        if (jumping > 0.2f && isGround)
        {
            isGround = false;
            playerrigid.velocity = new Vector2(0f, jumping * jumpHeight * Time.deltaTime);
        }
        if (jumping >0.2f && !doubleJumped && !isGround)
        {
            doubleJumped = true;
            playerrigid.velocity = new Vector2(0f,jumping*jumpHeight* Time.deltaTime);
        }

    }
}
