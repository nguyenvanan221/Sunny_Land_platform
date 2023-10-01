using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMoveController : MonoBehaviour
{
    public float speed;
    public abstract void Move();
}
