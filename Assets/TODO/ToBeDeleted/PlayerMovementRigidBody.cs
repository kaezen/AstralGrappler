using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: delete this file. It is currently outdated, only being kept as reference
public class PlayerMovementRigidBody : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5;
    public float maxSpeed = 15;

    public float gravity = -5;

    public float deadZone = .2f;

    [Range(0, 1)]
    public float friction = .7f;

    Vector3 pVelocity = new Vector3();

    public float jumpSpeed = 5;

    Vector3 direction;

    public Transform cameraTarget;

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

            BaseMovement();
            //print(direction);        
            //direction.y -= gravity * Time.deltaTime;


            //apply movement
            controller.Move(direction * Time.deltaTime);
            //TODO: Make this actually work
            pVelocity = direction * (1-friction);

            //apply friction
            if (Input.GetAxis("Vertical") <= deadZone && Input.GetAxis("Horizontal") <= deadZone) pVelocity *= Time.deltaTime;


            //cleanup
            //if (controller.isGrounded) velocityY = 0;
        }
    }

    void CheckForRotation()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            player.transform.rotation = Quaternion.Euler(0, cameraTarget.rotation.eulerAngles.y, 0);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            player.transform.rotation = Quaternion.Euler(0, cameraTarget.rotation.eulerAngles.y, 0);
        }
    }

    void BaseMovement()
    {
        if (controller.isGrounded)
        {
            direction = Input.GetAxis("Vertical") * transform.forward;
            direction += Input.GetAxis("Horizontal") * transform.right;
            direction *= speed;

            if (Input.GetButton("Jump"))
            {
                direction.y = jumpSpeed;
            }
        }
        else
        {//if not grounded
            Vector3 airControl = new Vector3();
            airControl = Input.GetAxis("Vertical") * transform.forward;
            airControl += Input.GetAxis("Horizontal") * transform.right;
            airControl *= speed;

            airControl.y -= gravity;

            direction += airControl * Time.deltaTime;
        }
    }
}
