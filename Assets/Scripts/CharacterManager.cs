using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public PlayerController charController;
    public PlayerController limbController;
    public FixedJoint limbJoint;
    public bool detached;
    public GameObject limb;
    public GameObject character;
    public bool limbProjectileMode;
    public ThirdPersonCamera cam;
    private Rigidbody limbrb;
    void Awake()
    {
        cam.target = character;
    }
    // Start is called before the first frame update
    void Start()
    {
        // controller initiated
        limbController = limb.GetComponent(typeof(PlayerController)) as PlayerController;
        charController = character.GetComponent(typeof(PlayerController)) as PlayerController;
        limbJoint = limb.GetComponent(typeof(FixedJoint)) as FixedJoint;

        limbController.jumpForce = 1f;
        limbController.enabled = false;
        limbProjectileMode = false;
        detached = false;
        // camera initiated

    }
    // Update is called once per frame
    void Update()
    {
        // Logic for detaching and reattaching
        if (Input.GetKeyUp(KeyCode.T))
        {

            if (!detached)
            {
                Debug.Log("detaching");
                Destroy(limbJoint);
                if (limbProjectileMode)
                {
                    limbrb = limb.GetComponent(typeof(Rigidbody)) as Rigidbody;
                    limbrb.AddForce(new Vector3(1, 0, 0) * 5f, ForceMode.Impulse);
                }
                charController.enabled = false;
                limbController.enabled = true;
                detached = true;
                cam.target = limb;
            }
            else if (detached && Vector3.Distance(character.transform.position, limb.transform.position) < 1.5f)
            {
                Debug.Log("reattaching");
                limbJoint = limb.AddComponent(typeof(FixedJoint)) as FixedJoint;
                limbJoint.connectedBody = character.GetComponent(typeof(Rigidbody)) as Rigidbody;
                charController.enabled = true;
                limbController.enabled = false;
                detached = false;
                cam.target = character;

            }
        }
    }


}
