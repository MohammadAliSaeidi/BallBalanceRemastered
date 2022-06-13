using UnityEngine;

namespace BallBalance
{
	public class BouncyTileController : MonoBehaviour
	{
		[SerializeField] private BouncyTile _bouncyTile;

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
				ball.Rb.AddForce(2 * collision.relativeVelocity.magnitude * _bouncyTile.transform.up, ForceMode.Impulse);
			}
		}

		#endregion
	}
}
