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

		protected override void Start()
		{
			base.Start();

			s_Signup.Close();
			CurrentScreen = null;
		}

		protected override void GetAllScreens()
		{
			Screens.Add(s_Signup);
		}

		internal void ShowSignup()
		{
			SwitchTo(s_Signup);
		}
	}
}
