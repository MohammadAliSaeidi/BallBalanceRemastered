using UnityEngine;

namespace BallBalance.Utility.Physics
{
	public class Force : MonoBehaviour
	{
		[Header("Random Force")]
		[SerializeField] private bool RandomForce;
		[SerializeField] private Vector3 _minForce;
		[SerializeField] private Vector3 _maxForce;
		[SerializeField] private ForceMode _forceMode;

		[Header("Initialization")]
		[SerializeField] private bool ApplyAtStart = true;
		[SerializeField] private ForceInfo _forceInfo;

		[Header("Rigidbody")]
		[SerializeField] private bool _getRbFromThisGO = true;
		public Rigidbody rb;

		private void Awake()
		{
			if (_getRbFromThisGO)
			{
				rb = GetComponent<Rigidbody>();
			}
		}

		private void Start()
		{
			if (ApplyAtStart)
			{
				if (RandomForce)
				{
					AddRandomForce(_minForce, _maxForce, _forceMode);
				}
				else
				{
					AddForce(_forceInfo);
				}
			}
		}

		private void AddForce(ForceInfo forceInfo)
		{
			rb.AddForce(forceInfo.Force, forceInfo.forceMode);
		}

		private void AddRandomForce(Vector3 minForce, Vector3 maxForce, ForceMode forceMode)
		{
			var force = new Vector3(
				UnityEngine.Random.Range(minForce.x, maxForce.x), 
				UnityEngine.Random.Range(minForce.y, maxForce.y), 
				UnityEngine.Random.Range(minForce.z, maxForce.z));

			rb.AddForce(force, forceMode);
		}
	}
}
