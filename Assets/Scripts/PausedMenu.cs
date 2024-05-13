using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedButton : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            pauseMenu.SetActive(isPaused);

            // Pause the game
            if (isPaused)
            {
                Time.timeScale = 0;
                Input.multiTouchEnabled = false;
            }
            else
            {
                Time.timeScale = 1;
                Input.multiTouchEnabled = true;
            }
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void QuitDesktop()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}