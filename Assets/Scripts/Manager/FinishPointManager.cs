using UnityEngine;
using UnityEngine.Events;

namespace BallBalance
{
	[RequireComponent(typeof(TriggerEventHandler))]
	public class FinishPointManager : MonoBehaviour
	{
		public UnityEvent e_OnFinishPointHit = new UnityEvent();

		private TriggerEventHandler triggerEventHandler;

		private void Awake()
		{
			triggerEventHandler = GetComponent<TriggerEventHandler>();

			triggerEventHandler.e_OnTriggerEnter.AddListener(
				delegate (Collider collider)
				{
					if (collider.gameObject.CompareTag("Player"))
					{
						e_OnFinishPointHit?.Invoke();
					}
				});

		}
	}
}
