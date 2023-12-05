using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public GameObject buttonPrefab;
    public const int numButtons = 2;
    GameObject[] buttons = new GameObject[numButtons];

    private void Start()
    {
        CreateButtons();
    }

    public void OpenScene()
    {
        //SceneManager.LoadScene("Level " );
        SceneManager.LoadScene("SampleScene 1");

    }
    public void CreateButtons()
    {
        if (buttonPrefab != null)
        {
            for (int i = 0; i < numButtons; i++)
            {
                GameObject btn = Instantiate(buttonPrefab);
                btn.name = "Button_" + i;
                btn.transform.SetParent(gameObject.transform);
                buttons[i] = btn;
               
                TextMeshProUGUI text = btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                text.text = (i + 1).ToString();
            }
        }
    }

}
