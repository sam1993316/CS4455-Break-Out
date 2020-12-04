using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Aiming : MonoBehaviour
{

    public CinemachineFreeLook thirdPersonCamera;
    public GameObject crosshair;
    public Transform aimLookAt;
    public Transform defaultLookAt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            if (thirdPersonCamera.m_Lens.FieldOfView == 40)
            {
                thirdPersonCamera.m_Lens.FieldOfView = 20;
                thirdPersonCamera.LookAt = aimLookAt;
                crosshair.SetActive(true);
            }
            else
            {
                thirdPersonCamera.m_Lens.FieldOfView = 40;
                thirdPersonCamera.LookAt = defaultLookAt;
                crosshair.SetActive(false);
            }
        }
    }
}
