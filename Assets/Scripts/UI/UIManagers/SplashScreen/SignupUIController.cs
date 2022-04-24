using System;
using UnityEngine;
using UnityEngine.UI;

namespace BallBalance.Signup
{
	public class SignupUIController : MonoBehaviour
	{
		[SerializeField] InputField inp_Name;
		[SerializeField] Button b_Signup;

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

				GameManager.Instance.UIController.HideLoadingEffect();
			});
		}
	}
}
