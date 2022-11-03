using BallBalance.Utility.Animation;
using UnityEngine;
using UnityEngine.UI;


namespace BallBalance.Tutorial
{
	internal partial class TutorialUIManager : MonoBehaviour
	{
		[SerializeField] private Animator anim_TutorialMessage;
		[SerializeField] private Text txt_Message;

		[Header("Hand")]
		[SerializeField] private Animator anim_LeftHand;
		[SerializeField] private Animator anim_RightHand;

		private bool _isHidden = true;
		private Utility.Animation.AnimationEventDispatcher tutorialMessageAnimEvent;

		private void Awake()
		{
			tutorialMessageAnimEvent = anim_TutorialMessage.GetComponent<AnimationEventDispatcher>();
		}

		private void Start()
		{
			anim_LeftHand.gameObject.SetActive(false);
			anim_RightHand.gameObject.SetActive(false);
		}

		internal void ShowMessage(string message)
		{
			tutorialMessageAnimEvent.e_OnAnimationComplete.RemoveAllListeners();

			if (!_isHidden)
			{
				HideMessage();

				tutorialMessageAnimEvent.e_OnAnimationComplete.AddListener(
					delegate
					{
						if (_isHidden)
						{
							txt_Message.text = message;
							anim_TutorialMessage.CrossFadeInFixedTime("Show", 0.05f);

							_isHidden = false;
						}
					});
			}

			else
			{
				txt_Message.text = message;
				anim_TutorialMessage.CrossFadeInFixedTime("Show", 0.05f);

				_isHidden = false;
			}
		}

		internal void HideMessage()
		{
			tutorialMessageAnimEvent.e_OnAnimationComplete.RemoveAllListeners();
			if (!_isHidden)
			{
				anim_TutorialMessage.CrossFadeInFixedTime("Hide", 0.05f);
				_isHidden = true;
			}
		}

		internal void ShowHandTutorial(HandTutorialType handTutorialType)
		{
			switch (handTutorialType)
			{
				case HandTutorialType.Look:
				anim_RightHand.gameObject.SetActive(true);
				anim_RightHand.Play("TutorialJoystick");
				break;

				case HandTutorialType.Movement:
				anim_LeftHand.gameObject.SetActive(true);
				anim_LeftHand.Play("TutorialJoystick");
				break;
			}
		}

		internal void HideHandTutorial(HandTutorialType handTutorialType)
		{
			switch (handTutorialType)
			{
				case HandTutorialType.Look:
				anim_RightHand.CrossFadeInFixedTime("Hide", 0.5f, 0, -0.5f);
				break;

				case HandTutorialType.Movement:
				anim_LeftHand.CrossFadeInFixedTime("Hide", 0.5f, 0, -0.5f);
				break;
			}
		}
	}
}