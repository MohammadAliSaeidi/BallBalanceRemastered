using System.Collections;
using UnityEngine;

namespace BallBalance
{
	public class AnimationStartDelay : MonoBehaviour
	{
		[SerializeField] private float _delay;

		private void Awake()
		{
			GetComponent<Animator>().enabled = false;
		}

		private IEnumerator Start()
		{
			yield return new WaitForSeconds(_delay);
			GetComponent<Animator>().enabled = true;
		}
	}
}
