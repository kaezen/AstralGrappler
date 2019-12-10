using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCanvasOnStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }
}
