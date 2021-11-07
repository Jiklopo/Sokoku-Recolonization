using System.Collections.Generic;
using Data;
using Events;
using Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class InventoryPanel: UIElementSingleton<InventoryPanel>
	{
		[SerializeField] private InventoryItem inventoryItemPrefab;
		[SerializeField] private GridLayoutGroup inventoryGrid;

		private List<InventoryItem> items = new List<InventoryItem>();
		protected override void OnAwake()
		{
			base.OnAwake();
			GameBus.OnInventoryUpdated += UpdateInventoryGrid;
		}

		public void Initialize(int slotsAmount)
		{
			items.Clear();
			inventoryGrid.transform.DestroyAllChildren();

			for (var i = 0; i < slotsAmount; i++)
			{
				items.Add(Instantiate(inventoryItemPrefab, inventoryGrid.transform));
				items[i].Clear();
			}
		}

		private void UpdateInventoryGrid(Dictionary<ItemData, int> inventory)
		{
			inventoryGrid.transform.DestroyAllChildren();
			foreach (var inventoryItem in items)
				inventoryItem.Clear();

			var i = 0;
			foreach (var itemData in inventory)
			{
				items[i++].SetData(itemData.Key, itemData.Value);
				if (i > items.Count)
					break;
			}
		}
	}
}