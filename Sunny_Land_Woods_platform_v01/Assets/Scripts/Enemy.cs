using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator anim;
    protected Rigidbody2D rb2D;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

    }

    public void JumpedOn()
    {
        anim.SetTrigger("Death");
    }

    public void Death()
    {
        Destroy(this.gameObject, 0.5f);
    }


}
