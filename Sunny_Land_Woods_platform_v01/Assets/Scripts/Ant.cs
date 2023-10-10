using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : EnemyMoveController
{
    private Rigidbody2D rb2D;
    private Animator anim;

    public float range = 0.3f;
    public GameObject rightCheck;
    public GameObject leftCheck;
    private Transform currentPoint;
    private void Start()
    {
        rb2D= GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
        currentPoint = rightCheck.transform;
    }

    private void Update()
    {
       Move();
    }


    public override void Move()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == rightCheck.transform)
        {
            rb2D.velocity = new Vector2(speed , rb2D.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            rb2D.velocity = new Vector2(-speed , rb2D.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        
        if (Vector2.Distance(transform.position, currentPoint.position) < range && currentPoint == rightCheck.transform)
        {
            currentPoint = leftCheck.transform;;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < range && currentPoint == leftCheck.transform)
        {
            currentPoint = rightCheck.transform;
        }
    }

    public void JumpedOn()
    {
        anim.SetTrigger("Death");
        Death();
    }

    public void Death()
    {
        Destroy(this.gameObject);
    }
    
}
