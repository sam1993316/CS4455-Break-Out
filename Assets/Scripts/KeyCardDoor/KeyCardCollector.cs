using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardCollector : MonoBehaviour
{
    // this class will tell us if the player has the various different keycards available in the level
        // setting the keyIDs to public will allow us to assign a key to one of these
    public bool hasYellowKey;
    public string YellowKeyID;

    public bool hasBlueKey;
    public string BlueKeyID; 

    void Start()
    {
        hasYellowKey = false;
        hasBlueKey = false;
    }

    public void ReceiveKey(string keyID)
    {
        if (keyID == YellowKeyID) {
            hasYellowKey = true;
        }
        if (keyID == BlueKeyID) {
            hasBlueKey = true;
        }
    }
}
