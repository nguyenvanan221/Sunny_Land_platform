using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float jumpForce = 5.0f;

    private Rigidbody2D rb2D;
    private Animator animator;
    private SpriteRenderer sprite;

    private float dirX = 0f;

    public Transform checkGround;
    public float groundRadius = .2f;
    public LayerMask whatIsGround;
    private bool onGround;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapCircle(checkGround.position, groundRadius, whatIsGround);

        Move();
        UpdateState();
    }


    void Move()
    {
        //onGround = Physics2D.OverlapCircle(checkGround.position, groundRadius, whatIsGround);
        dirX = Input.GetAxisRaw("Horizontal");
        rb2D.velocity =  new Vector2(dirX * moveSpeed, rb2D.velocity.y);

        if (Input.GetButtonDown("Jump") && onGround == true)
        { 
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }
    }

    void UpdateState()
    {
        if (dirX > 0)
        {
            animator.SetBool("IsRun", true);
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            animator.SetBool("IsRun", true);
            sprite.flipX = true;
        }
        else
        {
            animator.SetBool("IsRun", false);
        }

        if (Input.GetButtonDown("Jump") && onGround == true)
        {
            animator.SetBool("IsJump", true);
        }

        if (onGround == true)
        {
            animator.SetBool("IsJump", false);
        }
        else
        {
            animator.SetBool("IsJump", true);
        }
 
        if(Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("IsCrouch", true);
        }
        else
        {
            animator.SetBool("IsCrouch", false);

        }







    }
}
