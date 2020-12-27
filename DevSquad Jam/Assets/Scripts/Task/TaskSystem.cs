using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TaskSystem : MonoBehaviour
{
    public TaskSO[] tasks;

    public TextMeshProUGUI objectiveText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI fuelText;
    public TextMeshProUGUI goldText;
    
    private int random;
    private List<int> checkList = new List<int>();
    
    public void SetRandomTaskWindow()
    {
        objectiveText.text = tasks[random].objectiveName;
        descriptionText.text = "  " + tasks[random].description;
        fuelText.text = tasks[random].fuel.ToString();
        goldText.text = tasks[random].gold.ToString();

    }
    public TaskSO GetRandomTaskSO()
    {
        while (checkList.Contains(random) && checkList.Count != tasks.Length)
        {
            if(tasks.Length == 1)
            {
                return tasks[0];
            }
            random = UnityEngine.Random.Range(0, tasks.Length);
        }
        checkList.Add(random);
        SetRandomTaskWindow();
        return tasks[random];
    }
}
