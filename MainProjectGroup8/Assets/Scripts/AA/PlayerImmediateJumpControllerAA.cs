using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImmediateJumpControllerAA : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private PlayerInputControllerAA playerInputController;
    [SerializeField] private GroundCheckerAA groundChecker;
    [SerializeField] private float jumpForce = 500f;

    private void Update()
    {
        //Apply jump force
        //Preferably interact with physics in FixedUpdate() 
        if (playerInputController.JumpInputDown && groundChecker.IsGrounded)
            myRigidbody.AddForce(Vector3.up * jumpForce);
    }
}
