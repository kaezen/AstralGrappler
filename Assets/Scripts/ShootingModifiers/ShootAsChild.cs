using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAsChild : Gun
{
    public override void Fire()
    {
        if (canFire)
        {
            GameObject g = Instantiate(projectilePrefab, gunEnd.position, gunEnd.rotation);

            g.transform.SetParent(this.transform);

            try
            {
            g.GetComponent<BulletStats>().SetParent(parentType);
            }
            catch
            {
                g.GetComponent<ObjectWithHealth>().SetParent(parentType);
            }

            canFire = false;
            Invoke("ResetFire", fireCooldown);
        }
    }
}
