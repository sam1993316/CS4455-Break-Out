using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using TMPro;

public class EnemyFOV : MonoBehaviour
{
    public GameObject eyes;
    public GameObject player;
    public TextMeshProUGUI detectionText;
    float maxFOVAngle = 30;
    float lookRadius = 8f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fovRadius = eyes.gameObject.transform.forward * lookRadius;
        float playerAngle = Vector3.Angle(player.gameObject.transform.position - eyes.gameObject.transform.position, fovRadius);

        Debug.DrawRay(eyes.gameObject.transform.position, player.gameObject.transform.position);
        if (playerAngle < maxFOVAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(eyes.gameObject.transform.position, player.gameObject.transform.position, out hit))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("HIT");
                    detectionText.text = "Player detected";
                }
                else
                {
                    Debug.Log("no player hit");
                    detectionText.text = "Player NOT detected";
                }
            } else
            {
                Debug.Log("nothing hit");
                detectionText.text = "NOTHING detected";
            }
        }
    }

    
}
