using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : ObjectWithHealth
{
    private void Start()
    {
        objectType = objectWithHealthType.enemy;
    }
    public override void TimeToDie()
    {

    }

    public override void TriggerOnDeath()
    {
        Destroy(gameObject);
    }
}
