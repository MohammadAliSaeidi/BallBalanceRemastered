using UnityEngine;

namespace BallBalance.LevelElements.BouncyTile
{
	public class BouncyTileController : MonoBehaviour
	{
		[SerializeField] private BouncyTile bouncyTile;
		[SerializeField] private float maxRelativeVelocity = 5;
		[SerializeField] private GameObject bounceEffect;

		#region Unity Methods

		private void Start()
		{
			if (bouncyTile != null)
			{
				bouncyTile.CollisionHandler.e_OnCollisionEnter.AddListener(ShootPlayer);
			}
		}

		#endregion

		#region private Methods

		private void ShootPlayer(Collision collision)
		{
			if (!collision.collider.CompareTag("Player")) return;
			
			var ball = collision.gameObject.GetComponent<Ball>();

			var relativeVelocity = collision.relativeVelocity.magnitude;
			if (relativeVelocity > maxRelativeVelocity)
			{
				relativeVelocity = maxRelativeVelocity;
			}

			ball.Rb.AddForce(2 * relativeVelocity * bouncyTile.transform.up, ForceMode.Impulse);

			Instantiate(bounceEffect, bouncyTile.transform.position, bouncyTile.transform.rotation);
		}

		#endregion
	}
}
