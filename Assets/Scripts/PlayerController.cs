using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private int grounded;

    public bool IsGrounded
    {
        get
        {
            return grounded > 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grounded = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            Vector3 movement = new Vector3(0.0f, 1500 * Time.deltaTime, 0.0f);
            rb.AddForce(movement * speed);
        }

        transform.position += new Vector3(moveHorizontal * Time.deltaTime * speed, 0, moveVertical * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            grounded++;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            grounded--;
        }
    }

}
