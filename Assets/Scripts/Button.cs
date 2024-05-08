using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(2);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Credits()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitDesktop()
    {
        Application.Quit();
    }
}