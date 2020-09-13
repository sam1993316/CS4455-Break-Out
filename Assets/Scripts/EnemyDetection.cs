using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyDetection : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI detectionText;
    public Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDir = player.transform.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);

        if (angle < 20.0f)
        {
            detectionText.text = "Player Detected!";
            moveTowardsPlayer();
        }
        else
        {
            detectionText.text = "Player Undetected!";
        }

    }

    void moveTowardsPlayer()
    {
        float speed = 1.0f;
        float distanceToStop = 5.0f;
        if (Vector3.Distance(transform.position, player.transform.position) > distanceToStop)
        {
            transform.LookAt(player.transform);
            body.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);
        }
    }
}
