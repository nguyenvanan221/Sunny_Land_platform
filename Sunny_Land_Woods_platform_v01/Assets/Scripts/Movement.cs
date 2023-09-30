using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float jumpForce = 4.5f;

    private Rigidbody2D rb2D;
    private Animator animator;
    private SpriteRenderer sprite;

    private float dirX = 0f;

    public Transform checkGround;
    public float groundRadius = .2f;
    public LayerMask whatIsGround;
    private bool onGround;

    public Collider2D col;

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

        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(Jump());
        }

    }

    void Move()
    {
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
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (dirX < 0)
        {
            animator.SetBool("IsRun", true);
            transform.localScale = new Vector3(-1, 1, 1);
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

    public IEnumerator Jump()
    {
        float time = 0f;
        col.enabled = false;
        while(time < 0.3f)
        {
            time += Time.deltaTime;
            yield return null;
        }
        col.enabled = true;
    }
}
