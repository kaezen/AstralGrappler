using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectWithHealth : MonoBehaviour
{

    public enum objectWithHealthType { player, enemy, destructible, terrain, nan }

    //sets the object's type to a default value to be overridden later
    public objectWithHealthType objectType = objectWithHealthType.nan;
    public float health = -1;
    public bool immortal = false;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if ((health <= 0) && !immortal)
        {
            TriggerOnDeath();
            TimeToDie();
        }
    }

    public abstract void TriggerOnDeath();

    public abstract void TimeToDie();

    public void SetParent(objectWithHealthType typeToSet)
    {
        objectType = typeToSet;
    }
}
