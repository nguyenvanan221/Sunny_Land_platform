using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2.0f;
    [SerializeField]
    private float jumpForce = 4.5f;
    [SerializeField]
    private float hurtForce = 1f;

    private Rigidbody2D rb2D;
    private Animator animator;
    private SpriteRenderer sprite;

    private float dirX = 0f;

    public Transform checkGround;
    public float groundRadius = .2f;
    public LayerMask whatIsGround;
    private bool onGround;

    [HideInInspector]
    public Collider2D col;

    enum State { idle, jump, run, crouch, hurt }
    private State state = State.idle;

    
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        //GameObject platformObject = GameObject.FindWithTag("Platform");
        //col = platformObject.GetComponentInChildren<Collider2D>();
        GameObject platformObject = GameObject.FindWithTag("Bough");
        col = platformObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapCircle(checkGround.position, groundRadius, whatIsGround);
        if (state != State.hurt)
        {
            Move();
            if (Input.GetButtonDown("Jump"))
            {
                StartCoroutine(Jump());
            }
        }
        
        UpdateState();
        
        
        animator.SetInteger("state", (int) state);

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
        rb2D.velocity = new Vector2(moveSpeed * dirX, rb2D.velocity.y);

        if (Input.GetButtonDown("Jump") && onGround == true)
        { 
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);       
        }
    }

    void UpdateState()
    {
        // moving left
        if (dirX < 0)
        {
            state = State.run;
            transform.localScale = new Vector2(-1, 1);
        }
        // moving right
        else if (dirX > 0)
        {
            state = State.run;
            transform.localScale = new Vector2(1, 1);
        }
        else if (state == State.hurt)
        {
            if (Mathf.Abs(rb2D.velocity.x) < .1f)
            {
                state= State.idle;
            }
        }
        //jump
        else if (onGround != true){
            state = State.jump;
        }
        else 
        {
            state = State.idle;
        }
    }

    public IEnumerator Jump()
    {
        float time = 0f;
            col.enabled = false;
            while (time < 0.3f)
            {
                time += Time.deltaTime;
                yield return null;
            }
            col.enabled = true;
    }
}
