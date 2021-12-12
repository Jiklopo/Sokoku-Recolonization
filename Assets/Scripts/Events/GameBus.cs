using System;
using System.Collections.Generic;
using Data;

namespace Events
{
	public static class GameBus
	{
		public static Action OnGameOver;
		public static Action OnGamePaused;
		public static Action OnGameCompleted;
		public static Action<Dictionary<ItemData, int>> OnInventoryUpdated;
	}
}