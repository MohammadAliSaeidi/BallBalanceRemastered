using UnityEngine;
using UnityEngine.Events;

namespace BallBalance.Tutorial
{
	internal class MovementTutorialController : TutorialController
	{
		[SerializeField] private float _minMovementToPassTutorial = 200;

		private float _totalMovement;
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
				_totalMovement += _controls.BallMovement.Move.ReadValue<Vector2>().magnitude;

				if (!_playerInteracted && _totalMovement > 0.1f)
				{
					e_OnPlayerInteract?.Invoke();
					_playerInteracted = true;
				}

				if (_totalMovement > _minMovementToPassTutorial)
				{
					IsPassed = true;
				}
			}
		}
	}
}