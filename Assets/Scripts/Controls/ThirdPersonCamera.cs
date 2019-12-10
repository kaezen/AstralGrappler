using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    float y;
    float x;

    public Transform target;

    public bool mouseControl = true;
    public float mouseSensitivity = 10;

    public float distanceFromTarget = 4;
    public Vector2 yMinMax = new Vector2(-40, 85);

    public float rotationSmoothTime = .12f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    // Update is called once per frame
    void LateUpdate()
    {
        //only run if game isn't paused
        if (!MasterStaticScript.gameIsPaused)
        {
            if (mouseControl)
            {
                x += Input.GetAxis("Mouse X") * mouseSensitivity;
                y -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            }

            y = Mathf.Clamp(y, yMinMax.x, yMinMax.y);

            Vector3 targetRotation = new Vector3(y, x);
            currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref rotationSmoothVelocity, rotationSmoothTime);

            transform.eulerAngles = currentRotation;

            transform.position = target.position - transform.forward * distanceFromTarget;

            target.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }
    }
}
