using System.Collections;
using UnityEngine;

namespace BallBalance
{
	[RequireComponent(typeof(InputManager), typeof(CameraLookController), typeof(BallMovement))]
	[RequireComponent(typeof(GemManager))]
	public class PlayerManager : MonoBehaviour
	{
		private InputManager inputManager;
		internal CameraLookController cameraLookController { get; private set; }
		private BallMovement ballMovement;
		private GemManager gemManager;

		private bool _lastJumpPermission;
		private bool _lastMovePermission;

		private void Awake()
		{
			inputManager = GetComponent<InputManager>();
			cameraLookController = GetComponent<CameraLookController>();
			ballMovement = GetComponent<BallMovement>();
			gemManager = GetComponent<GemManager>();
		}

		internal void FreezePlayer()
		{
			_lastJumpPermission = ballMovement.allowJump;
			ballMovement.allowJump = false;

			_lastMovePermission = ballMovement.allowMove;
			ballMovement.allowMove = false;

			cameraLookController.allowCameraLook = false;
		}

		internal void UnfreezePlayer()
		{
			ballMovement.allowJump = _lastJumpPermission;
			ballMovement.allowMove = _lastMovePermission;

			cameraLookController.allowCameraLook = false;
		}

		internal void DisablePlayerMovement() => ballMovement.allowMove = false;

		internal void EnablePlayerMovement() => ballMovement.allowMove = true;

		internal void DisablePlayerJump() => ballMovement.allowJump = false;

		internal void EnablePlayerJump() => ballMovement.allowJump = true;

		internal void DisableCameraLook() => cameraLookController.allowCameraLook = false;

		internal void EnableCameraLook() => cameraLookController.allowCameraLook = true;
	}
}