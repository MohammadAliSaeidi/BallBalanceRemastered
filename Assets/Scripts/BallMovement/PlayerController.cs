using UnityEngine;

namespace BallBalance
{
	[RequireComponent(typeof(InputManager), typeof(CameraLookController), typeof(BallMovement))]
	[RequireComponent(typeof(GemManager))]
	public class PlayerController : MonoBehaviour
	{
		private InputManager inputManager;
		private CameraLookController cameraLookController;
		private BallMovement ballMovement;
		private GemManager gemManager;

		private void Awake()
		{
			inputManager = GetComponent<InputManager>();
			cameraLookController = GetComponent<CameraLookController>();
			ballMovement = GetComponent<BallMovement>();
			gemManager = GetComponent<GemManager>();
		}

		private void PausePlayer()
		{
			ballMovement.DisableMovement();
			cameraLookController.DisableCameraController();
		}

		private void UnpausePlayer()
		{
			ballMovement.EnableMovement();
			cameraLookController.EnableCameraController();
		}
	}
}