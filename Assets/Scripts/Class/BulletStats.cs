using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStats : MonoBehaviour
{
    public float damage = 1;
    
    public ObjectWithHealth.objectWithHealthType parentType;

    public void SetParent(ObjectWithHealth.objectWithHealthType type)
    {
        parentType = type;
    }
}
