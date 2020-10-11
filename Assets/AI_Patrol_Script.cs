using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class AI_Patrol_Script : MonoBehaviour
{
    public enum State
    {
        Patrol,
        Chase,
        QTEvent
    }

    public GameObject[] waypoints;
    public State state;

    private NavMeshAgent agent;
    private int currWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = State.Patrol;
        currWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            default:
            case State.Patrol:
                if (agent.remainingDistance < 0.1f)
                {
                    UpdateWaypoint();
                }
                if (currWaypoint == 0)
                {
                    //Go to waypoint 1
                    agent.SetDestination(waypoints[1].transform.position);
                }
                else if (currWaypoint == 1)
                {
                    //Go to waypoint 0
                    agent.SetDestination(waypoints[0].transform.position);
                }
                break;
            case State.Chase:
                break;
            case State.QTEvent:
                break;
        }
    }

    void UpdateWaypoint()
    {
        currWaypoint = currWaypoint == 0 ? 1 : 0;
    }

}

