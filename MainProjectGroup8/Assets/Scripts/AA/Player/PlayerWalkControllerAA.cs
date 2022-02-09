using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkControllerAA : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private PlayerInputControllerAA playerInputController;
    [SerializeField] private GroundCheckerAA groundChecker;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float chargingMoveSpeedFactor = 0.5f;

    private void Update()
    {
        //Slower move speed while charging a jump.
        var currentMoveSpeed = moveSpeed;
        if (playerInputController.JumpInput && groundChecker.IsGrounded)
            currentMoveSpeed *= chargingMoveSpeedFactor;

        myRigidbody.velocity = new Vector3(playerInputController.MoveInput * currentMoveSpeed, myRigidbody.velocity.y, 0);
    }
}
