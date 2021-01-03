using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUI : MonoBehaviour
{
    private ShipController shipController;


    //public float credits;


    public float fuel;
    [HideInInspector]public float newFuel;
    [SerializeField] TMPro.TMP_Text fuelText;
    public TMPro.TMP_Text errorText;
    float errorTime = 0f;
    public TMPro.TMP_Text planetNameText;

    [SerializeField]GameObject pauseMenu;
    public bool isGamePause = false;

    void Start()
    {

        shipController = FindObjectOfType<ShipController>();
        fuel = shipController.currentFuel;
        newFuel = fuel;
        fuelText.text = "FUEL: " + fuel.ToString("0.00");
        planetNameText.text = "";
        errorText.text = "";
    }

    void Update()
    {
        //Fuel
        fuel = Mathf.Lerp(fuel, newFuel, 5 * Time.deltaTime);
        fuelText.text = "FUEL: " + fuel.ToString("0.00");
        if(fuel <= 100)
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
        if(errorTime >= 2f)
        {
            errorText.text = "";
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

    public void SetErrorText(string text)
    {
        errorText.text = text;
        errorTime = 0f;
    }
}
