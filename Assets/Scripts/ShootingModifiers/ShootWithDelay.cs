using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWithDelay : Gun
{
    public float delayToShoot = 0.1f;
    public override void Fire()
    {
        if (canFire)
        {
            Invoke("DelayedFire", delayToShoot);
            canFire = false;
            Invoke("ResetFire", fireCooldown);
        }
    }

    void DelayedFire()
    {
        GameObject g = Instantiate(projectilePrefab, gunEnd.position, gunEnd.rotation);
        g.GetComponent<BulletStats>().SetParent(parentType);
    }
}
