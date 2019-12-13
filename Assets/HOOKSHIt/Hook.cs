using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private Vector3 scale;
    public GameObject hook;
    public GameObject hookHolder;

    public float hookTravelSpeed;
    public float playerTravelSpeed;

    public static bool fired;
    public static bool reelIn;
    public bool hooked;
    public GameObject hookedObj;

    public float maxDistance;
    private float currentDistance;
    private float ropeDis;

  

    private void Update()
    {
       
        // fireing the hok
        if (Input.GetMouseButton(0) && fired == false)
        {
            fired = true;
        }

        if (fired)
        {
            LineRenderer rope = hook.GetComponent<LineRenderer>();
            rope.SetVertexCount(2);
            rope.SetPosition(0, hookHolder.transform.position);
            rope.SetPosition(1, hook.transform.position);


        }

        //reel in to hok
        if (Input.GetKeyDown(KeyCode.O) && hooked)
        {
            reelIn = true;
        }
        //if the hook is fired and is also not hooked into somthing do this
        if (fired == true && hooked == false)
        {
            hook.transform.parent = null;
            hook.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelSpeed);
            currentDistance = Vector3.Distance(transform.position, hook.transform.position);

            if (currentDistance >= maxDistance)
                ReturnHook();
        }
        // Debug.Log(currentDistance);
        //if the hook is hooked into somthing do this
        if (hooked == true)
        {
            hook.transform.parent = hookedObj.transform;
            float distanceToHook = Vector3.Distance(transform.position, hook.transform.position);
            //if reeling in do this
            if (reelIn)
            { 
            transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, Time.deltaTime * playerTravelSpeed);
                //TODO turn off gravity for the player so that the grapple works more smoothly
                this.GetComponent<Rigidbody>().useGravity = false;
            }
            // if not reeling in do this
            if (!reelIn && distanceToHook > currentDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, Time.deltaTime * playerTravelSpeed);
            }

            // return the hook to the player
            if (Input.GetKeyDown(KeyCode.P))
                  ReturnHook();

            
            //Debug.Log(distanceToHook);
            if (distanceToHook < 2)           
                ReturnHook();
            

        } else {
            //if the hook is not shot attach it to the player
            if (!fired)
            hook.transform.parent = hookHolder.transform;

            //TODO turn on gravity
            this.GetComponent<Rigidbody>().useGravity = true;




        }
    }
    //resets hook into players gun
    void ReturnHook()
    {
        hook.transform.rotation = hookHolder.transform.rotation;
        hook.transform.position = hookHolder.transform.position;       

        fired = false;
        reelIn = false;
        hooked = false;

        LineRenderer rope = hook.GetComponent<LineRenderer>();
        rope.SetVertexCount(0);
       
    }

}
