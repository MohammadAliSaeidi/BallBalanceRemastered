using System;
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

		void Awake()
		{
			Singleton();
		}

		void Start()
		{
			InitDatabase();
		}

		void InitDatabase()
		{
			
		}
	}
}
