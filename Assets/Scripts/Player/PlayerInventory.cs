using System;
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

		private void ToggleInventory(InputAction.CallbackContext context)
		{
			InventoryPanel.ToggleInstance();
		}
	}
}