using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFire : MonoBehaviour
{
public Gun gun;

    // Update is called once per frame
    void Update()
    {
        if (!MasterStaticScript.gameIsPaused)
        {
        gun.Fire();
        }
    }
}
