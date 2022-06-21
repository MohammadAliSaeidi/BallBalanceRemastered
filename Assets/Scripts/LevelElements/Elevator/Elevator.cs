using UnityEngine;

namespace BallBalance
{
	[RequireComponent(typeof(MovableElement))]
	public partial class Elevator : MonoBehaviour
	{
		[SerializeField] private Animator _animator;

		[Space(20)]
		[SerializeField] private ElevatorMode _elevatorMode;
		[Range(0.2f, 5)]
		[SerializeField] private float _elevatorAnimationSpeedMultiplier = 1;

		private void Start()
		{
			InitElevatorMode();

			_animator.speed *= _elevatorAnimationSpeedMultiplier;
		}

		private void InitElevatorMode()
		{
			switch (_elevatorMode)
			{
				case ElevatorMode.Horizontal:
					_animator.SetBool("Horizontal", true);
					break;

				case ElevatorMode.Vertical:
					_animator.SetBool("Vertical", true);
					break;
			}
		}
	}
}
