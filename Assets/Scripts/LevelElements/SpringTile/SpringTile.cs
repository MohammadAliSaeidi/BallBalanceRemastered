using UnityEngine;

namespace BallBalance
{
	[RequireComponent(typeof(OnTriggerEnterEventHandler))]
	[RequireComponent(typeof(SpringJoint))]
	public class SpringTile : MonoBehaviour
	{
		internal OnTriggerEnterEventHandler onTriggerHandler;
		internal SpringJoint springJoint;

		private void Awake()
		{
			springJoint = GetComponent<SpringJoint>();
			onTriggerHandler = GetComponent<OnTriggerEnterEventHandler>();
		}
	}
}
