using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
	[SerializeField]
	private float pressTimeTolerance = 0.5f;

	[SerializeField]
	private CommandContainer commandContainer;

	private float keyPressTime;


	private Vector3 MoveInput;

	public float MoveInputHorizontal { get; private set; }
	public float MoveInputVertical { get; private set; }
	public bool JumpInputUp { get; private set; }
	public bool JumpInput { get; private set; }

	public bool LShiftTap { get; private set; }
	public bool LShiftLongPress { get; private set; }
	
	public bool ParachuteInput { get; private set; }
	
	public bool FlyingInput { get; private set; }

 
	private void Update()
	{
		GetInputs();
		SetCommands();
	}

	private void GetInputs()
	{
		MoveInputHorizontal = Input.GetAxisRaw("Horizontal");
		MoveInputVertical = Input.GetAxisRaw("Vertical");
		MoveInput = new Vector3(MoveInputHorizontal, MoveInputVertical, 0);
		JumpInputUp = Input.GetKeyUp(KeyCode.Space);
		JumpInput = Input.GetKey(KeyCode.Space);
		FlyingInput = Input.GetKey(KeyCode.Q);
		ParachuteInput = Input.GetKey(KeyCode.E);
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
		commandContainer.JumpCommandUp = JumpInputUp;
		commandContainer.JumpCommand = JumpInput;
		commandContainer.DashCommand = LShiftTap;
		commandContainer.SprintCommand = LShiftLongPress;
		commandContainer.MoveDirectionCommand = MoveInput;
	}

	private void TapInput()
	{
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

		}
		else
		{
			LShiftLongPress = true;
		}
	}
}
