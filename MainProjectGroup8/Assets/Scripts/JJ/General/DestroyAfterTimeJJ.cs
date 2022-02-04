using System.Collections;
using UnityEngine;

public class DestroyAfterTimeJJ : MonoBehaviour
{
	public void DestroyAfterTime(float time)
	{
		StartCoroutine(KillAfterTime(time));
	}

	private IEnumerator KillAfterTime(float time)
	{
		yield return new WaitForSeconds(time);

		Destroy(gameObject);
	}
}
