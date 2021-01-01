using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCheck : MonoBehaviour
{
    public float fuel;

    void Update()
    {
        fuel -= Time.deltaTime;
    }
}
