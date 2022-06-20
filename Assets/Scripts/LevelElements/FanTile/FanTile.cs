using UnityEngine;

namespace BallBalance
{
	public class FanTile : MonoBehaviour
	{
		[SerializeField] private float _fanPower = 1;

		private void OnTriggerStay(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				// apply force to the ball
				var rb = other.GetComponent<Rigidbody>();
				var distFactor = Vector3.Distance(transform.position, other.transform.position);

				rb.AddForce(_fanPower * distFactor * transform.forward);
			}
		}
	}
}
