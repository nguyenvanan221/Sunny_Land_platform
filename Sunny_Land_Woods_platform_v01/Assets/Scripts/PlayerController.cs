using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public int acorn = 0;

    [SerializeField]
    private Text acornText;
    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private float jumpForce = 4f;
    [SerializeField]
    private float hurtForce = 3f;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private float radius = 0.1f;
    [SerializeField]
    private Transform pos;
    private bool onGround;

    private Rigidbody2D rb2D;
    private Animator animator;

    private Collider2D coll;
    private float dirX = 0f;

    enum State { idle, jump, run, crouch, hurt }
    private State state = State.idle;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        onGround = Physics2D.OverlapCircle(pos.position, radius, whatIsGround);
        if (state != State.hurt)
        {
            Movement();
        }

        UpdateState();
        animator.SetInteger("state", (int)state);
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Jump trigger");
            Enemy ant = collision.gameObject.GetComponent<Ant>();
            ant.JumpedOn();
            state = State.jump;
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            ant.Death();
        }

        if (collision.gameObject.CompareTag("CanBePickUp"))
        {
            bool apppear = false;
            Item acornObject = collision.gameObject.GetComponent<Consumable>().item;
            if (acornObject != null)
            {
                apppear = true;
                acorn += 1;
                acornText.text = acorn.ToString();
            }

            if (apppear)
            {
                collision.gameObject.SetActive(false);
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hurt Coll");
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

    void Movement()
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
        if (Input.GetButtonDown("Jump") && onGround)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }
    }

    void UpdateState()
    {
        if (state == State.hurt)
        {
            if (Mathf.Abs(rb2D.velocity.x) < .1f)
            {
                state = State.idle;
            }
        }
        else if (!onGround)
        {
            state = State.jump;
        }
        else if (Mathf.Abs(rb2D.velocity.x) > 0.5f)
        {
            state = State.run;
        }
        else state= State.idle;
    }

}
