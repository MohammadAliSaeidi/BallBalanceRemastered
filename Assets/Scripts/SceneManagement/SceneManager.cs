using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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

		void Awake()
		{
			Singleton();
		}

		internal void Load(GameLevel level)
		{

		}
	}

	internal class GamesLevels
	{
		internal readonly GameLevel Splash = new GameLevel("Splash");
	}

	internal class GameLevel
	{
		internal readonly string LevelName;

		public GameLevel(string levelName)
		{
			LevelName = levelName;
		}
	}
}
