using BallBalance.SceneManagement;
using BallBalance.Signup;
using UIManager;
using UnityEngine;


namespace BallBalance.SplashScreen
{
	public class SplashScreenUIController : UISystem
	{
		#region UI Elements

		[Header("UI Elements")]
		[SerializeField] private SignupUIController s_Signup;

		#endregion

		protected override void Start()
		{
			base.Start();

			s_Signup.Close();
			CurrentScreen = null;
		}

		protected override void GetAllScreens()
		{
			_screensList.Add(s_Signup);
		}

		internal void ShowSignup()
		{
			SwitchTo(s_Signup);

			s_Signup.e_OnSignup.AddListener(
				delegate
				{
					SceneManager.Instance.Load(GameLevels.MainMenu);
				});
		}

		protected override void InitUI()
		{
			s_Signup.InitUI();
		}
	}
}
