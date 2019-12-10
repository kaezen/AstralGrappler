using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTestBrackey : MonoBehaviour
{
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {

        }
    }
}
