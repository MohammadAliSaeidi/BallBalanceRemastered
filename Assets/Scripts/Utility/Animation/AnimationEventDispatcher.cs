using UnityEngine;
using BallBalance.UnityEventModels;

namespace BallBalance.Utility.Animation
{
	[RequireComponent(typeof(Animator))]
	public class AnimationEventDispatcher : MonoBehaviour
	{
		[HideInInspector] public UnityEvent_String e_OnAnimationStart = new UnityEvent_String();
		[HideInInspector] public UnityEvent_String e_OnAnimationComplete = new UnityEvent_String();

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
			e_OnAnimationStart?.Invoke(name);
		}

		public void AnimationCompleteHandler(string name)
		{
			e_OnAnimationComplete?.Invoke(name);
		}

	}
}
