using UIManager;
using UnityEngine;
using UnityEngine.UI;

namespace BallBalance
{
	public class MainMenu : UIScreen
	{
		[SerializeField] private Button b_Start;
		[SerializeField] private Button b_Setting;

		private MainMenuUIController uIController;

		public void InitUI(MainMenuUIController uIController)
		{
			this.uIController = uIController;

			b_Start.onClick.AddListener(
				delegate
				{
					GameManager.Instance.ResumeGame();
				});
		}
	}
}
