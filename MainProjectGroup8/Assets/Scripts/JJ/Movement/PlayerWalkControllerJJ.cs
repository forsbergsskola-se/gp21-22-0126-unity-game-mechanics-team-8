using UnityEngine;

public class PlayerWalkControllerJJ : MonoBehaviour
{
	[SerializeField]
	private Rigidbody myRigidBody;

	[SerializeField]
	private float moveSpeed = 5f;

	[SerializeField]
	private GroundCheckerJJ groundChecker;

	[SerializeField]
	private CommandContainer commandContainer;

	[SerializeField]
	private ShortDashJJ dash;

	[SerializeField]
	private SprintDashJJ sprint;

	[SerializeField]
	private float chargingMoveSpeedFactor = 0.5f;

	[SerializeField]
	private GameObject sprintChargingEffect;

	private void Update()
	{
		var currentMoveSpeed = moveSpeed;
		var movementInputVector = new Vector3(commandContainer.MoveCommandHorizontal, commandContainer.MoveCommandVertical, 0);

		if (commandContainer.JumpCommand && groundChecker.IsGrounded)
		{
			currentMoveSpeed *= chargingMoveSpeedFactor;
		}

		if (commandContainer.LShiftTapCommand)
		{
			dash.Dash(movementInputVector);

			return;
		}

		if (commandContainer.ChargingSprint)
		{
			sprintChargingEffect.SetActive(true);

			if (commandContainer.LShiftLongPressCommand && groundChecker.IsGrounded)
			{
				sprint.SprintDash(movementInputVector);

				return;
			}
		}

		if (sprintChargingEffect && !commandContainer.ChargingSprint)
		{
			sprintChargingEffect.SetActive(false);
		}

		myRigidBody.velocity = new Vector3(commandContainer.MoveCommandHorizontal*currentMoveSpeed, myRigidBody.velocity.y, 0);
	}
}
