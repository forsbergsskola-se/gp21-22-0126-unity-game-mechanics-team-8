 using System;
 using UnityEngine;

public class PlayerRestartLevelEventEmitter : MonoBehaviour
{
	public Action OnRestartLevel;

	[SerializeField]
	private CommandContainer commandContainer;
	
	private void Update()
	{
		if (commandContainer.RestartLevel)
		{
			OnRestartLevel.Invoke();
		}
	}
}
