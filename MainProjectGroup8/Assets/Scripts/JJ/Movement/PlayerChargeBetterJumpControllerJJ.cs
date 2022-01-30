using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PlayerChargeBetterJumpControllerJJ : MonoBehaviour
{
    [SerializeField]
    private PlayerInputControllerJJ playerInputController;

    [SerializeField]
    private Rigidbody myRigidBody;

    [SerializeField]
    private GroundCheckerJJ groundChecker;

    [SerializeField]
    private float maximumJumpForce = 1000f;

    [SerializeField]
    private float minimumJumpForce = 100f;

    [SerializeField]
    private float chargeTime = 1f;

    private float jumpCharge = 0f;

    [SerializeField]
    private float gravityFallMultiplier = 2.5f;

    private void Update()
    {
        if (playerInputController.JumpInput)
        {
            
            jumpCharge += Time.deltaTime/chargeTime;
        }

        if (playerInputController.JumpInputUp)
        {
            var jumpForce = Mathf.Lerp(minimumJumpForce, maximumJumpForce, jumpCharge);
            jumpCharge = 0f;

            if (groundChecker.IsGrounded)
            {
                myRigidBody.AddForce(Vector3.up*jumpForce);
            }
        }

        if (myRigidBody.velocity.y < 0)
        {
            myRigidBody.velocity += Vector3.up*Physics.gravity.y*(gravityFallMultiplier - 1)*Time.deltaTime;
            
        } else if (myRigidBody.velocity.y > 0 && !playerInputController.JumpInputUp)
        {
            myRigidBody.velocity += Vector3.up * Physics.gravity.y * (gravityFallMultiplier - 1)*Time.deltaTime;
        }
		
    }
}
