using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableKeyCard : MonoBehaviour
{
    // made public so that devs can set the key ID of a new key
    public string keyID;
    public Transform player;
    public GameObject playerObject;

    public float pickUpRange;

    private void Start() {
        pickUpRange = 3f;
    }

    private void Update() {
        Vector3 distanceToPlayer = player.position - this.transform.position;
        if (distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("Keycard: " + keyID + " has been picked up");
            takeCard();
        }
    }

    void takeCard() {
        Debug.Log("Key is being taken and stored away");
        KeyCardCollector kc = playerObject.GetComponent<KeyCardCollector>();
        if (kc != null) {
            Debug.Log("kc is not null proceeding to take the card");
            kc.ReceiveKey(keyID);
            Destroy(this.gameObject);
        }
        
    }

    // void OnTriggerEnter(Collider c)
    // {
    //     if (c.attachedRigidbody != null) {
    //         // BallCollector bc = c.attachedRigidbody.gameObject.GetComponent<BallCollector>();
    //         // Debug.LogError(bc);
    //         // if (bc != null) {
    //         //     bc.ReceiveBall();
    //         //     Destroy(this.gameObject);
    //         // }
    //     }
        
    // }
}
