using System;
using Data;
using Events;
using InventorySystem;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
	[RequireComponent(typeof(Player))]
	public class PlayerInventory : MonoBehaviour
	{
		[SerializeField] private int maxSize;
		
		private Player player;
		private Inventory inventory;

		private void Awake()
		{
			player = GetComponent<Player>();
			inventory = new Inventory(maxSize);
		}

		private void Start()
		{
			InventoryPanel.Instance.Initialize(maxSize);
			player.InputActions.UI.Inventory.performed += ToggleInventory;
		}

		public bool AddItems(ItemData itemData, int amount = 1)
		{
			if (!inventory.TryAddItems(itemData, amount)) 
				return false;
			
			GameBus.OnInventoryUpdated.Invoke(inventory.items);
			return true;

		}

		public bool RemoveItems(ItemData itemData, int amount = 1)
		{
			if (!inventory.TryRemoveItems(itemData, amount)) 
				return false;
			
			GameBus.OnInventoryUpdated.Invoke(inventory.items);
			return true;
		}

		private void ToggleInventory(InputAction.CallbackContext context)
		{
			InventoryPanel.ToggleInstance();
		}
	}
}