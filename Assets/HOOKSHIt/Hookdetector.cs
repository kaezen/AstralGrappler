using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hookdetector : MonoBehaviour
{
    public GameObject player;

   void OnTriggerEnter(Collider other)
    {
        //if the hook hits somthing hookable do this
        if (other.tag == "Hookable")
        {
            player.GetComponent<Hook>().hooked = true;
            player.GetComponent<Hook>().hookedObj = other.gameObject;
        }
    }
}
