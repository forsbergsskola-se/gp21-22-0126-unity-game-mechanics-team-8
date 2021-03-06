using System;
using UnityEngine;
using UnityEngine.UI;

public class SprintCoolDownUIJJ : MonoBehaviour
{
	[SerializeField]
	private Image shadowImage;

	private readonly bool isOnCoolDown = false;

	private float coolDownTime;

	private float coolDownTimer;

 

	 
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

	public void CoolDownEvent(float coolDownTime)
	{
		this.coolDownTime = coolDownTime;
		coolDownTimer = this.coolDownTime;
	}
}
