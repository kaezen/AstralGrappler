using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModuleAssistant : MonoBehaviour
{
    public Transform cameraTarget;
    public Transform player;
    public CharacterController controller;

    public BaseMovementModule movementModule;

    //public BaseMovementModule defaultModuleReference;
    float defaultModuleTimer;
    public float defaultModuleTimerBase = 2;
    // Start is called before the first frame update
    void Start()
    {
        defaultModuleTimer = defaultModuleTimerBase;
        BaseMovementModule baseMod = GetComponent<BaseMovementModule>();
        if (baseMod != null) SetModule(baseMod);
    }

    // Update is called once per frame
    void Update()
    {
        //make sure there is at least one movement module so the player can move
        if (movementModule == null)
        {
            defaultModuleTimer -= Time.deltaTime;
            if(defaultModuleTimer <= 0)
            {
               BaseMovementModule defaultModuleReference = gameObject.AddComponent<BaseMovementModule>();
                SetModule(defaultModuleReference);
                defaultModuleTimer = defaultModuleTimerBase;
            }
        }
        else
        {
            defaultModuleTimer = defaultModuleTimerBase;
        }
    }

    void InformModule(BaseMovementModule m)
    {
        movementModule.SetPlayer(player);
        movementModule.SetCameraTarget(cameraTarget);
        movementModule.SetCharacterController(controller);
    }

    void SetModule(BaseMovementModule b)
    {
        movementModule = b;
        InformModule(movementModule);
    }
}
