using System;
using UnityEngine;
using UIManager;

namespace BallBalance
{
	internal class GameManagerUIController : UISystem
	{
		[SerializeField] private UIScreen s_LoadingEffect;

		private void Awake()
		{
			s_LoadingEffect.DelayBeforeClosingScreen = 1;
		}

		protected override void Start()
		{
			base.Start();
		}

		protected override void InitUI()
		{
		}

		protected override void GetAllScreens()
		{
			_screensList.Add(s_LoadingEffect);
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
