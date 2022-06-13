using UnityEngine;

namespace BallBalance
{
	[RequireComponent(typeof(OnCollisionEnterEventHandler))]
	public class BouncyTile : MonoBehaviour
	{
		internal OnCollisionEnterEventHandler CollisionHandler { get; private set; }

		private void Awake()
		{
			CollisionHandler = GetComponent<OnCollisionEnterEventHandler>();
		}
	}
}
