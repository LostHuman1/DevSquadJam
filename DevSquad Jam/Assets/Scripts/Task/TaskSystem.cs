using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TaskSystem : MonoBehaviour
{
    public enum Planets
    {
        GENERIC,
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
    
    private int randomTask;
    private int randomPlanet;
    public TaskSO previousTask;
    private Planets previousPlanet;
    public TaskSO nowTask;
    private Planets nowPlanet;
    public List<TaskSO> doneTask = new List<TaskSO>();
    private void Start()
    {
        previousPlanet = (Planets)Random.Range(0, tasks.Length);
        randomTask  = Random.Range(0, tasks[(int)previousPlanet].tasks.Length);
        previousTask = tasks[(int)previousPlanet].tasks[randomTask];
        SetRandomTaskWindow(previousTask);
    }
    public void SetRandomTaskWindow(TaskSO task)
    {
        objectiveText.text = task.objectiveName;
        descriptionText.text = "  " + task.description;
        fuelText.text = task.fuel.ToString();
        goldText.text = task.gold.ToString();
        previousPlanet = (Planets)randomPlanet;
        previousTask = task;
        nowTask = previousTask;
        doneTask.Add(task);
    }
    public void RandomTaskSO()
    {
        RandomPlanet();
        while (nowTask == previousTask && doneTask.Contains(nowTask))
        {
            randomTask = Random.Range(0, tasks[randomPlanet].tasks.Length);
            nowTask = tasks[randomPlanet].tasks[randomTask];
        }
        SetRandomTaskWindow(nowTask);
    }

    public void RandomPlanet()
    {
        while (nowPlanet == previousPlanet && tasks.Length != 0)
        {
            randomPlanet = Random.Range(0, tasks.Length);
            nowPlanet = tasks[randomPlanet].planet;
        }
    }
}
