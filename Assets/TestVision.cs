using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVision : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(gameObject.transform.position, player.gameObject.transform.position);
    }
}
