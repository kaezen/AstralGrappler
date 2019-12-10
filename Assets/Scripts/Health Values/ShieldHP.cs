using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHP : ObjectWithHealth
{
    public override void TimeToDie()
    {
    }

    public override void TriggerOnDeath()
    {
        Destroy(gameObject);
    }
}
