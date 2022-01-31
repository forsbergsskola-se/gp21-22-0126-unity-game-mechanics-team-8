using System.Collections;
using UnityEngine;

public class SprintDashJJ : MonoBehaviour
{
	[SerializeField]
	private CommandContainer commandContainer;

	[SerializeField]
	private Rigidbody myRigidBody;

	[SerializeField]
	private float sprintSpeed = 20f;

	[SerializeField]
	private float sprintCoolDown = 2f;

	[SerializeField]
	private float afterSprintBrakeFactor = 0.2f;

	[SerializeField]
	private float sprintTime = 1f;

	private bool allowSprint = true;

	[SerializeField]
	private GameObject sprintChargeEffect;

	[SerializeField]
	private GroundCheckerJJ groundChecker;
	
	private void Update()
	{
		if (commandContainer.ChargingSprint)
		{
			sprintChargeEffect.SetActive(true);	
			if (commandContainer.SprintCommand && allowSprint && groundChecker.IsGrounded)
			{
			 
				StartCoroutine(Sprint(commandContainer.MoveDirectionCommand));
				commandContainer.DenyMoveCommand = true;
			}
		}

		if (!commandContainer.ChargingSprint && !commandContainer.SprintCommand)
		{
			sprintChargeEffect.SetActive(false);
		}
		
	}

	private IEnumerator Sprint(Vector3 dir)
	{
		myRigidBody.velocity = new Vector3(dir.x*sprintSpeed, dir.y, 0);

		yield return new WaitForSeconds(sprintTime);

		myRigidBody.velocity *= afterSprintBrakeFactor;
		allowSprint = false;
		commandContainer.DenyMoveCommand = false;
		StartCoroutine(SprintCoolDown(sprintCoolDown));
	}

	private IEnumerator SprintCoolDown(float sprintCoolDown)
	{
		yield return new WaitForSeconds(sprintCoolDown);

		allowSprint = true;
	}
}
