using UnityEngine;

namespace BallBalance
{
	public class DoorController : MonoBehaviour
	{
		[SerializeField] private Animator _animator;
		internal bool IsOpen { get; private set; } = false;

		private void Awake()
		{
			_animator = GetComponent<Animator>();
		}

		internal void Lock()
		{
			if (IsOpen)
			{
				_animator.Play("Lock");
				IsOpen = false;
			}
		}

		internal void Unlock()
		{
			if (!IsOpen)
			{
				_animator.Play("Unlock");
				IsOpen = true;
			}
		}
	}
}
