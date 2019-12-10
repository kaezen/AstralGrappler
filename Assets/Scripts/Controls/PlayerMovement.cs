using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float lookDamper = .1f;

    public float smoothTurnSpeed = .2f;
    public float smoothTurnTime = .1f;

    Rigidbody Player;

    Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponentInChildren<Rigidbody>();
        camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (MasterStaticScript.gameIsPaused == false)
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
            input = input.normalized;

            if (input != Vector2.zero)
            {
                float targetRotation = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg * camera.eulerAngles.y;
                Player.rotation = Quaternion.Euler(Vector3.up * Mathf.SmoothDampAngle(Player.transform.eulerAngles.y, targetRotation, ref smoothTurnSpeed, smoothTurnTime));
            }
            //print(input.x);
            Player.velocity += transform.forward * input.x * speed;
        }
    }
}
