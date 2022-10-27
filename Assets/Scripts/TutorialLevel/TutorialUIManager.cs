using BallBalance.Utility.Animation;
using UnityEngine;
using UnityEngine.UI;


namespace BallBalance.Tutorial
{
	internal class TutorialUIManager : MonoBehaviour
	{
		[SerializeField] private Animator anim_TutorialMessage;
		[SerializeField] private Text txt_Message;

		private bool _isHidden = true;
		private Utility.Animation.AnimationEventDispatcher tutorialMessageAnimEvent;

		private void Awake()
		{
			tutorialMessageAnimEvent = anim_TutorialMessage.GetComponent<AnimationEventDispatcher>();
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
			if (!_isHidden)
			{
				anim_TutorialMessage.CrossFadeInFixedTime("Hide", 0.05f);
				_isHidden = true;
			}
		}
	}
}