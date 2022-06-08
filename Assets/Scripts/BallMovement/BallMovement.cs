using UnityEngine;
using UnityEngine.Events;

namespace BallBalance
{
	public class BallMovement : MonoBehaviour
	{
		#region Variables

		public UnityEvent onJumped;

		[SerializeField] private float angularPower = 1;
		[SerializeField] private float movePower = 1;
		[SerializeField] private float jumpPower = 5;
		[SerializeField] private float maxAngularVelocity = 10;
		private float _groundCheck;
		private bool _allowJump = true;
		private bool _allowMove = true;

		private Rigidbody _rb;

		#endregion

		#region Unity Methods

		private void Awake()
		{
			InitComponents();
		}

		private void Start()
		{
			InitGroundCheck();

			_rb.maxAngularVelocity = maxAngularVelocity;
		}

		#endregion

		#region Private Methods

		private void InitComponents()
		{
			_rb = FindObjectOfType<Ball>().GetComponent<Rigidbody>();
		}

		private void InitGroundCheck()
		{
			if (!_rb)
			{
				return;
			}

			var radius = _rb.transform.localScale.x / 2;
			_groundCheck = radius + 0.1f;
		}

		public void HandlePlayerMovement(Vector2 inputValue)
		{
			if (!_rb || !_allowMove)
			{
				return;
			}

			if (Camera.main == null)
			{
				return;
			}

			var cameraDir = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
			var v = inputValue.y;
			var h = inputValue.x;

			// create a normalized direction of the camera relative to the horizon
			var moveDirection = (v * cameraDir + h * Camera.main.transform.right).normalized;

			_rb.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x) * angularPower);
			_rb.AddForce(moveDirection * movePower);
		}

		public void Jump()
		{
			if (!_rb)
			{
				return;
			}

			if (!_allowJump)
			{
				return;
			}

			if (!Physics.CheckSphere(
					_rb.transform.position + new Vector3(0, -0.01f, 0),
					_rb.GetComponent<SphereCollider>().radius,
					~(1 << 12)))
			{
				return;
			}

			_rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
			onJumped?.Invoke();
		}

		#endregion
	}
}