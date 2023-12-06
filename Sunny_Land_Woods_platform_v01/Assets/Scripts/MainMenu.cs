using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject panelToLoad;
    public void PlayGame()
    {
        panelToLoad.SetActive(true);
    }

    public void BackToMenu()
    {
        panelToLoad.SetActive(false);
    }

    public void LoadControls()
    {
        panelToLoad.SetActive(true);

    }

    public void LoadCredits()
    {
        panelToLoad.SetActive(true);

    }

    public void Quit()
    {
        Application.Quit();
    }
}
