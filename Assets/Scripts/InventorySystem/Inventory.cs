using System.Collections.Generic;
using Data;

namespace InventorySystem
{
	public class Inventory
	{
		public readonly Dictionary<ItemData, int> items;

		public Inventory()
		{
			items = new Dictionary<ItemData, int>();
		}

		public void AddItems(ItemData item, int amount = 1)
		{
			if (items.ContainsKey(item))
				items[item] += amount;
			else
				items.Add(item, amount);
		}

		public bool TryRemoveItems(ItemData item, int removeAmount = 1)
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
	}
}