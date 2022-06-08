using UnityEngine;

namespace BallBalance.Utility
{

	public class FollowController : MonoBehaviour
	{
		#region Variables

		public float FollowSmooth = 5f;
		public Transform Target;
		public UpdateMode updateMode;

		#endregion

		#region Unity Methods

		private void Update()
		{
			if (updateMode == UpdateMode.Update)
			{
				FollowTarget();
			}
		}

		private void FixedUpdate()
		{
			if (updateMode == UpdateMode.FixedUpdate)
			{
				FollowTarget();
			}
		}

		private void LateUpdate()
		{
			if (updateMode == UpdateMode.LateUpdate)
			{
				FollowTarget();
			}
		}

		#endregion

		#region Private Methods

		private void FollowTarget()
		{
			if (Target)
			{
				transform.position = Vector3.Lerp(transform.position, Target.transform.position, Time.smoothDeltaTime * FollowSmooth);
			}
		}

		#endregion
	}
}