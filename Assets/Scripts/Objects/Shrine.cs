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

		private static IEntity PlayerEntity => Player.Player.Instance;
		private bool isUsed;

		public void OnInteract()
		{
			if (isUsed || PlayerEntity.Health <= damage)
				return;

			isUsed = true;
			PlayerEntity.ReceiveDamage(damage);
			var item = ItemFactory.Instance.SpawnRandomItem(dropChance, transform);
			item.transform.Translate(itemOffset);
			CustomLogger.Log($"Shrine({name}) dropped an item ({item.ItemData.name}");
		}
	}
}