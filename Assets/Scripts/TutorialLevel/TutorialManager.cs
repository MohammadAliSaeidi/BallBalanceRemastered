using System.Collections;
using UnityEngine;

namespace BallBalance.Tutorial
{
	[RequireComponent(typeof(CameraLookTutorialController), typeof(TutorialUIManager), typeof(MovementTutorialController))]
	[RequireComponent(typeof(GemTutorialController))]
	public class TutorialManager : MonoBehaviour
	{
		[SerializeField] private Animator anim_Ground;
		[SerializeField] private TutorialWall[] Walls;

		[Header("Gem tutorial")]
		[SerializeField] private OnTriggerEnterEventHandler gemTutorialTrigger;
		[SerializeField] private Animator anim_GemSection;

		private TutorialUIManager uIManager;
		private PlayerManager playerManager;
		private bool _isWallsEnable = false;
		private Ball _currentBall;

		#region Tutorials

		private CameraLookTutorialController cameraLookTutorial;
		private MovementTutorialController movementTutorial;
		private GemTutorialController gemTutorial;

		#endregion



		private void Awake()
		{
			uIManager = GetComponent<TutorialUIManager>();
			playerManager = FindObjectOfType<PlayerManager>();
			cameraLookTutorial = GetComponent<CameraLookTutorialController>();
			movementTutorial = GetComponent<MovementTutorialController>();
			gemTutorial = GetComponent<GemTutorialController>();
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
			// Init tutorial and Intro
			{
				playerManager.FreezePlayer();
				yield return new WaitForSeconds(2);

				uIManager.ShowMessage("Hello my friend!");
				yield return new WaitForSeconds(2);

				uIManager.ShowMessage("We are here to learn some basics");
				yield return new WaitForSeconds(3);
			}

			// Movement Tutorial
			{
				uIManager.ShowMessage("Try to move the ball with this little joystick");
				if (anim_Ground)
				{
					anim_Ground.Play("ground_expantion");
				}
				_isWallsEnable = true;
				yield return new WaitForSeconds(1.5f);
				movementTutorial.StartTutorial();
				playerManager.EnablePlayerMovement();
				uIManager.ShowHandTutorial(TutorialUIManager.HandTutorialType.Movement);
				movementTutorial.e_OnPlayerInteract.AddListener(() => uIManager.HideHandTutorial(TutorialUIManager.HandTutorialType.Movement));

				yield return new WaitUntil(() => movementTutorial.IsPassed);
			}

			// Camera control tutorial
			{
				uIManager.ShowMessage("Great!");
				yield return new WaitForSeconds(2);
				uIManager.ShowMessage("Now try to move the camera around the ball");
				cameraLookTutorial.StartTutorial();
				playerManager.EnableCameraLook();
				uIManager.ShowHandTutorial(TutorialUIManager.HandTutorialType.Look);
				cameraLookTutorial.e_OnPlayerInteract.AddListener(() => uIManager.HideHandTutorial(TutorialUIManager.HandTutorialType.Look));

				yield return new WaitUntil(() => cameraLookTutorial.IsPassed);
				uIManager.ShowMessage("Well done, very good!");
			}

			// Gem tutorial
			{
				uIManager.ShowMessage("Now Lets get to the next part");
				gemTutorialTrigger.e_OnTriggerEnter.AddListener(
					delegate (Collider collider)
					{
						gemTutorial.StartTutorial();
						Destroy(gemTutorialTrigger.gameObject);
					});
				anim_GemSection.Play("ground_expantion");
			}
		}
	}
}