using System.Collections;
using UnityEngine;

namespace BallBalance.Tutorial
{
	[RequireComponent(typeof(CameraLookTutorialController), typeof(TutorialUIManager))]
	public class TutorialManager : MonoBehaviour
	{
		private TutorialUIManager uIManager;

		#region Tutorials

		private CameraLookTutorialController cameraLookTutorial;

		#endregion

		private void Awake()
		{
			uIManager = GetComponent<TutorialUIManager>();
			cameraLookTutorial = GetComponent<CameraLookTutorialController>();
		}

		private void Start()
		{
			StartCoroutine(Co_StartTutorial());
		}

		private IEnumerator Co_StartTutorial()
		{
			yield return new WaitForSeconds(2);

			uIManager.ShowMessage(Messages.Hi);
		}


		internal class Messages
		{
			public const string Hi = "Hello my friend!";
		}
	}
}