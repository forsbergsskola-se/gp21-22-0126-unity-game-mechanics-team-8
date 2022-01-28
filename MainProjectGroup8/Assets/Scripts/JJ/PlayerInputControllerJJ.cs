using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputControllerJJ : MonoBehaviour
{
    public float MoveInputHorizontal { get; private set; }
    public float MoveInputVertical { get; private set; }
    public bool JumpInputDown { get; private set; }
    public bool JumpInputUp { get; private set; }
    public bool JumpInput  { get; private set; }
    
    public bool DashInputDown { get; private set; }
	
    private void Update()
    {
        MoveInputHorizontal = Input.GetAxisRaw("Horizontal");
        MoveInputVertical = Input.GetAxisRaw("Vertical");
        JumpInputDown = Input.GetKeyDown(KeyCode.Space);
        JumpInputUp = Input.GetKeyUp(KeyCode.Space);
        JumpInput  = Input.GetKey(KeyCode.Space);
        DashInputDown = Input.GetKeyDown(KeyCode.LeftShift);
    }
}
