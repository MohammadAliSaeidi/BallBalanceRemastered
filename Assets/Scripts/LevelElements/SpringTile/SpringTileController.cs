using System;
using System.Collections;
using UnityEngine;

namespace BallBalance
{
	public partial class SpringTileController : MonoBehaviour
	{
		[SerializeField] private SpringTile _spring;
		[SerializeField] private float _springPower;
		private float originSpringAmount;
		private Coroutine _releaseCoroutine;

		private void Start()
		{
			_spring.onTriggerHandler.e_OnTriggerEnter.AddListener(OnCollisionEnterHandler);
			originSpringAmount = _spring.springJoint.spring;
		}

		private void OnCollisionEnterHandler(Collider collider)
		{
			if (collider.CompareTag("SpringLowerBound"))
			{
				if (_releaseCoroutine != null)
				{
					StopCoroutine(_releaseCoroutine);
				}
				_releaseCoroutine = StartCoroutine(Co_ReleaseSpring());
			}
		}

		private IEnumerator Co_ReleaseSpring()
		{
			_spring.springJoint.spring = originSpringAmount * _springPower;
			yield return new WaitForSeconds(0.2f);
			_spring.springJoint.spring = originSpringAmount;
		}
	}
}
