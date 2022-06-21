using UnityEngine;
using BallBalance.UnityEventModels;

namespace BallBalance
{
	public class TriggerEventHandler : MonoBehaviour
	{
		public UnityEvent_Collider e_OnTriggerEnter = new UnityEvent_Collider();
		public UnityEvent_Collider e_OnTriggerExit = new UnityEvent_Collider();

		private void OnTriggerEnter(Collider collider)
		{
			e_OnTriggerEnter?.Invoke(collider);
		}

		private void OnTriggerExit(Collider collider)
		{
			e_OnTriggerExit?.Invoke(collider);
		}
	}
}