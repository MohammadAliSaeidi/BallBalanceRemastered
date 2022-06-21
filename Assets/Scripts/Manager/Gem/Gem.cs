using System;
using UnityEngine;

namespace BallBalance
{
	public class GemManager : MonoBehaviour
	{
		[SerializeField] private TriggerEventHandler _playerTriggerHandler;
		[SerializeField] private GameObject _gemCollectionEffect;

		private void Start()
		{
			_playerTriggerHandler.e_OnTriggerEnter.AddListener(HandleTrigger);
		}

		private void HandleTrigger(Collider collider)
		{
			if (collider.gameObject.CompareTag("Gem"))
			{
				Instantiate(_gemCollectionEffect, collider.transform.position, collider.transform.rotation);
				Destroy(collider.gameObject);
			}
		}
	}
}
