using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelHP : ObjectWithHealth
{
    private void Start()
    {
        objectType = objectWithHealthType.destructible;
    }

    public override void TimeToDie()
    {
        
    }

    public override void TriggerOnDeath()
    {
        //print("Barrel go boom");
        Destroy(gameObject);
    }
}
