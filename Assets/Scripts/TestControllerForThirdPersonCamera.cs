using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControllerForThirdPersonCamera : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Rigidbody rb;
    public float speed = 6f;


    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        // logic for compatibility for third person camera
        Vector3 direction = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;



        // test for moving using character controller
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float smoothedAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, smoothedAngle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //controller.Move(moveDirection.normalized * speed * Time.deltaTime);
            rb.MovePosition(rb.position + moveDirection.normalized * speed * Time.deltaTime);
        }
    }
}
