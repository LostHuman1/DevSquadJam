using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TaskSystem : MonoBehaviour
{
    public enum Planets
    {
        //GENERIC,
        MERCURY,
        VENUS,
        EARTH,
        MARS,
        JUPITER,
        SATURN,
        URANUS,
        NEPTUNE,
        PLUTO
    }

    [System.Serializable]
    public struct Task
    {
        public Planets planet;
        public TaskSO[] tasks;
    }
    public Task[] tasks;
    public TextMeshProUGUI objectiveText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI fuelText;
    public TextMeshProUGUI goldText;
    
    public int allTask;
   
    private int randomTask;
    private int randomPlanet;
    private Planets previousPlanet;
    public TaskSO nowTask;
    private Planets nowPlanet;
    public List<TaskSO> taskSOCheckList = new List<TaskSO>();

    public bool isCompleteAll = false;
    private void Start()
    {
        previousPlanet = (Planets)Random.Range(0, tasks.Length);
        while(previousPlanet == Planets.EARTH)
        {
            previousPlanet = (Planets)Random.Range(0, tasks.Length);
        }
        nowTask = tasks[(int)previousPlanet].tasks[randomTask];
        SetRandomTaskWindow(nowTask);
        for (int y = 0; y < tasks.Length; y++)
        {
            for(int x = 0; x< tasks[y].tasks.Length; x++)
            {
                allTask++;
            }
        }
    }
    public void SetRandomTaskWindow(TaskSO task)
    {
        
        objectiveText.text = task.objectiveName;
        descriptionText.text = "  " + task.description;
        fuelText.text = task.fuel.ToString();
        goldText.text = task.gold.ToString();
        previousPlanet = (Planets)randomPlanet;
        taskSOCheckList.Add(task);
    }
    public void RandomTaskSO()
    {
        if(taskSOCheckList.Count >= allTask)
        {
            isCompleteAll = true;
            return;
        }
        int i = 0;
        while (nowPlanet == previousPlanet)
        {
            RandomPlanet();
        }
        while (taskSOCheckList.Contains(nowTask))
        {
            randomTask = Random.Range(0, tasks[randomPlanet].tasks.Length);
            nowTask = tasks[randomPlanet].tasks[randomTask];
            if(i > tasks[randomPlanet].tasks.Length - 1)
            {
                RandomPlanet();
            }
            i++;
        }
        SetRandomTaskWindow(nowTask);
    }

    public void RandomPlanet()
    {
        randomPlanet = Random.Range(0, tasks.Length);
        nowPlanet = tasks[randomPlanet].planet;
        
    }
}
