using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnContactJJ : MonoBehaviour
{
	[SerializeField]
	private bool destroySelfOnContact = false;
	private void OnCollisionEnter(Collision collision)
	{
		if (destroySelfOnContact)
		{
		Destroy(gameObject);	
		}
		else
		{
		Destroy(collision.gameObject);	
		} 
	}
}
