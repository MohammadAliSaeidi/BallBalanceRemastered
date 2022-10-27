using System.Collections;
using UnityEngine;

namespace BallBalance.Tutorial
{
	[RequireComponent(typeof(CameraLookTutorialController), typeof(TutorialUIManager))]
	public class TutorialManager : MonoBehaviour
	{
		private TutorialUIManager uIManager;
		private PlayerManager playerManager;

		#region Tutorials

		private CameraLookTutorialController cameraLookTutorial;

		#endregion

		private void Awake()
		{
			uIManager = GetComponent<TutorialUIManager>();
			playerManager = FindObjectOfType<PlayerManager>();
			cameraLookTutorial = GetComponent<CameraLookTutorialController>();
		}

		private void Start()
		{
			StartCoroutine(Co_StartTutorial());
		}

		private IEnumerator Co_StartTutorial()
		{
			playerManager.FreezePlayer();

			yield return new WaitForSeconds(2);

			uIManager.ShowMessage(Messages.Hi);

			yield return new WaitForSeconds(2);

			uIManager.ShowMessage(Messages.Intro);

			yield return new WaitForSeconds(3);

			uIManager.ShowMessage(Messages.MoveCamera);
			playerManager.EnableCameraLook();
			cameraLookTutorial.StartTutorial();
			yield return new WaitUntil(() => cameraLookTutorial.IsPassed);

			uIManager.HideMessage();
		}


		internal class Messages
		{
			public const string Hi = "Hello my friend!";
			public const string Intro = "We are here to learn some basics";
			public const string MoveCamera = "Try to move the camera around the ball with this little joystick";
		}
	}
}