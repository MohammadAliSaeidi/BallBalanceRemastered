using UnityEngine;

namespace BallBalance
{
	[RequireComponent(typeof(Rigidbody))]
	public class Ball : MonoBehaviour
	{
		internal Rigidbody Rb { get; private set; }

		[Header("Collision effect")]
		[SerializeField] private GameObject CollisionEffect;
		[SerializeField] private float minHitVelocityToSpawnEffect = 0.5f; // x: min, y: max
		[SerializeField] private Vector2 hitVelRange = new Vector2(0, 10); // x: min, y: max
		[SerializeField] private Vector2 emmitionRange = new Vector2(3, 15); // x: min, y: max
		[SerializeField] private Vector2 particleSpeedRange = new Vector2(4, 11); // x: min, y: max
		[SerializeField] private Vector2 particleSizeRange = new Vector2(0.1f, 0.2f); // x: min, y: max

		private void Awake()
		{
			Rb = GetComponent<Rigidbody>();
		}

		private void OnCollisionEnter(Collision collision)
		{
			var hitVel = Mathf.Clamp(collision.relativeVelocity.magnitude, hitVelRange.x, hitVelRange.y);
			if (collision.relativeVelocity.magnitude >= minHitVelocityToSpawnEffect)
			{
				var cp = collision.contacts[0];
				var inst = Instantiate(CollisionEffect, cp.point, Quaternion.LookRotation(cp.normal));
				var particle = inst.GetComponentInChildren<ParticleSystem>();

				// ,______________________________________________________________________________,
				// | clamp particle emmision between "emmitionRange (B)" based on "hitVel (A)":   |
				// |	 //	number	-	A.min  \                   \                              |
				// |	|| ____________________ | * (B.max - B.min) | + B.min                     |
				// |	 \\	A.max	-	A.min  /                   /                              |
				// |______________________________________________________________________________|
				float particleEmmition = ((hitVel - hitVelRange.x) / (hitVelRange.y - hitVelRange.x) * (emmitionRange.y - emmitionRange.x)) + emmitionRange.x;
				var particleBurst = new ParticleSystem.Burst(_time: 0, particleEmmition, _cycleCount: 1, _repeatInterval: 0.01f);
				particle.emission.SetBurst(0, particleBurst);

				float speed = ((hitVel - hitVelRange.x) / (hitVelRange.y - hitVelRange.x) * (particleSpeedRange.y - particleSpeedRange.x)) + particleSpeedRange.x;
				var main = particle.main;
				main.startSpeed = new ParticleSystem.MinMaxCurve(min: speed * 0.6f, max: speed);

				float size = ((hitVel - hitVelRange.x) / (hitVelRange.y - hitVelRange.x) * (particleSizeRange.y - particleSizeRange.x)) + particleSizeRange.x;
				main.startSize = new ParticleSystem.MinMaxCurve(min: size * 0.25f, max: size);
			}
		}
	}
}
