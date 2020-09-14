using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ThirdPersonCamera : MonoBehaviour
{
    public GameObject target;
    private Vector3 offset;
    public GameObject oldTarget;
    void Start()
    {
        offset = transform.position - target.transform.position;
        oldTarget = target;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (oldTarget != target)
        {
            offset = transform.position - target.transform.position;
            oldTarget = target;
        }
        transform.position = target.transform.position + offset;


    }

}
