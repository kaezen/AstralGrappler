using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNew : MonoBehaviour
{
    CharacterController player;
    public float speed = 5;
    public float maxsSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            //player.Move(player.transform.forward * speed * Time.deltaTime);            
            player.SimpleMove(player.transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            //player.Move(-player.transform.forward * speed * Time.deltaTime);            
            player.SimpleMove(-player.transform.forward * speed * Time.deltaTime);
        }
    }
}
