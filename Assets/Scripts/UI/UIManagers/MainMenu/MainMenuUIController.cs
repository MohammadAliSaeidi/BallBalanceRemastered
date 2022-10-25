using UIManager;
using UnityEngine;

namespace BallBalance
{
	public class MainMenuUIController : UISystem
	{
		#region Screens

		[Header("Screens")]
		[SerializeField] MainMenu s_MainMenu;

		#endregion

		protected override void Start()
		{
			base.Start();
		}

		protected override void GetAllScreens()
		{

		}

		protected override void InitUI()
		{
			
		}
	}
}
