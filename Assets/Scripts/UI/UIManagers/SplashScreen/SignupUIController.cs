using UIManager;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BallBalance.Signup
{
	public class SignupUIController : UIScreen
	{
		[SerializeField] private InputField inp_Name;
		[SerializeField] private Button b_Signup;
		[SerializeField] private Animator anim_Error;
		[SerializeField] private Text txt_Error;

		#region Events

		internal UnityEvent e_OnSignup = new UnityEvent();

		#endregion

		public void InitUI()
		{
			inp_Name.onValueChanged.AddListener(
				delegate
				{
					CheckInput();
				});

			b_Signup.onClick.AddListener(
				async () =>
				{
					if (!CheckInput())
					{
						return;
					}

					GameManager.Instance.UIController.ShowLoadingEffect();

					await Database.DatabaseManager.Instance.AddUserAccount(new Account() { name = inp_Name.text });

					EventHandler.FireEvent(ref e_OnSignup);

					GameManager.Instance.UIController.HideLoadingEffect();
				});
		}

		private bool CheckInput()
		{
			var inpText = inp_Name.text;

			if (InputChecker.IsEmptyOrWhiteSpace(inpText))
			{
				ShowError("The name can not be empty!");

				return false;
			}

			return true;
		}

		private void ShowError(string errorText)
		{
			txt_Error.text = errorText;
			anim_Error.CrossFadeInFixedTime("Show", 0.05f);
		}

		private void HideError()
		{
			anim_Error.CrossFadeInFixedTime("Hide", 0.05f);
		}
	}
}
