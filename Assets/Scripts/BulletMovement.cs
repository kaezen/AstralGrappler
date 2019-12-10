using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 20;
    public float lifeSpan = 4;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("DestroySelf", 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (MasterStaticScript.gameIsPaused == false)
        {
        transform.position += this.transform.forward * speed * Time.deltaTime;
            lifeSpan -= Time.deltaTime;
            if(lifeSpan <= 0)
            {
                DestroySelf();
            }
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
