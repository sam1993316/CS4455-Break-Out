using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// put this on the player
public class KeyCardCollector : MonoBehaviour
{
    // this class will tell us if the player has the various different keycards available in the level
        // setting the keyIDs to public will allow us to assign a key to one of these
    public bool hasYellowKey;
    public string YellowKeyID;

    public bool hasBlueKey;
    public string BlueKeyID; 

    private List<string> keys = new List<string>();

    void Start()
    {
        hasYellowKey = false;
        hasBlueKey = false;
    }

    public void ReceiveKey(string keyID)
    {
        if (keyID == YellowKeyID) {
            hasYellowKey = true;
            keys.Add(keyID);
        }
        if (keyID == BlueKeyID) {
            hasBlueKey = true;
            keys.Add(keyID);
        }
    }

    public bool HasKey(string keyID) {
        if (keys.Contains(keyID)) {
            return true;
        }
        return false;
    }

}
