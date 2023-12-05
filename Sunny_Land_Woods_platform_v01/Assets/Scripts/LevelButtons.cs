using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class LevelButtons : MonoBehaviour
{
    public GameObject buttonPrefab;
    public const int numButtons = 2;
    GameObject[] buttons = new GameObject[numButtons];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CreateButtons()
    {
        if (buttonPrefab != null)
        {
            Debug.Log("1");
            for (int i = 0; i < numButtons; i++)
            {
                GameObject btn = Instantiate(buttonPrefab);
                btn.name = "Button_" + i + 1;
                btn.transform.SetParent(gameObject.transform);
                buttons[i] = btn;
            }
        }
    }

}
