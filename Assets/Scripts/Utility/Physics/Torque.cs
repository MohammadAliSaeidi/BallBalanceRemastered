using UnityEngine;

namespace BallBalance.Utility.Physics
{
	public partial class Torque : MonoBehaviour
	{
		[Header("Rigidbody")]
		[SerializeField] private bool _getRbFromThisGO = true;
		public Rigidbody rb;

		[Header("Initialization")]
		[SerializeField] private bool ApplyAtStart = true;
		[SerializeField] private ForceInfo _forceInfo;

		[Header("Random Force")]
		[SerializeField] private bool RandomForce;
		[SerializeField] private Vector3 _minForce;
		[SerializeField] private Vector3 _maxForce;
		[SerializeField] private ForceMode _forceMode;


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
			rb.AddTorque(forceInfo.Force, forceInfo.forceMode);
		}

		private void AddRandomForce(Vector3 minForce, Vector3 maxForce, ForceMode forceMode)
		{
			var force = new Vector3(
				UnityEngine.Random.Range(minForce.x, maxForce.x), 
				UnityEngine.Random.Range(minForce.y, maxForce.y), 
				UnityEngine.Random.Range(minForce.z, maxForce.z));

			rb.AddTorque(force, forceMode);
		}
	}
}
