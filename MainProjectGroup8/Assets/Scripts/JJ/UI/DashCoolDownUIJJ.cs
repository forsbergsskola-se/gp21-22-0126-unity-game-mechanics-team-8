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

	public void CoolDownEvent()
	{
		// coolDownTime = 
		coolDownTimer = coolDownTime;
		isOnCoolDown = true;
	}
}
