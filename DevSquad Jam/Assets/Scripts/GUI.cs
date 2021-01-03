using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUI : MonoBehaviour
{
    private ShipController shipController;


    public float gold = 100;


    public float fuel;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    [HideInInspector]public float newFuel;
    float newGold = 100f;
    [SerializeField] TMPro.TMP_Text goldText;
=======
    [HideInInspector] public float newFuel;
>>>>>>> d6a6430a4da4524095268556c051a0fec54740bb
=======
    [HideInInspector] public float newFuel;
>>>>>>> d6a6430a4da4524095268556c051a0fec54740bb
=======
    [HideInInspector] public float newFuel;
>>>>>>> d6a6430a4da4524095268556c051a0fec54740bb
=======
    [HideInInspector] public float newFuel;
>>>>>>> d6a6430a4da4524095268556c051a0fec54740bb
    [SerializeField] TMPro.TMP_Text fuelText;
    public TMPro.TMP_Text errorText;
    float errorTime = 0f;
    public TMPro.TMP_Text planetNameText;

    [SerializeField] GameObject pauseMenu;
    public bool isGamePause = false;

    [SerializeField] private AudioCue buttonAudioCue;
    [SerializeField] private AudioManager audioManager;
    void Start()
    {

        shipController = FindObjectOfType<ShipController>();
        fuel = shipController.currentFuel;
        newFuel = fuel;
        fuelText.text = "FUEL: " + fuel.ToString("0.00");
        planetNameText.text = "";
        errorText.text = "";
        goldText.text = "GOLD: " + gold.ToString();
    }

    void Update()
    {
        //Fuel
        fuel = Mathf.Lerp(fuel, newFuel, 5 * Time.deltaTime);
        fuelText.text = "FUEL: " + fuel.ToString("0.00");
        if (fuel <= 100)
        {
            fuelText.color = Color.red;
        }
        else
        {
            fuelText.color = Color.white;
        }

        //Pause
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

        //error text
        errorTime += Time.deltaTime;
        if (errorTime >= 2f)
        {
            errorText.text = "";
        }


        gold = Mathf.Lerp(gold, newGold, 5 * Time.deltaTime);
        goldText.text = "GOLD: " + gold.ToString("0");
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
    public void SetMusicVolume(float volume)
    {
        audioManager.SetGroupVolume("BGMVolume", volume);
    }
    public void SetSFXVolume(float volume)
    {
        audioManager.SetGroupVolume("SFXVolume", volume);
    }
    public void PlayButtonSFX()
    {
        buttonAudioCue.PlayAudioCue();
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetErrorText(string text)
    {
        errorText.text = text;
        errorTime = 0f;
    }

    public void AddGold(float value)
    {
        newGold += value;
    }
}
