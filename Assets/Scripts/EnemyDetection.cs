using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR;

public class EnemyDetection : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyEyes;
    public TextMeshProUGUI detectionText;
    public Rigidbody body;

    float FOVAngle = 20;
    float lookRadius = 8f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 fovRadius = enemyEyes.gameObject.transform.forward * lookRadius;
        float playerAngle = Vector3.Angle(player.gameObject.transform.position - enemyEyes.gameObject.transform.position, fovRadius);

        if (playerAngle < FOVAngle)
        {
            RaycastHit hit;

            Vector3 newPlayerDirection = player.gameObject.transform.position - enemyEyes.gameObject.transform.position;
            Debug.DrawRay(enemyEyes.gameObject.transform.position, newPlayerDirection);
            if (Physics.Raycast(enemyEyes.gameObject.transform.position, newPlayerDirection, out hit))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    detectionText.text = "Player detected";
                }
                else
                {
                    detectionText.text = "Something other than player detected";
                }
            }
            else
            {
                detectionText.text = "Nothing detected";
            }
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
