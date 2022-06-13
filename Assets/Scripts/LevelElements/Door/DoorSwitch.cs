using UnityEngine;

namespace BallBalance
{
	public class DoorSwitch : MonoBehaviour
	{
		[SerializeField] private DoorController _door;
		[SerializeField] private OnCollisionEnterEventHandler _collider;
		[SerializeField] private float _minVelocityToActivate = 1;

		private Animator _animator;
		private bool _isOpen = false;

		private void Awake()
		{
			_animator = GetComponent<Animator>();
			Init();
		}

		internal void Init()
		{
			_collider.e_OnCollisionEnter.AddListener(OnCollisionEnterEventHandler);
		}

		public void OnCollisionEnterEventHandler(Collision collision)
		{
			if (_door && !_isOpen && collision.relativeVelocity.magnitude > _minVelocityToActivate)
			{
				_door.Unlock();

				_animator.CrossFadeInFixedTime("Unlock", 0.05f);

				_isOpen = true;
			}
		}
	}
}