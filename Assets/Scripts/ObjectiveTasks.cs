using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveTasks : MonoBehaviour
{

    public Text tasksText;
    public string currentTask;

    private Collider m_ObjectCollider;


    // Start is called before the first frame update
    void Start()
    {
        m_ObjectCollider = GetComponent<Collider>();
        m_ObjectCollider.isTrigger = true;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tasksText.text = currentTask;
            m_ObjectCollider.isTrigger = false;
        }
    }
}
