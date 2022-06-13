using UnityEngine;
using BallBalance.UnityEventModels;

namespace BallBalance
{
	public class OnCollisionEnterEventHandler : MonoBehaviour
	{
		public UnityEvent_Collision e_OnCollisionEnter = new UnityEvent_Collision();

		private void OnCollisionEnter(Collision collision)
		{
			e_OnCollisionEnter?.Invoke(collision);
		}
	}
}