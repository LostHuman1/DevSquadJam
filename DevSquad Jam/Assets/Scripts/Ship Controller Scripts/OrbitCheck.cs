using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCheck : MonoBehaviour
{
    public GameObject player;
    public GameObject fuelDisplay;
    public GameObject fuelLow;
    private FuelCheck fuelCheck;
    private ShipController shipController;

    public float orbitDistance;

    private void Start()
    {
        fuelCheck = player.GetComponent<FuelCheck>();
        shipController = player.GetComponent<ShipController>();

        fuelDisplay.SetActive(false);
        fuelLow.SetActive(false);
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if(distance < orbitDistance)
        {
            fuelDisplay.SetActive(true);
            if(fuelCheck.fuel >= 10)
            {
                fuelLow.SetActive(false);
                shipController.orbit = true;


                if (Input.GetKey(KeyCode.O))
                {

                }
            }
            else
            {
                fuelLow.SetActive(true);

            }
        }
    }
}
