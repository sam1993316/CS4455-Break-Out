using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;

public class GuardStateMachine : MonoBehaviour
{
    public enum State
    {
        patrol,
        chase,
        qtevent
    }

    public GameObject[] waypoints;

    private NavMeshAgent agent;
    private State state;
    private int currWaypoint;

    public GameObject eyes;
    public GameObject player;
    public TextMeshProUGUI detectionText;

    private float maxFOVAngle = 20;
    private float lookRadius = 1f;
    public float sightRange = 0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = State.patrol;
        currWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.patrol:
                if (agent.remainingDistance < 1f && agent.pathPending == false)
                {
                    currWaypoint = currWaypoint == 0 ? 1 : 0;
                }
                agent.SetDestination(waypoints[currWaypoint].transform.position);
                findPlayer();
                break;
            case State.chase:
                agent.SetDestination(player.transform.position);
                findPlayer();
                break;
            case State.qtevent:
                break;
        }
    }

    void findPlayer()
    {
        //Raycast to look for player, if player is found, set state to chase, otherwise set state to patrol
        Vector3 fovRadius = eyes.transform.forward * lookRadius;
        float playerAngle = Vector3.Angle(player.transform.position - eyes.transform.position, fovRadius);


        Vector3 playerDirection = player.transform.position - eyes.transform.position;
        Vector3 playerHeight = new Vector3(0, transform.localScale.y, 0);

        if (playerAngle < maxFOVAngle)
        {
            RaycastHit hit;

            

            if (Physics.Raycast(eyes.transform.position, playerDirection + playerHeight, out hit, sightRange))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.DrawRay(eyes.transform.position, playerDirection + playerHeight);
                    detectionText.text = "Player found";
                    state = State.chase;
                }
                else
                {
                    detectionText.text = "Player not found 1";
                    state = State.patrol;
                }
            }
            else
            {
                detectionText.text = "Player not found 2";
            }
        }



    }
}