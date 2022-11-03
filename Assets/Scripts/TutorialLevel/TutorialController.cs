using UnityEngine;
namespace BallBalance.Tutorial
{
	internal abstract class TutorialController : MonoBehaviour
	{
		internal bool IsPassed = false;

		protected bool _isStarted = false;
		protected Controls _controls;

		protected virtual void Start()
		{
			_controls = FindObjectOfType<InputManager>()._controls;
		}

		public virtual void StartTutorial()
		{
			IsPassed = false;
			_isStarted = true;
		}
	}
}