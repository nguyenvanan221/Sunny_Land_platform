using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1.2f;
    [SerializeField]
    private float jumpForce = 4.5f;
    [SerializeField]
    private float hurtForce = 3f;

    private Rigidbody2D rb2D;
    private Animator animator;

    public LayerMask whatIsGround;
    private float dirX = 0f;

    private Collider2D coll;
    enum State { idle, jump, run, crouch, hurt }
    private State state = State.idle;

    
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state != State.hurt)
        {
            Move();
        }
        
        UpdateState();
        animator.SetInteger("state", (int) state);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy ant = collision.gameObject.GetComponent<Ant>();
            ant.JumpedOn();
            state = State.jump;
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            ant.Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            state = State.hurt;
            if (collision.transform.position.x > transform.position.x)
            {
                rb2D.velocity = new Vector2(-hurtForce, rb2D.velocity.y);
            }
            else
            {
                rb2D.velocity = new Vector2(hurtForce, rb2D.velocity.y);
            }
        }
    }

    void Move()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        // moving left
        if (dirX < 0)
        {
            rb2D.velocity = new Vector2(-moveSpeed, rb2D.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        // moving right
        else if (dirX > 0)
        {
            rb2D.velocity = new Vector2(moveSpeed, rb2D.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        //jumping
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(whatIsGround))
        { 
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }
    }

    void UpdateState()
    {
        // moving
        if (dirX < 0 || dirX > 0)
        {
            state = State.run;
        }
        else if (state == State.hurt)
        {
            if (Mathf.Abs(rb2D.velocity.x) < .1f)
            {
                state= State.idle;
            }
        }
        // jump
        else if (!coll.IsTouchingLayers(whatIsGround))
        {
            state = State.jump;
        }
        else
        {
            state = State.idle;
        }
    }
}
