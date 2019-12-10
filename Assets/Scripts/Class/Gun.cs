using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public Transform gunEnd;
    public GameObject projectilePrefab;
    public float fireCooldown = .3f;
    public bool canFire = true;

    public ObjectWithHealth.objectWithHealthType parentType;

    private void Start()
    {
        parentType = GetComponentInParent<ObjectWithHealth>().objectType;
    }


    public abstract void Fire();
    public void ResetFire()
    {
        canFire = true;
    }

}
