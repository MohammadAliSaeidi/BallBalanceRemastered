using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace BallBalance.Utility.Logger
{
	internal class FloatingButton : MonoBehaviour, IDragHandler
	{
		RectTransform rect;
		public Button button { get; private set; }

		void Awake()
		{
			InitComponents();
		}

		void InitComponents()
		{
			rect = GetComponent<RectTransform>();
			button = GetComponent<Button>();
		}

		public void OnDrag(PointerEventData eventData)
		{
			Debug.Log($"eventData pos : {eventData.position}");
			Debug.Log($"mouse pos : {Input.mousePosition}");
		}
	}
}
