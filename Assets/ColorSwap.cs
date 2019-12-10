using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwap : MonoBehaviour
{
    public Material playerMat;
    public Material demonMat;
    public MeshRenderer player;
    public MeshRenderer gun;
    public MeshRenderer eyes;
    public MeshRenderer demon;
    public bool counter = false;
    GameObject dummy;
    public GameObject dummyBase;
    public GameObject leftHand;
    public GameObject rightHand;
    // Start is called before the first frame update
    void Start()
    {
 
        rightHand.SetActive(true);
        leftHand.SetActive(false);
        demon.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //if swapping
            if (counter == true)
            {
                demon.enabled = true;
                player.enabled = false;
                gun.enabled = false;
                eyes.enabled = false;
                dummy = Instantiate(dummyBase, transform.position, Quaternion.identity);
                rightHand.SetActive(false);
                leftHand.SetActive(true);
            }

            if (counter == false)
            {
                demon.enabled = false;
                player.enabled = true;
                gun.enabled = true;
                eyes.enabled = true;
                Destroy(dummy);
                rightHand.SetActive(true);
                leftHand.SetActive(false);
            }
            counter = !counter;
        }
    }
}
