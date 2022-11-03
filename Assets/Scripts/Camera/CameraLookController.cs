using System.Collections;
using UnityEngine;

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

		internal bool allowCameraLook;

		private void Start()
		{
			_horizontal = -_cameraPivot.eulerAngles.x;
			_vertical = _cameraPivot.eulerAngles.y;
		}

		public void HandleLook(Vector2 delta)
		{
			if (allowCameraLook)
			{
				_horizontal += delta.y * _lookSpeed;
				_vertical += delta.x * _lookSpeed;
			}

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

		public void RotateCameraTowardThe(Vector3 targetPosition, float smooth)
		{
			StartCoroutine(Co_SmoothRotateToward(targetPosition, smooth));
		}

		private IEnumerator Co_SmoothRotateToward(Vector3 targetPosition, float smooth)
		{
			var IsLookingAt = false;
			var lastCameraLookPermit = allowCameraLook;
			var lastLookSmoothAmount = LookSmoothing;
			var dir = (targetPosition - _cameraPivot.position).normalized;
			var targetRotation = Quaternion.LookRotation(dir);

			allowCameraLook = false;
			LookSmoothing = smooth;

			_horizontal = -targetRotation.eulerAngles.x;
			_vertical = targetRotation.eulerAngles.y;

			while (IsLookingAt == false)
			{
				if (Quaternion.Angle(_cameraPivot.rotation, targetRotation) <= 0.1f)
				{
					IsLookingAt = true;
				}

				yield return null;
			}

			yield return new WaitUntil(() => IsLookingAt);

			yield return new WaitForSeconds(1);

			allowCameraLook = lastCameraLookPermit;
			LookSmoothing = lastLookSmoothAmount;
		}
	}
}
