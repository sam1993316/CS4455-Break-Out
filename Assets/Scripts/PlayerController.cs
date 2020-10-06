using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private int grounded;
    public float jumpForce;
    private Animator anim;

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
        anim = GetComponent<Animator>();
        grounded = 0;
        this.jumpForce = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            Vector3 jump = new Vector3(0.0f, 1500 * Time.deltaTime, 0.0f);
            rb.AddForce(jump * speed * jumpForce);
        }

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical) * speed * Time.deltaTime;

        rb.MovePosition(this.transform.position + movement);

        float movespeed = moveHorizontal;
        if (moveVertical > moveHorizontal)
        {
            movespeed = moveVertical;
        }
        Debug.Log(movespeed);
        anim.SetFloat("velocity", movespeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded++;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded--;
        }
    }

}
