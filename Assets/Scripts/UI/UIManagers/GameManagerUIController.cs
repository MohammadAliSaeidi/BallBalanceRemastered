using System;
using UnityEngine;
using BallBalance.UISystem;

namespace BallBalance
{
	internal class GameManagerUIController : UISystem.UISystem
	{
		[SerializeField] private UIScreen s_LoadingEffect;

		private void Awake()
		{
			s_LoadingEffect.DelayBeforeClosingScreen = 1;
		}

		protected override void GetAllScreens()
		{
			Screens.Add(s_LoadingEffect);
		}

		internal void ShowLoadingEffect()
		{
			s_LoadingEffect.Show();
		}

		internal void HideLoadingEffect()
		{
			s_LoadingEffect.Close();
		}
	}
}
