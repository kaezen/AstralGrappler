using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldLife : MonoBehaviour
{
    public float shieldDuration = 5;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", shieldDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
