using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    public void PlayAgain()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void NextLevel()
    {

    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
