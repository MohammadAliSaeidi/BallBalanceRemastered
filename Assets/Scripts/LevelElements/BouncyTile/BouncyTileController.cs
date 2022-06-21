using UnityEngine;

namespace BallBalance
{
	public class BouncyTileController : MonoBehaviour
	{
		[SerializeField] private BouncyTile _bouncyTile;
		[SerializeField] private float _maxRelativeVelocity= 30; 

		#region Unity Methods

		private void Start()
		{
			if (_bouncyTile != null)
			{
				_bouncyTile.CollisionHandler.e_OnCollisionEnter.AddListener(ShootPlayer);
			}
		}

		#endregion

		#region private Methods

		private void ShootPlayer(Collision collision)
		{
			if (collision.collider.CompareTag("Player"))
			{
				var ball = collision.gameObject.GetComponent<Ball>();

				var relativeVelocity = collision.relativeVelocity.magnitude;
				if (relativeVelocity > _maxRelativeVelocity)
				{
					relativeVelocity = _maxRelativeVelocity;
				}

				ball.Rb.AddForce(2 * relativeVelocity * _bouncyTile.transform.up, ForceMode.Impulse);
			}
		}

		#endregion
	}
}
