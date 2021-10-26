using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject inGameUI;
    public static bool gameIsPause = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        inGameUI.SetActive(true);
        Time.timeScale = 1f;
        gameIsPause = false;
    }
   public void Pause()
    {
        pauseUI.SetActive(true);
        inGameUI.SetActive(false);
        Time.timeScale = 0f;
        gameIsPause = true;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        gameIsPause = false;
    }

    public void Quit()
    {

        Application.Quit();
    }
}
