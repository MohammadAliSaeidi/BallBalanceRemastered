using System.Collections;
using UnityEngine;

namespace BallBalance.Tutorial
{
	[RequireComponent(typeof(CameraLookTutorialController), typeof(TutorialUIManager), typeof(MovementTutorialController))]
	public class TutorialManager : MonoBehaviour
	{
		[SerializeField] private Animator anim_Ground;
		[SerializeField] private TutorialWall[] Walls;

		private TutorialUIManager uIManager;
		private PlayerManager playerManager;
		private bool _isWallsEnable = false;
		private Ball _currentBall;

		#region Tutorials

		private CameraLookTutorialController cameraLookTutorial;
		private MovementTutorialController movementTutorial;

		#endregion

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
			_currentBall = GameManager.Instance.currentLevelManager.CurrentBall;
		}

		private void Update()
		{
			if (_isWallsEnable)
			{
				foreach (var wall in Walls)
				{
					if (wall.AxisX)
					{
						wall.transform.position = new Vector3(
																x: _currentBall.transform.position.x,
																y: _currentBall.transform.position.y,
																z: wall.transform.position.z);
					}
					if (wall.AxisZ)
					{
						wall.transform.position = new Vector3(
																x: wall.transform.position.x,
																y: _currentBall.transform.position.y,
																z: _currentBall.transform.position.z);
					}
				}
			}
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
			_isWallsEnable = true;
			yield return new WaitForSeconds(1.5f);
			movementTutorial.StartTutorial();
			playerManager.EnablePlayerMovement();
			uIManager.ShowLookJoystickAndHandTutorial();

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