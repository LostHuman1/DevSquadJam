using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewTask", menuName = "Task/Task")]
public class TaskSO : ScriptableObject
{
    public string objectiveName;
    [Multiline(10)]
    public string description;
    public float fuel;
    public float gold;
    
}
