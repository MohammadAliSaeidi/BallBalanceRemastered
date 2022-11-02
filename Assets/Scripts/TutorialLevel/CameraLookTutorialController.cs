using UnityEngine;
using UnityEngine.Events;

namespace BallBalance.Tutorial
{
	internal class CameraLookTutorialController : TutorialController
	{
		[SerializeField] private float MinCameraInputToPassTutorial = 200;
		private float _totalCameraRotation;
		internal UnityEvent e_OnPlayerInteract { get; private set; } = new UnityEvent();
		private bool _playerInteracted = false;

		protected override void Start()
		{
			base.Start();
		}

		private void Update()
		{
			if (_isStarted)
			{
				_totalCameraRotation += _controls.BallMovement.Look.ReadValue<Vector2>().magnitude;

				if (!_playerInteracted && _totalCameraRotation > 0.1f)
				{
					e_OnPlayerInteract?.Invoke();
					_playerInteracted = true;
				}

				if (_totalCameraRotation > MinCameraInputToPassTutorial)
				{
					IsPassed = true;
				}
			}
		}
	}
}