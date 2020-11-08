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
        qtevent,
        investigateSound
    }

    public GameObject[] waypoints;

    private NavMeshAgent agent;
    private State state;
    private int currWaypoint;

    public GameObject eyes;
    public GameObject player;
    public TextMeshProUGUI detectionText;
    public Animator animator;

    private float maxFOVAngle = 30;
    private float lookRadius = 4f;
    public float sightRange;

    private Vector3 soundLocation;
    public float investigationLengthLowerLimit = 12.0f;
    public float investigationLengthUpperLimit = 20.0f;
    private float investigationLength;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        state = State.patrol;
        currWaypoint = 0;
        sightRange = 20f;
    }

    private void OnAnimatorMove()
    {
        if (Time.timeScale > 0)
        {
            float speed = (animator.deltaPosition / Time.deltaTime).magnitude;
            if (!float.IsNaN(speed))
            {
                agent.speed = speed;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.patrol:
                if (waypoints.Length > 1)
                {
                    animator.SetBool("playerFound", false);
                }
                else
                {
                    animator.SetBool("Idle", true);
                }
                if (agent.remainingDistance < 1f && agent.pathPending == false)
                {
                    if (currWaypoint == waypoints.Length - 1)
                    {
                        currWaypoint = 0;
                    }
                    else
                    {
                        currWaypoint += 1;
                    }
                }
                agent.SetDestination(waypoints[currWaypoint].transform.position);
                findPlayer();
                break;
            case State.chase:
                if (agent.remainingDistance < 1f && agent.pathPending == false)
                {
                    TestControllerForThirdPersonCamera script = player.GetComponent<TestControllerForThirdPersonCamera>();
                    script.LoseGame();
                }
                agent.SetDestination(player.transform.position);
                animator.SetBool("Idle", false);
                animator.SetBool("playerFound", true);
                findPlayer();
                break;
            case State.qtevent:
                break;
            case State.investigateSound:
                // Debug.Log("Investigating Sound " + investigationLength);
                if (agent.remainingDistance < 1f && agent.pathPending == false)
                {
                    animator.SetBool("Idle", true);
                }
                agent.SetDestination(soundLocation);
                investigationLength -= Time.deltaTime;
                if (investigationLength <= 0.0f)
                {
                    Debug.Log("Got bored of sound, going back to patrolling");
                    state = State.patrol;
                    animator.SetBool("Idle", false);
                }
                findPlayer();
                break;
        }
    }

    void findPlayer()
    {
        //Raycast to look for player, if player is found, set state to chase, otherwise set state to patrol
        Vector3 fovRadius = eyes.transform.forward * lookRadius;
        float playerAngle = Vector3.Angle(player.transform.position - eyes.transform.position, fovRadius);


        Vector3 playerDirection = player.transform.position - eyes.transform.position;
        Vector3 playerHeight = new Vector3(0, transform.localScale.y * 1.5f, 0);

        if (playerAngle < maxFOVAngle)
        {
            RaycastHit hit;
            


            if (Physics.Raycast(eyes.transform.position, playerDirection + playerHeight, out hit, sightRange))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    //Debug.DrawRay(eyes.transform.position, playerDirection + playerHeight);
                    //detectionText.text = "Player found";
                    //Debug.Log("Player found");
                    float y_distance = Math.Abs(hit.collider.transform.position.y - this.transform.position.y);
                    if (y_distance <= 2.0f) //Make sure that cop can't see the player if the player is high up
                    {
                        state = State.chase;
                    }
                }
                else
                {
                    //detectionText.text = "Player not found 1";
                    //Debug.Log("Player not found 1");
                    if (state == State.chase)
                    {
                        state = State.patrol;
                    }
                }
            }
            else
            {
                //detectionText.text = "Player not found 2";
                //Debug.Log("Player not found 2");
            }
        }
    }

    public void noticeSound(Vector3 soundLocation)
    {
        if (state != State.chase)
        {
            this.soundLocation = soundLocation;
            investigationLength = UnityEngine.Random.Range(investigationLengthLowerLimit, investigationLengthUpperLimit);
            state = State.investigateSound;
            Debug.Log("Going to investigate " + soundLocation + " for " + investigationLength);
        }
    }
}