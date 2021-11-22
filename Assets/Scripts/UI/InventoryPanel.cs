using System.Collections.Generic;
using Data;
using Events;
using Extensions;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class InventoryPanel: UIElementSingleton<InventoryPanel>
	{
		[SerializeField] private InventoryItem inventoryItemPrefab;
		[SerializeField] private RectTransform inventoryGrid;

		private readonly List<InventoryItem> items = new List<InventoryItem>();
		protected override void OnAwake()
		{
			base.OnAwake();
			GameBus.OnInventoryUpdated += UpdateInventoryGrid;
		}

		public void Initialize()
		{
			items.Clear();
			inventoryGrid.transform.DestroyAllChildren();
		}

		private void UpdateInventoryGrid(Dictionary<ItemData, int> inventory)
		{
			inventoryGrid.transform.DestroyAllChildren();
			foreach (var itemData in inventory.Keys)
				items.Add(
					Instantiate(inventoryItemPrefab, inventoryGrid)
						.SetData(itemData, inventory[itemData]));
		}
	}
}