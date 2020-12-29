using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settings;
    public GameObject credits;
    public AudioManager audioManager;
    public void Settings()
    {
        if (!settings.activeInHierarchy)
        {
            settings.SetActive(true);
            credits.SetActive(false);
        }
        else
        {
            settings.SetActive(false);
        }       
    }

    public void Credits()
    {
        if (!credits.activeInHierarchy)
        {
            credits.SetActive(true);
            settings.SetActive(false);
        }
        else
        {
            credits.SetActive(false);
        }
    }
    public void BGMVolumeSetting(float volume)
    {
        audioManager.SetGroupVolume("BGMVolume",volume);
    }
    public void SFXVolumeSetting(float volume)
    {
        audioManager.SetGroupVolume("SFXVolume",volume);
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
