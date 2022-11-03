using UnityEngine;
using UnityEngine.Playables;

namespace BallBalance.Tutorial
{
	internal class GemTutorialController : TutorialController
	{
		[SerializeField] private PlayableDirector _timeline;

		protected override void Start()
		{
			base.Start();
		}

		public override void StartTutorial()
		{
			base.StartTutorial();

			_timeline.Play();
		}
	}
}