using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovementModule : MonoBehaviour
{
    //reference to the charactercontroller component of the player
    public CharacterController controller;

    [Tooltip("How fast the player moves")]
    public float speed = 18;

    public float AirSpeed = 5f;

    [Tooltip("Max speed of the player")]
    public float maxSpeed = 25;
    //TODO: Check this is working correctly

    [Tooltip("How fast the player falls (should be negative value)")]
    public float gravity = -35;


    [Tooltip("How much dead area before the control sticks cause movement")]
    public float deadZone = .2f;
    //TODO: apply this with controller support

    [Tooltip("How quickly the player slows down each frame (1 - value)")]
    [Range(0, 1)]
    public float friction = .8f;
    //TODO: Apply this better

    //How fast the playery was moving last frame
    [System.NonSerialized]
    public Vector3 pVelocity = new Vector3();
    //TODO: Apply this better

    [Tooltip("Amount of force applied when player jumps")]
    public float jumpSpeed = 20;

    //aka velocity. the direction the player is moving this frame
    [System.NonSerialized]
    public Vector3 direction;

    //reference to the camera target assistant
    public Transform cameraTarget;

    //the player's transform, for editing correctly
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //only run if game isn't paused
        if (!MasterStaticScript.gameIsPaused)
        {
            CheckForRotation();

            XYMovement();
            //print(direction);        
            //direction.y -= gravity * Time.deltaTime;


            //apply movement
            controller.Move(direction * Time.deltaTime);
            //TODO: Make this actually work better
            pVelocity = direction * (1 - friction);

            //apply friction
            if (Input.GetAxis("Vertical") <= deadZone && Input.GetAxis("Horizontal") <= deadZone)
            {
                controller.Move(pVelocity * Time.deltaTime);

            }


            //cleanup
            //if (controller.isGrounded) velocityY = 0;
        }
    }

    virtual public void CheckForRotation()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            player.transform.rotation = Quaternion.Euler(0, cameraTarget.rotation.eulerAngles.y, 0);
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            player.transform.rotation = Quaternion.Euler(0, cameraTarget.rotation.eulerAngles.y, 0);
        }
    }

    virtual public void XYMovement()
    {
        //print(controller.isGrounded);
        if (controller.isGrounded)
        {
            direction = Input.GetAxis("Vertical") * transform.forward;
            direction += Input.GetAxis("Horizontal") * transform.right;
            direction *= speed;

            //TODO: implement coyote time to prevent jump getting eaten
            if (Input.GetButton("Jump"))
            {
                Jump();
            }
        }
        else
        {//if not grounded
            Vector3 airControl = new Vector3();
            airControl = Input.GetAxis("Vertical") * transform.forward;
            airControl += Input.GetAxis("Horizontal") * transform.right;
            airControl *= AirSpeed;

            airControl.y += gravity;

            direction += airControl * Time.deltaTime;
        }
    }

    virtual public void Jump()
    {
        direction.y = jumpSpeed;
    }

    public void SetPlayer(Transform p)
    {
        player = p;
    }

    public void SetCharacterController(CharacterController c)
    {
        controller = c;
    }

    public void SetCameraTarget(Transform t)
    {
        cameraTarget = t;
    }
}
