using UnityEngine;

public class PlayerWalkControllerJJ : MonoBehaviour
{
	[SerializeField]
	private Rigidbody myRigidBody;

	[SerializeField]
	private float moveSpeed = 5f;

	[SerializeField]
	private GroundChecker groundChecker;

	[SerializeField]
	private CommandContainer commandContainer;

	[SerializeField]
	private float chargingMoveSpeedFactor = 0.5f;

	private void Update()
	{
		var currentMoveSpeed = moveSpeed;
		
		if (commandContainer.JumpCommand && groundChecker.IsGrounded)
		{
			currentMoveSpeed *= chargingMoveSpeedFactor;
		}

		if (!commandContainer.DenyMoveCommand)
		{
			myRigidBody.velocity = new Vector3(commandContainer.MoveCommandHorizontal*currentMoveSpeed, myRigidBody.velocity.y, 0);
		}
	}
}
