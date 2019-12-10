using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : ObjectWithHealth
{
    private void Start()
    {
        objectType = objectWithHealthType.player;
    }
    public override void TimeToDie()
    {
        Debug.Log("player down!! Player down!!");
    }

    public override void TriggerOnDeath()
    {

    }
}
