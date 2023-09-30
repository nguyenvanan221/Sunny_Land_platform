using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int hitPoins = 3;

    public void Kill()
    {
        Destroy(gameObject);
    }

    
}
