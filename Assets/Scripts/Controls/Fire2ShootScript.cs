using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire2ShootScript : MonoBehaviour
{
    [SerializeField]
    Gun[] leftArmGuns;
    // Start is called before the first frame update
    void Start()
    {
        UpdateGuns();
        //get every Gun script able to fire
        //put into list
    }

    // Update is called once per frame
    void Update()
    {
        //only fire if not paused
        if (MasterStaticScript.gameIsPaused == false)
        {
            if (Input.GetAxis("Fire2") > 0)
            {
                foreach (Gun g in leftArmGuns)
                {
                    if (g != null) g.Fire();
                }
            }
        }
    }

    public void ClearGunList()
    {
        foreach (Gun g in leftArmGuns)
        {
            Object.Destroy(g.gameObject);
        }
    }

    public void UpdateGuns()
    {
        leftArmGuns = GetComponentsInChildren<Gun>();
    }
}
