using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainHP : ObjectWithHealth
{
    private void Start()
    {
        objectType = objectWithHealthType.terrain;
    }

    public override void TimeToDie()
    {

    }

    public override void TriggerOnDeath()
    {

    }
}
