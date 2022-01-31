using System;
using UnityEngine;
using UnityEngine.UI;

public class DashCoolDownUIJJ : MonoBehaviour
{
	[SerializeField]
	private Image shadowImage;

	private float coolDownTime;

	private float coolDownTimer;
	private bool isOnCoolDown = false;

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
		if (isOnCoolDown)
		{
			ApplyCoolDown();
		}
	}

	private void OnEnable()
	{
		EventManagerJJ.Instance.StartListening(EventList.UpdateDashUI, listener);
	}

	private void OnDisable()
	{
		EventManagerJJ.Instance.StopListening(EventList.UpdateDashUI, listener);
	}

	private void ApplyCoolDown()
	{

		Debug.Log(coolDownTimer);
		if (coolDownTimer < 0.0f)
		{
			shadowImage.fillAmount = 0;
			isOnCoolDown = false;
		}
		else
		{
			coolDownTimer -= Time.deltaTime;
			shadowImage.fillAmount = coolDownTimer/coolDownTime;
		}
	}

	public void CoolDownEvent(EventParam eventParam)
	{
		coolDownTime = eventParam.EventFloat;
		coolDownTimer = coolDownTime;
		isOnCoolDown = true;
	}
}
