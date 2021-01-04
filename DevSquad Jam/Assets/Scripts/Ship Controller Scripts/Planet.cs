using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private ShipController shipController;
    private GUI gui;
    public GameObject highLight;

    public float orbitDistance;

    bool mouseOver = false;

    private void Start()
    {
        shipController = FindObjectOfType<ShipController>();
        orbitDistance = transform.localScale.x * 2f;
        gui = FindObjectOfType<GUI>();
    }

    private void Update()
    {
        if (mouseOver)
            if(shipController.orbit)
                if (shipController.targetPlanet != this.transform)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        shipController.SetTrarget(this.transform);
                        if (shipController.CheckTask())
                        {
                            shipController.taskSystem.RandomTaskSO();
                        }
                    }
                }
                else
                {
                    gui.SetErrorText("TARGET NOT VALID");
                }

        if (shipController.CheckPosition(this))
        {
            highLight.SetActive(true);
        }
        else
        {
            highLight.SetActive(false);
        }

    }


    private void OnMouseEnter()
    {
        mouseOver = true;
        gui.planetNameText.text = gameObject.name;
    }

    private void OnMouseExit()
    {
        mouseOver = false;
        gui.planetNameText.text = "";
    }


}
