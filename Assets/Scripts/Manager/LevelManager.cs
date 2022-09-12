using UnityEngine;

namespace BallBalance
{
	public class LevelManager : MonoBehaviour
	{
		public Ball CurrentBall;

		public void OnEnable()
		{
			GameManager.Instance.currentLevelManager = this;
		}

		public void OnDisable()
		{
			if (GameManager.Instance.currentLevelManager == this)
			{
				GameManager.Instance.currentLevelManager = null;
			}
		}
	}
}
