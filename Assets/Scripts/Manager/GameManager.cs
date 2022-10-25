using BallBalance.SceneManagement;
using BallBalance.SplashScreen;
using System.Collections;
using UnityEngine;

namespace BallBalance
{
	public class GameManager : MonoBehaviour
	{
		#region Singletone

		private static GameManager _instance;
		public static GameManager Instance { get { return _instance; } }

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

		#region Components

		internal GameManagerUIController UIController;
		internal LevelManager currentLevelManager;

		#endregion

		public const bool isDebug = false;

		internal Account account;
		internal AccountSaveModel AccountSave;

		void Awake()
		{
			Singleton();

			InitComponents();
		}

		void InitComponents()
		{
			UIController = GetComponent<GameManagerUIController>();
		}

		IEnumerator Start()
		{
			var splashManager = new GameObject("SplashManager", typeof(SplashManager)).GetComponent<SplashManager>();
			var splashScreenUIController = FindObjectOfType<SplashScreenUIController>();

			yield return splashManager.Init(splashScreenUIController);

			AccountSave = SaveAndLoadManager.LoadSaves(account.name);
		}

		public void ResumeGame()
		{
			var savedLevel = AccountSave.lastPlayedLevelSave;

			if (savedLevel == null)
			{
				// start new game
				SceneManager.Instance.Load(GameLevels.Tutorial);
			}

			else
			{

			}
		}
	}
}
