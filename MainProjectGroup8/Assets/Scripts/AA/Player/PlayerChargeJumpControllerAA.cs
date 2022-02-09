using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargeJumpControllerAA : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private PlayerInputControllerAA playerInputController;
    [SerializeField] private GroundCheckerAA groundChecker;
    [SerializeField] private float minimumJumpForce = 100f;
    [SerializeField] private float maximumJumpForce = 1000f;
    [SerializeField] private float chargeTime = 1f;

    private float jumpCharge;

    private void Update()
    {
        if (playerInputController.JumpInput)
            jumpCharge += Time.deltaTime / chargeTime;

        if (playerInputController.JumpInputUp)
        {
            var jumpForce = Mathf.Lerp(minimumJumpForce, maximumJumpForce, jumpCharge);
            jumpCharge = 0f;

            if (groundChecker.IsGrounded)
                myRigidbody.AddForce(Vector3.up * jumpForce);
        }
    }
}