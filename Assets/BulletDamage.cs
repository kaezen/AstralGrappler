using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : BulletStats
{


    private void OnTriggerEnter(Collider other)
    {
        ObjectWithHealth target = other.gameObject.GetComponent<ObjectWithHealth>();

        if (target != null)
        {
            //only interact with whatever you hit if it's not the same type as the gameobject that fired the bullet
            if (parentType != target.objectType)
            {
                target.TakeDamage(damage);
                Destroy(gameObject);
            }
            //print("I HIT A THING! " + other.gameObject.name);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        ObjectWithHealth target = collision.gameObject.GetComponent<ObjectWithHealth>();

        if (target != null)
        {
            //only interact with whatever you hit if it's not the same type as the gameobject that fired the bullet
            if (parentType != target.objectType)
            {
                target.TakeDamage(damage);
                Destroy(gameObject);
            }
            //print("I HIT A THING! " + collision.gameObject.name);

        }
    }
}
