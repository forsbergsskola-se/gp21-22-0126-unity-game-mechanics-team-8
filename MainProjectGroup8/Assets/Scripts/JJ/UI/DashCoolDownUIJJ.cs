using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCoolDownUIJJ : MonoBehaviour
{
	[SerializeField]
	private Image shadowImage;

	private void Start()
	{
		shadowImage.fillAmount = 0;
	}

	private float coolDownTimer = 0f;
	private float coolDownTime = 5f;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.L))
		{
			coolDownTimer = coolDownTime;
		}
		ApplyCoolDown();

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
}
