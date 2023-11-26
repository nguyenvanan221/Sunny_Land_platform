using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PermanentUI : MonoBehaviour
{
    public static PermanentUI perm;

    [HideInInspector]
    public int acorn = 0;
    public TextMeshProUGUI acornText;
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        //singleton
        if (perm != null && perm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            perm = this;
        }
    }

    public void Reset()
    {
        acorn = 0;
        acornText.text = acorn.ToString();
    }
}
