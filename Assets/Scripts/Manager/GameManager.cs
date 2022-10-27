using BallBalance.SceneManagement;
using BallBalance.SplashScreen;
using System.Collections;
using UnityEngine;

namespace BallBalance
{
	public class GameManager : MonoBehaviour
	{
		[SerializeField] private GameObject _sceneManager;
		[SerializeField] private GameObject _databaseManager;

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

			// Create Managers
			CreateSceneManager();
			CreateDatabaseManager();
		}

		void InitComponents()
		{
			UIController = GetComponent<GameManagerUIController>();
		}

		IEnumerator Start()
		{
			if (SceneManager.Instance.IsCurrentScene(GameLevels.Splash.Name))
			{
				var splashManager = new GameObject("SplashManager", typeof(SplashManager)).GetComponent<SplashManager>();
				var splashScreenUIController = FindObjectOfType<SplashScreenUIController>();

				yield return splashManager.Init(splashScreenUIController);

				if (account != null)
					AccountSave = SaveAndLoadManager.LoadSaves(account.name);
			}
		}

		private void CreateSceneManager()
		{
			Instantiate(_sceneManager);
		}

		private void CreateDatabaseManager()
		{
			Instantiate(_databaseManager);
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
