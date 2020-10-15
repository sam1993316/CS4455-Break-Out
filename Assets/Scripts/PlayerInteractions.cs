using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [Header("InteractableInfo")]
    public float sphereCastRadius = 0.25f;
    public int interactableLayerIndex;
    private Vector3 raycastPos;
    public GameObject lookObject;
    // private PhysicsObject physicsObject;
    private Camera mainCamera;
    private GameObject pickUpRadius;

    [Header("Pickup")]
    [SerializeField] private Transform pickupParent;
    public GameObject currentlyPickedUpObject;
    private Rigidbody pickupRB;

    // [Header("ObjectFollow")]
    // [SerializeField] private float minSpeed = 0;
    // [SerializeField] private float maxSpeed = 300f;
    // [SerializeField] private float maxDistance = 4f;
    // private float currentSpeed = 0f;
    // private float currentDist = 0f;

    // [Header("Rotation")]
    // public float rotationSpeed = 100f;
    // Quaternion lookRot;




    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(LayerMask.NameToLayer("Interactable")); // layer mask index = 8 or 1 << 8, this returns the right layer mask
        interactableLayerIndex = LayerMask.NameToLayer("Interactable");
        mainCamera = Camera.main; //grabs the camera in the scene if it's the only camera, else you would have to iterate
    }

    // Update is called once per frame
    private void Update() {
        
    }

    private void FixedUpdate() {
        
    }

    
}

// public class PhysicsObject : MonoBehaviour
// {
//     // public float waitOnPickup = 0.2f;
//     // public float breakForce = 35f;
//     // [HideInInspector] public bool pickedUp = false;
//     // [HideInInspector] public PlayerInteractions playerInteractions;

//     // private void OnCollisionEnter(Collision c) {
//     //     if (pickedUp) 
//     //     {
//     //         if (c.relativeVelocity.magnitude > breakForce) 
//     //         {
//     //             playerInteractions.BreakConnection();
//     //         }
//     //     }
//     // }

//     // public IEnumerator PickUp()
//     // {
//     //     yield return new WaitForSecondsRealtime(waitOnPickup);
//     //     pickedUp = true;
//     // }
// }

// Velocity movement toward pickup parent and rotation
    // private void FixedUpdate() 
    // {
    //     // if (currentlyPickedUpObject != null)
    //     // {
    //     //     currentDist = Vector3.Distance(pickupParent.position, pickupRB.position);
    //     //     currentSpeed = Mathf.SmoothStep(minSpeed, maxSpeed, currentDist/maxDistance);
    //     //     currentSpeed = Time.fixedDeltaTime;
    //     //     Vector3 direction = pickupParent.position - pickupRB.position;
    //     //     pickupRB.velocity = direction.normalized * currentSpeed;        

    //     //     // Rotation
    //     //     lookRot = Quaternion.LookRotation(mainCamera.transform.position - currentlyPickedUpObject.transform.position);
    //     //     lookRot = Quaternion.Slerp(mainCamera.transform.rotation, lookRot, rotationSpeed * Time.fixedDeltaTime);
    //     //     pickupRB.MoveRotation(lookRot);
    //     // }
    // }

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

// void Update()
//     {
//         // This is a raycast from the Camera, and Camera direction
//         raycastPos = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));       
//         RaycastHit hit;
//         if (Physics.SphereCast(raycastPos, sphereCastRadius, mainCamera.transform.forward, out hit, maxDistance, 1 << interactableLayerIndex))
//         {
//             Debug.Log("We hit something on the 8th layer");
//             Debug.Log(hit.transform.position);
//             Debug.DrawRay(raycastPos, raycastPos + hit.transform.position, Color.red);
//         }

//         // Using A Collider Shape as the pickup radius of the player

        
        

//         // if (Physics.SphereCast(raycastPos, sphereCastRadius, mainCamera.transform.forward, out hit, maxDistance, 8)) 
//         // {
//         //     lookObject = hit.Collider.transform.root.gameObject;
//         // }
//         // else
//         // {
//         //     lookObject = null;
//         // }

//         // check to see if the player has decided to pick up an object
//         // if (Input.GetMouseButtonDown(0)) 
//         // {
//         //     //currently not holding anything
//         //     if (currentlyPickedUpObject == null) 
//         //     {
//         //         // if we are looking at an interactable object
//         //         if (lookObject != null) 
//         //         {
//         //             PickUpObject();
//         //         }
//         //     }
//         //     // if we are currently holding an object
//         //     else
//         //     {   
//         //         BreakConnection();
//         //     }
//         // }

//         // // if the object gets stuck behind a wall while you're still holding it, then if you walk faraway enough it will break the connection
//         // if (currentlyPickedUpObject != null && currentDist > maxDistance) BreakConnection();
//     }