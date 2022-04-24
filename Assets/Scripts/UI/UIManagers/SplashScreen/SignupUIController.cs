using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace BallBalance.Signup
{
	public class SignupUIController : MonoBehaviour
	{
		#region Events

		internal UnityEvent e_OnSignup = new UnityEvent();

		#endregion

		[SerializeField] private InputField inp_Name;
		[SerializeField] private Button b_Signup;

		void Awake()
		{
			InitUI();
		}

		void InitUI()
		{
			b_Signup.onClick.AddListener(async () => 
			{
				GameManager.Instance.UIController.ShowLoadingEffect();

				await Database.DatabaseManager.Instance.AddUserAccount(new Account() { name = inp_Name.text });

				EventHandler.FireEvent(ref e_OnSignup);

				GameManager.Instance.UIController.HideLoadingEffect();
			});
		}
	}
}
