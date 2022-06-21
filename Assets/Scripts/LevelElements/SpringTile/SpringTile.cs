using UnityEngine;

namespace BallBalance
{
	[RequireComponent(typeof(TriggerEventHandler))]
	[RequireComponent(typeof(SpringJoint))]
	public class SpringTile : MonoBehaviour
	{
		internal TriggerEventHandler onTriggerHandler;
		internal SpringJoint springJoint;

		private void Awake()
		{
			springJoint = GetComponent<SpringJoint>();
			onTriggerHandler = GetComponent<TriggerEventHandler>();
		}
	}
}
