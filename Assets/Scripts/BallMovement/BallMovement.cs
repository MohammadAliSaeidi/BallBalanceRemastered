using UnityEngine;
using UnityEngine.Events;

namespace BallBalance
{
	public class BallMovement : MonoBehaviour
	{
		public UnityEvent e_OnJumped;

		[SerializeField] private float _angularPower = 1;
		[SerializeField] private float _movePower = 1;
		[SerializeField] private float _jumpPower = 5;
		[SerializeField] private float _maxAngularVelocity = 10;
		private float _groundCheck = 0.05f;
		private bool _allowJump = true;
		private bool _allowMove = true;

		private Rigidbody rb;

		private void Awake()
		{
			InitComponents();
		}

		private void Start()
		{
			InitGroundCheck();

			Debug.Log(LayerMask.LayerToName(12));
			Debug.Log(LayerMask.NameToLayer("IgnoreJumpPad"));
		}

		internal void InitGroundCheck()
		{
			if (rb)
			{
				rb.maxAngularVelocity = _maxAngularVelocity;
				float radius = rb.transform.localScale.x / 2;
				_groundCheck = (radius) + 0.1f;
			}
		}

		private void LateUpdate()
		{
			if (CheckInput() &&
				Physics.CheckSphere(rb.transform.position + new Vector3(0, -0.01f, 0), rb.GetComponent<SphereCollider>().radius, ~(1 << 12)))
			{
				PlayerJump();
			}
		}

		private bool CheckInput()
		{
#if PLATFORM_STANDALONE_WIN
			if (Input.GetKeyDown(KeyCode.Space))
			{
				return true;
			}

			return false;
#endif
			// TODO: write input check for android
		}

		private void FixedUpdate()
		{
			if (rb && _allowMove)
			{
				MovePlayer();
			}
		}

		private void MovePlayer()
		{
			Vector3 cameraDir = Vector3.Scale(a: Camera.main.transform.forward, b: new Vector3(1, 0, 1)).normalized;
			float v = Input.GetAxis("Vertical");
			float h = Input.GetAxis("Horizontal");

			// create a normalized direction of the camera relative to the horizon
			Vector3 moveDirection = ((v * cameraDir) + (h * Camera.main.transform.right)).normalized;

			rb.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x) * _angularPower);
			rb.AddForce(moveDirection * _movePower);
		}

		private void PlayerJump()
		{
			if (rb && _allowJump)
			{
				rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
				if (e_OnJumped != null)
				{
					e_OnJumped.Invoke();
				}
			}
		}

		private void InitComponents()
		{
			rb = GetComponent<Rigidbody>();
		}
	}
}
