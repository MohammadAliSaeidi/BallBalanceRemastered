using UnityEngine;

namespace BallBalance
{
	[RequireComponent(typeof(Rigidbody))]
	public class Ball : MonoBehaviour
	{
		internal Rigidbody Rb { get; private set; }

		private void Awake()
		{
			Rb = GetComponent<Rigidbody>();
		}
	}
}
