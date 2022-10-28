using System.Collections;
using UnityEngine;

namespace BallBalance.Tutorial
{
	[RequireComponent(typeof(CameraLookTutorialController), typeof(TutorialUIManager), typeof(MovementTutorialController))]
	public class TutorialManager : MonoBehaviour
	{
		private TutorialUIManager uIManager;
		private PlayerManager playerManager;

		#region Tutorials

		private CameraLookTutorialController cameraLookTutorial;
		private MovementTutorialController movementTutorial;

		#endregion

		[SerializeField] private Animator anim_Ground;

		private void Awake()
		{
			uIManager = GetComponent<TutorialUIManager>();
			playerManager = FindObjectOfType<PlayerManager>();
			cameraLookTutorial = GetComponent<CameraLookTutorialController>();
			movementTutorial = GetComponent<MovementTutorialController>();
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

			uIManager.ShowMessage(Messages.MoveBall);
			if (anim_Ground)
			{
				anim_Ground.Play("ground_expantion");
			}
			movementTutorial.StartTutorial();
			playerManager.EnablePlayerMovement();
			
			yield return new WaitUntil(() => movementTutorial.IsPassed);

			uIManager.ShowMessage(Messages.MoveCamera);
			cameraLookTutorial.StartTutorial();
			playerManager.EnableCameraLook();


		}


		internal class Messages
		{
			public const string Hi = "Hello my friend!";
			public const string Intro = "We are here to learn some basics";
			public const string MoveBall = "Try to move the ball with this little joystick";
			public const string MoveCamera = "Great! Now try to move the camera around the ball";
		}
	}
}