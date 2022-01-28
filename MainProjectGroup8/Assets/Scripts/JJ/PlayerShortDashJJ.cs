using System.Collections;
using UnityEngine;

public class PlayerShortDashJJ : MonoBehaviour
{
	[SerializeField]
	private PlayerInputControllerJJ playerInputController;

	[SerializeField]
	private Rigidbody myRigidBody;

	[SerializeField]
	private float DashStrength = 10f;

	private bool allowDash = true;

	[SerializeField]
	private float dashCoolDown = 1f;

	private void Update()
	{
		var movementInputVector = new Vector3(playerInputController.MoveInputHorizontal, playerInputController.MoveInputVertical, 0);
		Debug.Log(movementInputVector);
		if (playerInputController.DashInputDown && allowDash)
		{
			allowDash = false;
			myRigidBody.AddRelativeForce(movementInputVector.normalized * DashStrength, ForceMode.Impulse);
			StartCoroutine(DashCoolDown(dashCoolDown));
		}
	}

	IEnumerator DashCoolDown(float dashCoolDown)
	{
		yield return new WaitForSeconds(dashCoolDown);

		allowDash = true;
	}
	
}
