using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using BallBalance.Utility.Animation;

namespace BallBalance.UISystem
{
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(CanvasGroup))]
	[RequireComponent(typeof(AnimationEventDispatcher))]
	public class UIScreen : MonoBehaviour
	{
		#region Vaiables

		#region Components

		Animator animator;
		AnimationEventDispatcher animationEventDispatcher;

		#endregion

		#region Events

		[Header("Events")]
		public UnityEvent OnScreenStart = new UnityEvent();
		public UnityEvent OnScreenClose = new UnityEvent();

		#endregion

		Transform Content;
		internal bool IsShowing { get; private set; }

		[SerializeField] internal UIScreen OverridePrevScreen;
		[SerializeField] internal float OverrideShowAnimSpeed;
		[SerializeField] internal float OverrideHideAnimSpeed;

		[Space(10)]
		public float DelayBeforeStartingScreen = 0;
		public float DefaultDelay
		{
			get
			{
				return UISystem.DefaultShowAnimSpeed / 2;
			}
		}

		internal ScreenState screenState { get; private set; }

		#endregion

		#region Unity Methods

		void OnValidate()
		{
			animator = GetComponent<Animator>();
			animationEventDispatcher = GetComponent<AnimationEventDispatcher>();

			if (animator.runtimeAnimatorController == null)
				animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(@"DefaultAnimations/DefaultScreenAnimation/UIScreen");
		}

		void Awake()
		{
			Content = transform.Find("Content");

			animationEventDispatcher.e_OnAnimationComplete.AddListener(
				delegate
				{
					if (screenState == ScreenState.IsBeingClosed)
					{
						if (Content != null)
						{
							Content.gameObject.SetActive(false);
						}

						screenState = ScreenState.Closed;
					}
					else if(screenState == ScreenState.IsBeingShown)
					{
						screenState = ScreenState.IsShowing;
					}
				});
		}

		void Start()
		{
			InitAnimationSpeed();
		}

		#endregion

		#region Methods

		[ContextMenu("Show Screen")]
		public void Show()
		{
			if (screenState != ScreenState.IsShowing || screenState != ScreenState.IsBeingShown)
			{
				StartCoroutine(Co_ShowScreen());
			}
		}

		[ContextMenu("Close Screen")]
		public void Close()
		{
			if (screenState != ScreenState.IsBeingClosed || screenState != ScreenState.IsBeingClosed)
			{
				if (OnScreenClose != null)
				{
					OnScreenClose.Invoke();
				}

				HandleAnimator("Hide");
			}
		}

		void InitAnimationSpeed()
		{
			float showAnimSpeed;
			float hideAnimSpeed;

			if (OverrideShowAnimSpeed > 0)
				showAnimSpeed = 1 / OverrideShowAnimSpeed;
			else
				showAnimSpeed = 1 / UISystem.DefaultShowAnimSpeed;

			if (OverrideHideAnimSpeed > 0)
				hideAnimSpeed = 1 / OverrideHideAnimSpeed;
			else
				hideAnimSpeed = 1 / UISystem.DefaultHideAnimSpeed;

			animator.SetFloat("ShowTranstionDuration", showAnimSpeed);
			animator.SetFloat("HideTranstionDuration", hideAnimSpeed);
		}

		IEnumerator Co_ShowScreen()
		{
			if (DelayBeforeStartingScreen > 0)
			{
				yield return new WaitForSeconds(DelayBeforeStartingScreen);
			}

			if (OnScreenStart != null)
			{
				OnScreenStart.Invoke();
			}

			HandleAnimator("Show");
		}

		void HandleAnimator(string aTrigger)
		{
			if (animator)
			{
				animator.SetTrigger(aTrigger);

				if(aTrigger == "Show")
				{
					screenState = ScreenState.IsBeingShown;
				}

				else if (aTrigger == "Hide")
				{
					screenState = ScreenState.IsBeingClosed;
				}
			}
		}

		#endregion
	}
}