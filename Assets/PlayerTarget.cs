using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerTarget : MonoBehaviour
{
    public Transform player;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        //only move if game is not paused
        if (MasterStaticScript.gameIsPaused)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
            transform.LookAt(player.position);
            transform.rotation *= Quaternion.Euler(0, -90, 0);
        }



    }
}
