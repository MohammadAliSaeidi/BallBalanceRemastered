using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BallBalance
{
	public class BrokenBrittleTile : MonoBehaviour
	{
		private List<Rigidbody> brokenPieces = new List<Rigidbody>();

		private void OnEnable()
		{
			brokenPieces = GetComponentsInChildren<Rigidbody>().ToList();
			foreach (var piece in brokenPieces)
			{
				piece.isKinematic = true;
			}
		}

		internal void Init(float breakDelay)
		{
			StartCoroutine(Co_Break(breakDelay));
		}

		private IEnumerator Co_Break(float breakDelay)
		{
			yield return new WaitForSeconds(breakDelay);

			GetComponent<Animator>().Play("Break");

			foreach (var piece in brokenPieces)
			{
				piece.isKinematic = false;
			}
		}
	}
}
