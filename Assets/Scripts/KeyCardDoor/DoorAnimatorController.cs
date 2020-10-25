using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimatorController : MonoBehaviour
{
    public string thisDoorsKey;
    public GameObject player;
    private KeyCardCollector kc;


    // [SerializeField] private Animator slideDoorController;
    private void OnTriggerEnter(Collider c)
    {
        // inlcude a check here for a keycard
        kc = player.GetComponent<KeyCardCollector>();
        if (c.CompareTag("Player"))
        {
            Debug.Log("Player has entered Door Collider");
            // slideDoorController.SetBool("slide", true);
        }
        
    }

    private void OnTriggerExit(Collider c)
    {
        if (c.CompareTag("Player"))
        {
            Debug.Log("Player has exited the Door Collider");
            // slideDoorController.SetBool("slide", false);
        }
    }
}
