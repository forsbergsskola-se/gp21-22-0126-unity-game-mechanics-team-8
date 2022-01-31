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

	private void Update()
	{
		if (commandContainer.SprintCommand && allowSprint)
		{
			 
			StartCoroutine(Sprint(commandContainer.MoveCommand));
			commandContainer.DenyMovementCommand = true;
		}
	}

	private IEnumerator Sprint(Vector3 dir)
	{
		myRigidBody.velocity = new Vector3(dir.x*sprintSpeed, dir.y, 0);

		yield return new WaitForSeconds(sprintTime);

		myRigidBody.velocity *= afterSprintBrakeFactor;
		allowSprint = false;
		commandContainer.DenyMovementCommand = false;
		StartCoroutine(SprintCoolDown(sprintCoolDown));
	}

	private IEnumerator SprintCoolDown(float sprintCoolDown)
	{
		yield return new WaitForSeconds(sprintCoolDown);

		allowSprint = true;
	}
}
