using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallBalance
{
    public class FrameRateController : MonoBehaviour
    {

        [SerializeField] private int _maxFrameRate = 30;

        [ContextMenu("Start")]
        void Start()
        {
            SetMaxFrame(_maxFrameRate);
        }


		public void SetMaxFrame(int maxFrameRate)
		{
            Application.targetFrameRate = maxFrameRate;
		}
	}
}
