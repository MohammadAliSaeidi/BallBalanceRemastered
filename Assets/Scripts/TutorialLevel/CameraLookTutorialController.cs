using UnityEngine;
using UnityEngine.Events;

namespace BallBalance.Tutorial
{
	internal class CameraLookTutorialController : MonoBehaviour, ITutorialController
	{
		public float minCameraInputToPassTutorial = 200;

		internal bool IsPassed;
		private bool started = false;
		private float totalCameraRotation;
		private Controls _controls;

		private void Awake()
		{
			_controls = FindObjectOfType<InputManager>()._controls;
		}

		public void StartTutorial()
		{
			IsPassed = false;
			started = true;
		}

		private void Update()
		{
			if (started)
			{
				totalCameraRotation += _controls.BallMovement.Look.ReadValue<Vector2>().magnitude;

				if (totalCameraRotation > minCameraInputToPassTutorial)
				{
					IsPassed = true;
				}
			}
		}
	}
}