using UnityEngine;
using BallBalance.UnityEventModels;

namespace BallBalance
{
	public class OnTriggerEnterEventHandler : MonoBehaviour
	{
		public UnityEvent_Collider e_OnTriggerEnter = new UnityEvent_Collider();

		private void OnTriggerEnter(Collider collider)
		{
			e_OnTriggerEnter?.Invoke(collider);
		}
	}
}