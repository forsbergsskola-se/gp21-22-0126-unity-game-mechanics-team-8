using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

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

	[SerializeField]
	private GroundChecker groundChecker;

	private bool allowSprint = true;

	public UnityEvent<float> SprintDashEvent;
 
	private void Update()
	{
		if (commandContainer.SprintCommand && allowSprint && groundChecker.IsGrounded)
		{
			StartCoroutine(Sprint(commandContainer.MoveDirectionCommand));
			commandContainer.DenyMoveCommand = true;
		}
	}

	private IEnumerator Sprint(Vector3 dir)
	{
		myRigidBody.velocity = new Vector3(dir.x*sprintSpeed, dir.y, 0);
		if(SprintDashEvent != null) // check if event is null in inspector. Ugly but quick
		{
			SprintDashEvent.Invoke(sprintCoolDown+sprintTime);	
		}
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
