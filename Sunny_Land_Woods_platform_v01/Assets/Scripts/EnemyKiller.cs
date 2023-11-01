using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    public GameObject enemyDeath;
    private GameObject a;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy ant = collision.gameObject.GetComponent<Ant>();
            ant.JumpedOn();
        }
    }

}
