using UnityEngine;

namespace BallBalance.Utility.Physics
{
	[System.Serializable]
	internal class ForceInfo
	{
		[SerializeField] internal Vector3 Force;
		[SerializeField] internal ForceMode forceMode;

		public ForceInfo(Vector3 force, ForceMode forceMode)
		{
			Force = force;
			this.forceMode = forceMode;
		}
	}
}
