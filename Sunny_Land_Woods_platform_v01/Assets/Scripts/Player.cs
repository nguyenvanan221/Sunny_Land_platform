using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public int acorn = 0;

    [SerializeField]
    private Text acornText;

    public void Kill()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CanBePickUp"))
        {
            bool apppear = false;
            Item acornObject = collision.gameObject.GetComponent<Consumable>().item;
            if (acornObject != null)
            {
                apppear = true;
                acorn += 1;
                acornText.text = acorn.ToString();
            }

            if (apppear)
            {

                collision.gameObject.SetActive(false);
            }

        }
    }

}
