using System.Collections;
using UnityEngine;

public class GameObjectAge : MonoBehaviour
{
	[SerializeField] private bool CountdownOnEnable = true;
	[SerializeField] private float _age = 1;

	private void OnEnable()
	{
		if (CountdownOnEnable)
		{
			StartCoroutine(Co_GameObjectAge());
		}
	}

	internal void StartCountDown(float age)
	{
		_age = age;
		StartCoroutine(Co_GameObjectAge());
	}

	private IEnumerator Co_GameObjectAge()
	{
		yield return new WaitForSeconds(_age);
		Destroy(gameObject);
	}
}
