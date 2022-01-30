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
	private float chargingMoveSpeedFactor = 0.5f;

	private void Update()
	{
		var currentMoveSpeed = moveSpeed;

		if (playerInputController.JumpInput && groundChecker.IsGrounded)
		{
			currentMoveSpeed *= chargingMoveSpeedFactor;
		}

		if (playerInputController.LShiftDash)
		{
 
			var movementInputVector = new Vector3(playerInputController.MoveInputHorizontal, playerInputController.MoveInputVertical, 0);
			dash.Dash(movementInputVector);
		}

		if (!dash.AreDashing)
		{
			myRigidBody.velocity = new Vector3(playerInputController.MoveInputHorizontal*currentMoveSpeed, myRigidBody.velocity.y, 0);
		}
	}
}
