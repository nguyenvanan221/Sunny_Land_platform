using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gator : Enemy
{
    public float range = 1f;
    float startY;
    int dir = 1;

    public float speed = 0.5f;
    protected override void Start()
    {
        base.Start();
        startY = transform.position.y;
    }
    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        transform.Translate(Vector2.up * speed * dir * Time.deltaTime);
        if (transform.position.y < startY || transform.position.y > startY + range)
        {
            dir *= -1;
        }
    }
}
