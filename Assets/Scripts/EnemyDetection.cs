using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyDetection : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI detectionText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDir = player.transform.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);

        if (angle < 20.0f)
        {
            detectionText.text = "Player Detected!";
        }
        else
        {
            detectionText.text = "Player Undetected!";
        }

    }
}
