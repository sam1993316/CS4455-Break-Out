using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControllerForThirdPersonCamera : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Rigidbody rb;
    public float speed = 6f;
    private Animator anim;
    public Canvas UI;
    public Canvas InGameMenu;
    private bool gameEnded = false;

    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;

    private float filteredForwardInput = 0f;
    public float forwardInputFilter = 5f;
    private float forwardSpeedLimit = 1f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    //Useful if you implement jump in the future...
    public float jumpHeight = 50.0f;
    public float jumpableGroundNormalMaxAngle = 45f;
    public bool closeToJumpableGround;


    private int groundContactCount = 0;

    public bool IsGrounded
    {
        get
        {
            return groundContactCount > 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        inventory = new Inventory();
        uiInventory.SetInvetory(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = IsGrounded || CharacterCommon.CheckGroundNear(this.transform.position, jumpableGroundNormalMaxAngle, 0.1f, 1f, out closeToJumpableGround);

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector3 jump = new Vector3(0.0f, 150.0f, 0.0f);
                rb.AddForce(jump * jumpHeight, ForceMode.Impulse);
                anim.SetBool("is_in_air", true);
            }
            else
            {
                anim.SetBool("is_in_air", false);
            }
        }

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        // logic for compatibility for third person camera
        Vector3 direction = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;



        //do some filtering of our input as well as clamp to a speed limit
        float movespeed = Mathf.Max(Mathf.Abs(moveHorizontal), Mathf.Abs(moveVertical));
        filteredForwardInput = Mathf.Clamp(Mathf.Lerp(filteredForwardInput, movespeed,
            Time.deltaTime * forwardInputFilter), -forwardSpeedLimit, forwardSpeedLimit);

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

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!gameEnded)
            {
                PauseMenuToggle pauseMenuScript = InGameMenu.GetComponent<PauseMenuToggle>();
                pauseMenuScript.PauseMenuInteraction();
            }
        }

        anim.SetFloat("velocity", filteredForwardInput);
    }

    public void LoseGame()
    {
        gameEnded = true;
        GameOver script = UI.GetComponent<GameOver>();
        script.LoseGame();
    }

    public void WinGame()
    {
        gameEnded = true;
        GameOver script = UI.GetComponent<GameOver>();
        script.WinGame();
    }
}
