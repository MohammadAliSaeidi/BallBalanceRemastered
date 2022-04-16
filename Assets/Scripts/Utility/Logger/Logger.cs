using UnityEngine;
using UnityEngine.UI;

namespace BallBalance.Utility.Logger
{
	public class Logger : MonoBehaviour
	{
		// TODO: if the build is on developer mode. then this script will work
		[SerializeField] FloatingButton floatingButton;
		[SerializeField] GameObject Panel;
		[SerializeField] Text LogText;

		bool isShowing = false;

		void Awake()
		{
			// Init floating button
			floatingButton.button.onClick.AddListener(delegate
			{
				if (isShowing)
				{
					isShowing = false;
				}
				else
				{
					isShowing = true;
				}
			});
		}

		internal void Log(string text)
		{
			LogText.text = $"{LogText.text}\n{text}";
		}

		internal void ShowLogs()
		{
			Panel.SetActive(true);
		}

		internal void HideLogs()
		{
			Panel.SetActive(false);
		}
	}
}
