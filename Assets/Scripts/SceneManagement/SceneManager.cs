using BallBalance.Utility.Animation;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BallBalance.SceneManagement
{
	internal class SceneManager : MonoBehaviour
	{
		#region Singletone

		private static SceneManager _instance;
		internal static SceneManager Instance { get { return _instance; } }

		void Singleton()
		{
			if (_instance != null && _instance != this)
			{
				Destroy(this.gameObject);
			}
			else
			{
				_instance = this;
			}

			DontDestroyOnLoad(_instance);
		}

		#endregion

		#region Events

		internal UnityEvent e_OnSceneLoaded = new UnityEvent();

		#endregion

		Animator TransitionAnimator;
		AnimationEventDispatcher transitionAnimationEventDispatcher;

		void Awake()
		{
			Singleton();

			TransitionAnimator = GetComponentInChildren<Animator>();

			transitionAnimationEventDispatcher = TransitionAnimator.GetComponent<AnimationEventDispatcher>();
		}

		internal void Load(GameLevel level)
		{
			TransitionAnimator.CrossFadeInFixedTime("Show", 0.05f);

			transitionAnimationEventDispatcher
				.e_OnAnimationComplete.RemoveAllListeners();

			transitionAnimationEventDispatcher
				.e_OnAnimationComplete.AddListener(delegate
			{
				var loadingOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(level.Name);
				loadingOperation.allowSceneActivation = true;
				loadingOperation.completed += OnSceneLoaded;
			});
		}

		void OnSceneLoaded(AsyncOperation ao)
		{
			transitionAnimationEventDispatcher
				.e_OnAnimationComplete.RemoveAllListeners();

			TransitionAnimator.CrossFadeInFixedTime("Hide", 0.05f);

			if (e_OnSceneLoaded != null)
				e_OnSceneLoaded.Invoke();
		}
	}
}
