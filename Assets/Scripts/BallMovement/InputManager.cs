using UnityEngine;

namespace BallBalance
{
	public class InputManager : MonoBehaviour
	{
		[SerializeField] private Transform _camera;
		private Controls _controls;
		private Vector2 _look;

		private void Awake()
		{
			_controls = new Controls();

			_controls.BallMovement.Look.performed += ctx => _look = ctx.ReadValue<Vector2>();
			_controls.BallMovement.Look.canceled += ctx => _look = Vector2.zero;
		}

		private void Update()
		{
			Vector2 r = new Vector2(-_look.y, _look.x) * Time.deltaTime * 100;
			_camera.Rotate(r, Space.World);
		}

		private void OnEnable()
		{
			_controls.BallMovement.Enable();
		}

		private void OnDisable()
		{
			_controls.BallMovement.Disable();
		}
	}
}
