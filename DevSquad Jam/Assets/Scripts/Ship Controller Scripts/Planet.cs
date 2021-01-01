using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private ShipController shipController;

    public float orbitDistance;

    bool mouseOver = false;

    private void Start()
    {
        shipController = FindObjectOfType<ShipController>();
        orbitDistance = transform.localScale.x * 2f;
    }

    private void Update()
    {
        if (mouseOver)
            if(shipController.orbit)
                if (shipController.targetPlanet != this.transform)
                    if (Input.GetMouseButtonDown(0))
                        shipController.SetTrarget(this.transform);
    }


    private void OnMouseEnter()
    {
        mouseOver = true;
    }

    private void OnMouseExit()
    {
        mouseOver = false;
    }


}
