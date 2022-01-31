using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShortDashJJ : MonoBehaviour
{
	[SerializeField]
	private CommandContainer commandContainer;

	[SerializeField]
	private Rigidbody myRigidBody;

	[SerializeField]
	private float dashStrength = 1000f;

	[SerializeField]
	private float dashCoolDown = 0.5f;

	[SerializeField]
	private float dashTime = 0.5f;

	[SerializeField]
	private float afterDashVelocityBrakeFactor = 0.20f;

	private bool allowDash = true;

	private EventParam UIDashCooldown = new EventParam();
	
	private void Update()
	{
		if (commandContainer.DashCommand && allowDash)
		{
			commandContainer.DenyMoveCommand = true;
			Dash(commandContainer.MoveDirectionCommand);
		}
	}

	private void Dash(Vector3 dashDirection)
	{
		if (allowDash)
		{
			allowDash = false;
			myRigidBody.AddRelativeForce(dashDirection.normalized*dashStrength, ForceMode.Force);
			StartCoroutine(DashTime(dashTime));
			StartCoroutine(DashCoolDown(dashCoolDown));
			UIDashCooldown.EventFloat = dashCoolDown;
			EventManagerJJ.TriggerEvent(EventList.UpdateDashUI, UIDashCooldown);
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

		myRigidBody.velocity *= afterDashVelocityBrakeFactor;
		commandContainer.DenyMoveCommand = false;
	}
}
