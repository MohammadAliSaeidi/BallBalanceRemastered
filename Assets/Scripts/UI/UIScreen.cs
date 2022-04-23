using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace BallBalance.UISystem
{

	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(CanvasGroup))]
	public class UIScreen : MonoBehaviour
	{
		#region Vaiables

		[Header("Screen Events")]
		public UnityEvent OnScreenStart = new UnityEvent();
		public UnityEvent OnScreenClose = new UnityEvent();

		[HideInInspector] public Animator animator;
		[HideInInspector] public bool IsShowing { get; private set; }

		[Header("Overrides")]
		[SerializeField] public bool OverridePrevScreen = false;
		public UIScreen PrevScreen;

		[Space(10)]
		public bool OverrideShowTransitionDuration = false;
		public float ShowTransitionDuration;

		[Space(10)]
		public bool OverrideHideTransitionDuration = false;
		public float HideTransitionDuration;

		[Space(10)]
		[SerializeField] public bool DelayBeforeStartingScreen;
		public float CustomDelay = 0;
		public float DefaultDelay
		{
			get
			{
				return UISystem.ShowTransitionDuration / 2;
			}
		}

		#endregion

		#region Unity Methods

		void Awake()
		{
			animator = GetComponent<Animator>();
		}

		#endregion

		#region Methods

		[ContextMenu("Show Screen")]
		public void Show()
		{
			if (!IsShowing)
			{
				UpdateAnimationSpeed();
				StartCoroutine(Co_ShowScreen());
				IsShowing = true;
			}
		}

		void UpdateAnimationSpeed()
		{
			float showAnimSpeed;
			float hideAnimSpeed;

			if (OverrideShowTransitionDuration)
				showAnimSpeed = 1 / ShowTransitionDuration;
			else
				showAnimSpeed = 1 / UISystem.ShowTransitionDuration;

			if (OverrideHideTransitionDuration)
				hideAnimSpeed = 1 / HideTransitionDuration;
			else
				hideAnimSpeed = 1 / UISystem.HideTranstionDuration;

			animator.SetFloat("ShowTranstionDuration", showAnimSpeed);
			animator.SetFloat("HideTranstionDuration", hideAnimSpeed);
		}

		IEnumerator Co_ShowScreen()
		{
			float delay = 0;

			if (DelayBeforeStartingScreen)
			{
				delay = CustomDelay;
				yield return new WaitForSeconds(delay);
			}

			if (OnScreenStart != null)
			{
				OnScreenStart.Invoke();
			}

			if (animator)
			{
				animator.SetTrigger("Show");
			}
		}

		[ContextMenu("Close Screen")]
		public void Close()
		{
			if (IsShowing)
			{
				if (OnScreenClose != null)
				{
					OnScreenClose.Invoke();
				}

				HandleAnimator("Hide");
				IsShowing = false;
			}
		}

		void HandleAnimator(string aTrigger)
		{
			if (animator)
			{
				animator.SetTrigger(aTrigger);
			}
		}

		public void OnHideAnimFinish()
		{
			//gameObject.SetActive(false);
		}

		#endregion
	}
}