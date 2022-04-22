using UnityEngine;
using BallBalance.UnityEventModels;

namespace BallBalance.Utility.Animation
{
	[RequireComponent(typeof(Animator))]
	public class AnimationEventDispatcher : MonoBehaviour
	{
		public UnityEvent_String OnAnimationStart;
		public UnityEvent_String OnAnimationComplete;

		Animator animator;

		void Awake()
		{
			animator = GetComponent<Animator>();

			for (int i = 0; i < animator.runtimeAnimatorController.animationClips.Length; i++)
			{
				AnimationClip clip = animator.runtimeAnimatorController.animationClips[i];

				AnimationEvent animationStartEvent = new AnimationEvent
				{
					time = 0,
					functionName = "AnimationStartHandler",
					stringParameter = clip.name
				};

				AnimationEvent animationEndEvent = new AnimationEvent
				{
					time = clip.length,
					functionName = "AnimationCompleteHandler",
					stringParameter = clip.name
				};

				clip.AddEvent(animationStartEvent);
				clip.AddEvent(animationEndEvent);
			}
		}

		public void AnimationStartHandler(string name)
		{
			Debug.Log($"{name} animation start.");
			OnAnimationStart?.Invoke(name);
		}

		public void AnimationCompleteHandler(string name)
		{
			Debug.Log($"{name} animation complete.");
			OnAnimationComplete?.Invoke(name);
		}

	}
}
