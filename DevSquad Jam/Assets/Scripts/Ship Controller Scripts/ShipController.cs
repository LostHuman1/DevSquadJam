using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public Planet[] planets;
    public TaskSystem taskSystem;
    //mercury   0
    //venus     1
    //earth     2
    //mars      3
    //jupiter   4
    //saturn    5
    //uranus    6
    //neptune   7
    //pluto     8

    int currentPlanet;
    public Transform targetPlanet;
    [HideInInspector] public bool orbit = false;
    float percentage = 0f;
    float offset;
    [SerializeField] float orbitSpeed = 20.0f;

    GUI gui;
    
    TrailRenderer trailRenderer;

    public float maxFuel = 100f;
    public float currentFuel = 100f;

    private void Start()
    {
        gui = FindObjectOfType<GUI>();
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.enabled = false;
        transform.parent = targetPlanet;
        for (int i = 0; i <= 8; i++)
        {
            if (targetPlanet.GetComponent<Planet>() == planets[i])
            {
                currentPlanet = i;
            }
        }
        SetTrarget(targetPlanet);
    }

    private void Update()
    {
        //Ship Move
        if (!orbit)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPlanet.position.x + offset, percentage), 0, Mathf.Lerp(transform.position.z, targetPlanet.position.z, percentage));
            percentage += Time.deltaTime;
            if(percentage >= 1f)
            {
                orbit = true;
                for (int i = 0; i <= 8; i++)
                {
                    if (targetPlanet.gameObject.GetComponent<Planet>() == planets[i])
                    {
                        currentPlanet = i;
                    }
                }
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
            if (CheckPosition(target.gameObject.GetComponent<Planet>()))
            {
                targetPlanet = target;
                orbit = false;
                offset = target.gameObject.GetComponent<Planet>().orbitDistance;
                transform.parent = target;
                trailRenderer.enabled = true;
                transform.localScale = new Vector3(0.2f / target.localScale.x, 0.2f / target.localScale.y, 0.2f / target.localScale.z);
            }  
        }   
    }

    bool enoughFuel(Transform target)
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance > currentFuel)
        {
            gui.SetErrorText("NOT ENOUGH FUEL");
            return false;
        }
        currentFuel -= distance;
        gui.newFuel = currentFuel;
        return true;
    }

    bool CheckPosition(Planet target)
    {
        for (int i = 0; i <= 8; i++)
        {
            if (target == planets[i])
            {
                if(i == currentPlanet + 1 || i == currentPlanet - 1)
                {
                    return true;
                }
            }
        }
        gui.SetErrorText("TARGET NOT VALID");
        return false;
    }

    public bool CheckTask()
    {
        if(taskSystem.nowTask.objectiveName == targetPlanet.GetComponent<Planet>().name)
        {
            currentFuel += taskSystem.nowTask.fuel;
            gui.AddGold(taskSystem.nowTask.gold);
            return true;
        }
        return false;
    }

}
