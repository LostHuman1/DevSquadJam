using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    [SerializeField] int speed = 10;
    

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, Time.deltaTime * speed, 0);
    }
}
