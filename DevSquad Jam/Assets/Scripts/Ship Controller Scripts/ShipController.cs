using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public Transform targetPlanet;
    GUI gui;
    float offset;
    [SerializeField] float orbitSpeed = 20.0f;
    public bool orbit = false;
    float percentage = 0f;
    TrailRenderer trailRenderer;

    public float maxFuel = 100f;
    public float currentFuel = 100f;

    private void Start()
    {
        gui = FindObjectOfType<GUI>();
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.enabled = false;
        SetTrarget(targetPlanet);
    }

    private void Update()
    {
        if (!orbit)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPlanet.position.x + offset, percentage), 0, Mathf.Lerp(transform.position.z, targetPlanet.position.z, percentage));
            percentage += Time.deltaTime;
            if(percentage >= 1f)
            {
                orbit = true;
                trailRenderer.enabled = false;
                percentage = 0f;
            }
        }

        
        //if (orbit)
        //{
        //    transform.RotateAround(targetPlanet.position, Vector3.up, orbitSpeed * Time.deltaTime);
        //    transform.rotation = Quaternion.Euler(0, targetPlanet.rotation.y, 0);
        //}
    }

    public void SetTrarget(Transform target)
    {
        if (enoughFuel(target))
        {
            targetPlanet = target;
            orbit = false;
            offset = target.gameObject.GetComponent<Planet>().orbitDistance;
            transform.parent = target;
            trailRenderer.enabled = true;
            transform.localScale = new Vector3(0.2f / target.localScale.x, 0.2f / target.localScale.y, 0.2f / target.localScale.z) ;
        }
        
        
    }

    bool enoughFuel(Transform target)
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance > currentFuel)
        {
            Debug.Log("NOT ENOUGH FUEL!");
            return false;
        }
        currentFuel -= distance;
        gui.newFuel = currentFuel;
        return true;
    }

}
