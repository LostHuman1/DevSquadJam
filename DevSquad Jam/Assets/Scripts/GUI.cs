using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI : MonoBehaviour
{
    private ShipController shipController;


    //public float credits;


    public float fuel;
    [HideInInspector]public float newFuel;
    [SerializeField] TMPro.TMP_Text fuelText;

    void Start()
    {

        shipController = FindObjectOfType<ShipController>();
        fuel = shipController.currentFuel;
        newFuel = fuel;
        fuelText.text = "FUEL: " + fuel.ToString("0.00");
    }

    void Update()
    {
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
    }

}
