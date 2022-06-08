using UnityEngine;

namespace BallBalance
{
	[RequireComponent(typeof(CameraLookController))]
	[RequireComponent(typeof(BallMovement))]
	public class InputManager : MonoBehaviour
	{
		#region Components

		private CameraLookController _cameraLookController;
		private BallMovement _ballMovement;

		#endregion

		private Controls _controls;

		private void Awake()
		{
			_controls = new Controls();
			_cameraLookController = GetComponent<CameraLookController>();
			_ballMovement = GetComponent<BallMovement>();
		}

		private void FixedUpdate()
		{
			_cameraLookController.HandleLook(_controls.BallMovement.Look.ReadValue<Vector2>());
			_ballMovement.HandlePlayerMovement(_controls.BallMovement.Move.ReadValue<Vector2>());
			_controls.BallMovement.Jump.performed += context => _ballMovement.Jump();
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
