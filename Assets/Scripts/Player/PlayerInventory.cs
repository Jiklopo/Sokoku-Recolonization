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
		private Player player;
		private Inventory inventory;

		private PlayerStats Stats => player.playerStats;

		private void Awake()
		{
			player = GetComponent<Player>();
			inventory = new Inventory();
		}

		private void Start()
		{
			InventoryPanel.Instance.Initialize();
			player.InputActions.UI.Inventory.performed += ToggleInventory;
		}

		public void AddItems(ItemData itemData, int amount = 1)
		{
			inventory.AddItems(itemData, amount);
			Stats.BoostStats(itemData, amount);
			GameBus.OnInventoryUpdated.Invoke(inventory.items);
		}

		public bool RemoveItems(ItemData itemData, int amount = 1)
		{
			if (!inventory.TryRemoveItems(itemData, amount)) 
				return false;
			
			Stats.RemoveStats(itemData, amount);
			GameBus.OnInventoryUpdated.Invoke(inventory.items);
			return true;
		}

		private void ToggleInventory(InputAction.CallbackContext context)
		{
			InventoryPanel.ToggleInstance();
		}
	}
}