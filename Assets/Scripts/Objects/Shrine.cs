using System;
using Factories;
using Interfaces;
using InventorySystem;
using UnityEngine;
using Utilities;

namespace Objects
{
	public class Shrine : MonoBehaviour, IInteractable
	{
		[SerializeField] private float damage;
		[SerializeField] [Range(0, 1)] private float dropChance;
		[SerializeField] private Vector3 itemOffset;

		private Player.Player player;
		private bool isUsed;

		private void Awake()
		{
			player = FindObjectOfType<Player.Player>();
		}

		public void OnInteract()
		{
			if (isUsed || player.Health <= damage)
				return;

			isUsed = true;
			player.ReceiveDamage(damage);
			var item = ItemFactory.Instance.SpawnRandomItem(dropChance, transform);
			item.transform.Translate(itemOffset);
			CustomLogger.Log($"Shrine({name}) dropped an item ({item.ItemData.name}");
		}
	}
}