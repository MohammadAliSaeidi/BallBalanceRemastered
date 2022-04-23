using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BallBalance.UISystem;

namespace BallBalance.SplashScreen
{
	public class SplashScreenUIController : UISystem.UISystem
	{
		#region UI Elements

		[Header("UI Elements")]
		[SerializeField] UIScreen s_Signup;

		#endregion

		void Awake()
		{
		}

		protected override void Start()
		{
			base.Start();
		}

		protected override void GetAllScreens()
		{
			Screens.Add(s_Signup);
		}
	}
}
