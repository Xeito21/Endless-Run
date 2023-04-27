using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;

    private int desiredLane = 1;//0:left, 1:middle, 2:right
    public float laneDistance = 2.5f;//The distance between tow lanes

    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;

    public float gravityForce = -12f;
    public float jumpForce = 2;
    public float groundRadius;
    private Vector3 velocity;

    public Animator animator;



    bool toggle = false;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Time.timeScale = 1.2f;

    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted || PlayerManager.gameOver)
            return;



        animator.SetBool("isGameStarted", true);
        direction.z = forwardSpeed;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundLayer);

        animator.SetBool("isGrounded", isGrounded);

        if (isGrounded)
        {
            if (SwipeController.swipeUp)
                Jump();

        }

        controller.Move(velocity * Time.deltaTime);

        //Gather the inputs on which lane we should be
        if (SwipeController.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (SwipeController.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        //Calculate where we should be in the future
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
            targetPosition += Vector3.left * laneDistance;
        else if (desiredLane == 2)
            targetPosition += Vector3.right * laneDistance;

        //transform.position = targetPosition;
        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 30 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.magnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);
        }

        controller.Move(direction * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted || PlayerManager.gameOver)
            return;

        //Increase Speed
        if (toggle)
        {
            toggle = false;
            if (forwardSpeed < maxSpeed)
                forwardSpeed += 0.1f * Time.fixedDeltaTime;
        }
        else
        {
            toggle = true;
            if (Time.timeScale < 2f)
                Time.timeScale += 0.005f * Time.fixedDeltaTime;
        }
    }

    private void Jump()
    {
        animator.SetTrigger("jump");
        controller.center = Vector3.zero;
        controller.height = 2;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
            FindObjectOfType<AudioManager>().StopSound("MainTheme");
        }
    }

}