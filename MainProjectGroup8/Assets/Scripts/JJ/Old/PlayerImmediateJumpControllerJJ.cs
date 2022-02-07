using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImmediateJumpControllerJJ : MonoBehaviour
{
	[SerializeField] private PlayerInputControllerJJ playerInputController;
	
	[SerializeField] private Rigidbody myRigidBody;
	[SerializeField] private float jumpForce = 500f;

	[SerializeField]
	private GroundCheckerJJ groundChecker;
 

	private void Update()
	{
 
		if (playerInputController.JumpInputDown && groundChecker.IsGrounded)
		{
			myRigidBody.AddForce(Vector3.up * jumpForce);
		}

	}
}
