using UnityEngine;

namespace BallBalance
{
	public class FanTile : MonoBehaviour
	{
		[SerializeField] private float _fanPower = 1;
		[SerializeField] private float _forceMaxDistEffect = 1.5f;

		private void OnTriggerStay(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				// apply force to the ball
				var rb = other.GetComponent<Rigidbody>();
				var distFactor = _forceMaxDistEffect / (Vector3.Distance(transform.position, other.transform.position) + 1);

				rb.AddForce(_fanPower * distFactor * transform.up);
			}
		}
	}
}
