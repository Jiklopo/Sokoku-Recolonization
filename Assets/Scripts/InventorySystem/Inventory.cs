﻿using System.Collections.Generic;

namespace InventorySystem
{
	public class Inventory
	{
		private int maxSize;
		
		private Dictionary<Item, int> items;

		public Inventory(int maxSize)
		{
			this.maxSize = maxSize;
			items = new Dictionary<Item, int>();
		}

		public bool TryAddItems(Item item, int amount = 1)
		{
			if (items.Count >= maxSize && !items.ContainsKey(item)) 
				return false;
			
			AddItemsWithoutChecks(item, amount);
			return true;
		}

		public bool TryRemoveItems(Item item, int removeAmount = 1)
		{
			if (!items.TryGetValue(item, out var itemAmount))
				return false;

			if (removeAmount > itemAmount)
				return false;

			if (removeAmount == itemAmount)
				items.Remove(item);
			else
				items[item] -= removeAmount;

			return true;
		}

		private void AddItemsWithoutChecks(Item item, int amount)
		{
			if (items.ContainsKey(item))
				items[item] += amount;
			else
				items.Add(item, amount);
		}
	}
}