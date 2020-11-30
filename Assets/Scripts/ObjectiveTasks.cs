using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveTasks : MonoBehaviour
{

    public Text tasksText;
    public string currentTask;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tasksText.text = currentTask;
        }
    }
}
