using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public GameObject buttonPrefab;
    public const int numButtons = 2;
    GameObject[] buttonsObject = new GameObject[numButtons];
    public Button[] buttons;

    private void Awake()
    {
        CreateButtons();
        LockedLevel();
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
                buttonsObject[i] = btn;

                TextMeshProUGUI text = btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                text.text = (i + 1).ToString();

                buttonsObject[i].GetComponent<LevelButtons>().level = i + 1;
                
                if (i < buttons.Length)
                {
                    buttons[i] = buttonsObject[i].GetComponent<Button>();

                }

            }
            
        }
    }

    public void LockedLevel()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i=0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i=0; i<unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }

}
