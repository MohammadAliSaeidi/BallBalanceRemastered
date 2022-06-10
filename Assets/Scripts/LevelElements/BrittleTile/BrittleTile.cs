using System.Collections;
using UnityEngine;

namespace BallBalance
{
	public class BrittleTile : MonoBehaviour
	{

		[SerializeField] private BrokenBrittleTile brokenPref; // the broken prefab of tile
		[SerializeField] private GameObject currentTile; // the tile that will be destroyed(note: it souldnt be this go)
		[SerializeField] private float breakDelay;
		public GameObject tileToSpawn;

		public void ResetTile()
		{
			gameObject.GetComponent<BoxCollider>().enabled = true;

			if (currentTile == null)
			{
				currentTile = Instantiate(tileToSpawn, transform.position, transform.rotation);
				currentTile.transform.parent = transform;
			}
			else
			{
				currentTile.transform.SetPositionAndRotation(transform.position, transform.rotation);
			}
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.CompareTag("Player"))
			{
				Break();
			}
		}

		private void Break()
		{
			var instance = Instantiate(brokenPref, transform.position, transform.rotation);
			instance.Init(breakDelay);
			gameObject.GetComponent<BoxCollider>().enabled = false;
			Destroy(currentTile);
		}
	}
}