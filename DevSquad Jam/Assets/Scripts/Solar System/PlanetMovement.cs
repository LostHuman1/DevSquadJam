using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    [SerializeField] int speed = 10;
    [SerializeField] int orbitSpeed = 10; 
    

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, Time.deltaTime * speed, 0);
        transform.RotateAround(Vector3.zero, Vector3.up, orbitSpeed * Time.deltaTime);
    }
}
