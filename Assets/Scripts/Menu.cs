using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject help;
    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitApp()
    {
        Application.Quit();
    }

    public void HelpKeys(bool state)
    {
        help.SetActive(state);
    }
}
