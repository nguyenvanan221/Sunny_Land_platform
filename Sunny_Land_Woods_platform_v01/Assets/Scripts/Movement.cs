using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float jumpSpeed = 5.0f;
    private Rigidbody2D rb2D;
    [HideInInspector]
    public Animator animator;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Jump");
        //movement.Normalize();

        if (Input.GetButtonDown("Jump"))
        {
            //rb2D.velocity = 
            animator.SetBool("IsJump", true);
        }
        else
        {
            animator.SetBool("IsJump", false);
            
        }

        rb2D.velocity = movement * moveSpeed;

    }

    void UpdateState()
    {

    }
}
