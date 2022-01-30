using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputControllerAA : MonoBehaviour
{
    public PlayerInputControllerAA(bool flyingInput)
    {
        FlyingInput = flyingInput;
    }

    public float MoveInput { get; private set; }
    public bool JumpInputDown { get; private set; }
    public bool JumpInputUp { get; private set; }
    public bool JumpInput { get; private set; }
    public bool FlyingInput { get; private set; }

    private void Update()
    {
        MoveInput = Input.GetAxis("Horizontal");
        JumpInputDown = Input.GetKeyDown(KeyCode.Space);
        JumpInputUp = Input.GetKeyUp(KeyCode.Space);
        JumpInput = Input.GetKey(KeyCode.Space);
        FlyingInput = Input.GetKey(KeyCode.E);
    }
}
