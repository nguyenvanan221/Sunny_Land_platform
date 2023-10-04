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
            //a = Instantiate(enemyDeath,transform.position, Quaternion.identity);

            collision.gameObject.SetActive(false);
            Debug.Log("3");
            StartCoroutine(Wait());
            a.SetActive(false);
            //gameObject.SetActive(false);
        }
    }

    IEnumerator Wait()
    {
        a = Instantiate(enemyDeath, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(10);
    }

    


}
