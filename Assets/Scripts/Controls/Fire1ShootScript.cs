using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire1ShootScript : MonoBehaviour
{
    [SerializeField]
    Gun[] rightArmGuns;
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
        if (MasterStaticScript.gameIsPaused == false)
        {
            if (Input.GetAxis("Fire1") > 0)
            {
                foreach (Gun g in rightArmGuns)
                {
                    if (g != null) g.Fire();
                }
            }
        }
    }

    public void ClearGunList()
    {
        foreach (Gun g in rightArmGuns)
        {
            Object.Destroy(g.gameObject);
        }
    }

    public void UpdateGuns()
    {
        rightArmGuns = GetComponentsInChildren<Gun>();
    }
}
