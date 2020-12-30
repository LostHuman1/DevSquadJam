using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    GameObject pauseMenu;
    public bool isGamePause = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePause)
            {
                Resume();
            }
            else
            {
                OnPause();
            }
        }
    }

    public void Resume()
    {
        if (pauseMenu.activeSelf) pauseMenu.SetActive(false);
        isGamePause = false;
    }
    
    public void OnPause()
    {
        pauseMenu.SetActive(true);
        isGamePause = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
