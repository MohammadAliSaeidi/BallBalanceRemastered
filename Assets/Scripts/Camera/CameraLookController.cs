using UnityEngine;
using Cinemachine;

namespace BallBalance
{
    public class CameraLookController : MonoBehaviour
    {
		[SerializeField] private float _lookSpeed = 1;
		[SerializeField] private Transform _cameraPivot;

		public float minTilt = 45f;
		public float maxTilt = 75f;

		public float LookSmoothing = 15f;

		private float _horizontal;
		private float _vertical;
		private float _smoothH;
		private float _smoothV;

		private void Start()
		{
			_horizontal = -_cameraPivot.eulerAngles.x;
			_vertical = _cameraPivot.eulerAngles.y;
		}

		public void HandleLook(Vector2 delta)
		{
			_horizontal += delta.y * _lookSpeed;
			_vertical += delta.x * _lookSpeed;

			_horizontal = Mathf.Clamp(_horizontal, -minTilt, maxTilt);
			LookSmoothing = Mathf.Clamp(LookSmoothing, 0f, 10f);

			if (LookSmoothing > 0)
			{
				_smoothH = Mathf.Lerp(_smoothH, _horizontal, LookSmoothing * Time.deltaTime);
				_smoothV = Mathf.Lerp(_smoothV, _vertical, LookSmoothing * Time.deltaTime);

				_cameraPivot.localRotation = Quaternion.Euler(-_smoothH, _smoothV, 0);
			}
			else
			{
				_cameraPivot.localRotation = Quaternion.Euler(-_horizontal, _vertical, 0);
			}
		}
	}
}
