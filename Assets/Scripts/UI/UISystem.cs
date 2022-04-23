﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BallBalance.UISystem
{
	public abstract class UISystem : MonoBehaviour
	{

		#region Vaiables

		public UnityEvent e_OnSwitchedScreen = new UnityEvent();

		protected List<UIScreen> Screens = new List<UIScreen>();

		public UIScreen FirstScreen;
		public UIScreen CurrentScreen { get; protected set; }
		public UIScreen PrevScreen { get; protected set; }

		public static readonly float ShowTransitionDuration = 0.5f;
		public static readonly float HideTranstionDuration = 0.5f;

		#endregion



		#region Methods

		protected virtual void Start()
		{
			ShowFirstScreen();
		}

		public void Switch(UIScreen screen)
		{
			if (screen && CurrentScreen != screen)
			{
				if (CurrentScreen)
				{
					CurrentScreen.gameObject.SetActive(true);
					CurrentScreen.Close();
					PrevScreen = CurrentScreen;
				}

				CurrentScreen = screen;
				CurrentScreen.gameObject.SetActive(true);
				CurrentScreen.Show();

				if (e_OnSwitchedScreen != null)
					e_OnSwitchedScreen.Invoke();
			}
		}

		public void Show(UIScreen screen)
		{
			screen.gameObject.SetActive(true);
			screen.Show();
		}

		public void Close(UIScreen screen)
		{
			screen.gameObject.SetActive(true);
			screen.Close();
		}

		public virtual void ShowFirstScreen()
		{
			if (FirstScreen)
			{
				Switch(FirstScreen);
			}
		}

		public virtual void SwitchPrevScreen()
		{
			if (CurrentScreen.OverridePrevScreen == true && CurrentScreen.PrevScreen != null)
				Switch(CurrentScreen.PrevScreen);
			else if (PrevScreen)
				Switch(PrevScreen);

			else Debug.LogError("The previous page is null");
		}

		public void CloseAllScreens()
		{
			Screens.ForEach(i =>
			{
				i.gameObject.SetActive(true);
				i.Close();
			});
		}

		protected abstract void GetAllScreens();

		#endregion
	}
}