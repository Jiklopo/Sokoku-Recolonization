using UnityEngine;

namespace Utilities
{
	public static class CustomLogger
	{
		public static void Log(string message, Object context = null)
		{
			Debug.Log(message, context);
		}

		public static void Warning(string message, Object context = null)
		{
			Debug.LogWarning(message, context);
		}

		public static void Error(string message, Object context = null)
		{
			Debug.LogError(message, context);
		}
	}
}