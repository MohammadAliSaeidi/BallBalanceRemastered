using System;
using UnityEngine.Events;

namespace BallBalance
{
	public static class EventHandler
	{
		public static void FireEvent(ref UnityEvent unityEvent)
		{
			if (unityEvent != null)
			{
				unityEvent.Invoke();
			}
		}

		public static void FireEvent<T>(ref UnityEvent<T> unityEvent, T argument)
		{
			if (unityEvent != null)
			{
				unityEvent.Invoke(argument);
			}
		}
	}
}
