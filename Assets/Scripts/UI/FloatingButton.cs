using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace BallBalance.UI
{
	internal class FloatingButton : MonoBehaviour, IDragHandler, IPointerUpHandler
	{
		public UnityEvent e_OnClick = new UnityEvent();

		public Button button { get; private set; }

		bool dragging = false;

		void Awake()
		{
			InitComponents();
		}

		void InitComponents()
		{
			button = GetComponent<Button>();
		}

		public void OnDrag(PointerEventData eventData)
		{
			dragging = true;
			transform.position = eventData.position;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			if (!dragging)
			{
				if (e_OnClick != null)
				{
					e_OnClick.Invoke();
				}
			}
			else
			{
				dragging = false;
			}
		}
	}
}
