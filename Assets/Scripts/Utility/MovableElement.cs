using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallBalance
{
    public class MovableElement : MonoBehaviour
    {
        [SerializeField] private TriggerEventHandler _playerEnterTrigger;

		[Space(20)]
		[SerializeField] private bool _setThisAsParent;
		[SerializeField] private Transform _playerParent;

		private void Start()
		{
			_playerEnterTrigger.e_OnTriggerEnter.AddListener(OnTriggerEnterHandler);
			_playerEnterTrigger.e_OnTriggerExit.AddListener(OnTriggerExitHandler);

			if (_setThisAsParent)
			{
				_playerParent = transform;
			}
		}

		private void OnTriggerEnterHandler(Collider collider)
		{
			if (collider.gameObject.CompareTag("Player"))
			{
				collider.transform.SetParent(_playerParent);
			}
		}

		private void OnTriggerExitHandler(Collider collider)
		{
			if (collider.gameObject.CompareTag("Player"))
			{
				collider.transform.SetParent(null);
			}
		}
	}
}
