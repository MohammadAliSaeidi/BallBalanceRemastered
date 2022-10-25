﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BallBalance
{
	public class LevelManager : MonoBehaviour
	{
		public int LevelId;
		public Ball CurrentBall;
		public List<Gem> Gems = new List<Gem>();
		public int Heals;
		public int TimeRemainingInSeconds;
		public FinishPointManager FinishPoint;

		private void OnEnable()
		{
			GameManager.Instance.currentLevelManager = this;
		}

		private void OnDisable()
		{
			if (GameManager.Instance.currentLevelManager == this)
			{
				GameManager.Instance.currentLevelManager = null;
			}
		}

		private void Start()
		{
			// init Gems
			Gems = FindObjectsOfType<Gem>().ToList();
			FinishPoint = FindObjectOfType<FinishPointManager>();
			FinishPoint.e_OnFinishPointHit.AddListener(OnFinished);
		}

		public void Pause()
		{

		}

		public void Resume()
		{

		}

		private void OnFinished()
		{

		}
	}
}
