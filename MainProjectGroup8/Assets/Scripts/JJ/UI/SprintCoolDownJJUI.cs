using UnityEngine;
using UnityEngine.UI;
 
	public class SprintCoolDownJJUI : MonoBehaviour
	{
		[SerializeField]
		private Image shadowImage;

		private void Start()
		{
			shadowImage.fillAmount = 0;
		}
	}

