using UnityEngine;
using UnityEngine.UI;
using BallBalance.UI;

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
			floatingButton.e_OnClick.AddListener(delegate
			{
				if (isShowing)
				{
					HideLogs();
					isShowing = false;
				}
				else
				{
					ShowLogs();
					isShowing = true;
				}
			});
		}

		void Start()
		{
			HideLogs();
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

		internal void ClearLogs()
		{
			LogText.text = "No Logs";
		}
	}
}
