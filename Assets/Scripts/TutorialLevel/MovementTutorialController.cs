using UnityEngine;

namespace BallBalance.Tutorial
{
	internal class MovementTutorialController : TutorialController
	{
		internal bool IsPasses = false;
		[SerializeField] private float _minMovementToPassTutorial = 200;

		private float _totalMovement;

		protected override void Start()
		{
			base.Start();
		}

		private void Update()
		{
			if (_isStarted)
			{
				_totalMovement += _controls.BallMovement.Move.ReadValue<Vector2>().magnitude;


				if (_totalMovement > _minMovementToPassTutorial)
				{
					IsPassed = true;
				}
			}
		}
	}
}