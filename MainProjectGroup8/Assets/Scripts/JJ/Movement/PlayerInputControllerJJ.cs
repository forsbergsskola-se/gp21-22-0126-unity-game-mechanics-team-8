using UnityEngine;

public class PlayerInputControllerJJ : MonoBehaviour
{
	[SerializeField]
	private float pressTimeTolerance = 0.7f;

	[SerializeField]
	private CommandContainer commandContainer;

	[SerializeField]
	private float keyPressTime;

	[SerializeField]
	private float chargingSprintNotificationTime = 0.2f;

	private bool chargingSprint;
	public float MoveInputHorizontal { get; private set; }
	public float MoveInputVertical { get; private set; }
	public bool JumpInputDown { get; private set; }
	public bool JumpInputUp { get; private set; }
	public bool JumpInput { get; private set; }

	public bool LShiftTap { get; private set; }
	public bool LShiftLongPress { get; private set; }

	private void Update()
	{
		GetInputs();
		SetCommands();
	}

	private void GetInputs()
	{
		MoveInputHorizontal = Input.GetAxisRaw("Horizontal");
		MoveInputVertical = Input.GetAxisRaw("Vertical");
		JumpInputDown = Input.GetKeyDown(KeyCode.Space);
		JumpInputUp = Input.GetKeyUp(KeyCode.Space);
		JumpInput = Input.GetKey(KeyCode.Space);
		LShiftTap = false;

		if (Input.GetKey(KeyCode.LeftShift))
		{
			LongPressInput();
		}
		else if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			TapInput();
		}
	}

	private void SetCommands()
	{
		commandContainer.MoveCommandHorizontal = MoveInputHorizontal;
		commandContainer.MoveCommandVertical = MoveInputVertical;
		commandContainer.JumpCommandDown = JumpInputDown;
		commandContainer.JumpCommandUp = JumpInputUp;
		commandContainer.JumpCommand = JumpInput;
		commandContainer.DashCommand = LShiftTap;
		commandContainer.SprintCommand = LShiftLongPress;
		commandContainer.ChargingSprint = chargingSprint;
	}

	private void TapInput()
	{
		chargingSprint = false;
		LShiftLongPress = false;

		if (keyPressTime < pressTimeTolerance)
		{
			LShiftTap = true;
		}

		keyPressTime = 0f;
	}

	private void LongPressInput()
	{
		if (keyPressTime < pressTimeTolerance)
		{
			keyPressTime += Time.deltaTime;

			if (keyPressTime > chargingSprintNotificationTime)
			{
				chargingSprint = true;
			}
		}
		else
		{
			LShiftLongPress = true;
		}
	}
}
