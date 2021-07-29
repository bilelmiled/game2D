using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePaused : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pausedMenu;
    public GameObject settingWindow;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else 
            {
                PauseMenu();
            }
        }
    }

    public void PauseMenu()
    {
        PlayerMove.Instance.enabled = false;
        pausedMenu.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void Resume()
    {
        PlayerMove.Instance.enabled = true;
        pausedMenu.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenSettings()
    {
        settingWindow.SetActive(true);
    }
    public void CloseSettings()
    {
        settingWindow.SetActive(false);
    }
}
