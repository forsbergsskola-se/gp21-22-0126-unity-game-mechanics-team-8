using UnityEngine;

public class PlayerWalkControllerJJ : MonoBehaviour
{
	[SerializeField]
	private Rigidbody myRigidBody;

	[SerializeField]
	private float moveSpeed = 5f;

	[SerializeField]
	private GroundCheckerJJ groundChecker;

	public PlayerInputControllerJJ playerInputController;

	[SerializeField]
	private ShortDashJJ dash;

	[SerializeField]
	private DashSprintJJ sprint;

	[SerializeField]
	private float chargingMoveSpeedFactor = 0.5f;

	private void Update()
	{
		var currentMoveSpeed = moveSpeed;

		if (playerInputController.JumpInput && groundChecker.IsGrounded)
		{
			currentMoveSpeed *= chargingMoveSpeedFactor;
		}
			var movementInputVector = new Vector3(playerInputController.MoveInputHorizontal, playerInputController.MoveInputVertical, 0);

		if (playerInputController.LShiftDash)
		{
 
			dash.Dash(movementInputVector);
		}

		if (playerInputController.LShiftSprint && groundChecker.IsGrounded)
		{
			sprint.SprintDash(movementInputVector);
		}

		if (!dash.AreDashing && !sprint.AreSprinting)
		{
			myRigidBody.velocity = new Vector3(playerInputController.MoveInputHorizontal*currentMoveSpeed, myRigidBody.velocity.y, 0);
		}
	}
}
