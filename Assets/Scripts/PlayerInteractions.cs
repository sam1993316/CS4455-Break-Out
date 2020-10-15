using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    // === Variables
    [Header("InteractableInfo")]
    // public float sphereCastRadius = 0.5f;
    public int interactableLayerIndex;
    private Vector3 raycastPos;
    // public GameObject lookObject;
    // private PhysicsObject physicsObject;
    private Camera mainCamera;

    // [Header("Pickup")]
    // [SerializeField] private Transform pickupParent;
    // public GameObject currentlyPickedUpObject;
    // private Rigidbody pickupRB;

    // [Header("ObjectFollow")]
    // [SerializeField] private float minSpeed = 0;
    // [SerializeField] private float maxSpeed = 300f;
    // [SerializeField] private float maxDistance = 10f;
    // private float currentSpeed = 0f;
    // private float currentDist = 0f;

    // [Header("Rotation")]
    // public float rotationSpeed = 100f;
    // Quaternion lookRot;




    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main; //grabs the camera in the scene if it's the only camera, else you would have to iterate
        interactableLayerIndex = 1 << 8;
        Debug.Log(mainCamera);
    }

    // float hitnumber = 0;
    // Update is called once per frame
    void Update()
    {
        // Checks for hits with sphereraycast then assign the lookobject as the object that has been hit
        RaycastHit hit;
        // origin point
        raycastPos = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));      
        bool rayhit = Physics.Raycast(raycastPos, raycastPos + mainCamera.transform.forward, out hit, 5, 1 << 8); // this will cast rays on colliders in the 8th layer
        Debug.Log("Did the ray hit a collider in layer 8: " + rayhit);
        Debug.DrawLine(raycastPos, raycastPos + mainCamera.transform.forward, Color.red);
        
        
        // Debug.Log(hit.transform.position);

        // if (Physics.SphereCast(raycastPos, sphereCastRadius, mainCamera.transform.forward, out hit, maxDistance, 8)) 
        // {
        //     lookObject = hit.Collider.transform.root.gameObject;
        // }
        // else
        // {
        //     lookObject = null;
        // }

        // check to see if the player has decided to pick up an object
        // if (Input.GetMouseButtonDown(0)) 
        // {
        //     //currently not holding anything
        //     if (currentlyPickedUpObject == null) 
        //     {
        //         // if we are looking at an interactable object
        //         if (lookObject != null) 
        //         {
        //             PickUpObject();
        //         }
        //     }
        //     // if we are currently holding an object
        //     else
        //     {   
        //         BreakConnection();
        //     }
        // }

        // // if the object gets stuck behind a wall while you're still holding it, then if you walk faraway enough it will break the connection
        // if (currentlyPickedUpObject != null && currentDist > maxDistance) BreakConnection();
    }

    // Velocity movement toward pickup parent and rotation
    private void FixedUpdate() 
    {
        // if (currentlyPickedUpObject != null)
        // {
        //     currentDist = Vector3.Distance(pickupParent.position, pickupRB.position);
        //     currentSpeed = Mathf.SmoothStep(minSpeed, maxSpeed, currentDist/maxDistance);
        //     currentSpeed = Time.fixedDeltaTime;
        //     Vector3 direction = pickupParent.position - pickupRB.position;
        //     pickupRB.velocity = direction.normalized * currentSpeed;        

        //     // Rotation
        //     lookRot = Quaternion.LookRotation(mainCamera.transform.position - currentlyPickedUpObject.transform.position);
        //     lookRot = Quaternion.Slerp(mainCamera.transform.rotation, lookRot, rotationSpeed * Time.fixedDeltaTime);
        //     pickupRB.MoveRotation(lookRot);
        // }
    }

    // // Release the object
    // public void PickUpObject() 
    // {
    //     physicsObject = lookObject.GetComponentInChildren<PhysicsObject>(); //grabs the PhysicsObject script from the lookObject/the hit object
    //     currentlyPickedUpObject = lookObject;
    //     pickupRB = currentlyPickedUpObject.GetComponent<Rigidbody>();
    //     pickupRB.constraints = RigidbodyConstraints.FreezeRotation;
    //     physicsObject.playerInteractions = this;
    //     StartCoroutine(physicsObject.PickUp()); // unsure what this does
    // }

    // public void BreakConnection()
    // {
    //     pickupRB.constraints = RigidbodyConstraints.None;
    //     currentlyPickedUpObject = null;
    //     physicsObject.pickedUp = false;
    //     currentDist = 0;
    // }
}
