using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkControllerJJ : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidBody;
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField]
    private GroundCheckerJJ groundChecker;
    public PlayerInputControllerJJ playerInputController;

    [SerializeField]
    private float chargingMoveSpeedFactor = 0.5f;
    private void Update()
    {
        var currentMoveSpeed = moveSpeed;

        if (playerInputController.JumpInput && groundChecker.IsGrounded)
        {
            currentMoveSpeed *= chargingMoveSpeedFactor;
        }
        myRigidBody.velocity = new Vector3(playerInputController.MoveInputHorizontal*currentMoveSpeed, myRigidBody.velocity.y, 0) ; 
    }
}
