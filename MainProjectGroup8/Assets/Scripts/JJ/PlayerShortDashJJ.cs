using System.Collections;
using UnityEngine;

public class PlayerShortDashJJ : MonoBehaviour
{
	[SerializeField]
	private PlayerInputControllerJJ playerInputController;

	[SerializeField]
	private Rigidbody myRigidBody;

	[SerializeField]
	private float dashStrength = 1000f;

	[SerializeField]
	private float dashCoolDown = 0.5f;

	[SerializeField]
	private float dashTime = 0.5f;

	[SerializeField]
	private float afterDashVelocityBreakFactor = 0.20f;

	private bool allowDash = true;

	public bool AreDashing { get; private set; }

	private void Update()
	{
		var movementInputVector = new Vector3(playerInputController.MoveInputHorizontal, playerInputController.MoveInputVertical, 0);

		if (playerInputController.DashInputDown && allowDash)
		{
			allowDash = false;
			AreDashing = true;
			myRigidBody.AddRelativeForce(movementInputVector.normalized*dashStrength, ForceMode.Force);
			StartCoroutine(DashTime(dashTime));
			StartCoroutine(DashCoolDown(dashCoolDown));
		}
	}

	private IEnumerator DashCoolDown(float dashCoolDown)
	{
		yield return new WaitForSeconds(dashCoolDown);

		allowDash = true;
	}

	private IEnumerator DashTime(float dashTime)
	{
		yield return new WaitForSeconds(dashTime);

		myRigidBody.velocity *= afterDashVelocityBreakFactor;
		AreDashing = false;
	}
}
