using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    bool prevPaused = false;
    public Canvas pauseCanvas;

    void Update()
    {
        if (Input.GetAxis("Pause") != 0 && prevPaused == MasterStaticScript.gameIsPaused)
        //if(Input.GetKeyDown(KeyCode.Escape) && prevPaused == MasterStaticScript.gamePaused)
        {
            MasterStaticScript.gameIsPaused = !MasterStaticScript.gameIsPaused;
            SetPauseCanvasState();

            print("pause state - " + MasterStaticScript.gameIsPaused);
        }

        //won't reset pause check until button is released
        if (Input.GetAxis("Pause") == 0)
        {
            prevPaused = MasterStaticScript.gameIsPaused;

        }
    }

    public void Pause()
    {
        MasterStaticScript.gameIsPaused = true;
        SetPauseCanvasState();
    }

    public void UnPause()
    {
        MasterStaticScript.gameIsPaused = false;
        SetPauseCanvasState();
    }
    void SetPauseCanvasState()
    {
        pauseCanvas.enabled = MasterStaticScript.gameIsPaused;
    }
}
