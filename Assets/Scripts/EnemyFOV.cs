using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using TMPro;

public class EnemyFOV : MonoBehaviour
{
    public GameObject eyes;
    public GameObject player;
    public GameObject test;
    public TextMeshProUGUI detectionText;
    float maxFOVAngle = 20;
    float lookRadius = 8f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 fovRadius = eyes.gameObject.transform.forward * lookRadius;
        float playerAngle = Vector3.Angle(player.gameObject.transform.position - eyes.gameObject.transform.position, fovRadius);


        if (playerAngle < maxFOVAngle)
        {
            
            RaycastHit hit;

            // player - enemy's eyes position for direction, bc just player will use position from origin to player instead of enemy eye to player
            Vector3 newPlayerDirection = player.gameObject.transform.position - eyes.gameObject.transform.position;
            Debug.DrawRay(eyes.gameObject.transform.position, newPlayerDirection);
            if (Physics.Raycast(eyes.gameObject.transform.position, newPlayerDirection, out hit))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("HIT");
                    detectionText.text = "Player detected";
                    moveTowardsPlayer();
                }
                else
                {
                    Debug.Log("no player hit");
                    detectionText.text = "Player NOT detected";
                }
            }
            else
            {
                Debug.Log("nothing hit");
                detectionText.text = "NOTHING detected";
            }
        }
    }

    void moveTowardsPlayer()
    {
        float speed = 5.0f;
        float distanceToStop = 5.0f;
        Vector3 position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, player.transform.position) > distanceToStop)
        {
            transform.LookAt(player.transform);
            //rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);
            rb.MovePosition(position);
            
        }
    }
}