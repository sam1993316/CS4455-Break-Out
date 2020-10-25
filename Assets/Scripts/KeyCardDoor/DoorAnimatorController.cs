using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// place this script on the door's collider
public class DoorAnimatorController : MonoBehaviour
{
    public string thisDoorsKey;
    public GameObject player;
    private KeyCardCollector kc;


    [SerializeField] private Animator movingDoorController;
    // public Animator movingDoorController;

    private void OnTriggerEnter(Collider c)
    {
        // inlcude a check here for a keycard
        kc = player.GetComponent<KeyCardCollector>();
        if (c.CompareTag("Player") && kc.HasKey(thisDoorsKey))
        {
            Debug.Log("Player has entered Door Collider");
            movingDoorController.SetBool("playerEnter", true);
        }
        
    }

    private void OnTriggerExit(Collider c)
    {
        if (c.CompareTag("Player"))
        {
            Debug.Log("Player has exited the Door Collider");
            movingDoorController.SetBool("playerEnter", false);
        }
    }
}
