using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatorMovement : EnemyMoveController
{
    public float range = 1f;
    float startY;
    int dir = 1;

    private void Start()
    {
        startY = transform.position.y;
    }
    private void FixedUpdate()
    {
        Move();
    }
    public override void Move()
    {
        transform.Translate(Vector2.up * speed * dir * Time.deltaTime);
        if (transform.position.y < startY || transform.position.y > startY + range)
        {
            dir *= -1;
        }
    }
}
