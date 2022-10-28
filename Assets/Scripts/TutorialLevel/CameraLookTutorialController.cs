using UnityEngine;
using UnityEngine.Events;

namespace BallBalance.Tutorial
{
	internal class CameraLookTutorialController : TutorialController
	{
		[SerializeField] private float MinCameraInputToPassTutorial = 200;
		private float _totalCameraRotation;

		protected override void Start()
		{
			base.Start();
		}

		private void Update()
		{
			if (_isStarted)
			{
				_totalCameraRotation += _controls.BallMovement.Look.ReadValue<Vector2>().magnitude;

				if (_totalCameraRotation > MinCameraInputToPassTutorial)
				{
					IsPassed = true;
				}
			}
		}
	}
}