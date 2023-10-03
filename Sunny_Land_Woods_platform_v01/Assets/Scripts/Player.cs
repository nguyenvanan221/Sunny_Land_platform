using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void Kill()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CanBePickUp"))
        {
            Debug.Log("1");
            bool apppear = false;
            Item acornObject = collision.gameObject.GetComponent<Consumable>().item;
            if (acornObject != null)
            {
                apppear = true;
                Debug.Log("Pick up");
            }

            if (apppear)
            {
                collision.gameObject.SetActive(false);
            }

        }
    }

}
