using UnityEngine;

public class CommandContainer : MonoBehaviour
{
	//Can be hidden later, visible for debug purposes
	public float MoveCommandHorizontal;
	public float MoveCommandVertical;
	public bool JumpCommandDown;
	public bool JumpCommandUp;
	public bool JumpCommand;

	public bool LShiftTapCommand;
	public bool LShiftLongPressCommand;
	public bool ChargingSprint;
}