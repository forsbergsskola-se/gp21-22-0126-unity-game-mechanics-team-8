using System;
using UnityEngine;
using UnityEngine.UI;

public class SprintCoolDownJJUI : MonoBehaviour
{
	[SerializeField]
	private Image shadowImage;

	private readonly bool isOnCoolDown = false;

	private float coolDownTime;

	private float coolDownTimer;

	private Action<EventParam> listener;

	private void Awake()
	{
		listener = CoolDownEvent;
	}

	private void Start()
	{
		shadowImage.fillAmount = 0;
	}

	private void Update()
	{
		if (!isOnCoolDown)
		{
			ApplyCoolDown();
		}
	}

	private void OnEnable()
	{
		EventManagerJJ.Instance.StartListening(EventList.UpdateSprintUI, listener);
	}

	private void OnDisable()
	{
		EventManagerJJ.Instance.StopListening(EventList.UpdateSprintUI, listener);
	}

	private void ApplyCoolDown()
	{
		coolDownTimer -= Time.deltaTime;

		if (coolDownTimer < 0.0f)
		{
			shadowImage.fillAmount = 0;
		}
		else
		{
			shadowImage.fillAmount = coolDownTimer/coolDownTime;
		}
	}

	public void CoolDownEvent(EventParam eventParam)
	{
		coolDownTime = eventParam.EventFloat;
		coolDownTimer = coolDownTime;
	}
}
