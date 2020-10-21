using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{

    // Make sure to add all the items needed in the inspector
    // also make sure for the rigid body that "interpolate" = Extrapolate, and "Collision Detection" = Continuous Speculative

    public Rigidbody rb;
    public BoxCollider bc;
    public Renderer render;
    public Transform player, itemContainer;

    public float pickUpRange;
    public float throwingForce;
    public float throwUpwardForce, throwForwardForce;

    public bool equipped;
    public static bool slotFull;

    public bool throwing;

    public float sound_radius = 100.0f;

    private Camera mainCamera;

    private AudioSource audioSource;

    public AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        // initial setup of the variables
        if (!equipped) {
            rb.isKinematic = false;
            bc.isTrigger = false;
        }
        if (equipped) {
            rb.isKinematic = true;
            bc.isTrigger = true;
            slotFull = true;
        }
        pickUpRange = 3f;
        mainCamera = Camera.main; // this grabs the main camera
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check to see if player is within range to press "E"
        Vector3 distanceToPlayer = player.position - this.transform.position;
        if (!slotFull && !equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E)) 
        {
            Debug.Log("An Item is Being Picked Up");
            PickUp();
        }

        // throw the item, with the primary mouse click
        if (Input.GetMouseButtonDown(0) && equipped) {
            Debug.Log("An Item is Being Thrown");
            ThrowItem();
            // it might be okay to put this here as it is a one time thing.
            // rb.AddForce(player.transform.up * throwUpwardForce, ForceMode.Impulse);
            // rb.AddForce(player.transform.forward * throwForwardForce, ForceMode.Impulse);
            Vector3 direction = mainCamera.transform.forward;
            rb.AddForce(direction * throwingForce, ForceMode.Impulse);

            // Rotation for some spice
            float random = Random.Range(-1f, 1f);
            rb.AddTorque(new Vector3(random, random, random) * 10);
            
        }

        if (equipped) {
            transform.position = itemContainer.transform.position;
        } 

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground" && throwing)
        {
            Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, sound_radius);
            foreach (var hitCollider in hitColliders)
            {
                GuardStateMachine enemy_ai = hitCollider.gameObject.GetComponent<GuardStateMachine>();
                if (enemy_ai != null)
                {
                    enemy_ai.noticeSound(gameObject.transform.position);
                    Debug.Log("Enemy noticed thrown object");
                }
            }
            AudioClip clip = clips[0];
            audioSource.PlayOneShot(clip);
            Collider collider = GetComponent<Collider>();
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            collider.enabled = false;
            renderer.enabled = false;
            rb.isKinematic = false;
            //Destroy(gameObject);
        }
    }

    private void FixedUpdate() {}

    void PickUp()
    {
        equipped = true;
        slotFull = true;

        // Make the Item a child of the item container
        transform.SetParent(itemContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        render.enabled = false;
        // transform.localScale = new Vector3(1f, 1f, 1f);
        
        // Making it kinematic makes sure no external forces affect it, is trigger makes it so it doesn't physically collide with the environment when holding it
        rb.isKinematic = true;
        bc.isTrigger = true;
        throwing = false;
    }

    void ThrowItem()
    {
        equipped = false;
        slotFull = false;

        // Set parent to null/detach from the item container object
        transform.SetParent(null);

        // Gun carries momentum of player
        rb.velocity = player.GetComponent<Rigidbody>().velocity;
        render.enabled = true;

        // Throwing Forces
        // Vector3 direction = mainCamera.transform.forward;
        // rb.AddForce(direction * throwingForce, ForceMode.Impulse);
        // rb.AddForce(player.transform.up * throwUpwardForce, ForceMode.Impulse);
        // rb.AddForce(player.transform.forward * throwForwardForce, ForceMode.Impulse);

        // Rotation for some spice
        // float random = Random.Range(-1f, 1f);
        // rb.AddTorque(new Vector3(random, random, random) * 10);

        // Reset these values to false so that the item acts like a physical object again
        rb.isKinematic = false;
        bc.isTrigger = false;
        throwing = true;
    }
}
